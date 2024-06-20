﻿// Decompiled with JetBrains decompiler
// Type: DodoTheGame.WorldObject.IWorldObject
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.WorldObject
{
  internal interface IWorldObject
  {
    string ObjectId { get; set; }

    Sprite StandardSprite { get; set; }

    string PresetMarker { get; set; }

    Vector2 Location { get; set; }

    int SpriteBottomY { get; }

    List<Rectangle> Hitbox { get; set; }

    Vector2 ExtraReach { get; set; }

    Vector2 ExplicitEpicenter { get; set; }

    int ExtraFloorHeight { get; set; }

    IDodoInteraction[] Interactions { get; set; }

    bool Visible { get; set; }

    Sprite CurrentDrawSprite { get; }

    Vector2 Epicenter { get; }

    string[] Tags { get; set; }

    bool IsAbove(int y);

    bool TestPointCollision(Vector2 collisionPoint);

    bool TestHorizontalLineCollision(Vector2 lineStart, int lineLength);

    bool TestVerticalLineCollision(Vector2 lineStart, int lineLength);

    void Interact(Cardinal side, Game1 game, Player player);

    void Draw(
      SpriteBatch spriteBatch,
      Vector2 screenlocation,
      GameTime gametime,
      Game1 game,
      SpriteEffects effect = SpriteEffects.None,
      Color? colorn = null,
      bool inReach = false,
      bool inReachAndHasInteractions = false);

    void DrawShadow(
      SpriteBatch spriteBatch,
      Vector2 screenlocation,
      GameTime gametime,
      Game1 game,
      SpriteEffects effect = SpriteEffects.None,
      Color? colorn = null,
      bool inReach = false,
      bool inReachAndHasInteractions = false);
  }
}
