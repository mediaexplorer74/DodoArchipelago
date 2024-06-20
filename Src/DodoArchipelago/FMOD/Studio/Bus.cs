// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.Bus
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct Bus
  {
    public IntPtr handle;

    public RESULT getID(out Guid id) => Bus.FMOD_Studio_Bus_GetID(this.handle, out id);

    public RESULT getPath(out string path)
    {
      path = (string) null;
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        IntPtr num = Marshal.AllocHGlobal(256);
        int retrieved = 0;
        RESULT path1 = Bus.FMOD_Studio_Bus_GetPath(this.handle, num, 256, out retrieved);
        if (path1 == RESULT.ERR_TRUNCATED)
        {
          Marshal.FreeHGlobal(num);
          num = Marshal.AllocHGlobal(retrieved);
          path1 = Bus.FMOD_Studio_Bus_GetPath(this.handle, num, retrieved, out retrieved);
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
      return Bus.FMOD_Studio_Bus_GetVolume(this.handle, out volume, out finalvolume);
    }

    public RESULT setVolume(float volume) => Bus.FMOD_Studio_Bus_SetVolume(this.handle, volume);

    public RESULT getPaused(out bool paused)
    {
      return Bus.FMOD_Studio_Bus_GetPaused(this.handle, out paused);
    }

    public RESULT setPaused(bool paused) => Bus.FMOD_Studio_Bus_SetPaused(this.handle, paused);

    public RESULT getMute(out bool mute) => Bus.FMOD_Studio_Bus_GetMute(this.handle, out mute);

    public RESULT setMute(bool mute) => Bus.FMOD_Studio_Bus_SetMute(this.handle, mute);

    public RESULT stopAllEvents(STOP_MODE mode)
    {
      return Bus.FMOD_Studio_Bus_StopAllEvents(this.handle, mode);
    }

    public RESULT lockChannelGroup() => Bus.FMOD_Studio_Bus_LockChannelGroup(this.handle);

    public RESULT unlockChannelGroup() => Bus.FMOD_Studio_Bus_UnlockChannelGroup(this.handle);

    public RESULT getChannelGroup(out ChannelGroup group)
    {
      return Bus.FMOD_Studio_Bus_GetChannelGroup(this.handle, out group.handle);
    }

    public RESULT getCPUUsage(out uint exclusive, out uint inclusive)
    {
      return Bus.FMOD_Studio_Bus_GetCPUUsage(this.handle, out exclusive, out inclusive);
    }

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_Bus_IsValid(IntPtr bus);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetID(IntPtr bus, out Guid id);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetPath(
      IntPtr bus,
      IntPtr path,
      int size,
      out int retrieved);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetVolume(
      IntPtr bus,
      out float volume,
      out float finalvolume);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_SetVolume(IntPtr bus, float volume);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetPaused(IntPtr bus, out bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_SetPaused(IntPtr bus, bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetMute(IntPtr bus, out bool mute);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_SetMute(IntPtr bus, bool mute);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_StopAllEvents(IntPtr bus, STOP_MODE mode);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_LockChannelGroup(IntPtr bus);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_UnlockChannelGroup(IntPtr bus);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetChannelGroup(IntPtr bus, out IntPtr group);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_Bus_GetCPUUsage(
      IntPtr bus,
      out uint exclusive,
      out uint inclusive);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid() => this.hasHandle() && Bus.FMOD_Studio_Bus_IsValid(this.handle);
  }
}
