// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GlobalEvent
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace DodoTheGame
{
  internal class GlobalEvent
  {
    public object argument1;
    public GlobalEvent.Event gameEvent;

    public GlobalEvent(GlobalEvent.Event gameEvent, object argument1 = null)
    {
      this.gameEvent = gameEvent;
      this.argument1 = argument1;
    }

    public enum Event
    {
      DodoCollisionWithObjectOrTerrain,
      DodoLeavingWater,
      DodoEnteringWater,
      DodoPulseSwimming,
      DodoBuilding,
      DodoUpgrading,
      DodoHarvesting,
      UIInventoryOpening,
      UIInventoryClosing,
      UIEscapeMenuOpening,
      UIEscapeMenuClosing,
      UIMenuSelection,
      UIInventorySelection,
      DodoBicycling,
      Logo,
      BbOpening,
      BbClosing,
      DodoWalking,
      BikeAppearing,
      BikeDisappearing,
      BikeMoving,
      BoardBuilt,
      BoardUpgraded,
      VehicleUnlocked,
      Owl,
      Seagull,
      CantDoAction,
      VineFlowerHarvested,
    }
  }
}
