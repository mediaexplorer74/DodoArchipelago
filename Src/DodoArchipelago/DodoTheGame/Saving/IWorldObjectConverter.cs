// Type: DodoTheGame.Saving.IWorldObjectConverter

using DodoTheGame.Interactions;
using DodoTheGame.Localization;
using DodoTheGame.WorldObject;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class IWorldObjectConverter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
        return default;//((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (s => (IEnumerable<Type>) s.GetTypes())).Where<Type>((Func<Type, bool>) (p => typeof (IWorldObject).IsAssignableFrom(p)));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      IWorldObject worldObject = (IWorldObject) obj;
      switch (obj)
      {
        case Static _:
          dictionary.Add("Type", (object) "Static");
          break;
        case Upgradable _:
          dictionary.Add("Type", (object) "Upgradable");
          break;
        case BuildPoint _:
          dictionary.Add("Type", (object) "BuildPoint");
          break;
        case Growable _:
          dictionary.Add("Type", (object) "Growable");
          break;
        case LinkingGrowable _:
          dictionary.Add("Type", (object) "LGrowable");
          break;
        case Hourglass _:
          dictionary.Add("Type", (object) "Hourglass");
          break;
        default:
          throw new Exception("Invalid IWO type");
      }
      dictionary.Add("PresetMarker", (object) worldObject.PresetMarker);
      dictionary.Add("Visible", (object) worldObject.Visible);
      dictionary.Add("ExplicitEpicenter", (object) worldObject.ExplicitEpicenter);
      dictionary.Add("ExtraFloorHeight", (object) worldObject.ExtraFloorHeight);
      dictionary.Add("ExtraReach", (object) worldObject.ExtraReach);
      dictionary.Add("Hitbox", (object) worldObject.Hitbox);
      dictionary.Add("Interactions", (object) worldObject.Interactions);
      dictionary.Add("Location", (object) worldObject.Location);
      dictionary.Add("ObjectId", (object) worldObject.ObjectId);
      dictionary.Add("StandardSprite", (object) worldObject.StandardSprite);
      dictionary.Add("Tags", (object) worldObject.Tags);
      switch (worldObject)
      {
        case Static @static:
          dictionary.Add("VisibilityIncompatibleTags", (object) @static.VisibilityIncompatibleTags);
          dictionary.Add("VisibilityRequirementTags", (object) @static.VisibilityRequirementTags);
          break;
        case BuildPoint buildPoint:
          dictionary.Add("bpIncompatibleTags", (object) buildPoint.bpIncompatibleTags);
          dictionary.Add("otherBuildsSpecialIncompatibleTags", (object) buildPoint.otherBuildsSpecialIncompatibleTags);
          dictionary.Add("isBpVisible", (object) buildPoint.isBpVisible);
          dictionary.Add("requiredLevel", (object) buildPoint.requiredLevel);
          break;
        case Growable growable:
          dictionary.Add("growSprites", (object) growable.growSprites);
          dictionary.Add("growTime", (object) growable.growTime);
          dictionary.Add("growTimePassed", (object) growable.growTimePassed);
          dictionary.Add("mainGrowState", (object) growable.mainGrowState);
          break;
        case Upgradable upgradable:
          dictionary.Add("incompatibleTagsToUpgrade", (object) upgradable.incompatibleTagsToUpgrade);
          dictionary.Add("otherBuildsSpecialIncompatibleTags", (object) upgradable.otherBuildsSpecialIncompatibleTags);
          break;
        case LinkingGrowable linkingGrowable:
          dictionary.Add("growSprites", (object) linkingGrowable.growSprites);
          dictionary.Add("growTime", (object) linkingGrowable.growTime);
          dictionary.Add("growTimePassed", (object) linkingGrowable.growTimePassed);
          dictionary.Add("mainGrowState", (object) linkingGrowable.mainGrowState);
          dictionary.Add("linkedSprite", (object) linkingGrowable.linkedSprite);
          dictionary.Add("linkToPreset", (object) linkingGrowable.linkToPreset);
          dictionary.Add("linkOffset", (object) linkingGrowable.linkOffset);
          break;
      }
      return (IDictionary<string, object>) dictionary;
    }

    public /*override*/ object Deserialize(
      IDictionary<string, object> dict,
      Type type,
      JavaScriptSerializer serializer)
    {
      if (dict == null)
        throw new ArgumentNullException(nameof (dict));
      switch ((string) dict["Type"])
      {
        case "Static":
                    return (object)new Static()
                    {
                        VisibilityIncompatibleTags = (string[]) serializer.ConvertToType(dict["VisibilityIncompatibleTags"], typeof (string[])),
                        VisibilityRequirementTags = (string[])serializer.ConvertToType(dict["VisibilityRequirementTags"], typeof(string[])),
                        Tags = (string[])serializer.ConvertToType(dict["Tags"], typeof(string[])),
                        PresetMarker = (string)dict["PresetMarker"],
                        Visible = (bool)serializer.ConvertToType(dict["Visible"], typeof(bool)),
                        ExplicitEpicenter = (Vector2)serializer.ConvertToType(dict["ExplicitEpicenter"], typeof(Vector2)),
                        ExtraFloorHeight = (int)dict["ExtraFloorHeight"],
                        ExtraReach = (Vector2)serializer.ConvertToType(dict["ExtraReach"], typeof(Vector2)),
                        Hitbox = (List<Rectangle>)serializer.ConvertToType(dict["Hitbox"], typeof(List<Rectangle>)),
                        Interactions = (IDodoInteraction[])serializer.ConvertToType(dict["Interactions"], typeof(IDodoInteraction[])),
                        Location = (Vector2)serializer.ConvertToType(dict["Location"], typeof(Vector2)),
                        ObjectId = (string)dict["ObjectId"],
                        StandardSprite = (Sprite)serializer.ConvertToType(dict["StandardSprite"], typeof(Sprite))
                    };
        case "Hourglass":
          return (object) new Hourglass()
          {
            Tags = (string[]) serializer.ConvertToType(dict["Tags"], typeof (string[])),
            PresetMarker = (string) dict["PresetMarker"],
            Visible = (bool) serializer.ConvertToType(dict["Visible"], typeof (bool)),
            ExplicitEpicenter = (Vector2) serializer.ConvertToType(dict["ExplicitEpicenter"], typeof (Vector2)),
            ExtraFloorHeight = (int) dict["ExtraFloorHeight"],
            ExtraReach = (Vector2) serializer.ConvertToType(dict["ExtraReach"], typeof (Vector2)),
            Hitbox = (List<Rectangle>) serializer.ConvertToType(dict["Hitbox"], typeof (List<Rectangle>)),
            Interactions = (IDodoInteraction[]) serializer.ConvertToType(dict["Interactions"], typeof (IDodoInteraction[])),
            Location = (Vector2) serializer.ConvertToType(dict["Location"], typeof (Vector2)),
            ObjectId = (string) dict["ObjectId"],
            StandardSprite = (Sprite) serializer.ConvertToType(dict["StandardSprite"], typeof (Sprite))
          };
        case "Upgradable":
          Upgradable upgradable = new Upgradable()
          {
            Tags = (string[]) serializer.ConvertToType(dict["Tags"], typeof (string[])),
            PresetMarker = (string) dict["PresetMarker"],
            Visible = (bool) serializer.ConvertToType(dict["Visible"], typeof (bool)),
            ExplicitEpicenter = (Vector2) serializer.ConvertToType(dict["ExplicitEpicenter"], typeof (Vector2)),
            ExtraFloorHeight = (int) dict["ExtraFloorHeight"],
            ExtraReach = (Vector2) serializer.ConvertToType(dict["ExtraReach"], typeof (Vector2)),
            Hitbox = (List<Rectangle>) serializer.ConvertToType(dict["Hitbox"], typeof (List<Rectangle>)),
            Interactions = (IDodoInteraction[]) serializer.ConvertToType(dict["Interactions"], typeof (IDodoInteraction[])),
            Location = (Vector2) serializer.ConvertToType(dict["Location"], typeof (Vector2)),
            ObjectId = (string) dict["ObjectId"],
            StandardSprite = (Sprite) serializer.ConvertToType(dict["StandardSprite"], typeof (Sprite)),
            incompatibleTagsToUpgrade = (string[]) serializer.ConvertToType(dict["incompatibleTagsToUpgrade"], typeof (string[])),
            otherBuildsSpecialIncompatibleTags = (string[]) serializer.ConvertToType(dict["otherBuildsSpecialIncompatibleTags"], typeof (string[]))
          };
          if (upgradable.PresetMarker == "Tableau de bord")
            upgradable.Upgraded += (EventHandler) ((sender, args) =>
            {
              Game1.world.Level = 2;
              GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BoardUpgraded));
            });
          else if (upgradable.PresetMarker == "Board2")
            upgradable.Upgraded += (EventHandler) ((sender, args) =>
            {
              Game1.world.Level = 3;
              GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BoardUpgraded));
            });
          return (object) upgradable;
        case "BuildPoint":
          BuildPoint buildPoint = new BuildPoint()
          {
            Tags = (string[]) serializer.ConvertToType(dict["Tags"], typeof (string[])),
            PresetMarker = (string) dict["PresetMarker"],
            Visible = (bool) serializer.ConvertToType(dict["Visible"], typeof (bool)),
            ExplicitEpicenter = (Vector2) serializer.ConvertToType(dict["ExplicitEpicenter"], typeof (Vector2)),
            ExtraFloorHeight = (int) dict["ExtraFloorHeight"],
            ExtraReach = (Vector2) serializer.ConvertToType(dict["ExtraReach"], typeof (Vector2)),
            Hitbox = (List<Rectangle>) serializer.ConvertToType(dict["Hitbox"], typeof (List<Rectangle>)),
            Interactions = (IDodoInteraction[]) serializer.ConvertToType(dict["Interactions"], typeof (IDodoInteraction[])),
            Location = (Vector2) serializer.ConvertToType(dict["Location"], typeof (Vector2)),
            ObjectId = (string) dict["ObjectId"],
            StandardSprite = (Sprite) serializer.ConvertToType(dict["StandardSprite"], typeof (Sprite)),
            bpIncompatibleTags = (string[]) serializer.ConvertToType(dict["bpIncompatibleTags"], typeof (string[])),
            isBpVisible = (bool) serializer.ConvertToType(dict["isBpVisible"], typeof (bool)),
            requiredLevel = (int) dict["requiredLevel"],
            otherBuildsSpecialIncompatibleTags = (string[]) serializer.ConvertToType(dict["otherBuildsSpecialIncompatibleTags"], typeof (string[]))
          };
          if (buildPoint.ObjectId == "bp1")
            buildPoint.Built += (EventHandler) ((sender, args) =>
            {
              GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.BoardBuilt));
              Game1.world.Level = 1;
            });
          return (object) buildPoint;
        case "Growable":
          Growable growable = new Growable()
          {
            Tags = (string[]) serializer.ConvertToType(dict["Tags"], typeof (string[])),
            PresetMarker = (string) dict["PresetMarker"],
            Visible = (bool) serializer.ConvertToType(dict["Visible"], typeof (bool)),
            ExplicitEpicenter = (Vector2) serializer.ConvertToType(dict["ExplicitEpicenter"], typeof (Vector2)),
            ExtraFloorHeight = (int) dict["ExtraFloorHeight"],
            ExtraReach = (Vector2) serializer.ConvertToType(dict["ExtraReach"], typeof (Vector2)),
            Hitbox = (List<Rectangle>) serializer.ConvertToType(dict["Hitbox"], typeof (List<Rectangle>)),
            Interactions = (IDodoInteraction[]) serializer.ConvertToType(dict["Interactions"], typeof (IDodoInteraction[])),
            Location = (Vector2) serializer.ConvertToType(dict["Location"], typeof (Vector2)),
            ObjectId = (string) dict["ObjectId"],
            StandardSprite = (Sprite) serializer.ConvertToType(dict["StandardSprite"], typeof (Sprite)),
            growSprites = (List<Sprite>) serializer.ConvertToType(dict["growSprites"], typeof (List<Sprite>)),
            growTime = Convert.ToInt32(dict["growTime"]),
            growTimePassed = Convert.ToInt32(dict["growTimePassed"]),
            mainGrowState = Convert.ToInt32(dict["mainGrowState"])
          };
          if (growable.ObjectId == "fleur geante 13-0")
            growable.Harvested += (EventHandler) ((sender, args) => GlobalEventManager.RegisterEvent(new GlobalEvent(GlobalEvent.Event.VineFlowerHarvested)));
          return (object) growable;
        case "LGrowable":
          return (object) new LinkingGrowable()
          {
            Tags = (string[]) serializer.ConvertToType(dict["Tags"], typeof (string[])),
            linkToPreset = (string) dict["linkToPreset"],
            linkOffset = (Vector2) serializer.ConvertToType(dict["linkOffset"], typeof (Vector2)),
            linkedSprite = (Sprite) serializer.ConvertToType(dict["linkedSprite"], typeof (Sprite)),
            PresetMarker = (string) dict["PresetMarker"],
            Visible = (bool) serializer.ConvertToType(dict["Visible"], typeof (bool)),
            ExplicitEpicenter = (Vector2) serializer.ConvertToType(dict["ExplicitEpicenter"], typeof (Vector2)),
            ExtraFloorHeight = (int) dict["ExtraFloorHeight"],
            ExtraReach = (Vector2) serializer.ConvertToType(dict["ExtraReach"], typeof (Vector2)),
            Hitbox = (List<Rectangle>) serializer.ConvertToType(dict["Hitbox"], typeof (List<Rectangle>)),
            Interactions = (IDodoInteraction[]) serializer.ConvertToType(dict["Interactions"], typeof (IDodoInteraction[])),
            Location = (Vector2) serializer.ConvertToType(dict["Location"], typeof (Vector2)),
            ObjectId = (string) dict["ObjectId"],
            StandardSprite = (Sprite) serializer.ConvertToType(dict["StandardSprite"], typeof (Sprite)),
            growSprites = (List<Sprite>) serializer.ConvertToType(dict["growSprites"], typeof (List<Sprite>)),
            growTime = Convert.ToInt32(dict["growTime"]),
            growTimePassed = Convert.ToInt32(dict["growTimePassed"]),
            mainGrowState = Convert.ToInt32(dict["mainGrowState"])
          };
        default:
          throw new Exception("Invalid IWO type in IWorldObjectConverter.Deserialize");
      }
    }
  }
}
