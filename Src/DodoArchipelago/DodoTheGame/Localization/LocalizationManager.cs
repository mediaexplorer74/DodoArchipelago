
// Type: DodoTheGame.Localization.LocalizationManager

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
//using System.Web.Script.Serialization;


namespace DodoTheGame.Localization
{
  internal static class LocalizationManager
  {
    private static readonly JavaScriptSerializer serializer = new JavaScriptSerializer();

    public static Language CurrentLanguage { get; private set; }

    public static List<Language> Languages { get; set; }

    public static void Init()
    {
      FileInfo[] fileInfoArray = ContentLoadingWrapper.ListAssets("localization");
      
      LocalizationManager.Languages = new List<Language>();

      foreach (FileInfo fileInfo in fileInfoArray)
      {
        string json_data =  File.ReadAllText("Content\\localization\\" + fileInfo.Name);

        Language lg = 
            LocalizationManager.serializer.Deserialize<Language>(json_data);

        LocalizationManager.Languages.Add(lg);
      }
    }

    public static void SetLanguage(Language lg)
    {
        LocalizationManager.CurrentLanguage = lg;
    }

    public static string GetString(string id, bool required = true)
    {
      if (LocalizationManager.CurrentLanguage.TextTable.ContainsKey(id))
        return LocalizationManager.CurrentLanguage.TextTable[id];
      if (!required)
        return (string) null;
      throw new Exception("Could not find localization for text id: " + id);
    }

    public static string GetPresetDisplayName(string id, bool required = true)
    {
      if (LocalizationManager.CurrentLanguage == null)
        return (string) null;
      if (LocalizationManager.CurrentLanguage.PresetNameTable.ContainsKey(id))
        return LocalizationManager.CurrentLanguage.PresetNameTable[id];
      return !required ? (string) null : id;
    }

    public static string GetAssetName(string id, bool required = true)
    {
      
      if (LocalizationManager.CurrentLanguage == null)
        return (string) null;

        if (LocalizationManager.CurrentLanguage.AssetTable.ContainsKey(id))
        {
            return LocalizationManager.CurrentLanguage.AssetTable[id];
        }

      if (!required)
        return (string) null;

      //throw new Exception("Could not find localization for asset id: " + id);
      System.Diagnostics.Debug.WriteLine("[warn] Could not find localization for asset id: " + id);

      // Plan B: return input value "as is" (output value)
      return id;
    }
  }
}
