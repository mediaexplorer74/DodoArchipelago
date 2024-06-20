// Decompiled with JetBrains decompiler
// Type: DodoTheGame.PerformanceCounter
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Collections.Generic;
using System.Linq;


namespace DodoTheGame
{
  internal class PerformanceCounter
  {
    private const int MAXIMUM_SAMPLES = 30;
    private List<float> updateTicks = new List<float>();
    private List<float> drawTicks = new List<float>();
    private Queue<float> _sampleBuffer = new Queue<float>();
    private double ticksPerSecondElapsed;
    internal double updateTicksAverage;
    internal double drawTicksAverage;
    internal double maxUpdateTicks;
    internal double maxDrawTicks;

    private long TotalFrames { get; set; }

    private float TotalSeconds { get; set; }

    private float AverageFramesPerSecond { get; set; }

    public int OutputFramesPerSecond { get; private set; }

    private float CurrentFramesPerSecond { get; set; }

    public bool Update(float deltaTime, double millisecondsTime)
    {
      this.ticksPerSecondElapsed += millisecondsTime;
      if (this.ticksPerSecondElapsed > 1000.0)
      {
        this.ticksPerSecondElapsed = 0.0;
        this.ComputeTicks();
      }
      this.CurrentFramesPerSecond = 1f / deltaTime;
      this._sampleBuffer.Enqueue(this.CurrentFramesPerSecond);
      if (this._sampleBuffer.Count > 30)
      {
        double num = (double) this._sampleBuffer.Dequeue();
        this.AverageFramesPerSecond = this._sampleBuffer.Average<float>((Func<float, float>) (i => i));
      }
      else
        this.AverageFramesPerSecond = this.CurrentFramesPerSecond;
      this.OutputFramesPerSecond = (int) Math.Round((double) this.AverageFramesPerSecond);
      ++this.TotalFrames;
      this.TotalSeconds += deltaTime;
      return true;
    }

    internal void RegisterUpdateTicks(float ticks) => this.updateTicks.Add(ticks);

    internal void RegisterDrawTicks(float ticks) => this.drawTicks.Add(ticks);

    private void ComputeTicks()
    {
      if (this.updateTicks.Count > 0)
      {
        this.updateTicksAverage = Math.Round((double) this.updateTicks.Average());
        this.maxUpdateTicks = Math.Round((double) this.updateTicks.Max());
      }
      if (this.drawTicks.Count > 0)
      {
        this.drawTicksAverage = Math.Round((double) this.drawTicks.Average());
        this.maxDrawTicks = Math.Round((double) this.drawTicks.Max());
      }
      this.updateTicks.Clear();
      this.drawTicks.Clear();
    }
  }
}
