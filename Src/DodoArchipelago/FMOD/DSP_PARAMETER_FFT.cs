// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_PARAMETER_FFT
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSP_PARAMETER_FFT
  {
    public int length;
    public int numchannels;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    private IntPtr[] spectrum_internal;

    public float[][] spectrum
    {
      get
      {
        float[][] spectrum = new float[this.numchannels][];
        for (int index = 0; index < this.numchannels; ++index)
        {
          spectrum[index] = new float[this.length];
          Marshal.Copy(this.spectrum_internal[index], spectrum[index], 0, this.length);
        }
        return spectrum;
      }
    }

    public void getSpectrum(ref float[][] buffer)
    {
      int num = Math.Min(buffer.Length, this.numchannels);
      for (int channel = 0; channel < num; ++channel)
        this.getSpectrum(channel, ref buffer[channel]);
    }

    public void getSpectrum(int channel, ref float[] buffer)
    {
      int length = Math.Min(buffer.Length, this.length);
      Marshal.Copy(this.spectrum_internal[channel], buffer, 0, length);
    }
  }
}
