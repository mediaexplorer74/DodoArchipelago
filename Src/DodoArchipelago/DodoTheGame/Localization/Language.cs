// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Localization.Language
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Collections.Generic;


namespace DodoTheGame.Localization
{
  internal class Language
  {
    public Dictionary<string, string> TextTable;
    public Dictionary<string, string> AssetTable;
    public Dictionary<string, string> PresetNameTable;

    public string LanguageCode { get; set; }

    public string DisplayName { get; set; }

    public string EnglishDisplayName { get; set; }
  }
}
