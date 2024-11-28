
// Type: DodoTheGame.NPC.INPC

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace DodoTheGame.NPC
{
  public interface INPC
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
