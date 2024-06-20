// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Localization.LocalizationManager
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

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
        LocalizationManager.Languages.Add(
            LocalizationManager.serializer.Deserialize<Language>(
                File.ReadAllText("Content\\localization\\" + fileInfo.Name)));
    }

    public static void SetLanguage(Language lg) => LocalizationManager.CurrentLanguage = lg;

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
        return LocalizationManager.CurrentLanguage.AssetTable[id];
      if (!required)
        return (string) null;
      throw new Exception("Could not find localization for asset id: " + id);
    }
  }
}
