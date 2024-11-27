
// Type: DodoTheGame.ForegroundEffects.HarvestResults

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.ForegroundEffects
{
  internal class HarvestResults : IForegroundEffect
  {
    private ItemStack[] harvestResults;
    private Vector2 objectEpicenter;
    private SpriteFont spriteFont;

    public bool ToDiscard { get; private set; }

    public double StartTime { get; }

    public HarvestResults(
      ItemStack[] harvestResults,
      Vector2 objectLocation,
      SpriteFont spriteFont,
      GameTime gameTime)
    {
      this.harvestResults = harvestResults;
      this.objectEpicenter = objectLocation;
      this.spriteFont = spriteFont;
      this.StartTime = gameTime.TotalGameTime.TotalMilliseconds;
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      double num1 = this.StartTime + 1000.0;
      float num2 = 1f;
      float num3 = (float)
                ((double) this.objectEpicenter.Y - 75.0 
                * (double) Convert.ToSingle(1.0 - (num1 - gameTime.TotalGameTime.TotalMilliseconds) / 1000.0) - 100.0);
      if ((double) Convert.ToSingle(gameTime.TotalGameTime.TotalMilliseconds - this.StartTime) > 800.0)
        num2 = Convert.ToSingle(num1 - gameTime.TotalGameTime.TotalMilliseconds) / 200f;
      if ((double) num2 < 0.0)
      {
        num2 = 0.0f;
        this.ToDiscard = true;
      }
      Vector2 vector2 = new Vector2((float) ((double) backgroundPos.X + (double) this.objectEpicenter.X - 20.0), (float) ((double) backgroundPos.Y + (double) num3 - 50.0));
      int num4 = 0;
      foreach (ItemStack harvestResult in this.harvestResults)
      {
        float x = Game1.rouliLSpriteFont.MeasureString(harvestResult.count.ToString() + "x").X;
        if (harvestResult.itemId < 80)
        {
          Recorder.RDrawString(sb, this.spriteFont, harvestResult.count.ToString() + "x", 
              new Vector2(vector2.X, vector2.Y + (float) (num4 * 50)), Color.Black * num2);
          Recorder.RDraw(sb, Game1.smallItemTextures[harvestResult.itemId], 
              new Vector2((float) ((double) vector2.X + (double) x + 0.0), vector2.Y + (float) (num4 * 50)), Color.White * num2);
        }
        else
          Recorder.RDraw(sb, Game1.staticMiniFlowersTextures[harvestResult.itemId - 81],
              new Vector2((float) ((double) vector2.X + (double) x + 0.0), vector2.Y + (float) (num4 * 50)), Color.White * num2);
        ++num4;
      }
    }
  }
}
