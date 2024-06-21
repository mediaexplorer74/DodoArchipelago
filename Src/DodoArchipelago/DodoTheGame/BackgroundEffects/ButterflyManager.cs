// DodoTheGame.BackgroundEffects.ButterflyManager


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.BackgroundEffects
{
  internal static class ButterflyManager
  {
    public static List<Butterfly> butterflyList;
    public static Sprite sprite;

    public static void Update(Player player)
    {
      if (Game1.RNG.Next(0, 100) > 90 && ButterflyManager.butterflyList.Count < 11)
      {
        Vector2 startingPoint;
        Vector2 generalGuidance;
        switch (Game1.RNG.Next(0, 4))
        {
          case 0:
            startingPoint = player.location + new Vector2((float) Game1.RNG.Next(-600, 1880), -700f);
            generalGuidance = new Vector2(0.0f, -2f);
            break;
          case 1:
            startingPoint = player.location + new Vector2(2000f, (float) Game1.RNG.Next(-600, 1320));
            generalGuidance = new Vector2(-2f, 0.0f);
            break;
          case 2:
            startingPoint = player.location + new Vector2((float) Game1.RNG.Next(-600, 1880), 1320f);
            generalGuidance = new Vector2(0.0f, 2f);
            break;
          default:
            startingPoint = player.location + new Vector2(-600f, (float) Game1.RNG.Next(-600, 1320));
            generalGuidance = new Vector2(2f, 0.0f);
            break;
        }
        ButterflyManager.butterflyList.Add(new Butterfly(startingPoint, ButterflyManager.sprite, 
            150, generalGuidance));
      }
      for (int index = ButterflyManager.butterflyList.Count - 1; index >= 0; --index)
      {
        Vector2 drawpos = ButterflyManager.butterflyList[index]
                    .GetDrawpos(ButterflyManager.butterflyList[index].passedTime);

        if ((double) drawpos.X > 22000.0 || (double) drawpos.X < -250.0 
                    || (double) drawpos.Y > 15100.0 || (double) drawpos.Y < -250.0 
                    || (double) Vector2.Distance(player.location, drawpos) > 5000.0)
          ButterflyManager.butterflyList.RemoveAt(index);
      }
    }

    public static void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      foreach (Butterfly butterfly in ButterflyManager.butterflyList)
        butterfly.Draw(sb, gameTime, backgroundPos);
    }
  }
}
