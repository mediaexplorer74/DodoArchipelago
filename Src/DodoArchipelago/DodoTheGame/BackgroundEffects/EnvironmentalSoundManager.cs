// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BackgroundEffects.EnvironmentalSoundManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using System;


namespace DodoTheGame.BackgroundEffects
{
  internal static class EnvironmentalSoundManager
  {
    private static int TimeSinceLastEnvironmentalSound;
    private static int TimeSinceLastTTChange;
    private static int Delay;
    private static int OwlsThisNight;
    private static TerrainType LastTerrainType;
    private static TerrainType tt;
    private static bool DayCycleWasNight;

    public static event EventHandler Owl;

    public static void Update(GameTime gametime, Player player)
    {
      EnvironmentalSoundManager.TimeSinceLastEnvironmentalSound += gametime.ElapsedGameTime.Milliseconds;
      EnvironmentalSoundManager.TimeSinceLastTTChange += gametime.ElapsedGameTime.Milliseconds;
      EnvironmentalSoundManager.tt = player.StandingOnTerrainType;
      if (EnvironmentalSoundManager.tt != EnvironmentalSoundManager.LastTerrainType)
      {
        EnvironmentalSoundManager.TimeSinceLastTTChange = 0;
        EnvironmentalSoundManager.TimeSinceLastEnvironmentalSound = 0;
      }
      EnvironmentalSoundManager.LastTerrainType = EnvironmentalSoundManager.tt;
      if (EnvironmentalSoundManager.DayCycleWasNight != DayCycle.IsNight)
        EnvironmentalSoundManager.Delay = Game1.RNG.Next(5, 25);
      EnvironmentalSoundManager.DayCycleWasNight = DayCycle.IsNight;
      if (EnvironmentalSoundManager.tt != TerrainType.Leaves || !DayCycle.IsNight || EnvironmentalSoundManager.TimeSinceLastEnvironmentalSound <= 7000 + EnvironmentalSoundManager.Delay * 1000 || EnvironmentalSoundManager.TimeSinceLastTTChange <= 2000)
        return;
      EventHandler owl = EnvironmentalSoundManager.Owl;
      if (owl != null)
        owl((object) null, EventArgs.Empty);
      EnvironmentalSoundManager.Delay = Game1.RNG.Next(0, 25);
      EnvironmentalSoundManager.TimeSinceLastEnvironmentalSound = 0;
    }
  }
}
