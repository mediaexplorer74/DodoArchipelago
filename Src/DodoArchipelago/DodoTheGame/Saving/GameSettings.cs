// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Saving.GameSettings
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;


namespace DodoTheGame.Saving
{
  internal class GameSettings
  {
    public bool fullscreenSelected;
    public Vector2 resolution;
    public float bgmVolume;
    public float sfxVolume;
    public string languageCode;

    public GameSettings()
    {
    }

    public static GameSettings Default
    {
      get => new GameSettings(false, new Vector2(1280f, 720f), 0.3f, 1f, "fr_FR");
    }

    public GameSettings(
      bool fullscreenSelected,
      Vector2 resolution,
      float bgmVolume,
      float sfxVolume,
      string languageCode)
    {
      this.fullscreenSelected = fullscreenSelected;
      this.resolution = resolution;
      this.bgmVolume = bgmVolume;
      this.sfxVolume = sfxVolume;
      this.languageCode = languageCode;
    }
  }
}
