// DodoTheGame.Interactions.UnlockPlayerUnlockable

using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame.Interactions
{
  internal class UnlockPlayerUnlockable : IDodoInteraction
  {
    public bool alreadyInteracted;
    public PlayerUnlockables.PlayerUnlockable unlockable;
    public List<ItemStack> upgradeItems;

    public bool ComputeShowState(IWorldObject parentWo, Player player)
    {
      return !player.unlockedPlayerTools[this.unlockable];
    }

    public string ShowName
    {
      get
      {
        return string.Format(LocalizationManager.GetString("InteractionUnlock"), 
            (object) LocalizationManager.GetString(this.unlockable.ToString() + "WithArticle"));
      }
    }

    public UnlockPlayerUnlockable()
    {
    }

    public UnlockPlayerUnlockable(
      PlayerUnlockables.PlayerUnlockable unlockable,
      List<ItemStack> upgradeItems)
    {
      this.unlockable = unlockable;
      this.upgradeItems = upgradeItems;
    }

    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      if (!(parentWo is Upgradable))
        throw new Exception("UnlockPlayerUnlockable interaction is not supported for this IWO");

      if (player.unlockedPlayerTools[this.unlockable] 
                || player.currentMovementType != Player.DodoMovement.Bike 
                && player.currentMovementType != Player.DodoMovement.Walk
                && player.currentMovementType != Player.DodoMovement.Swim)
        return;
      if (!this.alreadyInteracted)
      {
        ((Upgradable) parentWo).ResetOpenBuildboxes();
        this.alreadyInteracted = true;
      }
      else
      {
        if (player.unlockedPlayerTools[this.unlockable])
          return;
        bool flag = true;
        foreach (ItemStack upgradeItem in this.upgradeItems)
        {
          ItemStack itm = upgradeItem;
          int num = 0;

          foreach (ItemStack itemStack in ((IEnumerable<ItemStack>) player.inventory.inventory)
                        .Where<ItemStack>((Func<ItemStack, bool>) (i => i != null
                        && i.itemId == itm.itemId)).ToList<ItemStack>())
            num += itemStack.count;

          if (num < itm.count)
          {
            flag = false;
            break;
          }
        }
        if (flag)
        {
          foreach (ItemStack upgradeItem in this.upgradeItems)
          {
            foreach (ItemStack itemStack in player.inventory.inventory)
            {
              int? itemId1 = itemStack?.itemId;
              int itemId2 = upgradeItem.itemId;
              if (itemId1.GetValueOrDefault() == itemId2 & itemId1.HasValue)
                itemStack.count -= upgradeItem.count;
            }
          }
          GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.VehicleUnlocked));
          if (this.unlockable == PlayerUnlockables.PlayerUnlockable.Bike)
            player.currentMovementType = Player.DodoMovement.WalkToBike;
          else if (this.unlockable == PlayerUnlockables.PlayerUnlockable.Bicycle)
          {
            player.BuildingBicycleException = true;
            player.currentMovementType = Player.DodoMovement.WalkToBicycle;
          }
          player.unlockedPlayerTools[this.unlockable] = true;
          ((Upgradable) parentWo).ResetOpenBuildboxes();
        }
        else
          Debug.WriteLine("[i] Unlock failed: missing items");
      }
    }
  }
}
