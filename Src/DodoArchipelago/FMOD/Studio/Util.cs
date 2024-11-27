
// Type: FMOD.Studio.Util

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
