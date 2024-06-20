// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.IDodoInteractionConverter
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Interactions;
using DodoTheGame.Localization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class IDodoInteractionConverter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
         return default;//((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (s => (IEnumerable<Type>) s.GetTypes())).Where<Type>((Func<Type, bool>) (p => typeof (IDodoInteraction).IsAssignableFrom(p)));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      IDodoInteraction dodoInteraction = (IDodoInteraction) obj;
      dictionary.Add("ShowName", (object) dodoInteraction.ShowName);
      if (dodoInteraction.GetType() == typeof (Build))
      {
        Build build = (Build) dodoInteraction;
        dictionary.Add("Type", (object) "Build");
        dictionary.Add("intake", (object) build.intake);
        dictionary.Add("buildPreset", (object) build.buildPreset);
      }
      else if (dodoInteraction.GetType() == typeof (Inspect))
        dictionary.Add("Type", (object) "Inspect");
      else if (dodoInteraction.GetType() == typeof (Upgrade))
      {
        Upgrade upgrade = (Upgrade) dodoInteraction;
        dictionary.Add("Type", (object) "Upgrade");
        dictionary.Add("upgradePreset", (object) upgrade.upgradePreset);
        dictionary.Add("upgradeItems", (object) upgrade.upgradeItems);
        dictionary.Add("requiredLevelToUpgrade", (object) upgrade.requiredLevelToUpgrade);
      }
      else if (dodoInteraction.GetType() == typeof (Harvest))
      {
        Harvest harvest = (Harvest) dodoInteraction;
        dictionary.Add("Type", (object) "Harvest");
        dictionary.Add("HarvestItem", (object) harvest.harvestItems);
      }
      else if (dodoInteraction.GetType() == typeof (UnlockPlayerUnlockable))
      {
        UnlockPlayerUnlockable playerUnlockable = (UnlockPlayerUnlockable) dodoInteraction;
        dictionary.Add("Type", (object) "PlayerUnlock");
        dictionary.Add("Unlock", (object) (int) playerUnlockable.unlockable);
        dictionary.Add("upgradeItems", (object) playerUnlockable.upgradeItems);
      }
      else
      {
        TakeNotes takeNotes = dodoInteraction.GetType() == typeof (TakeNotes) ? (TakeNotes) dodoInteraction : throw new Exception("Unknown Interaction type in IDodoInteractionConverter");
        dictionary.Add("Type", (object) "TakeNotes");
        dictionary.Add("HarvestItem", (object) takeNotes.harvestItems);
      }
      return (IDictionary<string, object>) dictionary;
    }

    public /*override*/ object Deserialize(
      IDictionary<string, object> dictionary,
      Type type,
      JavaScriptSerializer serializer)
    {
      if (dictionary == null)
        throw new ArgumentNullException(nameof (dictionary));
      if ((string) dictionary["Type"] == "Build")
      {
        Build build = new Build();
        List<ItemStack> itemStackList = new List<ItemStack>();
        foreach (Dictionary<string, object> dictionary1 in (ArrayList) dictionary["intake"])
        {
          ItemStack itemStack = new ItemStack()
          {
            itemId = (int) dictionary1["ItemId"],
            count = (int) dictionary1["Count"]
          };
          itemStackList.Add(itemStack);
        }
        build.intake = itemStackList;
        build.buildPreset = (Preset) serializer.ConvertToType(dictionary["buildPreset"], typeof (Preset));
        return (object) build;
      }
      if ((string) dictionary["Type"] == "Upgrade")
        return (object) new Upgrade()
        {
          requiredLevelToUpgrade = Convert.ToInt32(dictionary["requiredLevelToUpgrade"]),
          upgradeItems = default,//(List<ItemStack>) serializer.ConvertToType(dictionary["upgradeItems"], typeof (List<ItemStack>)),
          upgradePreset = (Preset) serializer.ConvertToType(dictionary["upgradePreset"], typeof (Preset))
        };
      if ((string) dictionary["Type"] == "Inspect")
        return (object) new Inspect();
      if ((string) dictionary["Type"] == "Harvest")
        return (object) new Harvest()
        {
          harvestItems = default,//(ItemStack[]) serializer.ConvertToType(dictionary["HarvestItem"], typeof (ItemStack[]))
        };
      if ((string) dictionary["Type"] == "TakeNotes")
        return (object) new TakeNotes()
        {
          harvestItems = default,//(ItemStack[]) serializer.ConvertToType(dictionary["HarvestItem"], typeof (ItemStack[]))
        };
      return (string) dictionary["Type"] == "PlayerUnlock" ? (object) new UnlockPlayerUnlockable()
      {
        unlockable = (PlayerUnlockables.PlayerUnlockable) dictionary["Unlock"],
        upgradeItems = default,//(List<ItemStack>) serializer.ConvertToType(dictionary["upgradeItems"], typeof (List<ItemStack>))
      } : throw new Exception("Unknown interaction type");
    }
  }
}
