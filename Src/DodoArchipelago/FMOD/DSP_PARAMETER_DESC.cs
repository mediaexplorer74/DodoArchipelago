﻿// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_PARAMETER_DESC
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSP_PARAMETER_DESC
  {
    public DSP_PARAMETER_TYPE type;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public char[] name;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public char[] label;
    public string description;
    public DSP_PARAMETER_DESC_UNION desc;
  }
}