
// Type: DodoTheGame.Cutscene.ICutscene

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
