// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.COMMANDREPLAY_FLAGS
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD.Studio
{
  [Flags]
  public enum COMMANDREPLAY_FLAGS : uint
  {
    NORMAL = 0,
    SKIP_CLEANUP = 1,
    FAST_FORWARD = 2,
    SKIP_BANK_LOAD = 4,
  }
}
