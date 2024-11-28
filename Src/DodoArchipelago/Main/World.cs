
// Type: DodoTheGame.World

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Hitbox;
using DodoTheGame.NPC;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame
{
  public class World
  {
    public string name;
    public TerrainBackground background;
    public List<IWorldObject> objects;
    public TerrainBehaviorMap behaviorMap;

    internal List<INPC> NPCs = Game1.NPCs;//new List<INPC>()
    //{
        //RnD
        //Location = default,
        //Hitbox = default,
        //CurrentDrawSprite = default,
        //IdleSprite = default,
        //runSprite = default,
        //SleepSprite = default,
        //FeetY = 50  
    //};

    public World()
    {
        //
    }

    public World(TerrainBackground background)
    {
      this.background = background;
      this.objects = new List<IWorldObject>();
      //experimental
      this.Level = 1; //!
      this.name = "mainworld";//!
    }

    public int Level { get; set; }

    // TestCollision
    internal Tuple<bool, object> TestCollision
    (
      IHitbox hitbox,
      bool withWOs = true,
      bool withNPCs = true,
      bool withTerrain = false,
      string[] iwosPresetsToIgnore = null
    )
    {
      if (withTerrain)
        throw new NotImplementedException();

      switch (hitbox)
      {
        case Box _:
          Rectangle rectangle1 = ((Box) hitbox).Rectangle;
          if (withWOs)
          {
            foreach (IWorldObject worldObject in iwosPresetsToIgnore != null 
                ? this.objects.Where<IWorldObject>((Func<IWorldObject, bool>) 
                (p => !((IEnumerable<string>) iwosPresetsToIgnore).Contains<string>(p.PresetMarker))) 
                : (IEnumerable<IWorldObject>) this.objects)
            {
              if (worldObject.TestHorizontalLineCollision(
                  new Vector2((float) rectangle1.X, (float) rectangle1.Y), rectangle1.Width)
                    || worldObject.TestVerticalLineCollision
                    (new Vector2((float) rectangle1.X, (float) rectangle1.Y),
                    rectangle1.Height)
                    || worldObject.TestHorizontalLineCollision(
                        new Vector2((float) rectangle1.X, 
                        (float) (rectangle1.Y + rectangle1.Height)), rectangle1.Width)
                    || worldObject.TestVerticalLineCollision(
                        new Vector2((float) (rectangle1.X + rectangle1.Width), 
                        (float) rectangle1.Y), rectangle1.Height))
                return new Tuple<bool, object>(true, (object) worldObject);
            }
          }

          if (withNPCs)
          {
            foreach (INPC npC in this.NPCs)
            {
              foreach (Rectangle rectangle2 in npC.Hitbox)
              {
                if (new Rectangle(rectangle2.X
                    + Convert.ToInt32(npC.Location.X), rectangle2.Y + Convert.ToInt32(npC.Location.Y), 
                    rectangle2.Width, rectangle2.Height).Intersects(rectangle1))
                  return new Tuple<bool, object>(true, (object) npC);
              }
            }
          }
          return new Tuple<bool, object>(false, (object) null);

        case HorizontalLine _:
          Vector2 startingPoint1 = ((HorizontalLine) hitbox).StartingPoint;
          int span1 = ((HorizontalLine) hitbox).Span;

          if (withWOs)
          {
            foreach (IWorldObject worldObject in iwosPresetsToIgnore != null
                            ? this.objects.Where<IWorldObject>((Func<IWorldObject, bool>)
                            (p => !((IEnumerable<string>) iwosPresetsToIgnore).Contains<string>(p.PresetMarker))) 
                            : (IEnumerable<IWorldObject>) this.objects)
            {
              if (worldObject.TestHorizontalLineCollision(startingPoint1, span1))
                return new Tuple<bool, object>(true, (object) worldObject);
            }
          }
           
                    
          if (withNPCs)
          {
            foreach (INPC npC in this.NPCs)
            {
              foreach (Rectangle rectangle3 in npC.Hitbox)
              {
                if (new Rectangle(rectangle3.X + Convert.ToInt32(npC.Location.X), 
                    rectangle3.Y + Convert.ToInt32(npC.Location.Y), rectangle3.Width, 
                    rectangle3.Height).Intersects(new Rectangle(Convert.ToInt32(startingPoint1.X), 
                    Convert.ToInt32(startingPoint1.Y), span1, 1)))
                  return new Tuple<bool, object>(true, (object) npC);
              }
            }
          }
          return new Tuple<bool, object>(false, (object) null);

        case VerticalLine _:
          Vector2 startingPoint2 = ((VerticalLine) hitbox).StartingPoint;
          int span2 = ((VerticalLine) hitbox).Span;

          if (withWOs)
          {
            foreach (IWorldObject worldObject in iwosPresetsToIgnore != null 
            ? this.objects.Where<IWorldObject>((Func<IWorldObject, bool>)
            (p => !((IEnumerable<string>) iwosPresetsToIgnore).Contains<string>(p.PresetMarker))) 
            : (IEnumerable<IWorldObject>) this.objects)
            {
              if (worldObject.TestVerticalLineCollision(startingPoint2, span2))
                return new Tuple<bool, object>(true, (object) worldObject);
            }
          }
          if (withNPCs)
          {
            foreach (INPC npC in this.NPCs)
            {
              foreach (Rectangle rectangle4 in npC.Hitbox)
              {
                    if (new Rectangle(
                        rectangle4.X + Convert.ToInt32(npC.Location.X),
                        rectangle4.Y + Convert.ToInt32(npC.Location.Y), 
                        rectangle4.Width, rectangle4.Height)
                                        .Intersects(
                                            new Rectangle( Convert.ToInt32(startingPoint2.X),
                                                  Convert.ToInt32(startingPoint2.Y), 1, span2 )
                        ))
                    { 
                        return new Tuple<bool, object>(true, (object)npC); 
                    }
              }
            }
          }
          return new Tuple<bool, object>(false, (object) null);

        case Points _:
          throw new NotImplementedException();

        default:
          return new Tuple<bool, object>(false, (object) null);
      }
    }
  }
}
