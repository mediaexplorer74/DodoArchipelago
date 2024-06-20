// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.Util
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct Util
  {
    public static RESULT parseID(string idString, out Guid id)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return Util.FMOD_Studio_ParseID(freeHelper.byteFromStringUTF8(idString), out id);
    }

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_ParseID(byte[] idString, out Guid id);
  }
}
