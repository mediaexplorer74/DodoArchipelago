// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.Union_IntBoolFloatString
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  [StructLayout(LayoutKind.Explicit)]
  internal struct Union_IntBoolFloatString
  {
    [FieldOffset(0)]
    public int intvalue;
    [FieldOffset(0)]
    public bool boolvalue;
    [FieldOffset(0)]
    public float floatvalue;
    [FieldOffset(0)]
    public StringWrapper stringvalue;
  }
}
