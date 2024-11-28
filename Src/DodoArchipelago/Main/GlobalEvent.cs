
// Type: DodoTheGame.GlobalEvent

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


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
