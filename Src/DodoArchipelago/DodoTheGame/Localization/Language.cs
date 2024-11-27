
// Type: DodoTheGame.Localization.Language

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
