﻿
// Type: DodoTheGame.Hitbox.VerticalLine

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;


namespace DodoTheGame.Hitbox
{
  internal class VerticalLine : IHitbox
  {
    internal Vector2 StartingPoint { get; set; }

    internal int Span { get; set; }
  }
}
