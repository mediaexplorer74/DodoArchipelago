﻿// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_DFT_IFFTREAL_FUNC
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public delegate RESULT DSP_DFT_IFFTREAL_FUNC(
    ref DSP_STATE dsp_state,
    int size,
    IntPtr dft,
    IntPtr signal,
    IntPtr window,
    int signalhop);
}
