
// Type: DodoTheGame.ScreenShake

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using System;


namespace DodoTheGame
{
  internal class ScreenShake
  {
    public static Vector2 CameraOffset = new Vector2(0.0f, 0.0f);
    public static Vector2 CameraOffsetGoal;
    private static Random r = new Random();

    public static void Update(GameTime gameTime, Player player)
    {
      if (player.currentMovementType == Player.DodoMovement.Bicycle)
        ScreenShake.CameraOffset = (float) player.actionTime * 0.0003f * new Vector2((float) ScreenShake.r.Next(-1, 2), (float) ScreenShake.r.Next(-1, 2));
      else if (player.currentMovementType == Player.DodoMovement.Bike)
      {
        ScreenShake.CameraOffsetGoal = -new Vector2((float) ((double) player.bikeVelocity.X * 4.0 * 1280.0 / 720.0), (float) ((double) player.bikeVelocity.Y * 4.0 * 720.0 / 1280.0));
        ScreenShake.CameraOffset = (3f * ScreenShake.CameraOffset + ScreenShake.CameraOffsetGoal) / 4f;
      }
      else
      {
        ScreenShake.CameraOffsetGoal = new Vector2(0.0f, 0.0f);
        ScreenShake.CameraOffset = (ScreenShake.CameraOffset + ScreenShake.CameraOffsetGoal) / 2f;
      }
    }
  }
}
