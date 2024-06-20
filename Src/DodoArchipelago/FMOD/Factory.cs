// Decompiled with JetBrains decompiler
// Type: FMOD.Factory
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct Factory
  {
    public static RESULT System_Create(out FMOD.System system)
    {
      return Factory.FMOD5_System_Create(out system.handle);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_System_Create(out IntPtr system);
  }
}
