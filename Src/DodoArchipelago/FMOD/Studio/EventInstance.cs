﻿// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.EventInstance
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct EventInstance
  {
    public IntPtr handle;

    public RESULT getDescription(out EventDescription description)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetDescription(this.handle, out description.handle);
    }

    public RESULT getVolume(out float volume) => this.getVolume(out volume, out float _);

    public RESULT getVolume(out float volume, out float finalvolume)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetVolume(this.handle, out volume, out finalvolume);
    }

    public RESULT setVolume(float volume)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetVolume(this.handle, volume);
    }

    public RESULT getPitch(out float pitch) => this.getPitch(out pitch, out float _);

    public RESULT getPitch(out float pitch, out float finalpitch)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetPitch(this.handle, out pitch, out finalpitch);
    }

    public RESULT setPitch(float pitch)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetPitch(this.handle, pitch);
    }

    public RESULT get3DAttributes(out ATTRIBUTES_3D attributes)
    {
      return EventInstance.FMOD_Studio_EventInstance_Get3DAttributes(this.handle, out attributes);
    }

    public RESULT set3DAttributes(ATTRIBUTES_3D attributes)
    {
      return EventInstance.FMOD_Studio_EventInstance_Set3DAttributes(this.handle, ref attributes);
    }

    public RESULT getListenerMask(out uint mask)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetListenerMask(this.handle, out mask);
    }

    public RESULT setListenerMask(uint mask)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetListenerMask(this.handle, mask);
    }

    public RESULT getProperty(EVENT_PROPERTY index, out float value)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetProperty(this.handle, index, out value);
    }

    public RESULT setProperty(EVENT_PROPERTY index, float value)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetProperty(this.handle, index, value);
    }

    public RESULT getReverbLevel(int index, out float level)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetReverbLevel(this.handle, index, out level);
    }

    public RESULT setReverbLevel(int index, float level)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetReverbLevel(this.handle, index, level);
    }

    public RESULT getPaused(out bool paused)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetPaused(this.handle, out paused);
    }

    public RESULT setPaused(bool paused)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetPaused(this.handle, paused);
    }

    public RESULT start() => EventInstance.FMOD_Studio_EventInstance_Start(this.handle);

    public RESULT stop(STOP_MODE mode)
    {
      return EventInstance.FMOD_Studio_EventInstance_Stop(this.handle, mode);
    }

    public RESULT getTimelinePosition(out int position)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetTimelinePosition(this.handle, out position);
    }

    public RESULT setTimelinePosition(int position)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetTimelinePosition(this.handle, position);
    }

    public RESULT getPlaybackState(out PLAYBACK_STATE state)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetPlaybackState(this.handle, out state);
    }

    public RESULT getChannelGroup(out ChannelGroup group)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetChannelGroup(this.handle, out group.handle);
    }

    public RESULT release() => EventInstance.FMOD_Studio_EventInstance_Release(this.handle);

    public RESULT isVirtual(out bool virtualstate)
    {
      return EventInstance.FMOD_Studio_EventInstance_IsVirtual(this.handle, out virtualstate);
    }

    public RESULT getParameterByID(PARAMETER_ID id, out float value)
    {
      return this.getParameterByID(id, out value, out float _);
    }

    public RESULT getParameterByID(PARAMETER_ID id, out float value, out float finalvalue)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetParameterByID(this.handle, id, out value, out finalvalue);
    }

    public RESULT setParameterByID(PARAMETER_ID id, float value, bool ignoreseekspeed = false)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetParameterByID(this.handle, id, value, ignoreseekspeed);
    }

    public RESULT setParametersByIDs(
      PARAMETER_ID[] ids,
      float[] values,
      int count,
      bool ignoreseekspeed = false)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetParametersByIDs(this.handle, ids, values, count, ignoreseekspeed);
    }

    public RESULT getParameterByName(string name, out float value)
    {
      return this.getParameterByName(name, out value, out float _);
    }

    public RESULT getParameterByName(string name, out float value, out float finalvalue)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return EventInstance.FMOD_Studio_EventInstance_GetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), out value, out finalvalue);
    }

    public RESULT setParameterByName(string name, float value, bool ignoreseekspeed = false)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return EventInstance.FMOD_Studio_EventInstance_SetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), value, ignoreseekspeed);
    }

    public RESULT triggerCue() => EventInstance.FMOD_Studio_EventInstance_TriggerCue(this.handle);

    public RESULT setCallback(EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask = EVENT_CALLBACK_TYPE.ALL)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetCallback(this.handle, callback, callbackmask);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetUserData(this.handle, out userdata);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return EventInstance.FMOD_Studio_EventInstance_SetUserData(this.handle, userdata);
    }

    public RESULT getCPUUsage(out uint exclusive, out uint inclusive)
    {
      return EventInstance.FMOD_Studio_EventInstance_GetCPUUsage(this.handle, out exclusive, out inclusive);
    }

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_EventInstance_IsValid(IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetDescription(
      IntPtr _event,
      out IntPtr description);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetVolume(
      IntPtr _event,
      out float volume,
      out float finalvolume);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetVolume(IntPtr _event, float volume);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetPitch(
      IntPtr _event,
      out float pitch,
      out float finalpitch);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetPitch(IntPtr _event, float pitch);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_Get3DAttributes(
      IntPtr _event,
      out ATTRIBUTES_3D attributes);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_Set3DAttributes(
      IntPtr _event,
      ref ATTRIBUTES_3D attributes);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetListenerMask(
      IntPtr _event,
      out uint mask);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetListenerMask(IntPtr _event, uint mask);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetProperty(
      IntPtr _event,
      EVENT_PROPERTY index,
      out float value);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetProperty(
      IntPtr _event,
      EVENT_PROPERTY index,
      float value);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetReverbLevel(
      IntPtr _event,
      int index,
      out float level);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetReverbLevel(
      IntPtr _event,
      int index,
      float level);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetPaused(IntPtr _event, out bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetPaused(IntPtr _event, bool paused);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_Start(IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_Stop(IntPtr _event, STOP_MODE mode);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetTimelinePosition(
      IntPtr _event,
      out int position);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetTimelinePosition(
      IntPtr _event,
      int position);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetPlaybackState(
      IntPtr _event,
      out PLAYBACK_STATE state);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetChannelGroup(
      IntPtr _event,
      out IntPtr group);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_Release(IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_IsVirtual(
      IntPtr _event,
      out bool virtualstate);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetParameterByName(
      IntPtr _event,
      byte[] name,
      out float value,
      out float finalvalue);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetParameterByName(
      IntPtr _event,
      byte[] name,
      float value,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetParameterByID(
      IntPtr _event,
      PARAMETER_ID id,
      out float value,
      out float finalvalue);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetParameterByID(
      IntPtr _event,
      PARAMETER_ID id,
      float value,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetParametersByIDs(
      IntPtr _event,
      PARAMETER_ID[] ids,
      float[] values,
      int count,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_TriggerCue(IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetCallback(
      IntPtr _event,
      EVENT_CALLBACK callback,
      EVENT_CALLBACK_TYPE callbackmask);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetUserData(
      IntPtr _event,
      out IntPtr userdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_SetUserData(
      IntPtr _event,
      IntPtr userdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventInstance_GetCPUUsage(
      IntPtr _event,
      out uint exclusive,
      out uint inclusive);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid()
    {
      return this.hasHandle() && EventInstance.FMOD_Studio_EventInstance_IsValid(this.handle);
    }
  }
}
