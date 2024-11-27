
// Type: FMOD.DSP_PARAMETER_FFT

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
