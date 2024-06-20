// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BackgroundEffects.IBackgroundEffect
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace DodoTheGame.BackgroundEffects
{
  internal interface IBackgroundEffect
  {
    void Draw(SpriteBatch sb, GameTime gameTime, Vector2 backgroundPos);
  }
}
