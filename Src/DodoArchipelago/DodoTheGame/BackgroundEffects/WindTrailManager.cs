// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BackgroundEffects.WindTrailManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.BackgroundEffects
{
  internal static class WindTrailManager
  {
    public static List<WindTrail> trailList = new List<WindTrail>();

    public static void Update(Player player, GameTime gameTime)
    {
      WindTrailManager.trailList.ForEach((Action<WindTrail>) (p => p.sprite.Update(gameTime)));
      if (Game1.RNG.Next(0, 100) <= (player.currentMovementType == Player.DodoMovement.Bike ? 50 : 100 - (int) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0)) * 10) || WindTrailManager.trailList.Count >= (player.currentMovementType == Player.DodoMovement.Bike ? 10 : (int) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0)) * 100 - 5))
        return;
      double getAngle = Wind.GetAngle;
      WindTrail.WindDirection direction;
      Vector2 loc;
      if (getAngle != Math.PI / 2.0)
      {
        if (getAngle != Math.PI / 4.0)
        {
          if (getAngle != 3.0 * Math.PI / 4.0)
          {
            if (getAngle != 5.0 * Math.PI / 4.0)
            {
              if (getAngle == 7.0 * Math.PI / 4.0)
              {
                loc = new Vector2(player.location.X - (float) Game1.RNG.Next(-600, 900), player.location.Y + (float) Game1.RNG.Next(-500, 1000));
                direction = WindTrail.WindDirection.UpLeft;
              }
              else
              {
                loc = new Vector2(player.location.X + (float) Game1.RNG.Next(-500, 1000), player.location.Y + (float) Game1.RNG.Next(-750, 750));
                direction = WindTrail.WindDirection.Left;
              }
            }
            else
            {
              loc = new Vector2(player.location.X + (float) Game1.RNG.Next(-600, 900), player.location.Y - (float) Game1.RNG.Next(-1000, 500));
              direction = WindTrail.WindDirection.DownLeft;
            }
          }
          else
          {
            loc = new Vector2(player.location.X + (float) Game1.RNG.Next(-900, 600), player.location.Y - (float) Game1.RNG.Next(-1000, 500));
            direction = WindTrail.WindDirection.DownRight;
          }
        }
        else
        {
          loc = new Vector2(player.location.X - (float) Game1.RNG.Next(-900, 600), player.location.Y + (float) Game1.RNG.Next(-500, 1000));
          direction = WindTrail.WindDirection.UpRight;
        }
      }
      else
      {
        loc = new Vector2(player.location.X + (float) Game1.RNG.Next(-1000, 500), player.location.Y + (float) Game1.RNG.Next(-750, 750));
        direction = WindTrail.WindDirection.Right;
      }
      if (WindTrailManager.trailList.Count<WindTrail>((Func<WindTrail, bool>) (p => (double) Math.Abs(p.startingPoint.Y - loc.Y) < 100.0)) != 0)
        return;
      WindTrailManager.trailList.Add(new WindTrail(loc, Game1.windSprites[Game1.RNG.Next(0, Game1.windSprites.Length)], direction));
    }

    public static void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      for (int index = WindTrailManager.trailList.Count - 1; index >= 0; --index)
      {
        if (WindTrailManager.trailList[index].time >= 1755.0)
          WindTrailManager.trailList.RemoveAt(index);
        else
          WindTrailManager.trailList[index].Draw(sb, gameTime, backgroundPos);
      }
    }
  }
}
