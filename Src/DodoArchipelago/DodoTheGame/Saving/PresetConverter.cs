// Type: DodoTheGame.Saving.PresetConverter

using DodoTheGame.Interactions;
using DodoTheGame.Localization;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class PresetConverter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
        return (IEnumerable<Type>) new ReadOnlyCollection<Type>(
            (IList<Type>) new List<Type>((IEnumerable<Type>) new Type[1]
        {
          typeof (Preset)
        }));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      Preset preset = (Preset) obj;
      return (IDictionary<string, object>) new Dictionary<string, object>()
      {
        {
          "Name",
          (object) preset.name
        },
        {
          "DisplayName",
          (object) preset.displayName
        },
        {
          "Sprite",
          (object) preset.sprite
        },
        {
          "growSprites",
          (object) preset.growSprites
        },
        {
          "hitbox",
          (object) preset.hitbox
        },
        {
          "epicenterOffset",
          (object) preset.epicenterOffset
        },
        {
          "type",
          (object) preset.type
        },
        {
          "interactions",
          (object) preset.interactions
        },
        {
          "extraReach",
          (object) preset.extraReach
        },
        {
          "growtime",
          (object) preset.growtime
        },
        {
          "growstate",
          (object) preset.growstate
        },
        {
          "buildOrUpgradeItems",
          (object) preset.buildOrUpgradeItems
        },
        {
          "tags",
          (object) preset.tags
        },
        {
          "incompatibleTags",
          (object) preset.incompatibleTags
        },
        {
          "otherBuildsSpecialIncompatibleTags",
          (object) preset.otherBuildsSpecialIncompatibleTags
        }
      };
    }

    public /*override*/ object Deserialize(
      IDictionary<string, object> dictionary,
      Type type,
      JavaScriptSerializer serializer)
    {
      Preset preset = new Preset();
      preset.name = (string) dictionary["Name"];

      preset.displayName = (string) dictionary["DisplayName"];

      preset.sprite = (Sprite) serializer.ConvertToType(
        dictionary["Sprite"], typeof (Sprite));
      preset.growSprites = (List<Sprite>) serializer.ConvertToType(
        dictionary["growSprites"], typeof (List<Sprite>));
      preset.hitbox = (List<Rectangle>) serializer.ConvertToType(
        dictionary["hitbox"], typeof (List<Rectangle>));
      preset.epicenterOffset = (Vector2) serializer.ConvertToType(
        dictionary["epicenterOffset"], typeof (Vector2));
      preset.type = (Preset.WOType) dictionary[nameof (type)];
      preset.interactions = (IDodoInteraction[]) serializer.ConvertToType(
            dictionary["interactions"], typeof (IDodoInteraction[]));
      preset.tags = (string[]) serializer.ConvertToType(
            dictionary["tags"], typeof (string[]));
      preset.incompatibleTags = (string[]) serializer.ConvertToType(
            dictionary["incompatibleTags"], typeof (string[]));
      preset.otherBuildsSpecialIncompatibleTags = (string[]) serializer.ConvertToType(
            dictionary["otherBuildsSpecialIncompatibleTags"], typeof (string[]));
        if (dictionary["extraReach"] != null)
            preset.extraReach = (Vector2?) serializer.ConvertToType(
                dictionary["extraReach"], typeof (Vector2));
      preset.growtime = (int) dictionary["growtime"];
      preset.growstate = (int) dictionary["growstate"];
            preset.buildOrUpgradeItems = (List<ItemStack>) serializer.ConvertToType(
                dictionary["buildOrUpgradeItems"], typeof (List<ItemStack>));
      return (object) preset;
    }
  }
}
