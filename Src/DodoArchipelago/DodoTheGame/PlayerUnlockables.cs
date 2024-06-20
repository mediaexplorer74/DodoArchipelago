// Decompiled with JetBrains decompiler
// Type: DodoTheGame.PlayerUnlockables
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace DodoTheGame
{
  internal class PlayerUnlockables
  {
    public static string DisplayName(
      PlayerUnlockables.PlayerUnlockable playerUnlockable,
      bool article = false)
    {
      if (playerUnlockable != PlayerUnlockables.PlayerUnlockable.Bike)
      {
        if (playerUnlockable == PlayerUnlockables.PlayerUnlockable.Bicycle)
        {
          if (!article)
            return "Bicycle";
          if (article)
            return "un véhicule du temps";
        }
      }
      else
      {
        if (!article)
          return "Moto";
        if (article)
          return "un véhicule du vent";
      }
      throw new Exception("PlayerUnlockable.DisplayName received invalid arguments");
    }

    public enum PlayerUnlockable
    {
      Bike,
      Bicycle,
    }
  }
}
