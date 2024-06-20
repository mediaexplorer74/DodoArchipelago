// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BGM.SimpleBGM
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

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
      Console.WriteLine("stopped");
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
