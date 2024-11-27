
// Type: DodoTheGame.Wind

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace DodoTheGame
{
  internal static class Wind
  {
    public static double mainspeed = 0.3;
    private static double timeSinceLastCycle = 0.0;
    private static double currentDeviation = 0.0;
    public static double maxDeviation = 0.0;
    public static double deviationAmount = 27.0;
    public static double deviationCycleTime = 610.0;
    public static List<double> windDirections = new List<double>()
    {
      315.0,
      270.0,
      225.0,
      135.0,
      90.0,
      45.0
    };
    public static double windDirectionWhenOnIsland = 45.0;

    public static double GetAngle => Wind.RawAngle * (Math.PI / 180.0) + Wind.currentDeviation;

    public static double RawAngle { get; set; } = 315.0;

    public static double GetSpeed => Wind.mainspeed;

    public static double MainAngle
    {
      get => Wind.RawAngle;
      set => Wind.RawAngle = value;
    }

    public static void Update(GameTime gameTime, Player player)
    {
      Vector2 vector2 = new Vector2(4200f, 11000f);
      if (Math.Sqrt(Math.Pow((double) player.location.X - (double) vector2.X, 2.0) + Math.Pow((double) player.location.Y - (double) vector2.Y, 2.0)) < 800.0)
        Wind.RawAngle = Wind.windDirectionWhenOnIsland;
      if (Wind.mainspeed > 1.0)
        Wind.mainspeed = 1.0;
      else if (Wind.mainspeed < 0.0)
        Wind.mainspeed = 0.0;
      if (Wind.RawAngle * (Math.PI / 180.0) < 0.0)
        Wind.RawAngle += 180.0;
      if (Wind.RawAngle * (Math.PI / 180.0) > 2.0 * Math.PI)
        Wind.RawAngle -= 180.0;
      Wind.timeSinceLastCycle += gameTime.ElapsedGameTime.TotalMilliseconds;
      if (Wind.timeSinceLastCycle < Wind.deviationCycleTime)
        return;
      Wind.timeSinceLastCycle = 0.0;
      double num1 = Game1.RNG.NextDouble() / Wind.deviationAmount;
      double num2 = Game1.RNG.NextDouble() < 0.5 ? -num1 : num1;
      Wind.currentDeviation += num2;
      if (Wind.currentDeviation > Wind.maxDeviation)
        Wind.currentDeviation = Wind.maxDeviation;
      if (Wind.currentDeviation >= -Wind.maxDeviation)
        return;
      Wind.currentDeviation = -Wind.maxDeviation;
    }
  }
}
