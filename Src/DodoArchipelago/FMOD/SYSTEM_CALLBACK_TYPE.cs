// Decompiled with JetBrains decompiler
// Type: FMOD.SYSTEM_CALLBACK_TYPE
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  [Flags]
  public enum SYSTEM_CALLBACK_TYPE : uint
  {
    DEVICELISTCHANGED = 1,
    DEVICELOST = 2,
    MEMORYALLOCATIONFAILED = 4,
    THREADCREATED = 8,
    BADDSPCONNECTION = 16, // 0x00000010
    PREMIX = 32, // 0x00000020
    POSTMIX = 64, // 0x00000040
    ERROR = 128, // 0x00000080
    MIDMIX = 256, // 0x00000100
    THREADDESTROYED = 512, // 0x00000200
    PREUPDATE = 1024, // 0x00000400
    POSTUPDATE = 2048, // 0x00000800
    RECORDLISTCHANGED = 4096, // 0x00001000
    ALL = 4294967295, // 0xFFFFFFFF
  }
}
