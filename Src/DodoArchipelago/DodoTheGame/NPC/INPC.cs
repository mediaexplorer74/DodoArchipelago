// Decompiled with JetBrains decompiler
// Type: DodoTheGame.NPC.INPC
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.NPC
{
  internal interface INPC
  {
    Vector2 Location { get; set; }

    List<Rectangle> Hitbox { get; }

    Sprite CurrentDrawSprite { get; }

    Sprite IdleSprite { get; set; }

    Sprite RunSprite { get; set; }

    Sprite SleepSprite { get; set; }

    int FeetY { get; }

    void Update(GameTime gameTime, World world);

    void Draw(SpriteBatch sb, GameTime gameTime, Vector2 screenLocation);
  }
}
