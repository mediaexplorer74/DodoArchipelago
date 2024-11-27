
// Type: DodoTheGame.Interactions.Harvest

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.ForegroundEffects;
using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;


namespace DodoTheGame.Interactions
{
  internal class Harvest : IDodoInteraction
  {
    public ItemStack[] harvestItems;
    public Harvest.HarvestType harvestType = Harvest.HarvestType.Regular;

    public bool ComputeShowState(IWorldObject parentWo, Player player)
    {
      return parentWo is Growable growable ? growable.mainGrowState == 0 : ((LinkingGrowable) parentWo).mainGrowState == 0;
    }

    public string ShowName => LocalizationManager.GetString("InteractionHarvest");

    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      if (player.currentMovementType != Player.DodoMovement.Walk && player.currentMovementType != Player.DodoMovement.Swim && player.currentMovementType != Player.DodoMovement.Drown || !player.HasHeadOutsideWater)
        return;
      player.CancelDrowning();
      bool flag = true;
      foreach (ItemStack harvestItem in this.harvestItems)
      {
        if (!player.inventory.AddItem(harvestItem, true))
          flag = false;
      }
      if ((!flag || !(parentWo is Growable) || ((Growable) parentWo).mainGrowState != 0) && (!(parentWo is LinkingGrowable) || ((LinkingGrowable) parentWo).mainGrowState != 0))
        return;
      if (this.harvestType == Harvest.HarvestType.Regular)
        game.dodoSpriteHarvesting.ResetAnimation();
      if (this.harvestType == Harvest.HarvestType.Small)
        game.dodoTakeSprite.ResetAnimation();
      game.harvestCloudSprite.ResetAnimation();
      player.actionTime = 0;
      player.currentMovementType = Player.DodoMovement.Harvest;
      player.buildingObject = parentWo;
    }

    public void RegisterSuccess(Player player, IWorldObject parentWo, GameTime gameTime)
    {
      ItemStack[] harvestResults = (ItemStack[]) this.harvestItems.Clone();
      Game1.foregroundEffectList.Add((IForegroundEffect) new HarvestResults(harvestResults, parentWo.Epicenter, Game1.rouliMSpriteFont, gameTime));
      foreach (ItemStack itemStack in harvestResults)
        player.inventory.AddItem(itemStack);
      if (parentWo is Growable growable)
      {
        growable.growTimePassed = 0;
        if (growable.mainGrowState == 0)
          growable.mainGrowState = growable.growSprites.Count - 1;
      }
      else if (parentWo is LinkingGrowable linkingGrowable)
      {
        linkingGrowable.growTimePassed = 0;
        if (linkingGrowable.mainGrowState == 0)
          linkingGrowable.mainGrowState = linkingGrowable.growSprites.Count - 1;
      }
      if (parentWo is Growable)
      {
        ((Growable) parentWo).TriggerHarvest();
      }
      else
      {
        if (!(parentWo is LinkingGrowable))
          return;
        ((LinkingGrowable) parentWo).TriggerHarvest();
      }
    }

    public Harvest()
    {
    }

    public Harvest(ItemStack[] harvestItem, Harvest.HarvestType harvestType = Harvest.HarvestType.Regular)
    {
      this.harvestItems = harvestItem;
      this.harvestType = harvestType;
    }

    public enum HarvestType
    {
      Small,
      Regular,
      Big,
    }
  }
}
