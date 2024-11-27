// Type: DodoTheGame.Interactions.Build

using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame.Interactions
{
  internal class Build : IDodoInteraction
  {
    public List<ItemStack> intake;
    public Preset buildPreset;

    public bool ComputeShowState(IWorldObject parentWo, Player player) => true;

    public Build(List<ItemStack> intake, Preset preset)
    {
      this.intake = intake;
      this.buildPreset = preset;
    }

    public Build()
    {
    }

    public string ShowName => LocalizationManager.GetString("InteractionBuild");


    public void Trigger(Game1 game, Player player, IWorldObject parentWo)
    {
      BuildPoint bp = (BuildPoint) parentWo;
      if (player.currentMovementType != Player.DodoMovement.Walk 
                && player.currentMovementType != Player.DodoMovement.Swim 
                && player.currentMovementType != Player.DodoMovement.Drown 
                || !player.HasHeadOutsideWater
                || Game1.world.objects.Any<IWorldObject>(
                    (Func<IWorldObject, bool>) 
                    (p => ((IEnumerable<string>) p.Tags)
                    .Intersect<string>((IEnumerable<string>) bp.bpIncompatibleTags).Any<string>())) 
                    || bp.otherBuildsSpecialIncompatibleTags.Length != 0 
                    && Game1.world.objects.Any<IWorldObject>((Func<IWorldObject, bool>)
                    (p => ((IEnumerable<string>) p.Tags).Intersect<string>(
                        (IEnumerable<string>) bp.otherBuildsSpecialIncompatibleTags).Any<string>())))
        return;

      player.CancelDrowning();

      bool flag = true;
      foreach (ItemStack itemStack1 in this.intake)
      {
        ItemStack itm = itemStack1;
        int num = 0;
        foreach (ItemStack itemStack2 in
                    ((IEnumerable<ItemStack>) player.inventory.inventory)
                    .Where<ItemStack>((Func<ItemStack, bool>) 
                    (i => i != null && i.itemId == itm.itemId)).ToList<ItemStack>())
          num += itemStack2.count;

        if (num < itm.count)
        {
          flag = false;
          break;
        }
      }

        if (flag)
        {
            foreach (ItemStack itemStack3 in this.intake)
            {
                foreach (ItemStack itemStack4 in player.inventory.inventory)
                {
                    int? itemId1 = itemStack4?.itemId;
                    int itemId2 = itemStack3.itemId;
                    if (itemId1.GetValueOrDefault() == itemId2 & itemId1.HasValue)
                        itemStack4.count -= itemStack3.count;
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
        {
            Debug.WriteLine("[!] Build failed: missing items");
        }
    }
  }
}
