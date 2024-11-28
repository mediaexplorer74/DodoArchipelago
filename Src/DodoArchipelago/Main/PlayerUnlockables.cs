
// Type: DodoTheGame.PlayerUnlockables

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;


namespace DodoTheGame
{
  public class PlayerUnlockables
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
