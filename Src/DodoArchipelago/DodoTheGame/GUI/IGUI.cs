// Decompiled with JetBrains decompiler
// Type: DodoTheGame.GUI.IGUI
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DodoTheGame.GUI
{
  internal interface IGUI
  {
    void Draw(SpriteBatch spriteBatch, Game1 game, GameTime gameTime);

    void Input(
      bool left,
      bool right,
      bool up,
      bool down,
      bool action1,
      bool hold,
      UserInputStatus.InputState alt,
      Game1 game);

    bool LockGameInput { get; }

    bool IsObstructing { get; }

    void Open();

    void Close();

    bool ReadyToRemove { get; }

    int Layer { get; }
  }
}
