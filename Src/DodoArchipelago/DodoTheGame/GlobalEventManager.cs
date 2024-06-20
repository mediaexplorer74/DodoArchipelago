// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GlobalEventManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

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
