﻿// Type: FMOD.Studio.CommandReplay

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct CommandReplay
  {
    public IntPtr handle;

    public RESULT getSystem(out FMOD.Studio.System system)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetSystem(this.handle, out system.handle);
    }

    public RESULT getLength(out float length)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetLength(this.handle, out length);
    }

    public RESULT getCommandCount(out int count)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetCommandCount(this.handle, out count);
    }

    public RESULT getCommandInfo(int commandIndex, out COMMAND_INFO info)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetCommandInfo(
          this.handle, commandIndex, out info);
    }

    public RESULT getCommandString(int commandIndex, out string buffer)
    {
      buffer = (string) null;
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        int num1 = 256;
        IntPtr num2 = Marshal.AllocHGlobal(256);
        RESULT commandString = CommandReplay.FMOD_Studio_CommandReplay_GetCommandString(
            this.handle, commandIndex, num2, num1);
        while (true)
        {
          switch (commandString)
          {
            case RESULT.OK:
              goto label_4;
            case RESULT.ERR_TRUNCATED:
              Marshal.FreeHGlobal(num2);
              num1 *= 2;
              num2 = Marshal.AllocHGlobal(num1);

              commandString = CommandReplay.FMOD_Studio_CommandReplay_GetCommandString(
                  this.handle, commandIndex, num2, num1);
              continue;
            default:
              goto label_5;
          }
        }
label_4:
        buffer = freeHelper.stringFromNative(num2);
label_5:
        Marshal.FreeHGlobal(num2);
        return commandString;
      }
    }

    public RESULT getCommandAtTime(float time, out int commandIndex)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetCommandAtTime(
          this.handle, time, out commandIndex);
    }

    public RESULT setBankPath(string bankPath)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return CommandReplay.FMOD_Studio_CommandReplay_SetBankPath(
            this.handle, freeHelper.byteFromStringUTF8(bankPath));
    }

    public RESULT start() => CommandReplay.FMOD_Studio_CommandReplay_Start(this.handle);

    public RESULT stop() => CommandReplay.FMOD_Studio_CommandReplay_Stop(this.handle);

    public RESULT seekToTime(float time)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SeekToTime(this.handle, time);
    }

    public RESULT seekToCommand(int commandIndex)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SeekToCommand(this.handle, commandIndex);
    }

    public RESULT getPaused(out bool paused)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetPaused(this.handle, out paused);
    }

    public RESULT setPaused(bool paused)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SetPaused(this.handle, paused);
    }

    public RESULT getPlaybackState(out PLAYBACK_STATE state)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetPlaybackState(this.handle, out state);
    }

    public RESULT getCurrentCommand(out int commandIndex, out float currentTime)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetCurrentCommand(
          this.handle, out commandIndex, out currentTime);
    }

    public RESULT release() => CommandReplay.FMOD_Studio_CommandReplay_Release(this.handle);

    public RESULT setFrameCallback(COMMANDREPLAY_FRAME_CALLBACK callback)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SetFrameCallback(this.handle, callback);
    }

    public RESULT setLoadBankCallback(COMMANDREPLAY_LOAD_BANK_CALLBACK callback)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SetLoadBankCallback(this.handle, callback);
    }

    public RESULT setCreateInstanceCallback(COMMANDREPLAY_CREATE_INSTANCE_CALLBACK callback)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SetCreateInstanceCallback(this.handle, callback);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_GetUserData(this.handle, out userdata);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return CommandReplay.FMOD_Studio_CommandReplay_SetUserData(this.handle, userdata);
    }

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_CommandReplay_IsValid(IntPtr replay);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetSystem(
      IntPtr replay,
      out IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetLength(
      IntPtr replay,
      out float length);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetCommandCount(
      IntPtr replay,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetCommandInfo(
      IntPtr replay,
      int commandindex,
      out COMMAND_INFO info);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetCommandString(
      IntPtr replay,
      int commandIndex,
      IntPtr buffer,
      int length);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetCommandAtTime(
      IntPtr replay,
      float time,
      out int commandIndex);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetBankPath(
      IntPtr replay,
      byte[] bankPath);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_Start(IntPtr replay);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_Stop(IntPtr replay);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SeekToTime(IntPtr replay, float time);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SeekToCommand(
      IntPtr replay,
      int commandIndex);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetPaused(IntPtr replay, out bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetPaused(IntPtr replay, bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetPlaybackState(
      IntPtr replay,
      out PLAYBACK_STATE state);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetCurrentCommand(
      IntPtr replay,
      out int commandIndex,
      out float currentTime);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_Release(IntPtr replay);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetFrameCallback(
      IntPtr replay,
      COMMANDREPLAY_FRAME_CALLBACK callback);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetLoadBankCallback(
      IntPtr replay,
      COMMANDREPLAY_LOAD_BANK_CALLBACK callback);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetCreateInstanceCallback(
      IntPtr replay,
      COMMANDREPLAY_CREATE_INSTANCE_CALLBACK callback);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_GetUserData(
      IntPtr replay,
      out IntPtr userdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_CommandReplay_SetUserData(
      IntPtr replay,
      IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid()
    {
      return this.hasHandle() && CommandReplay.FMOD_Studio_CommandReplay_IsValid(this.handle);
    }
  }
}
