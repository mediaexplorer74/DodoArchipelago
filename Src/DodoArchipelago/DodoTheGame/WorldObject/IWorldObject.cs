
// Type: DodoTheGame.WorldObject.IWorldObject

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using DodoTheGame.Interactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.WorldObject
{
  public interface IWorldObject
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
