
// Type: DodoTheGame.GUI.MainMenuGUI

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class MainMenuGUI : IGUI
  {
    public Texture2D mainbackground;
    public Texture2D jouer;
    public Texture2D parameters;
    public Texture2D jouer_selected;
    public Texture2D parameters_selected;
    public Texture2D bande1;
    public Texture2D bande2;
    public Texture2D bande3;
    public Texture2D mainlogo;
    public Texture2D exit;
    public Texture2D exit_selected;
    private int selectedButton = 1;
    private int playButtonTimer;

    public event EventHandler Opened;

    public event EventHandler Closed;

    public event EventHandler MovedItemSelection;

    public int Layer => 100;

    public bool LockGameInput => true;

    public bool IsObstructing => true;

    public bool ReadyToRemove { get; private set; }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.playButtonTimer += gameTime.ElapsedGameTime.Milliseconds;
      Recorder.RDraw(spriteBatch, this.mainbackground, new Vector2(0.0f, 0.0f), Color.White);
      Texture2D texture1;
      Texture2D texture2;
      Texture2D texture3;
      switch (this.selectedButton)
      {
        case 1:
          texture1 = this.jouer_selected;
          texture2 = this.parameters;
          texture3 = this.exit;
          break;
        case 2:
          texture1 = this.jouer;
          texture2 = this.parameters_selected;
          texture3 = this.exit;
          break;
        case 3:
          texture1 = this.jouer;
          texture2 = this.parameters;
          texture3 = this.exit_selected;
          break;
        default:
          texture1 = this.jouer;
          texture2 = this.parameters;
          texture3 = this.exit;
          break;
      }
      double num = 231.0 * (double) Game1.renderSize.Y / 720.0;
      Recorder.RDraw(spriteBatch, this.bande1, new Vector2((float) 
          ((double) GUIManager.GUITimer / 5.0 % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float)
          (((double) GUIManager.GUITimer / 5.0 + 450.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande3, new Vector2((float) 
          (((double) GUIManager.GUITimer / 5.0 + 900.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float)
          (((double) GUIManager.GUITimer / 5.0 + 1350.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      if (texture1 == this.jouer_selected)
        Recorder.RDraw(spriteBatch, texture1, new Vector2(Game1.renderSize.X / 2f,
            Game1.renderSize.Y - 200f), Color.White * 1f, 
            (float) (1.0 + 0.059999998658895493 * (double) Convert.ToSingle(
                Math.Sin((double) this.playButtonTimer / 125.0))));
      else
        Recorder.RDraw(spriteBatch, texture1, new Vector2(Game1.renderSize.X / 2f, 
            Game1.renderSize.Y - 200f), Color.White * 1f, 1f);
      if (texture2 == this.parameters_selected)
        Recorder.RDraw(spriteBatch, texture2, new Vector2(Game1.renderSize.X - 50f,
            Game1.renderSize.Y - 50f), Color.White * 1f, 1.2f);
      else
        Recorder.RDraw(spriteBatch, texture2, new Vector2(Game1.renderSize.X - 50f, 
            Game1.renderSize.Y - 50f), Color.White * 1f, 1f);
      if (texture3 == this.exit_selected)
        Recorder.RDraw(spriteBatch, texture3, new Vector2(50f, Game1.renderSize.Y - 50f),
            Color.White * 1f, 1.2f);
      else
        Recorder.RDraw(spriteBatch, texture3, new Vector2(50f, Game1.renderSize.Y - 50f),
            Color.White * 1f, 1f);
      Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, "Crédits", 
          new Vector2(1215f, 2f), this.selectedButton == 4 ? Color.White : Color.Black * 0.5f);
      Recorder.RDrawString(spriteBatch, Game1.rouliMSpriteFont, "V1.0.1",
          new Vector2(3f, 1f), Color.Black * 0.5f);
      Recorder.RDraw(spriteBatch, this.mainlogo, new Vector2((float)
          ((double) Game1.renderSize.X / 2.0 - 430.0), 0.0f), Color.White * 1f);
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
      if (action1 && this.selectedButton == 1 && 
                game.WorldLoader == Game1.WorldLoaderType.dynamicSaves)
        GUIManager.ClearThenSet((IGUI) GUIManager.loadGUI);
      else if (action1 && this.selectedButton == 1)
      {
        GUIManager.Clear();
        game.LoadDefaultSave();
      }
      if (action1 && this.selectedButton == 2)
        GUIManager.ClearThenSet((IGUI) GUIManager.settings);
      if (action1 && this.selectedButton == 3)
        GUIManager.pendingExit = true;
      if (action1 && this.selectedButton == 4)
        GUIManager.ClearThenSet((IGUI) GUIManager.credits);
      if (up && this.selectedButton == 2)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        --this.selectedButton;
        this.playButtonTimer = 0;
      }
      else if (up && this.selectedButton == 1)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 4;
        this.playButtonTimer = 0;
      }
      else if (down | left && this.selectedButton == 4)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 1;
        this.playButtonTimer = 0;
      }
      else if (left && this.selectedButton == 2)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 1;
      }
      else if (up && this.selectedButton == 3)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 1;
        this.playButtonTimer = 0;
      }
      else if (right && this.selectedButton == 3)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 1;
      }
      else if (down | right && this.selectedButton == 1)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 2;
      }
      else
      {
        if (!left || this.selectedButton != 1)
          return;
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        this.selectedButton = 3;
      }
    }

    public void Close()
    {
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
    }
  }
}
