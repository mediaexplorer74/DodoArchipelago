// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Pathfinder
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Hitbox;
using Microsoft.Xna.Framework;
using SharpRaven.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace DodoTheGame
{
  internal class Pathfinder
  {
    private World referenceWorld;
    private const int resolution = 5;
    private int lastRequestId;
    private const float distanceBetweenPts = 12f;

    public event EventHandler Pathfound;

    private Rectangle Size => new Rectangle(0, 0, 4200, 3000);

    public Pathfinder(World world) => this.referenceWorld = world;

    public int RequestPathfind(Point istart, Point iend, int playerLevel, object requester = null)
    {
      ++this.lastRequestId;
      Game1.Log(requester.GetType().ToString() + " requested pathfinding from (" + istart.X.ToString() + "; " + istart.Y.ToString() + ") to (" + iend.X.ToString() + "; " + iend.Y.ToString() + "). Associated ID: " + this.lastRequestId.ToString(), BreadcrumbLevel.Debug, nameof (Pathfinder));
      this.referenceWorld.behaviorMap.StartBackgroundCaching();
      this.referenceWorld.behaviorMap.LockBackgroundCaching();
      this.referenceWorld.behaviorMap.FillBackgroundCaching(playerLevel);
      new Thread((ParameterizedThreadStart) (requestId =>
      {
        List<Vector2> vector2List = this.Pathfind(istart, iend, playerLevel, (int) requestId);
        EventHandler pathfound = this.Pathfound;
        if (pathfound != null)
          pathfound((object) this, (EventArgs) new PathfoundEventArgs()
          {
            Path = vector2List,
            RequestId = (int) requestId
          });
        this.referenceWorld.behaviorMap.UnlockBackgroundCaching();
        this.referenceWorld.behaviorMap.StopBackgroundCaching();
      })).Start((object) this.lastRequestId);
      return this.lastRequestId;
    }

    private List<Vector2> Pathfind(Point istart, Point iend, int playerLevel, int requestId)
    {
      Vector2 vector2_1 = iend.ToVector2() - istart.ToVector2();
      double num1 = (double) vector2_1.Length();
      List<Vector2> vector2List1 = new List<Vector2>();
      for (int index = 0; (double) index < Math.Ceiling(num1 / 12.0); ++index)
      {
        double num2 = (double) index / Math.Ceiling(num1 / 12.0);
        Vector2 vector2_2 = vector2_1 * Convert.ToSingle(num2);
        Vector2 vector2_3 = istart.ToVector2() + vector2_2;
        vector2_3 = new Vector2(Convert.ToSingle(Math.Round((double) vector2_3.X)), Convert.ToSingle(Math.Round((double) vector2_3.Y)));
        vector2List1.Add(vector2_3);
      }
      bool flag = false;
      List<Vector2> vector2List2 = new List<Vector2>();
      for (int index = 0; index < vector2List1.Count; ++index)
      {
        Vector2 vector2_4 = vector2List1[index];
        if (this.IsLocationWalkable(vector2_4.ToPoint().X, vector2_4.ToPoint().Y) == (byte) 0)
          flag = true;
        else if (flag)
        {
          Vector2 vector2_5 = vector2List2[vector2List2.Count - 1];
          vector2List2.RemoveAt(vector2List2.Count - 1);
          Vector2 vector2_6 = vector2List1[index + 1];
          List<Vector2> collection = this.AStarPathfind(vector2_5.ToPoint(), vector2_6.ToPoint());
          vector2List2.AddRange((IEnumerable<Vector2>) collection);
          ++index;
          flag = false;
        }
        else
          vector2List2.Add(vector2_4);
      }
      Game1.Log("Pathfinding request " + requestId.ToString() + " completed.", BreadcrumbLevel.Debug, nameof (Pathfinder));
      return vector2List2;
    }

    private byte IsLocationWalkable(int x, int y)
    {
      Vector2 location = new Vector2((float) x, (float) y);
      if (this.referenceWorld.TestCollision((IHitbox) new HorizontalLine()
      {
        StartingPoint = location,
        Span = 1
      }, withNPCs: false).Item1)
        return 0;
      TerrainBehavior locationInfo = this.referenceWorld.behaviorMap.GetLocationInfo(location);
      return locationInfo.collision || locationInfo.movementType == Player.DodoMovement.Swim ? (byte) 0 : (byte) 1;
    }

    private List<Vector2> AStarPathfind(Point istart, Point iend)
    {
      Point key = new Point(Convert.ToInt32(istart.X / 5), Convert.ToInt32(istart.Y / 5));
      Point current = new Point(Convert.ToInt32(iend.X / 5), Convert.ToInt32(iend.Y / 5));
      List<Point> pointList1 = new List<Point>();
      List<Point> source = new List<Point>() { key };
      Dictionary<Point, Point> cameFrom = new Dictionary<Point, Point>();
      Dictionary<Point, int> dictionary = new Dictionary<Point, int>();
      Dictionary<Point, float> predictedDistance = new Dictionary<Point, float>();
      dictionary.Add(key, 0);
      predictedDistance.Add(key, (float) (Math.Abs(key.X - current.X) + Math.Abs(key.Y - current.Y)));
      while (source.Count > 0)
      {
        Point point1 = source.OrderBy<Point, float>((Func<Point, float>) (p => predictedDistance[p])).First<Point>();
        if (point1.X == current.X && point1.Y == current.Y)
        {
          List<Point> pointList2 = this.ReconstructPath(cameFrom, current);
          List<Vector2> vector2List = new List<Vector2>();
          foreach (Point point2 in pointList2)
            vector2List.Add(new Vector2((float) (point2.X * 5), (float) (point2.Y * 5)));
          return vector2List;
        }
        source.Remove(point1);
        pointList1.Add(point1);
        foreach (Point neighborNode in this.GetNeighborNodes(point1))
        {
          int count = pointList1.Count;
          string str1 = count.ToString();
          count = source.Count;
          string str2 = count.ToString();
          Game1.Log("[A*] Closed: " + str1 + " Open: " + str2, BreadcrumbLevel.Debug, "Pathfinding");
          int num = dictionary[point1] + 1;
          if ((!pointList1.Contains(neighborNode) || num < dictionary[neighborNode]) && (!pointList1.Contains(neighborNode) || num < dictionary[neighborNode]))
          {
            if (cameFrom.Keys.Contains<Point>(neighborNode))
              cameFrom[neighborNode] = point1;
            else
              cameFrom.Add(neighborNode, point1);
            dictionary[neighborNode] = num;
            predictedDistance[neighborNode] = (float) (dictionary[neighborNode] + Math.Abs(neighborNode.X - current.X) + Math.Abs(neighborNode.Y - current.Y));
            if (!source.Contains(neighborNode))
              source.Add(neighborNode);
          }
        }
      }
      return (List<Vector2>) null;
    }

    private IEnumerable<Point> GetNeighborNodes(Point node)
    {
      List<Point> neighborNodes = new List<Point>();
      if (this.IsLocationWalkable(node.X * 5, (node.Y - 1) * 5) > (byte) 0)
        neighborNodes.Add(new Point(node.X, node.Y - 1));
      if (this.IsLocationWalkable((node.X + 1) * 5, node.Y * 5) > (byte) 0)
        neighborNodes.Add(new Point(node.X + 1, node.Y));
      if (this.IsLocationWalkable(node.X * 5, (node.Y + 1) * 5) > (byte) 0)
        neighborNodes.Add(new Point(node.X, node.Y + 1));
      if (this.IsLocationWalkable((node.X - 1) * 5, node.Y * 5) > (byte) 0)
        neighborNodes.Add(new Point(node.X - 1, node.Y));
      return (IEnumerable<Point>) neighborNodes;
    }

    private List<Point> ReconstructPath(Dictionary<Point, Point> cameFrom, Point current)
    {
      if (!cameFrom.Keys.Contains<Point>(current))
        return new List<Point>() { current };
      List<Point> pointList = this.ReconstructPath(cameFrom, cameFrom[current]);
      pointList.Add(current);
      return pointList;
    }
  }
}
