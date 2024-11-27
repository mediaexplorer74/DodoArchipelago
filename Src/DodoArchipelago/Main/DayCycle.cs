
// Type: DodoTheGame.DayCycle

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using System;
using System.Linq;


namespace DodoTheGame
{
  internal static class DayCycle
  {
    public static double dayTime = 0.0;
    public static double previousdayTime = 0.0;
    public static double timeSpeed = 0.0;
    public static Color dayColor = Color.White;
    public static Color sunsetColor = new Color(0.89f, 0.658f, 0.341f);
    public static Color nightColor = new Color(0.4f, 0.4f, 0.63f, 0.6f);
    public static int currentWindIndex = 0;

    public static bool IsNight => DayCycle.dayTime >= 370.0;

    public static double CurrentTime => DayCycle.dayTime;

    public static string CyclePart
    {
      get
      {
        if (DayCycle.dayTime >= 0.0 && DayCycle.dayTime < 300.0)
          return "Day";
        if (DayCycle.dayTime >= 300.0 && DayCycle.dayTime < 320.0)
          return "Day->Sunset";
        if (DayCycle.dayTime >= 320.0 && DayCycle.dayTime < 350.0)
          return "Sunset";
        if (DayCycle.dayTime >= 350.0 && DayCycle.dayTime < 370.0)
          return "Sunset->Night";
        if (DayCycle.dayTime >= 370.0 && DayCycle.dayTime < 490.0)
          return "Night";
        if (DayCycle.dayTime >= 490.0 && DayCycle.dayTime < 510.0)
          return "Night->Day";
        throw new Exception("Daytime out of range");
      }
    }

    public static Color ColorFilter
    {
      get
      {
        if (DayCycle.dayTime >= 0.0 && DayCycle.dayTime < 300.0)
          return DayCycle.dayColor;
        if (DayCycle.dayTime >= 300.0 && DayCycle.dayTime < 320.0)
          return new Color(Convert.ToSingle(Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.sunsetColor.R / (float) byte.MaxValue)) * (1.0 - (320.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.sunsetColor.G / (float) byte.MaxValue)) * (1.0 - (320.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.sunsetColor.B / (float) byte.MaxValue)) * (1.0 - (320.0 - DayCycle.dayTime) / 20.0)));
        if (DayCycle.dayTime >= 320.0 && DayCycle.dayTime < 350.0)
          return DayCycle.sunsetColor;
        if (DayCycle.dayTime >= 350.0 && DayCycle.dayTime < 370.0)
          return new Color(Convert.ToSingle(Convert.ToDouble((float) DayCycle.sunsetColor.R / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.sunsetColor.R / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.nightColor.R / (float) byte.MaxValue)) * (1.0 - (370.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.sunsetColor.G / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.sunsetColor.G / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.nightColor.G / (float) byte.MaxValue)) * (1.0 - (370.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.sunsetColor.B / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.sunsetColor.B / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.nightColor.B / (float) byte.MaxValue)) * (1.0 - (370.0 - DayCycle.dayTime) / 20.0)));
        if (DayCycle.dayTime >= 370.0 && DayCycle.dayTime < 490.0)
          return DayCycle.nightColor;
        if (DayCycle.dayTime >= 490.0 && DayCycle.dayTime < 510.0)
          return new Color(Convert.ToSingle(Convert.ToDouble((float) DayCycle.nightColor.R / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.nightColor.R / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.dayColor.R / (float) byte.MaxValue)) * (1.0 - (510.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.nightColor.G / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.nightColor.G / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.dayColor.G / (float) byte.MaxValue)) * (1.0 - (510.0 - DayCycle.dayTime) / 20.0)), Convert.ToSingle(Convert.ToDouble((float) DayCycle.nightColor.B / (float) byte.MaxValue) - (Convert.ToDouble((float) DayCycle.nightColor.B / (float) byte.MaxValue) - Convert.ToDouble((float) DayCycle.dayColor.B / (float) byte.MaxValue)) * (1.0 - (510.0 - DayCycle.dayTime) / 20.0)));
        throw new Exception("Daytime out of range");
      }
    }

    public static double NightFactor
    {
      get
      {
        if (DayCycle.dayTime >= 0.0 && DayCycle.dayTime < 350.0)
          return 1.0;
        if (DayCycle.dayTime >= 350.0 && DayCycle.dayTime < 370.0)
          return (370.0 - DayCycle.dayTime) / 20.0;
        return DayCycle.dayTime >= 370.0 && DayCycle.dayTime < 490.0 || DayCycle.dayTime < 490.0 ? 0.0 : 1.0 - (510.0 - DayCycle.dayTime) / 20.0;
      }
    }

    public static void Update(Game1 game, GameTime gameTime)
    {
      DayCycle.dayTime += gameTime.ElapsedGameTime.TotalMilliseconds / 500.0;
      if (DayCycle.dayTime <= 510.0)
        return;
      ++DayCycle.currentWindIndex;
      if (DayCycle.currentWindIndex > Wind.windDirections.Count - 1)
        DayCycle.currentWindIndex = 0;
      Wind.MainAngle = Wind.windDirections[DayCycle.currentWindIndex];
      Game1.player.bgmThemeCount = 0;
      foreach (IWorldObject worldObject in Game1.world.objects.Where<IWorldObject>((Func<IWorldObject, bool>) (p => p is Growable || p is LinkingGrowable)))
      {
        if (worldObject is Growable growable)
        {
          if (growable.regrowOverTime)
          {
            ++growable.growTimePassed;
            if (growable.growTimePassed >= growable.growTime)
            {
              growable.growTimePassed = 0;
              if (growable.mainGrowState > 0)
                --growable.mainGrowState;
            }
          }
        }
        else if (worldObject is LinkingGrowable linkingGrowable)
        {
          ++linkingGrowable.growTimePassed;
          if (linkingGrowable.growTimePassed >= linkingGrowable.growTime)
          {
            linkingGrowable.growTimePassed = 0;
            if (linkingGrowable.mainGrowState > 0)
              --linkingGrowable.mainGrowState;
          }
        }
      }
      DayCycle.dayTime = 0.0;
    }
  }
}
