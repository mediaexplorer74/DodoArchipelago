// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.ItemStackConverter
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Localization;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class ItemStackConverter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
        return (IEnumerable<Type>) 
                    new ReadOnlyCollection<Type>(
                        (IList<Type>) new List<Type>((IEnumerable<Type>) new Type[1]
        {
          typeof (ItemStack)
        }));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      ItemStack itemStack = (ItemStack) obj;
      return (IDictionary<string, object>) new Dictionary<string, object>()
      {
        {
          "ItemId",
          (object) itemStack.itemId
        },
        {
          "Count",
          (object) itemStack.count
        }
      };
    }

    public /*override*/ object Deserialize(
      IDictionary<string, object> dictionary,
      Type type,
      JavaScriptSerializer serializer)
    {
      return (object) new ItemStack()
      {
        itemId = (int) dictionary["ItemId"],
        count = (int) dictionary["Count"]
      };
    }
  }
}
