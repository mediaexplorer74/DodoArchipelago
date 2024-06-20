// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_PARAMETER_3DATTRIBUTES_MULTI
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSP_PARAMETER_3DATTRIBUTES_MULTI
  {
    public int numlisteners;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public ATTRIBUTES_3D[] relative;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public float[] weight;
    public ATTRIBUTES_3D absolute;
  }
}
