
// Type: DodoTheGame.Saving.Texture2DConverter

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Localization;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class Texture2DConverter : JavaScriptConverter
  {
    public static List<Texture2D> commonTextures;

    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
        return (IEnumerable<Type>) new ReadOnlyCollection<Type>((IList<Type>) new List<Type>((IEnumerable<Type>) new Type[1]
        {
          typeof (Texture2D)
        }));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      return (IDictionary<string, object>) new Dictionary<string, object>()
      {
        {
          "Name",
          (object) ((GraphicsResource) obj).Name
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
      if (dictionary["Name"] == null)
        throw new ArgumentNullException(nameof (dictionary));
      List<Texture2D> list = Texture2DConverter.commonTextures.Where<Texture2D>((Func<Texture2D, bool>) (p => p.Name == (string) dictionary["Name"])).ToList<Texture2D>();
      if (list.Count < 1)
        throw new Exception("Missing texture in Texture2DConverter.commonTextures: " + (string) dictionary["Name"]);
      if (list.Count > 1)
        throw new Exception("Multiple textures have the same name in Texture2DConverter.commonTextures");
      return list[0] != null ? (object) list[0] : throw new Exception("Null texture Texture2DConverter.commonTextures");
    }
  }
}
