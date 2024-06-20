// Decompiled with JetBrains decompiler
// Type: FMOD.ADVANCEDSETTINGS
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct ADVANCEDSETTINGS
  {
    public int cbSize;
    public int maxMPEGCodecs;
    public int maxADPCMCodecs;
    public int maxXMACodecs;
    public int maxVorbisCodecs;
    public int maxAT9Codecs;
    public int maxFADPCMCodecs;
    public int maxPCMCodecs;
    public int ASIONumChannels;
    public IntPtr ASIOChannelList;
    public IntPtr ASIOSpeakerList;
    public float vol0virtualvol;
    public uint defaultDecodeBufferSize;
    public ushort profilePort;
    public uint geometryMaxFadeTime;
    public float distanceFilterCenterFreq;
    public int reverb3Dinstance;
    public int DSPBufferPoolSize;
    public uint stackSizeStream;
    public uint stackSizeNonBlocking;
    public uint stackSizeMixer;
    public DSP_RESAMPLER resamplerMethod;
    public uint commandQueueSize;
    public uint randomSeed;
  }
}
