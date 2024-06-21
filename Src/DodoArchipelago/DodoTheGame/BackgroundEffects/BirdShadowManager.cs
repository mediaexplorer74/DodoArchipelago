// Type: DodoTheGame.BackgroundEffects.BirdShadowManager

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpRaven.Data;
using System;
using System.Collections.Generic;


namespace DodoTheGame.BackgroundEffects
{
  internal static class BirdShadowManager
  {
    public static List<BirdShadow> BirdShadowList;
    public static Sprite sprite;
    private static int TimeSinceLastSeagullSound;

    public static event EventHandler Seagull;

    public static void Update(Player player, GameTime gameTime)
    {
      if (Game1.RNG.Next(0, 100) > 1 
                && (double) BirdShadowManager.BirdShadowList.Count < 5.0 * DayCycle.timeSpeed)
      {
        Vector2 startingPoint;
        switch (Game1.RNG.Next(0, 4))
        {
          case 0:
            startingPoint = new Vector2((float) Game1.RNG.Next(-200, 21500), -200f);
            break;
          case 1:
            startingPoint = new Vector2(18000f, (float) Game1.RNG.Next(-200, 15000));
            break;
          case 2:
            startingPoint = new Vector2((float) Game1.RNG.Next(-200, 21500), 15000f);
            break;
          default:
            startingPoint = new Vector2(-200f, (float) Game1.RNG.Next(-200, 15000));
            break;
        }
        BirdShadowManager.BirdShadowList.Add(new BirdShadow(startingPoint, 
            Game1.RNG.NextDouble() * Math.PI * 2.0, BirdShadowManager.sprite, 2.7));
      }
      BirdShadowManager.TimeSinceLastSeagullSound += gameTime.ElapsedGameTime.Milliseconds;
      for (int index = BirdShadowManager.BirdShadowList.Count - 1; index >= 0; --index)
      {
        Vector2 drawpos = BirdShadowManager.BirdShadowList[index]
                    .GetDrawpos(BirdShadowManager.BirdShadowList[index].passedTime);

        if ((double) drawpos.X > 22000.0 || (double) drawpos.X < -250.0 
                    || (double) drawpos.Y > 15100.0 || (double) drawpos.Y < -250.0)
          BirdShadowManager.BirdShadowList.RemoveAt(index);

        if ((double) (drawpos - player.location).Length() < 600.0 
                    && BirdShadowManager.TimeSinceLastSeagullSound > 4800)
        {
          EventHandler seagull = BirdShadowManager.Seagull;
          if (seagull != null)
            seagull((object) null, EventArgs.Empty);
          Game1.Log("Seagull Sound", BreadcrumbLevel.Info);
          BirdShadowManager.TimeSinceLastSeagullSound = 0;
        }
      }
    }

    public static void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      foreach (BirdShadow birdShadow in BirdShadowManager.BirdShadowList)
        birdShadow.Draw(sb, gameTime, backgroundPos);
    }
  }
}
