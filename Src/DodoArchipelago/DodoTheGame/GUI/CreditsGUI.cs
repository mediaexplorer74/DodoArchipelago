// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GUI.CreditsGUI
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class CreditsGUI : IGUI
  {
    public Texture2D mainbackground;
    public Texture2D creditsbackground;
    public Texture2D retour;
    public Texture2D retour_selected;
    public Texture2D bande1;
    public Texture2D bande2;
    public Texture2D bande3;
    private int ResolutionsArrowsTimer;
    private int RetourButtonTimer;
    private float timer;
    private float creditscroll;

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
      double num = 231.0 * (double) Game1.renderSize.Y / 720.0;
      Recorder.RDraw(spriteBatch, this.bande1, new Vector2((float) ((double) GUIManager.GUITimer / 5.0 % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float) (((double) GUIManager.GUITimer / 5.0 + 450.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande3, new Vector2((float) (((double) GUIManager.GUITimer / 5.0 + 900.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.bande2, new Vector2((float) (((double) GUIManager.GUITimer / 5.0 + 1350.0) % ((double) Game1.renderSize.X + 500.0) - 300.0), 0.0f), Color.White * 1f);
      Recorder.RDraw(spriteBatch, this.creditsbackground, new Vector2(0.0f, (float) (-1.0 * (double) this.creditscroll + 600.0)), Color.White * 1f);
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
      if ((double) this.creditscroll < 3300.0)
        this.creditscroll += 1.5f;
      if (hold && (double) this.creditscroll < 3300.0)
        this.creditscroll += 9f;
      if (!action1 || (double) this.creditscroll < 3300.0)
        return;
      GUIManager.ClearThenSet((IGUI) GUIManager.mainmenu);
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
      this.creditscroll = 0.0f;
      EventHandler opened = this.Opened;
      if (opened != null)
        opened((object) this, EventArgs.Empty);
      this.ReadyToRemove = false;
    }
  }
}
