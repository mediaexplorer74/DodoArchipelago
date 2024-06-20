// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_METERING_INFO
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSP_METERING_INFO
  {
    public int numsamples;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public float[] peaklevel;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public float[] rmslevel;
    public short numchannels;
  }
}
