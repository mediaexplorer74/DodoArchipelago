// Type: DodoTheGame.Saving.INPCConverter

using DodoTheGame.Localization;
using DodoTheGame.NPC;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Saving
{
  internal class INPCConverter : JavaScriptConverter
  {
    public /*override*/ IEnumerable<Type> SupportedTypes
    {
      get
      {
         return default; //((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>) (s => (IEnumerable<Type>) s.GetTypes())).Where<Type>((Func<Type, bool>) (p => typeof (INPC).IsAssignableFrom(p)));
      }
    }

    public /*override*/ IDictionary<string, object> Serialize(
      object obj,
      JavaScriptSerializer serializer)
    {
      Dictionary<string, object> dictionary = new Dictionary<string, object>();
      switch (obj)
      {
        case BlueDodo blueDodo:
          dictionary.Add("Type", (object) "BlueDodo");
          dictionary.Add("FacingLeft", (object) blueDodo.facingLeft);
          dictionary.Add("Location", (object) blueDodo.Location);
          dictionary.Add("IdleSprite", (object) blueDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) blueDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) blueDodo.SleepSprite);
          break;
        case GreenDodo greenDodo:
          dictionary.Add("Type", (object) "GreenDodo");
          dictionary.Add("FacingLeft", (object) greenDodo.facingLeft);
          dictionary.Add("Location", (object) greenDodo.Location);
          dictionary.Add("IdleSprite", (object) greenDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) greenDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) greenDodo.SleepSprite);
          break;
        case OrangeDodo orangeDodo:
          dictionary.Add("Type", (object) "OrangeDodo");
          dictionary.Add("FacingLeft", (object) orangeDodo.facingLeft);
          dictionary.Add("Location", (object) orangeDodo.Location);
          dictionary.Add("IdleSprite", (object) orangeDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) orangeDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) orangeDodo.SleepSprite);
          break;
        case PinkDodo pinkDodo:
          dictionary.Add("Type", (object) "PinkDodo");
          dictionary.Add("FacingLeft", (object) pinkDodo.facingLeft);
          dictionary.Add("Location", (object) pinkDodo.Location);
          dictionary.Add("IdleSprite", (object) pinkDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) pinkDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) pinkDodo.SleepSprite);
          break;
        case RedDodo redDodo:
          dictionary.Add("Type", (object) "RedDodo");
          dictionary.Add("FacingLeft", (object) redDodo.facingLeft);
          dictionary.Add("Location", (object) redDodo.Location);
          dictionary.Add("IdleSprite", (object) redDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) redDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) redDodo.SleepSprite);
          break;
        case ShroomDodo shroomDodo:
          dictionary.Add("Type", (object) "ShroomDodo");
          dictionary.Add("FacingLeft", (object) shroomDodo.facingLeft);
          dictionary.Add("Location", (object) shroomDodo.Location);
          dictionary.Add("IdleSprite", (object) shroomDodo.IdleSprite);
          dictionary.Add("RunSprite", (object) shroomDodo.RunSprite);
          dictionary.Add("SleepSprite", (object) shroomDodo.SleepSprite);
          break;
        default:
          throw new Exception("NPC type in not handled in INPCConverter");
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
      if ((string) dictionary["Type"] == "BlueDodo")
        return (object) new BlueDodo()
        {
          IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
          RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
          SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
          Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
          facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
        };
      if ((string) dictionary["Type"] == "GreenDodo")
        return (object) new GreenDodo()
        {
          IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
          RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
          SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
          Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
          facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
        };
      if ((string) dictionary["Type"] == "OrangeDodo")
        return (object) new OrangeDodo()
        {
          IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
          RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
          SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
          Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
          facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
        };
      if ((string) dictionary["Type"] == "PinkDodo")
        return (object) new PinkDodo()
        {
          IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
          RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
          SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
          Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
          facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
        };
      if ((string) dictionary["Type"] == "RedDodo")
        return (object) new RedDodo()
        {
          IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
          RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
          SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
          Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
          facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
        };
      return (string) dictionary["Type"] == "ShroomDodo" ? (object) new ShroomDodo()
      {
        IdleSprite = (Sprite) serializer.ConvertToType(dictionary["IdleSprite"], typeof (Sprite)),
        RunSprite = (Sprite) serializer.ConvertToType(dictionary["RunSprite"], typeof (Sprite)),
        SleepSprite = (Sprite) serializer.ConvertToType(dictionary["SleepSprite"], typeof (Sprite)),
        Location = (Vector2) serializer.ConvertToType(dictionary["Location"], typeof (Vector2)),
        facingLeft = (bool) serializer.ConvertToType(dictionary["FacingLeft"], typeof (bool))
      } : throw new Exception("NPC type in not handled in INPCConverter");
    }
  }
}
