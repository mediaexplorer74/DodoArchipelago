﻿
// Type: FMOD.Studio.VCA

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct VCA
  {
    public IntPtr handle;

    public RESULT getID(out Guid id) => VCA.FMOD_Studio_VCA_GetID(this.handle, out id);

    public RESULT getPath(out string path)
    {
      path = (string) null;
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        IntPtr num = Marshal.AllocHGlobal(256);
        int retrieved = 0;
        RESULT path1 = VCA.FMOD_Studio_VCA_GetPath(this.handle, num, 256, out retrieved);
        if (path1 == RESULT.ERR_TRUNCATED)
        {
          Marshal.FreeHGlobal(num);
          num = Marshal.AllocHGlobal(retrieved);
          path1 = VCA.FMOD_Studio_VCA_GetPath(this.handle, num, retrieved, out retrieved);
        }
        if (path1 == RESULT.OK)
          path = freeHelper.stringFromNative(num);
        Marshal.FreeHGlobal(num);
        return path1;
      }
    }

    public RESULT getVolume(out float volume) => this.getVolume(out volume, out float _);

    public RESULT getVolume(out float volume, out float finalvolume)
    {
      return VCA.FMOD_Studio_VCA_GetVolume(this.handle, out volume, out finalvolume);
    }

    public RESULT setVolume(float volume) => VCA.FMOD_Studio_VCA_SetVolume(this.handle, volume);

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_VCA_IsValid(IntPtr vca);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_VCA_GetID(IntPtr vca, out Guid id);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_VCA_GetPath(
      IntPtr vca,
      IntPtr path,
      int size,
      out int retrieved);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_VCA_GetVolume(
      IntPtr vca,
      out float volume,
      out float finalvolume);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_VCA_SetVolume(IntPtr vca, float volume);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid() => this.hasHandle() && VCA.FMOD_Studio_VCA_IsValid(this.handle);
  }
}
