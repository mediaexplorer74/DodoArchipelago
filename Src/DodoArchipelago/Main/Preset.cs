// Type: DodoTheGame.Preset


using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using DodoTheGame.Interactions;
using DodoTheGame.WorldObject;


namespace DodoTheGame
{
  internal class Preset
  {
    public Preset.WOType type;
    public string name;
    public string category;
    public string[] tags;
    public string[] otherBuildsSpecialIncompatibleTags;
    public string displayName;
    public string[] incompatibleTags;
    public Sprite sprite;
    public List<Rectangle> hitbox;
    public Vector2 epicenterOffset;
    public IDodoInteraction[] interactions;
    public Vector2? extraReach;
    public int extraFloorHeight;
    public List<Sprite> growSprites;
    public int growtime;
    public int growstate;
    public bool regrowOverTime;
    public List<List<Rectangle>> growHitboxes;
    public List<ItemStack> buildOrUpgradeItems;
    public Sprite linkingSprite;
    public string linkToPreset;
    public Vector2 linkOffset;

    public Preset(
      string displayname,
      string name,
      Preset.WOType type,
      Sprite sprite,
      List<Rectangle> hitbox,
      Vector2 epicenterOffset,
      IDodoInteraction[] interactions,
      string category,
      Vector2? extraReach = null,
      List<ItemStack> buildOrUpgradeItems = null,
      string[] tags = null,
      string[] incompatibleTags = null,
      string[] otherBuildsSpecialIncompatibleTags = null,
      int extraFloorHeight = 0)
    {
      this.displayName = displayname;
      this.name = name;
      this.type = type;
      this.sprite = sprite;
      this.hitbox = hitbox;
      this.epicenterOffset = epicenterOffset;
      this.interactions = interactions;
      this.extraReach = extraReach;
      this.extraFloorHeight = extraFloorHeight;
      this.category = category;
      this.buildOrUpgradeItems = buildOrUpgradeItems;
      this.tags = tags;
      this.incompatibleTags = incompatibleTags;
      this.otherBuildsSpecialIncompatibleTags = otherBuildsSpecialIncompatibleTags;
    }

    public Preset(
      string displayname,
      string name,
      Preset.WOType type,
      List<Sprite> sprites,
      List<Rectangle> hitbox,
      Vector2 epicenterOffset,
      IDodoInteraction[] interactions,
      string category,
      Vector2? extraReach = null,
      int growtime = 1,
      int growstate = 0,
      List<ItemStack> buildOrUpgradeItems = null,
      string[] tags = null,
      string[] incompatibleTags = null,
      bool regrowOverTime = true)
    {
      if (type != Preset.WOType.Growable && type != Preset.WOType.LinkingGrowable)
        Debug.WriteLine("[!!!] Second preset constructor expects Growable or LinkingGrowable. " +
            "There may be an error in this Preset declaration.");
      this.growtime = growtime;
      this.name = name;
      this.type = type;
      this.growSprites = sprites;
      this.hitbox = hitbox;
      this.epicenterOffset = epicenterOffset;
      this.interactions = interactions;
      this.extraReach = extraReach;
      this.growstate = growstate;
      this.category = category;
      this.buildOrUpgradeItems = buildOrUpgradeItems;
      this.tags = tags;
      this.incompatibleTags = incompatibleTags;
      this.regrowOverTime = regrowOverTime;
    }

    public Preset
    (
      string displayname,
      string name,
      Preset.WOType type,
      List<Sprite> sprites,
      List<List<Rectangle>> growHitboxes,
      Vector2 epicenterOffset,
      IDodoInteraction[] interactions,
      string category,
      Vector2? extraReach = null,
      int growtime = 1,
      int growstate = 0,
      List<ItemStack> buildOrUpgradeItems = null,
      string[] tags = null,
      string[] incompatibleTags = null,
      bool regrowOverTime = true
    )
    {
      if (type != Preset.WOType.Growable && type != Preset.WOType.LinkingGrowable)
        Debug.WriteLine("[!!!] Second preset constructor expects Growable or LinkingGrowable." +
            " There may be an error in this Preset declaration.");
      this.growtime = growtime;
      this.name = name;
      this.type = type;
      this.growSprites = sprites;
      this.growHitboxes = growHitboxes;
      this.epicenterOffset = epicenterOffset;
      this.interactions = interactions;
      this.extraReach = extraReach;
      this.growstate = growstate;
      this.category = category;
      this.buildOrUpgradeItems = buildOrUpgradeItems;
      this.tags = tags;
      this.incompatibleTags = incompatibleTags;
      this.regrowOverTime = regrowOverTime;
    }

    public Preset()
    {
    }

    public List<IWorldObject> MakeWOs(List<Tuple<Vector2, string>> locationAndNameList)
    {
      List<IWorldObject> worldObjectList = new List<IWorldObject>();

      foreach (Tuple<Vector2, string> locationAndName in locationAndNameList)
        worldObjectList.Add(this.MakeWO(locationAndName.Item1, locationAndName.Item2));

      return worldObjectList;
    }

    public IWorldObject MakeWO(Vector2 location, string woName)
    {
      if (woName == null)
        woName = this.name + ((int) DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds).ToString();
      IWorldObject worldObject;

      switch (this.type)
      {
        case Preset.WOType.Static:
          this.sprite.autoUpdate = false;
          worldObject = (IWorldObject) new Static(woName, this.sprite, location,
              this.hitbox, new Vector2?(new Vector2(location.X + this.epicenterOffset.X, 
              location.Y + this.epicenterOffset.Y)))
          {
            PresetMarker = this.name,
            ExtraFloorHeight = this.extraFloorHeight
          };
          break;

        case Preset.WOType.Growable:
          this.growSprites.ForEach((Action<Sprite>) (spr => spr.autoUpdate = false));
          worldObject = (IWorldObject) new Growable(woName, 
              this.growSprites, location, this.hitbox, 
              new Vector2?(new Vector2(location.X + this.epicenterOffset.X, 
              location.Y + this.epicenterOffset.Y)))
          {
            PresetMarker = this.name,
            growTime = this.growtime,
            mainGrowState = this.growstate,
            ExtraFloorHeight = this.extraFloorHeight,
            regrowOverTime = this.regrowOverTime
          };
          break;

        case Preset.WOType.BuildPoint:
          this.sprite.autoUpdate = false;
          worldObject = (IWorldObject) new BuildPoint(woName, this.sprite, 
              location, this.hitbox, 
              new Vector2?(new Vector2(location.X + 
              this.epicenterOffset.X, location.Y + this.epicenterOffset.Y)))
          {
            PresetMarker = this.name,
            otherBuildsSpecialIncompatibleTags = (this.otherBuildsSpecialIncompatibleTags ?? new string[0]),
            ExtraFloorHeight = this.extraFloorHeight
          };
          break;

        case Preset.WOType.LinkingGrowable:
          this.growSprites.ForEach((Action<Sprite>) (spr => spr.autoUpdate = false));
          this.linkingSprite.autoUpdate = false;
          worldObject = (IWorldObject) new LinkingGrowable(woName, this.growSprites, 
              location, this.hitbox, new Vector2?(new Vector2(location.X + this.epicenterOffset.X, 
              location.Y + this.epicenterOffset.Y)))
          {
            PresetMarker = this.name,
            growTime = this.growtime,
            mainGrowState = this.growstate,
            linkedSprite = this.linkingSprite,
            linkToPreset = this.linkToPreset,
            linkOffset = this.linkOffset,
            ExtraFloorHeight = this.extraFloorHeight
          };
          break;
        case Preset.WOType.Upgradable:
          this.sprite.autoUpdate = false;
          worldObject = (IWorldObject) new Upgradable(woName, this.sprite, location, 
              this.hitbox, new Vector2?(new Vector2(location.X + this.epicenterOffset.X, 
              location.Y + this.epicenterOffset.Y)))
          {
            incompatibleTagsToUpgrade = (this.incompatibleTags ?? new string[0]),
            PresetMarker = this.name,
            otherBuildsSpecialIncompatibleTags = (this.otherBuildsSpecialIncompatibleTags ?? new string[0]),
            ExtraFloorHeight = this.extraFloorHeight
          };
          break;
        case Preset.WOType.Hourglass:
          this.sprite.autoUpdate = false;
          worldObject = (IWorldObject) new Hourglass(woName, this.sprite, 
              location, this.hitbox, new Vector2?(new Vector2(
                  location.X + this.epicenterOffset.X, location.Y + this.epicenterOffset.Y)))
          {
            PresetMarker = this.name,
            ExtraFloorHeight = this.extraFloorHeight
          };
          break;

        default:
          throw new Exception("Unknown value for enum WOType in Preset.MakeWOs");
        }

            if (this.name == "Tableau de bord")
            {
                ((Upgradable)worldObject).Upgraded += (EventHandler)((sender, args) =>
                {
                    GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BoardUpgraded));
                    Game1.world.Level = 2;
                });
            }
            else if (this.name == "Board2")
            {
                ((Upgradable)worldObject).Upgraded += (EventHandler)((sender, args) =>
                {
                    GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BoardUpgraded));
                    Game1.world.Level = 3;
                });
            }
            else if (this.name == "UpgradableHouse" || this.name == "house2"
                        || this.name == "house3" || this.name == "house4")
            {
                Game1.SpawnDodo(location + new Vector2((float)this.sprite.Width / 2f,
                    (float)this.sprite.height) + new Vector2(0.0f, 30f));
            }

        if (this.extraReach.HasValue)
            worldObject.ExtraReach = this.extraReach.Value;

      worldObject.Tags = this.tags ?? new string[0];
      worldObject.Interactions = this.interactions;
      return worldObject;
    }

    public enum WOType
    {
      Static,
      Growable,
      BuildPoint,
      LinkingGrowable,
      Upgradable,
      Hourglass,
    }
  }
}
