// Type: DodoTheGame.GUI.SettingsGUI

using DodoTheGame.Localization;
using DodoTheGame.Saving;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace DodoTheGame.GUI
{
  internal class SettingsGUI : IGUI
  {
    private string gameLanguage;
    public Texture2D mainbackground;
    public Texture2D settingsbackground;
    public Texture2D cursor;
    public Texture2D cursor_selected;
    public Texture2D retour;
    public Texture2D retour_selected;
    public Texture2D arrow;
    public Texture2D bande1;
    public Texture2D bande2;
    public Texture2D bande3;
    public Texture2D more;
    public Texture2D more_mirror;
    public Texture2D more_s;
    public Texture2D more_mirror_s;
    public Texture2D francais;
    public Texture2D francais_s;
    public Texture2D english;
    public Texture2D english_s;
    public Texture2D fullscreen;
    public Texture2D windowed;
    public Texture2D fullscreen_s;
    public Texture2D windowed_s;
    private List<Vector2> Resolutions = new List<Vector2>()
    {
      new Vector2(1920f, 1080f),
      new Vector2(1600f, 900f),
      new Vector2(1440f, 900f),
      new Vector2(1280f, 720f)
    };
    public int CurrentResolutionID;
    public int SelectedResolutionID;
    public float MusicVolume = 1f;
    public float EffectsVolume = 1f;
    private int selectedButton = 1;
    private int ResolutionsArrowsTimer;
    private int RetourButtonTimer;
    private float timer;
    private bool fullscreenSelected;

    public event EventHandler Opened;

    public event EventHandler Closed;

    public event EventHandler MovedItemSelection;

    public int Layer => 100;

    public bool LockGameInput => true;

    public bool IsObstructing => true;

    public bool ReadyToRemove { get; private set; }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.RetourButtonTimer += gameTime.ElapsedGameTime.Milliseconds;
      this.ResolutionsArrowsTimer += gameTime.ElapsedGameTime.Milliseconds / 2;
      Recorder.RDraw(spriteBatch, this.mainbackground, new Vector2(0.0f, 0.0f), Color.White);
      Texture2D texture1;
      Texture2D texture2;
      Texture2D texture3;
      switch (this.selectedButton)
      {
        case 1:
          texture1 = this.retour_selected;
          texture2 = this.cursor;
          texture3 = this.cursor;
          break;
        case 2:
          texture1 = this.retour;
          texture2 = this.cursor;
          texture3 = this.cursor;
          break;
        case 3:
          texture1 = this.retour;
          texture2 = this.cursor;
          texture3 = this.cursor;
          break;
        case 4:
          texture1 = this.retour;
          texture2 = this.cursor;
          texture3 = this.cursor;
          break;
        case 5:
          texture1 = this.retour;
          texture2 = this.cursor_selected;
          texture3 = this.cursor;
          break;
        case 6:
          texture1 = this.retour;
          texture2 = this.cursor;
          texture3 = this.cursor_selected;
          break;
        default:
          texture1 = this.retour;
          texture2 = this.cursor;
          texture3 = this.cursor;
          break;
      }
      double num = 231.0 * (double) Game1.renderSize.Y / 720.0;
      Recorder.RDraw(spriteBatch, this.bande1, new Vector2((float) (
          (double) GUIManager.GUITimer / 5.0 % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), 
          Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float) (
          ((double) GUIManager.GUITimer / 5.0 + 450.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 
          0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande3, new Vector2((float) (
          ((double) GUIManager.GUITimer / 5.0 + 900.0) % ((double) Game1.renderSize.X + 500.0) - 300.0),
          0.0f), Color.White * 1f);

      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float) (
          ((double) GUIManager.GUITimer / 5.0 + 1350.0) % ((double) Game1.renderSize.X + 500.0) - 300.0),
          0.0f), Color.White * 1f);

      for (int index = -2; index < 3; ++index)
      {
        if (0 <= index + this.SelectedResolutionID 
                    & index + this.SelectedResolutionID < this.Resolutions.Count)
        {
          if (index == 0)
            Recorder.RDrawString(spriteBatch, Game1.rouliXLSpriteFont, 
                Convert.ToString(this.Resolutions[index + this.SelectedResolutionID].X)
                + "x" + this.Resolutions[index + this.SelectedResolutionID].Y.ToString(),
                new Vector2((float) (index * 110 + 830), 506f), Color.Black);
          else if (index < 0 && !this.fullscreenSelected)
            Recorder.RDrawString(spriteBatch, Game1.rouliLSpriteFont, 
                Convert.ToString(this.Resolutions[index + this.SelectedResolutionID].X) 
                + "x" + this.Resolutions[index + this.SelectedResolutionID].Y.ToString(),
                new Vector2((float) (index * 110 + 830), 516f), new Color(40, 40, 40));
          else if (!this.fullscreenSelected)
            Recorder.RDrawString(spriteBatch, Game1.rouliLSpriteFont, 
                Convert.ToString(this.Resolutions[index + this.SelectedResolutionID].X) 
                + "x" + this.Resolutions[index + this.SelectedResolutionID].Y.ToString(), 
                new Vector2((float) (index * 110 + 870), 516f), new Color(40, 40, 40));
        }
      }
      if (!this.fullscreenSelected)
      {
        if (this.selectedButton == 2)
        {
          if (this.SelectedResolutionID > 0)
            Recorder.RDraw(spriteBatch, this.more_s, new Vector2(
                (float) (570.0 - 10.0 * (double) Convert.ToSingle(
                    Math.Cos(Math.PI * Math.Cos(Math.PI * Math.Cos(
                        (double) Convert.ToSingle((float) this.ResolutionsArrowsTimer / 220f)))))), 
                486f), Color.White * 1f);

          if (this.SelectedResolutionID < this.Resolutions.Count - 1)
            Recorder.RDraw(spriteBatch, this.more_mirror_s, new Vector2(
                (float) (1190.0 + 10.0 * (double) Convert.ToSingle(
                    Math.Cos(Math.PI * Math.Cos(Math.PI * Math.Cos(
                        (double) Convert.ToSingle((float) this.ResolutionsArrowsTimer / 220f)))))),
                486f), Color.White * 1f);
        }
        else
        {
          if (this.SelectedResolutionID > 0)
            Recorder.RDraw(spriteBatch, this.more, new Vector2(580f, 486f), Color.White * 1f);
          if (this.SelectedResolutionID < this.Resolutions.Count - 1)
            Recorder.RDraw(spriteBatch, this.more_mirror, new Vector2(1180f, 486f), Color.White * 1f);
        }
      }
      Recorder.RDraw(spriteBatch, this.settingsbackground, new Vector2(0.0f, 0.0f), Color.White * 1f);
      if (texture1 == this.retour_selected)
        Recorder.RDraw(spriteBatch, texture1, new Vector2(100f, Game1.renderSize.Y - 65f),
            Color.White * 1f, 1.06f);
      else
        Recorder.RDraw(spriteBatch, texture1, new Vector2(100f, Game1.renderSize.Y - 65f), 
            Color.White * 1f, 1f);
      if (texture3 == this.cursor_selected)
        Recorder.RDraw(spriteBatch, texture3, new Vector2((float) (615.0 +
            (double) Sound.sfxVolume * 450.0), 138f), Color.White * 1f, 1.2f);
      else
        Recorder.RDraw(spriteBatch, texture3, new Vector2((float) (615.0 +
            (double) Sound.sfxVolume * 450.0), 138f), Color.White * 1f, 1f);
      if (texture2 == this.cursor_selected)
        Recorder.RDraw(spriteBatch, texture2, new Vector2((float) (615.0 + 
            (double) Sound.bgmVolume * 450.0), 230f), Color.White * 1f, 1.2f);
      else
        Recorder.RDraw(spriteBatch, texture2, new Vector2((float) (615.0 + 
            (double) Sound.bgmVolume * 450.0), 230f), Color.White * 1f, 1f);
      if (this.selectedButton == 3)
      {
        if (this.fullscreenSelected)
          Recorder.RDraw(spriteBatch, this.fullscreen_s, new Vector2(703f, 422f), 
              Color.White * 1f, 1.05f);
        else
          Recorder.RDraw(spriteBatch, this.windowed_s, new Vector2(872f, 422f),
              Color.White * 1f, 1.1f);
      }
      else if (this.fullscreenSelected)
        Recorder.RDraw(spriteBatch, this.fullscreen, new Vector2(703f, 422f),
            Color.White * 1f, 1f);
      else
        Recorder.RDraw(spriteBatch, this.windowed, new Vector2(872f, 422f), Color.White * 1f, 1f);
      if (this.selectedButton == 4)
      {
        if (this.gameLanguage == "fr_FR")
          Recorder.RDraw(spriteBatch, this.francais_s, new Vector2(675f, 323f), 
              Color.White * 1f, 1.05f);
        else
          Recorder.RDraw(spriteBatch, this.english_s, new Vector2(842f, 324f), 
              Color.White * 1f, 1.1f);
      }
      else if (this.gameLanguage == "fr_FR")
        Recorder.RDraw(spriteBatch, this.francais, new Vector2(675f, 323f),
            Color.White * 1f, 1f);
      else
        Recorder.RDraw(spriteBatch, this.english, new Vector2(842f, 324f), 
            Color.White * 1f, 1f);
    }

    public void Input(
      bool left,
      bool right,
      bool up,
      bool down,
      bool action1,
      bool hold,
      UserInputStatus.InputState alt,
      Game1 game)
    {
      if (action1 && this.selectedButton == 1)
      {
        if (this.fullscreenSelected)
        {
          Game1.SetFullscreen(true);
        }
        else
        {
          Game1.SetFullscreen(false);
          Game1.ResizeWindow(this.Resolutions[this.SelectedResolutionID]);
        }
        if (GUIManager.SettingsOpenFromEscape)
        {
          GUIManager.ClearThenSet((IGUI) GUIManager.escapeGUI);
          Debug.WriteLine("[i] Escape menu open from Settings menu.");
        }
        else
          GUIManager.ClearThenSet((IGUI) GUIManager.mainmenu);
      }
      if (down && this.selectedButton >= 2)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.RetourButtonTimer = 0;
        --this.selectedButton;
        this.ResolutionsArrowsTimer = 0;
        if (this.selectedButton == 2 && this.fullscreenSelected)
          --this.selectedButton;
      }
      if (left && this.selectedButton == 5 && (double) Sound.bgmVolume > 0.0)
      {
        Sound.bgmVolume -= 0.06666667f;
        if ((double) Sound.bgmVolume < 0.0099999997764825821)
          Sound.bgmVolume = 0.0f;
      }
      if (right && this.selectedButton == 5 && (double) Sound.bgmVolume < 1.0)
      {
        Sound.bgmVolume += 0.06666667f;
        if ((double) Sound.bgmVolume > 0.99000000953674316)
          Sound.bgmVolume = 1f;
      }
      if (left && this.selectedButton == 6 && (double) Sound.sfxVolume > 0.0)
      {
        Sound.sfxVolume -= 0.06666667f;
        if ((double) Sound.sfxVolume < 0.0099999997764825821)
          Sound.sfxVolume = 0.0f;
      }
      if (right && this.selectedButton == 6 && (double) Sound.sfxVolume < 1.0)
      {
        Sound.sfxVolume += 0.06666667f;
        if ((double) Sound.sfxVolume > 0.99000000953674316)
          Sound.sfxVolume = 1f;
      }
      if (left && this.selectedButton == 2 && this.SelectedResolutionID > 0)
        --this.SelectedResolutionID;
      if (right && this.selectedButton == 2 && this.SelectedResolutionID < this.Resolutions.Count - 1)
        ++this.SelectedResolutionID;
      if (left && this.selectedButton == 3)
        this.fullscreenSelected = true;
      if (right && this.selectedButton == 3)
        this.fullscreenSelected = false;
      if (action1 && this.selectedButton == 3)
        this.fullscreenSelected = !this.fullscreenSelected;
      if (left && this.selectedButton == 4)
        this.gameLanguage = "fr_FR";
      if (right && this.selectedButton == 4)
        this.gameLanguage = "en_US";
      if (action1 && this.selectedButton == 4)
        this.gameLanguage = this.gameLanguage == "fr_FR" ? "en_US" : "fr_FR";
      if (!up || this.selectedButton > 5)
        return;
      EventHandler movedItemSelection1 = this.MovedItemSelection;
      if (movedItemSelection1 != null)
        movedItemSelection1((object) this, EventArgs.Empty);
      ++this.selectedButton;
      this.ResolutionsArrowsTimer = 0;
      if (this.selectedButton != 2 || !this.fullscreenSelected)
        return;
      ++this.selectedButton;
    }

    public void Close()
    {
      SaveHandler.SaveSettings(new GameSettings(this.fullscreenSelected, this.Resolutions[this.SelectedResolutionID], Sound.bgmVolume, Sound.sfxVolume, this.gameLanguage));
      LocalizationManager.SetLanguage(LocalizationManager.Languages.First<Language>((Func<Language, bool>) (p => p.LanguageCode == this.gameLanguage)));
      EventHandler closed = this.Closed;
      if (closed != null)
        closed((object) this, EventArgs.Empty);
      this.ReadyToRemove = true;
    }

    public void Open()
    {
      EventHandler opened = this.Opened;
      if (opened != null)
        opened((object) this, EventArgs.Empty);
      this.ReadyToRemove = false;
      if (!this.Resolutions.Contains(Game1.windowSize))
        this.Resolutions.Add(Game1.windowSize);
      this.SelectedResolutionID = this.Resolutions.FindIndex((Predicate<Vector2>) (a => a == Game1.windowSize));
      this.fullscreenSelected = Game1.isFullscreen;
      this.gameLanguage = LocalizationManager.CurrentLanguage.LanguageCode;
    }
  }
}
