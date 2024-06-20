// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GUI.TutorialGUI
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DodoTheGame.GUI
{
  internal class TutorialGUI : IGUI
  {
    public Sprite animatedBackground;
    private bool closing;

    public bool LockGameInput => true;

    public bool IsObstructing => false;

    public bool ReadyToRemove { get; private set; }

    public int Layer => 200;

    public void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime)
    {
      this.animatedBackground.backwardAnimation = this.closing;
      this.animatedBackground.Draw(spriteBatch, new Vector2(265f, 120f), gameTime);
      if (this.closing && this.animatedBackground.CurrentFrame == 0)
        this.ReadyToRemove = true;
      if (this.closing)
        return;
      int currentFrame = this.animatedBackground.CurrentFrame;
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
      if (!(action1 | left | up | down | right) || this.animatedBackground.CurrentFrame != this.animatedBackground.TotalFrameCount - 1)
        return;
      this.Close();
    }

    public void Close() => this.closing = true;

    public void Open()
    {
      this.animatedBackground.ResetAnimation();
      this.ReadyToRemove = false;
      this.closing = false;
    }
  }
}
