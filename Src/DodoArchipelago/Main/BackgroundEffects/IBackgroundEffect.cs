﻿
// Type: DodoTheGame.BackgroundEffects.IBackgroundEffect

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DodoTheGame.BackgroundEffects
{
  internal interface IBackgroundEffect
  {
    void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos);
  }
}
