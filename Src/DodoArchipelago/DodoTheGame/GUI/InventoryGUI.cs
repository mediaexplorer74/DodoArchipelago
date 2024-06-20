// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GUI.InventoryGUI
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.GUI
{
  internal class InventoryGUI : IGUI
  {
    public SpriteFont font;
    public Texture2D inventaire;
    public Texture2D background;
    public Texture2D tile;
    public Texture2D selectedtiletexture;
    public Texture2D empty_flower;
    public Texture2D[] itemTextures;
    public Texture2D[] miniFlowersTextures;
    public Sprite animatedBackground;
    private Vector2[] tileLocations = new Vector2[0];
    private bool closing;
    private int currentSlot;
    private int? selectedSlot;

    internal event EventHandler Opened;

    internal event EventHandler Closed;

    internal event EventHandler MovedItemSelection;

    public bool LockGameInput => true;

    public bool IsObstructing => false;

    public int Layer => 50;

    public bool ReadyToRemove { get; private set; }

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.animatedBackground.backwardAnimation = this.closing;
      this.animatedBackground.Draw(spriteBatch, new Vector2(90f, 35f), gameTime);
      if (this.closing && this.animatedBackground.CurrentFrame == 0)
        this.ReadyToRemove = true;
      if (this.closing || this.animatedBackground.CurrentFrame <= 4)
        return;
      Recorder.RDraw(spriteBatch, this.inventaire, new Vector2(550f, 80f), Color.White);
      Vector2[] vector2Array = new Vector2[30];
      for (int index = 0; index < 24; ++index)
        vector2Array[index] = new Vector2((float) (140 + 126 * (index % 8)), (float) (135 + 123 * ((index - index % 8) / 8)));
      for (int index = 0; index < 24; ++index)
      {
        float num = 1f;
        Texture2D tile = this.tile;
        Recorder.RDraw(spriteBatch, tile, vector2Array[index], Color.White * num);
        if (Game1.player.inventory.inventory[index] != null)
        {
          Recorder.RDraw(spriteBatch, this.itemTextures[Game1.player.inventory.inventory[index].itemId], vector2Array[index], Color.White);
          int x = (int) this.font.MeasureString(Game1.player.inventory.inventory[index].count.ToString()).X;
          Recorder.RDrawString(spriteBatch, this.font, Game1.player.inventory.inventory[index].count.ToString(), new Vector2(vector2Array[index].X + 98f - (float) x, vector2Array[index].Y + 76f), Color.White);
        }
      }
      for (int index = 0; index < 13; ++index)
      {
        if (Game1.player.inventory.flowerinventory[index] != null)
          Recorder.RDraw(spriteBatch, this.miniFlowersTextures[index], new Vector2((float) (280 + 60 * index), 520f), Color.White);
        else
          Recorder.RDraw(spriteBatch, this.empty_flower, new Vector2((float) (280 + 60 * index), 520f), Color.White);
      }
      if (!Game1.player.unlockedPlayerTools[PlayerUnlockables.PlayerUnlockable.Bicycle])
        return;
      game.timebar.CurrentFrame = (int) Math.Round(21.0 * (double) Game1.player.TimeBar / 100.0, 0);
      game.timebar.Draw(spriteBatch, new Vector2(345f, 610f), gameTime, colorn: new Color?(Color.White));
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
    }

    public void ResetSelection() => this.selectedSlot = new int?();

    public void Close()
    {
      EventHandler closed = this.Closed;
      if (closed != null)
        closed((object) this, EventArgs.Empty);
      this.closing = true;
    }

    public void Open()
    {
      EventHandler opened = this.Opened;
      if (opened != null)
        opened((object) this, EventArgs.Empty);
      GUIManager.holdcount = 0;
      this.animatedBackground.ResetAnimation();
      this.ReadyToRemove = false;
      this.closing = false;
    }
  }
}
