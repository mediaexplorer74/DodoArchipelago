// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_PARAMETER_DESC_UNION
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD
{
  [StructLayout(LayoutKind.Explicit)]
  public struct DSP_PARAMETER_DESC_UNION
  {
    [FieldOffset(0)]
    public DSP_PARAMETER_DESC_FLOAT floatdesc;
    [FieldOffset(0)]
    public DSP_PARAMETER_DESC_INT intdesc;
    [FieldOffset(0)]
    public DSP_PARAMETER_DESC_BOOL booldesc;
    [FieldOffset(0)]
    public DSP_PARAMETER_DESC_DATA datadesc;
  }
}
