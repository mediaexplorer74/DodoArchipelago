// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.Vector2Converter
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Localization;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class Vector2Converter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
        return (IEnumerable<Type>) new ReadOnlyCollection<Type>((IList<Type>) 
            new List<Type>((IEnumerable<Type>) new Type[1]
        {
          typeof (Vector2)
        }));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      Vector2 vector2 = (Vector2) obj;
      return (IDictionary<string, object>) new Dictionary<string, object>()
      {
        {
          "X",
          (object) vector2.X
        },
        {
          "Y",
          (object) vector2.Y
        }
      };
    }

    public /*override*/ object Deserialize(
      IDictionary<string, object> dictionary,
      Type type,
      JavaScriptSerializer serializer)
    {
      if (dictionary == null)
        throw new ArgumentNullException(nameof (dictionary));
      return dictionary["X"] != null && dictionary["Y"] != null 
                ? (object) new Vector2(Convert.ToSingle(dictionary["X"]), 
                Convert.ToSingle(dictionary["Y"])) 
                : throw new ArgumentNullException("dictionary[\"X/Y\"]");
    }
  }
}
