// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.SYSTEM_CALLBACK_TYPE
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD.Studio
{
  [Flags]
  public enum SYSTEM_CALLBACK_TYPE : uint
  {
    PREUPDATE = 1,
    POSTUPDATE = 2,
    BANK_UNLOAD = 4,
    ALL = 4294967295, // 0xFFFFFFFF
  }
}
