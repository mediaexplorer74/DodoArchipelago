// Decompiled with JetBrains decompiler
// Type: FMOD.DSPConnection
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSPConnection
  {
    public IntPtr handle;

    public RESULT getInput(out DSP input)
    {
      return DSPConnection.FMOD5_DSPConnection_GetInput(this.handle, out input.handle);
    }

    public RESULT getOutput(out DSP output)
    {
      return DSPConnection.FMOD5_DSPConnection_GetOutput(this.handle, out output.handle);
    }

    public RESULT setMix(float volume)
    {
      return DSPConnection.FMOD5_DSPConnection_SetMix(this.handle, volume);
    }

    public RESULT getMix(out float volume)
    {
      return DSPConnection.FMOD5_DSPConnection_GetMix(this.handle, out volume);
    }

    public RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop = 0)
    {
      return DSPConnection.FMOD5_DSPConnection_SetMixMatrix(this.handle, matrix, outchannels, inchannels, inchannel_hop);
    }

    public RESULT getMixMatrix(
      float[] matrix,
      out int outchannels,
      out int inchannels,
      int inchannel_hop = 0)
    {
      return DSPConnection.FMOD5_DSPConnection_GetMixMatrix(this.handle, matrix, out outchannels, out inchannels, inchannel_hop);
    }

    public RESULT getType(out DSPCONNECTION_TYPE type)
    {
      return DSPConnection.FMOD5_DSPConnection_GetType(this.handle, out type);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return DSPConnection.FMOD5_DSPConnection_SetUserData(this.handle, userdata);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return DSPConnection.FMOD5_DSPConnection_GetUserData(this.handle, out userdata);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetInput(
      IntPtr dspconnection,
      out IntPtr input);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetOutput(
      IntPtr dspconnection,
      out IntPtr output);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_SetMix(IntPtr dspconnection, float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetMix(IntPtr dspconnection, out float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_SetMixMatrix(
      IntPtr dspconnection,
      float[] matrix,
      int outchannels,
      int inchannels,
      int inchannel_hop);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetMixMatrix(
      IntPtr dspconnection,
      float[] matrix,
      out int outchannels,
      out int inchannels,
      int inchannel_hop);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetType(
      IntPtr dspconnection,
      out DSPCONNECTION_TYPE type);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_SetUserData(
      IntPtr dspconnection,
      IntPtr userdata);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_DSPConnection_GetUserData(
      IntPtr dspconnection,
      out IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;
  }
}
