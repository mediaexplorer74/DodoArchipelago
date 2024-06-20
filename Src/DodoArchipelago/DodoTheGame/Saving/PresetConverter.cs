// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.PresetConverter
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

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
        return (IEnumerable<Type>) new ReadOnlyCollection<Type>((IList<Type>) new List<Type>((IEnumerable<Type>) new Type[1]
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
            preset.sprite = default;//(Sprite) serializer.ConvertToType(dictionary["Sprite"], typeof (Sprite));
            preset.growSprites = default;//(List<Sprite>) serializer.ConvertToType(dictionary["growSprites"], typeof (List<Sprite>));
            preset.hitbox = default;//(List<Rectangle>) serializer.ConvertToType(dictionary["hitbox"], typeof (List<Rectangle>));
            preset.epicenterOffset = default;//(Vector2) serializer.ConvertToType(dictionary["epicenterOffset"], typeof (Vector2));
      preset.type = (Preset.WOType) dictionary[nameof (type)];
            preset.interactions = default;//(IDodoInteraction[]) serializer.ConvertToType(dictionary["interactions"], typeof (IDodoInteraction[]));
            preset.tags = default;//(string[]) serializer.ConvertToType(dictionary["tags"], typeof (string[]));
            preset.incompatibleTags = default;//(string[]) serializer.ConvertToType(dictionary["incompatibleTags"], typeof (string[]));
            preset.otherBuildsSpecialIncompatibleTags = default;//(string[]) serializer.ConvertToType(dictionary["otherBuildsSpecialIncompatibleTags"], typeof (string[]));
            if (dictionary["extraReach"] != null)
                preset.extraReach = default;//(Vector2?) serializer.ConvertToType(dictionary["extraReach"], typeof (Vector2));
      preset.growtime = (int) dictionary["growtime"];
      preset.growstate = (int) dictionary["growstate"];
            preset.buildOrUpgradeItems = default;//(List<ItemStack>) serializer.ConvertToType(dictionary["buildOrUpgradeItems"], typeof (List<ItemStack>));
      return (object) preset;
    }
  }
}
