// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_STATE
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct DSP_STATE
  {
    public IntPtr instance;
    public IntPtr plugindata;
    public uint channelmask;
    public int source_speakermode;
    public IntPtr sidechaindata;
    public int sidechainchannels;
    public IntPtr functions;
    public int systemobject;
  }
}
