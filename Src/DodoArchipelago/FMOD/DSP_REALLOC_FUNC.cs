﻿// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_REALLOC_FUNC
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public delegate IntPtr DSP_REALLOC_FUNC(
    IntPtr ptr,
    uint size,
    MEMORY_TYPE type,
    StringWrapper sourcestr);
}
