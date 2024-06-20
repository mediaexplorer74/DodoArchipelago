// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.INITFLAGS
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD.Studio
{
  [Flags]
  public enum INITFLAGS : uint
  {
    NORMAL = 0,
    LIVEUPDATE = 1,
    ALLOW_MISSING_PLUGINS = 2,
    SYNCHRONOUS_UPDATE = 4,
    DEFERRED_CALLBACKS = 8,
    LOAD_FROM_UPDATE = 16, // 0x00000010
  }
}
