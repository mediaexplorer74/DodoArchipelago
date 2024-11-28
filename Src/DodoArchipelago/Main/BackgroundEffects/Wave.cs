
// Type: DodoTheGame.BackgroundEffects.Wave

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.BackgroundEffects
{
  internal class Wave : IBackgroundEffect
  {
    public double waveAngle;
    public Vector2 startingPoint;
    private int switchTime = 1900;
    private int endTime = 3200;
    public int length;
    public int[] waveTimes = new int[2]{ 1, 0 };
    private int[] waveSprites = new int[2];

    public Wave(Vector2 startingPoint, int length, double waveAngle, bool inputInRadians = false)
    {
      this.length = length;
      this.startingPoint = startingPoint;
      this.waveAngle = !inputInRadians ? Convert.ToDouble(waveAngle) * (Math.PI / 180.0) : waveAngle;
      this.waveSprites[1] = Game1.rand.Next(0, 4);
      this.waveSprites[0] = Game1.rand.Next(0, 4);
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      Vector2 vector2_1 = Vector2.Zero;
      Vector2 vector2_2 = Vector2.Zero;
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = 0; index < 2; ++index)
      {
        if (this.waveTimes[index] > 0)
          this.waveTimes[index] = this.waveTimes[index] + (int) gameTime.ElapsedGameTime.TotalMilliseconds * (int) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0));
        if (this.waveTimes[index] > this.endTime)
          this.waveTimes[index] = 0;
        if (this.waveTimes[index] > this.switchTime)
        {
          if (index == 0 && this.waveTimes[1] == 0)
          {
            int num3 = Game1.rand.Next(0, 4);
            while (num3 == this.waveSprites[0])
              num3 = Game1.rand.Next(0, 4);
            this.waveSprites[1] = num3;
            this.waveTimes[1] = 1;
          }
          else if (index == 1 && this.waveTimes[0] == 0)
          {
            int num4 = Game1.rand.Next(0, 4);
            while (num4 == this.waveSprites[1])
              num4 = Game1.rand.Next(0, 4);
            this.waveSprites[0] = num4;
            this.waveTimes[0] = 1;
          }
        }
        float num5 = (double) this.waveTimes[index] <= (double) this.endTime / 3.0 ? (float) this.waveTimes[index] / ((float) this.endTime / 4f) : 1f;
        if ((double) num5 > 1.0)
          num5 = 1f;
        double num6 = this.waveAngle - Math.PI / 2.0;
        double num7 = (double) this.waveTimes[index] / 1200.0;
        Vector2 vector2_3 = new Vector2((float) (150.0 * Math.Cos(num6) * Math.Cos(num7 - Math.PI / 2.0)) + this.startingPoint.X, (float) (150.0 * Math.Sin(num6) * Math.Cos(num7 - Math.PI / 2.0)) + this.startingPoint.Y);
        if (index == 0)
        {
          vector2_1 = vector2_3;
          num1 = num5;
        }
        else
        {
          vector2_2 = vector2_3;
          num2 = num5;
        }
      }
      if (((double) vector2_1.X + (double) backgroundPos.X <= -1300.0 || (double) vector2_1.X + (double) backgroundPos.X >= 3000.0 || (double) vector2_1.Y + (double) backgroundPos.Y <= -1300.0 || (double) vector2_1.Y + (double) backgroundPos.Y >= 3000.0) && ((double) vector2_2.X + (double) backgroundPos.X <= -1300.0 || (double) vector2_2.X + (double) backgroundPos.X >= 3000.0 || (double) vector2_2.Y + (double) backgroundPos.Y <= -1300.0 || (double) vector2_2.Y + (double) backgroundPos.Y >= 3000.0))
        return;
      ++Game1.wavecounterdebug;
      if (this.waveTimes[0] > this.waveTimes[1])
      {
        Recorder.RDraw(sb, Game1.wavesTextures[this.waveSprites[0]], new Vector2(vector2_1.X + backgroundPos.X, vector2_1.Y + backgroundPos.Y), new Rectangle?(), Color.White * num1, (float) this.waveAngle, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
        Recorder.RDraw(sb, Game1.wavesTextures[this.waveSprites[1]], new Vector2(vector2_2.X + backgroundPos.X, vector2_2.Y + backgroundPos.Y), new Rectangle?(), Color.White * num2, (float) this.waveAngle, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
      }
      else
      {
        Recorder.RDraw(sb, Game1.wavesTextures[this.waveSprites[1]], new Vector2(vector2_2.X + backgroundPos.X, vector2_2.Y + backgroundPos.Y), new Rectangle?(), Color.White * num2, (float) this.waveAngle, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
        Recorder.RDraw(sb, Game1.wavesTextures[this.waveSprites[0]], new Vector2(vector2_1.X + backgroundPos.X, vector2_1.Y + backgroundPos.Y), new Rectangle?(), Color.White * num1, (float) this.waveAngle, Vector2.Zero, new Vector2(1f, 1f), SpriteEffects.None, 0.0f);
      }
    }
  }
}
