// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Hitbox.HorizontalLine
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;


namespace DodoTheGame.Hitbox
{
  internal class HorizontalLine : IHitbox
  {
    internal Vector2 StartingPoint { get; set; }

    internal int Span { get; set; }
  }
}
