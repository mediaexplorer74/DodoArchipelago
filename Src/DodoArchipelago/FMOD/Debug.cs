// Decompiled with JetBrains decompiler
// Type: FMOD.Debug
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Runtime.InteropServices;


namespace FMOD
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct Debug
  {
    public static RESULT Initialize(
      DEBUG_FLAGS flags,
      DEBUG_MODE mode = DEBUG_MODE.TTY,
      DEBUG_CALLBACK callback = null,
      string filename = null)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return Debug.FMOD5_Debug_Initialize(flags, mode, callback, freeHelper.byteFromStringUTF8(filename));
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Debug_Initialize(
      DEBUG_FLAGS flags,
      DEBUG_MODE mode,
      DEBUG_CALLBACK callback,
      byte[] filename);
  }
}
