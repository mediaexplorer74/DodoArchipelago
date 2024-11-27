
// Type: DodoTheGame.GlobalEventManager

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.WorldObject;
using System;


namespace DodoTheGame
{
  internal static class GlobalEventManager
  {
    public static void RegisterEvent(GlobalEvent gEvent)
    {
      Sound.RegisterLegacyEvent(gEvent);
      if (gEvent.gameEvent != GlobalEvent.Event.VineFlowerHarvested)
        return;
      Game1.world.objects.RemoveAll((Predicate<IWorldObject>) (p => p.PresetMarker == "ronces" || p.PresetMarker == "flatronce" || p.PresetMarker == "turningronce"));
    }
  }
}
