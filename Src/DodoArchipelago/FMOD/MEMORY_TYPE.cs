// Decompiled with JetBrains decompiler
// Type: FMOD.MEMORY_TYPE
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  [Flags]
  public enum MEMORY_TYPE : uint
  {
    NORMAL = 0,
    STREAM_FILE = 1,
    STREAM_DECODE = 2,
    SAMPLEDATA = 4,
    DSP_BUFFER = 8,
    PLUGIN = 16, // 0x00000010
    PERSISTENT = 2097152, // 0x00200000
    ALL = 4294967295, // 0xFFFFFFFF
  }
}
