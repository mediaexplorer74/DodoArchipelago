// Type: DodoTheGame.Interactions.Upgrade

using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame.Interactions
{
  internal class Upgrade : IDodoInteraction
  {
    public bool alreadyInteracted;
    public Preset upgradePreset;
    public List<ItemStack> upgradeItems;
    public int requiredLevelToUpgrade;

    public bool ComputeShowState(IWorldObject parentWo, Player player) => true;

    public string ShowName
    {
      get
      {
        return !this.alreadyInteracted 
                    ? LocalizationManager.GetString("InteractionUpgradeSee")
                    : LocalizationManager.GetString("InteractionUpgradeActivate");
      }
    }

    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      Upgradable upg = parentWo is Upgradable 
                ? (Upgradable) parentWo 
                : throw new Exception("Upgrade interaction is not supported for this IWO");
      if (!this.alreadyInteracted)
      {
        ((Upgradable) parentWo).ResetOpenBuildboxes();
        this.alreadyInteracted = true;
      }
      else
      {
        if (parentWo.PresetMarker == "Atelier" 
                    && !player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bike] 
                    || parentWo.PresetMarker == "Atelier 2" 
                    && !player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle] 
                    || player.currentMovementType == Player.DodoMovement.Build 
                    || Game1.world.Level < this.requiredLevelToUpgrade 
                    || upg.incompatibleTagsToUpgrade.Length != 0 
                    && Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>)
                    (p => ((IEnumerable<string>) p.Tags)
                    .Intersect<string>((IEnumerable<string>) 
                    upg.incompatibleTagsToUpgrade).Any<string>())) 
                    || upg.otherBuildsSpecialIncompatibleTags.Length != 0 
                    && Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>) 
                    (p => ((IEnumerable<string>) p.Tags)
                    .Intersect<string>((IEnumerable<string>) 
                    upg.otherBuildsSpecialIncompatibleTags).Any<string>())))
          return;

        bool flag = true;
        foreach (ItemStack upgradeItem in this.upgradeItems)
        {
          ItemStack itm = upgradeItem;
          int num = 0;

          foreach (ItemStack itemStack 
                        in ((IEnumerable<ItemStack>) player.inventory.inventory)
                        .Where<ItemStack>((Func<ItemStack, bool>) 
                        (i => i != null && i.itemId == itm.itemId)).ToList<ItemStack>())
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
          game.dodoSpriteBuilding.ResetAnimation();
          game.buildingCloudSprite.ResetAnimation();
          game.preBuildingCloudSprite.ResetAnimation();
          player.currentMovementType = Player.DodoMovement.Build;
          player.buildingObject = parentWo;
          player.actionTime = 0;
        }
        else
          Debug.WriteLine("[i] Upgrade failed: missing items");
      }
    }

    public Upgrade()
    {
       //TODO
    }

    public Upgrade(Preset upgradePreset, List<ItemStack> upgradeItems, int requiredLevelToUpgrade)
    {
      this.upgradePreset = upgradePreset;
      this.upgradeItems = upgradeItems;
      this.requiredLevelToUpgrade = requiredLevelToUpgrade;
    }
  }
}
