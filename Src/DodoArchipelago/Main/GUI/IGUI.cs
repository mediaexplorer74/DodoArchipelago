
// Type: DodoTheGame.GUI.IGUI

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
