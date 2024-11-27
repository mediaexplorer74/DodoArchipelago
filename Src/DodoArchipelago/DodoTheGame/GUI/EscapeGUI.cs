
// Type: DodoTheGame.GUI.EscapeGUI

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Saving;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class EscapeGUI : IGUI
  {
    public Texture2D background;
    public Texture2D text1;
    public Texture2D text2;
    public Texture2D text3;
    public Texture2D text4;
    public Texture2D text5;
    public Texture2D text1s;
    public Texture2D text2s;
    public Texture2D text3s;
    public Texture2D text4s;
    public Texture2D text5s;
    private int selectedButton = 1;

    public event EventHandler Opened;

    public event EventHandler Closed;

    public event EventHandler MovedItemSelection;

    public int Layer => 100;

    public bool LockGameInput => true;

    public bool IsObstructing => false;

    public bool ReadyToRemove { get; private set; }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      Recorder.RDraw(spriteBatch, this.background, new Vector2(0.0f, 0.0f), Color.White * 0.5f);
      Texture2D texture1;
      Texture2D texture2;
      Texture2D texture3;
      Texture2D texture4;
      Texture2D texture5;
      switch (this.selectedButton)
      {
        case 1:
          texture1 = this.text1s;
          texture2 = this.text2;
          texture3 = this.text3;
          texture4 = this.text4;
          texture5 = this.text5;
          break;
        case 2:
          texture1 = this.text1;
          texture2 = this.text2s;
          texture3 = this.text3;
          texture4 = this.text4;
          texture5 = this.text5;
          break;
        case 3:
          texture1 = this.text1;
          texture2 = this.text2;
          texture3 = this.text3s;
          texture4 = this.text4;
          texture5 = this.text5;
          break;
        case 4:
          texture1 = this.text1;
          texture2 = this.text2;
          texture3 = this.text3;
          texture4 = this.text4s;
          texture5 = this.text5;
          break;
        case 5:
          texture1 = this.text1;
          texture2 = this.text2;
          texture3 = this.text3;
          texture4 = this.text4;
          texture5 = this.text5s;
          break;
        default:
          texture1 = this.text1;
          texture2 = this.text2;
          texture3 = this.text3;
          texture4 = this.text4s;
          texture5 = this.text5s;
          break;
      }
      float y = (float) (231.0 * (double) Game1.renderSize.Y / 720.0);
      Recorder.RDraw(spriteBatch, texture1, new Vector2((float) ((double) Game1.renderSize.X / 2.0 - 100.0), y), Color.White * 1f);
      Recorder.RDraw(spriteBatch, texture2, new Vector2((float) ((double) Game1.renderSize.X / 2.0 - 100.0), y + 51f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, texture3, new Vector2((float) ((double) Game1.renderSize.X / 2.0 - 100.0), y + 102f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, texture4, new Vector2((float) ((double) Game1.renderSize.X / 2.0 - 120.0), y + 153f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, texture5, new Vector2((float) ((double) Game1.renderSize.X / 2.0 - 100.0), y + 204f), Color.White * 1f);
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
        GUIManager.Clear();
      else if (action1 && this.selectedButton == 3 && game.WorldLoader == Game1.WorldLoaderType.dynamicSaves)
        GUIManager.ClearThenSet((IGUI) GUIManager.loadGUI);
      else if (action1 && this.selectedButton == 4)
      {
        SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
        GUIManager.ClearThenSet((IGUI) GUIManager.mainmenu);
      }
      else if (action1 && this.selectedButton == 2)
      {
        System.Diagnostics.Debug.WriteLine("Settings menu open from escape menu.");
        GUIManager.ClearThenSet((IGUI) GUIManager.settings);
      }
      else if (action1 && this.selectedButton == 5)
      {
        SaveHandler.SaveGame(Game1.world, Game1.player, game.lastFrame);
        GUIManager.pendingExit = true;
      }
      if (up && this.selectedButton > 1)
      {
        EventHandler movedItemSelection = this.MovedItemSelection;
        if (movedItemSelection != null)
          movedItemSelection((object) this, EventArgs.Empty);
        --this.selectedButton;
      }
      if (!down || this.selectedButton >= 5)
        return;
      EventHandler movedItemSelection1 = this.MovedItemSelection;
      if (movedItemSelection1 != null)
        movedItemSelection1((object) this, EventArgs.Empty);
      ++this.selectedButton;
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
