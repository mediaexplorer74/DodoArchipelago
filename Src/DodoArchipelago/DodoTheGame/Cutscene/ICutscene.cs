// Decompiled with JetBrains decompiler
// Type: DodoTheGame.Cutscene.ICutscene
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.Cutscene
{
  internal interface ICutscene
  {
    UserInputStatus Process(GameTime gameTime, Player player, World world);

    void DrawOverride(
      RenderOverride @override,
      SpriteBatch spriteBatch,
      GameTime gameTime,
      Game1 game,
      Vector2 layerLocation);

    void Start(GameTime gameTime, Player player, World world);

    bool Terminated { get; }

    float BlackFade { get; }

    float WhiteFade { get; }

    List<RenderOverride> Overrides { get; }
  }
}
