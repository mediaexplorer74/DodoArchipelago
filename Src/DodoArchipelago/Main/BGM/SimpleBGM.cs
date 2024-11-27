
// Type: DodoTheGame.BGM.SimpleBGM

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;


namespace DodoTheGame.BGM
{
  internal class SimpleBGM : IBGM
  {
    public Song mainPart;

    public float Volume { get; set; }

    public BGMStatus Status { get; private set; } = BGMStatus.Stopped;

    public void Start()
    {
      if (this.Status != BGMStatus.Stopped)
        return;
      this.Status = BGMStatus.Playing;
      MediaPlayer.IsRepeating = false;
      MediaPlayer.Play(this.mainPart);
    }

    public void StateSongChanged(object sender, EventArgs e)
    {
      TimeSpan timeSpan = MediaPlayer.PlayPosition;
      double totalMilliseconds = timeSpan.TotalMilliseconds;
      timeSpan = this.mainPart.Duration;
      double num = timeSpan.TotalMilliseconds - 1000.0;
      if (totalMilliseconds < num)
        return;
      this.Status = BGMStatus.Stopped;
      System.Diagnostics.Debug.WriteLine("stopped");
    }

    public void Update(GameTime gameTime)
    {
    }

    public void Kill()
    {
      this.Status = BGMStatus.Stopped;
      MediaPlayer.Stop();
    }

    public bool RequestStop(bool doStop) => false;
  }
}
