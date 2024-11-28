
// Type: DodoTheGame.Saving.SaveInfo

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework.Graphics;
using System;


namespace DodoTheGame.Saving
{
  internal class SaveInfo
  {
    public DateTime saveTime;
    public int playTime;
    public Texture2D screenshot;
    public bool isValid;

    public SaveInfo(bool isValid, int playTime, DateTime saveTime, Texture2D screenshot)
    {
      this.isValid = isValid;
      this.playTime = playTime;
      this.saveTime = saveTime;
      this.screenshot = screenshot;
    }

    public SaveInfo()
    {
    }
  }
}
