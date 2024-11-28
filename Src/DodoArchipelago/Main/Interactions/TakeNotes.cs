
// Type: DodoTheGame.Interactions.TakeNotes

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.ForegroundEffects;
using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;


namespace DodoTheGame.Interactions
{
  internal class TakeNotes : IDodoInteraction
  {
    public ItemStack[] harvestItems;

    public bool ComputeShowState(IWorldObject parentWo, Player player)
    {
      if (this.harvestItems[0].itemId <= 80 || player.inventory.flowerinventory[this.harvestItems[0].itemId - 81] != null)
        return false;
      return parentWo is Growable growable ? growable.mainGrowState == 0 : ((LinkingGrowable) parentWo).mainGrowState == 0;
    }

    public string ShowName => LocalizationManager.GetString("InteractionTakeNote");

    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      if (player.inventory.flowerinventory[this.harvestItems[0].itemId - 81] != null || player.currentMovementType != Player.DodoMovement.Walk && player.currentMovementType != Player.DodoMovement.Swim && player.currentMovementType != Player.DodoMovement.Drown || !player.HasHeadOutsideWater)
        return;
      player.CancelDrowning();
      bool flag = true;
      foreach (ItemStack harvestItem in this.harvestItems)
      {
        if (!player.inventory.AddItem(harvestItem, true))
          flag = false;
      }
      if (!flag)
        return;
      game.dodoTakeNotes.ResetAnimation();
      player.actionTime = 0;
      player.currentMovementType = Player.DodoMovement.TakeNotes;
      player.buildingObject = parentWo;
    }

    public void RegisterSuccess(Player player, IWorldObject parentWo, GameTime gameTime)
    {
      ItemStack[] harvestResults = (ItemStack[]) this.harvestItems.Clone();
      Game1.foregroundEffectList.Add((IForegroundEffect) new HarvestResults(harvestResults, parentWo.Epicenter, Game1.rouliMSpriteFont, gameTime));
      foreach (ItemStack itemStack in harvestResults)
        player.inventory.AddItem(itemStack);
      if (parentWo is Growable)
        return;
      LinkingGrowable linkingGrowable = parentWo as LinkingGrowable;
    }

    public TakeNotes()
    {
    }

    public TakeNotes(ItemStack[] harvestItem) => this.harvestItems = harvestItem;
  }
}
