// Decompiled with JetBrains decompiler
// Type: FMOD.StringWrapper
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct StringWrapper
  {
    private IntPtr nativeUtf8Ptr;

    public static implicit operator string(StringWrapper fstring)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return freeHelper.stringFromNative(fstring.nativeUtf8Ptr);
    }
  }
}
