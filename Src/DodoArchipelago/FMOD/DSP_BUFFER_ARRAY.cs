// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_BUFFER_ARRAY
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct DSP_BUFFER_ARRAY
  {
    public int numbuffers;
    public int[] buffernumchannels;
    public CHANNELMASK[] bufferchannelmask;
    public IntPtr[] buffers;
    public SPEAKERMODE speakermode;
  }
}
