// Decompiled with JetBrains decompiler
// Type: FMOD.TIMEUNIT
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  [Flags]
  public enum TIMEUNIT : uint
  {
    MS = 1,
    PCM = 2,
    PCMBYTES = 4,
    RAWBYTES = 8,
    PCMFRACTION = 16, // 0x00000010
    MODORDER = 256, // 0x00000100
    MODROW = 512, // 0x00000200
    MODPATTERN = 1024, // 0x00000400
  }
}
