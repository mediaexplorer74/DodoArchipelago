
// Type: DodoTheGame.Saving.GameSettings

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
