// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.LOAD_BANK_FLAGS
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD.Studio
{
  [Flags]
  public enum LOAD_BANK_FLAGS : uint
  {
    NORMAL = 0,
    NONBLOCKING = 1,
    DECOMPRESS_SAMPLES = 2,
    UNENCRYPTED = 4,
  }
}
