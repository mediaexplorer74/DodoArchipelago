// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BackgroundEffects.BirdShadow
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.BackgroundEffects
{
  internal class BirdShadow : IBackgroundEffect
  {
    public float passedTime;
    private double flyangle;
    private Vector2 startingpoint;
    private Sprite sprite;
    private double speed;

    public Vector2 GetDrawpos(float time)
    {
      return new Vector2(Convert.ToSingle((double) this.startingpoint.X + (double) time / this.speed * Math.Cos(this.flyangle) + Math.Sin(this.flyangle) * 20.0 * Math.Cos((double) time / 400.0)), Convert.ToSingle((double) this.startingpoint.Y + (double) time / this.speed * Math.Sin(this.flyangle) + Math.Cos(this.flyangle) * 20.0 * Math.Sin((double) time / 400.0)));
    }

    public BirdShadow(Vector2 startingPoint, double angle, Sprite sprite, double speed)
    {
      this.startingpoint = startingPoint;
      this.flyangle = angle;
      this.sprite = sprite;
      this.speed = speed;
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      this.passedTime += (float) (gameTime.ElapsedGameTime.TotalMilliseconds * DayCycle.timeSpeed);
      Vector2 drawpos = this.GetDrawpos(this.passedTime);
      this.sprite.Draw(sb, new Vector2(backgroundPos.X + drawpos.X, backgroundPos.Y + drawpos.Y), gameTime, colorn: new Color?(Color.White * 0.3f), rotation: this.flyangle);
    }
  }
}
