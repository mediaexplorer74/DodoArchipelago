// Decompiled with JetBrains decompiler
// Type: DodoTheGame.BGM.LoopingBGM
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;


namespace DodoTheGame.BGM
{
  internal class LoopingBGM : IBGM
  {
    public Song introPart;
    public Song[] loopingParts;
    public Song outroPart;
    private int currentPart = -2;
    private Song currentSong;

    public float Volume { get; set; }

    public BGMStatus Status { get; private set; } = BGMStatus.Stopped;

    public void Start()
    {
      if (this.Status != BGMStatus.Stopped)
        return;
      this.currentPart = -1;
      this.Status = BGMStatus.Playing;
      this.currentSong = this.introPart;
      MediaPlayer.IsRepeating = false;
      MediaPlayer.Play(this.currentSong);
    }

    public void Update(GameTime gametime)
    {
    }

    public void StateSongChanged(object sender, EventArgs e)
    {
      TimeSpan timeSpan = MediaPlayer.PlayPosition;
      double totalMilliseconds = timeSpan.TotalMilliseconds;
      timeSpan = this.currentSong.Duration;
      double num = timeSpan.TotalMilliseconds - 1000.0;
      if (totalMilliseconds < num)
        return;
      ++this.currentPart;
      if (this.currentPart > this.loopingParts.Length)
      {
        this.Status = BGMStatus.Stopped;
      }
      else
      {
        if (this.Status == BGMStatus.StopPending)
        {
          this.Status = BGMStatus.Stopping;
          this.currentPart = this.loopingParts.Length;
        }
        else if (this.currentPart == this.loopingParts.Length && this.Status == BGMStatus.Playing)
          this.currentPart = 0;
        this.currentSong = this.currentPart != -1 ? (this.currentPart != this.loopingParts.Length ? this.loopingParts[this.currentPart] : this.outroPart) : this.introPart;
        MediaPlayer.Play(this.currentSong);
      }
    }

    public bool RequestStop(bool doStop)
    {
      if (this.Status != BGMStatus.StopPending && this.Status != BGMStatus.Playing)
        return false;
      this.Status = doStop ? BGMStatus.StopPending : BGMStatus.Playing;
      return true;
    }

    public void Kill()
    {
      this.Status = BGMStatus.Stopped;
      MediaPlayer.Stop();
    }
  }
}
