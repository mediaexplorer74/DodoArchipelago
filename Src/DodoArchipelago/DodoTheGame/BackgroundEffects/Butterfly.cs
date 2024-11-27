
// Type: DodoTheGame.BackgroundEffects.Butterfly

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame.BackgroundEffects
{
  internal class Butterfly : IBackgroundEffect
  {
    public float passedTime;
    private readonly Sprite sprite;
    private readonly Vector2 generalGuidance;
    private const float guidanceStrictness = 0.1f;
    private List<Vector2> targetPoints;
    private const int splineCoef = 10;
    private readonly int amplitude;

    private double timeBetweenPoints => 60.0;

    public Vector2 GetDrawpos(float time)
    {
      int index = Convert.ToInt32(Math.Floor((double) this.passedTime / this.timeBetweenPoints)) + 1;
      float single = Convert.ToSingle((double) this.passedTime / this.timeBetweenPoints - Math.Floor((double) this.passedTime / this.timeBetweenPoints));
      if (index > this.targetPoints.Count - 1)
      {
        this.targetPoints = new List<Vector2>()
        {
          this.targetPoints[this.targetPoints.Count - 2],
          this.targetPoints[this.targetPoints.Count - 1]
        };
        this.targetPoints.AddRange(this.GeneratePoints(200, this.targetPoints[this.targetPoints.Count - 1]));
        index = 1;
        this.passedTime = 0.0f;
      }
      return this.targetPoints[index - 1] + (this.targetPoints[index] - this.targetPoints[index - 1]) * single;
    }

    public Butterfly(Vector2 startingPoint, Sprite sprite, int amplitude, Vector2 generalGuidance)
    {
      this.sprite = sprite;
      this.amplitude = amplitude;
      this.generalGuidance = generalGuidance;
      this.targetPoints = new List<Vector2>();
      this.targetPoints.AddRange(this.GeneratePoints(200, startingPoint));
    }

    private IEnumerable<Vector2> GeneratePoints(int count, Vector2 initialLocation)
    {
      Vector2 vector2 = initialLocation;
      List<Vector2> source = new List<Vector2>();
      for (int index = 0; index < count; ++index)
      {
        source.Add(vector2);
        vector2.X += (float) Game1.RNG.Next(-this.amplitude + Convert.ToInt32(this.generalGuidance.X * 0.1f), this.amplitude + Convert.ToInt32(this.generalGuidance.X));
        vector2.Y += (float) Game1.RNG.Next(-this.amplitude + Convert.ToInt32(this.generalGuidance.Y * 0.1f), this.amplitude + Convert.ToInt32(this.generalGuidance.Y));
      }
      float[] xs;
      float[] ys;
      CubicSpline.FitParametric(source.Select<Vector2, float>((Func<Vector2, float>) (item => item.X)).ToArray<float>(), source.Select<Vector2, float>((Func<Vector2, float>) (item => item.Y)).ToArray<float>(), count * 10, out xs, out ys);
      return (IEnumerable<Vector2>) ((IEnumerable<float>) xs).Select<float, Vector2>((Func<float, int, Vector2>) ((t, i) => new Vector2(t, ys[i]))).ToList<Vector2>();
    }

    public void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos)
    {
      this.passedTime += (float) (gameTime.ElapsedGameTime.TotalMilliseconds * DayCycle.timeSpeed);
      this.sprite.Draw(sb, backgroundPos + this.GetDrawpos(this.passedTime), gameTime, colorn: new Color?(Color.White * 1f));
    }
  }
}
