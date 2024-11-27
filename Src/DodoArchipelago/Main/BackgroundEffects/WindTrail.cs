
// Type: DodoTheGame.BackgroundEffects.WindTrail

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.BackgroundEffects
{
  internal class WindTrail : IBackgroundEffect
  {
    public readonly Sprite sprite;
    public Vector2 startingPoint;
    private double diagonalSpeed = 4.0;
    private double horizontalSpeed = 3.5999999046325684;
    private readonly WindTrail.WindDirection direction;
    public double time;

    public WindTrail(Vector2 startingPoint, Sprite sprite, WindTrail.WindDirection direction)
    {
      this.startingPoint = startingPoint;
      this.sprite = sprite.Duplicate();
      this.direction = direction;
      this.sprite.ResetAnimation();
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      this.time += gameTime.ElapsedGameTime.TotalMilliseconds * (double) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0)) / 2.0;
      this.diagonalSpeed = 4.0 * (double) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0));
      this.horizontalSpeed = 3.5999999046325684 * (double) Convert.ToInt16(Math.Round(DayCycle.timeSpeed, 0));
      if (this.time >= 1755.0)
        return;
      double num = 1.0;
      Vector2 location;
      float rotation;
      SpriteEffects globaleffect;
      switch (this.direction)
      {
        case WindTrail.WindDirection.Left:
          location = new Vector2(backgroundPos.X + this.startingPoint.X - Convert.ToSingle(Math.Round(this.time / this.horizontalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y);
          rotation = 0.0f;
          globaleffect = SpriteEffects.None;
          break;
        case WindTrail.WindDirection.Right:
          location = new Vector2(backgroundPos.X + this.startingPoint.X + Convert.ToSingle(Math.Round(this.time / this.horizontalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y);
          rotation = 0.0f;
          globaleffect = SpriteEffects.FlipHorizontally;
          break;
        case WindTrail.WindDirection.UpLeft:
          location = new Vector2(backgroundPos.X + this.startingPoint.X - Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y - Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)));
          rotation = Convert.ToSingle(Math.PI / 4.0);
          globaleffect = SpriteEffects.None;
          break;
        case WindTrail.WindDirection.UpRight:
          location = new Vector2(backgroundPos.X + this.startingPoint.X + Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y - Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)));
          rotation = Convert.ToSingle(-1.0 * Math.PI / 4.0);
          globaleffect = SpriteEffects.FlipHorizontally;
          break;
        case WindTrail.WindDirection.DownLeft:
          location = new Vector2(backgroundPos.X + this.startingPoint.X - Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y + Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)));
          rotation = Convert.ToSingle(-1.0 * Math.PI / 4.0);
          globaleffect = SpriteEffects.None;
          break;
        case WindTrail.WindDirection.DownRight:
          location = new Vector2(backgroundPos.X + this.startingPoint.X + Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)), backgroundPos.Y + this.startingPoint.Y + Convert.ToSingle(Math.Round(this.time / this.diagonalSpeed, 0)));
          rotation = Convert.ToSingle(Math.PI / 4.0);
          globaleffect = SpriteEffects.FlipHorizontally;
          break;
        default:
          Vector2 zero = Vector2.Zero;
          throw new Exception("Unknown Windtrail direction");
      }
      this.sprite.Draw(sb, location, gameTime, globaleffect, new Color?(Color.White * Convert.ToSingle(num)), rotation: (double) rotation);
    }

    public enum WindDirection
    {
      Left,
      Right,
      UpLeft,
      UpRight,
      DownLeft,
      DownRight,
    }
  }
}
