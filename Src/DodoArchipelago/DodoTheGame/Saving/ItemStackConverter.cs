// Type: DodoTheGame.Saving.ItemStackConverter


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
