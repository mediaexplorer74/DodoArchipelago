// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.EventDescription
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct EventDescription
  {
    public IntPtr handle;

    public RESULT getID(out Guid id)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetID(this.handle, out id);
    }

    public RESULT getPath(out string path)
    {
      path = (string) null;
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        IntPtr num = Marshal.AllocHGlobal(256);
        int retrieved = 0;
        RESULT path1 = EventDescription.FMOD_Studio_EventDescription_GetPath(this.handle, num, 256, out retrieved);
        if (path1 == RESULT.ERR_TRUNCATED)
        {
          Marshal.FreeHGlobal(num);
          num = Marshal.AllocHGlobal(retrieved);
          path1 = EventDescription.FMOD_Studio_EventDescription_GetPath(this.handle, num, retrieved, out retrieved);
        }
        if (path1 == RESULT.OK)
          path = freeHelper.stringFromNative(num);
        Marshal.FreeHGlobal(num);
        return path1;
      }
    }

    public RESULT getParameterDescriptionCount(out int count)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionCount(this.handle, out count);
    }

    public RESULT getParameterDescriptionByIndex(int index, out PARAMETER_DESCRIPTION parameter)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByIndex(this.handle, index, out parameter);
    }

    public RESULT getParameterDescriptionByName(string name, out PARAMETER_DESCRIPTION parameter)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByName(this.handle, freeHelper.byteFromStringUTF8(name), out parameter);
    }

    public RESULT getParameterDescriptionByID(PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetParameterDescriptionByID(this.handle, id, out parameter);
    }

    public RESULT getUserPropertyCount(out int count)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetUserPropertyCount(this.handle, out count);
    }

    public RESULT getUserPropertyByIndex(int index, out USER_PROPERTY property)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetUserPropertyByIndex(this.handle, index, out property);
    }

    public RESULT getUserProperty(string name, out USER_PROPERTY property)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return EventDescription.FMOD_Studio_EventDescription_GetUserProperty(this.handle, freeHelper.byteFromStringUTF8(name), out property);
    }

    public RESULT getLength(out int length)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetLength(this.handle, out length);
    }

    public RESULT getMinimumDistance(out float distance)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetMinimumDistance(this.handle, out distance);
    }

    public RESULT getMaximumDistance(out float distance)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetMaximumDistance(this.handle, out distance);
    }

    public RESULT getSoundSize(out float size)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetSoundSize(this.handle, out size);
    }

    public RESULT isSnapshot(out bool snapshot)
    {
      return EventDescription.FMOD_Studio_EventDescription_IsSnapshot(this.handle, out snapshot);
    }

    public RESULT isOneshot(out bool oneshot)
    {
      return EventDescription.FMOD_Studio_EventDescription_IsOneshot(this.handle, out oneshot);
    }

    public RESULT isStream(out bool isStream)
    {
      return EventDescription.FMOD_Studio_EventDescription_IsStream(this.handle, out isStream);
    }

    public RESULT is3D(out bool is3D)
    {
      return EventDescription.FMOD_Studio_EventDescription_Is3D(this.handle, out is3D);
    }

    public RESULT hasCue(out bool cue)
    {
      return EventDescription.FMOD_Studio_EventDescription_HasCue(this.handle, out cue);
    }

    public RESULT createInstance(out EventInstance instance)
    {
      return EventDescription.FMOD_Studio_EventDescription_CreateInstance(this.handle, out instance.handle);
    }

    public RESULT getInstanceCount(out int count)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetInstanceCount(this.handle, out count);
    }

    public RESULT getInstanceList(out EventInstance[] array)
    {
      array = (EventInstance[]) null;
      int count1;
      RESULT instanceCount = EventDescription.FMOD_Studio_EventDescription_GetInstanceCount(this.handle, out count1);
      if (instanceCount != RESULT.OK)
        return instanceCount;
      if (count1 == 0)
      {
        array = new EventInstance[0];
        return instanceCount;
      }
      IntPtr[] array1 = new IntPtr[count1];
      int count2;
      RESULT instanceList = EventDescription.FMOD_Studio_EventDescription_GetInstanceList(this.handle, array1, count1, out count2);
      if (instanceList != RESULT.OK)
        return instanceList;
      if (count2 > count1)
        count2 = count1;
      array = new EventInstance[count2];
      for (int index = 0; index < count2; ++index)
        array[index].handle = array1[index];
      return RESULT.OK;
    }

    public RESULT loadSampleData()
    {
      return EventDescription.FMOD_Studio_EventDescription_LoadSampleData(this.handle);
    }

    public RESULT unloadSampleData()
    {
      return EventDescription.FMOD_Studio_EventDescription_UnloadSampleData(this.handle);
    }

    public RESULT getSampleLoadingState(out LOADING_STATE state)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetSampleLoadingState(this.handle, out state);
    }

    public RESULT releaseAllInstances()
    {
      return EventDescription.FMOD_Studio_EventDescription_ReleaseAllInstances(this.handle);
    }

    public RESULT setCallback(EVENT_CALLBACK callback, EVENT_CALLBACK_TYPE callbackmask = EVENT_CALLBACK_TYPE.ALL)
    {
      return EventDescription.FMOD_Studio_EventDescription_SetCallback(this.handle, callback, callbackmask);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return EventDescription.FMOD_Studio_EventDescription_GetUserData(this.handle, out userdata);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return EventDescription.FMOD_Studio_EventDescription_SetUserData(this.handle, userdata);
    }

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_EventDescription_IsValid(IntPtr eventdescription);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetID(
      IntPtr eventdescription,
      out Guid id);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetPath(
      IntPtr eventdescription,
      IntPtr path,
      int size,
      out int retrieved);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionCount(
      IntPtr eventdescription,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByIndex(
      IntPtr eventdescription,
      int index,
      out PARAMETER_DESCRIPTION parameter);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByName(
      IntPtr eventdescription,
      byte[] name,
      out PARAMETER_DESCRIPTION parameter);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetParameterDescriptionByID(
      IntPtr eventdescription,
      PARAMETER_ID id,
      out PARAMETER_DESCRIPTION parameter);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetUserPropertyCount(
      IntPtr eventdescription,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetUserPropertyByIndex(
      IntPtr eventdescription,
      int index,
      out USER_PROPERTY property);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetUserProperty(
      IntPtr eventdescription,
      byte[] name,
      out USER_PROPERTY property);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetLength(
      IntPtr eventdescription,
      out int length);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetMinimumDistance(
      IntPtr eventdescription,
      out float distance);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetMaximumDistance(
      IntPtr eventdescription,
      out float distance);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetSoundSize(
      IntPtr eventdescription,
      out float size);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_IsSnapshot(
      IntPtr eventdescription,
      out bool snapshot);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_IsOneshot(
      IntPtr eventdescription,
      out bool oneshot);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_IsStream(
      IntPtr eventdescription,
      out bool isStream);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_Is3D(
      IntPtr eventdescription,
      out bool is3D);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_HasCue(
      IntPtr eventdescription,
      out bool cue);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_CreateInstance(
      IntPtr eventdescription,
      out IntPtr instance);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetInstanceCount(
      IntPtr eventdescription,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetInstanceList(
      IntPtr eventdescription,
      IntPtr[] array,
      int capacity,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_LoadSampleData(IntPtr eventdescription);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_UnloadSampleData(
      IntPtr eventdescription);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetSampleLoadingState(
      IntPtr eventdescription,
      out LOADING_STATE state);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_ReleaseAllInstances(
      IntPtr eventdescription);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_SetCallback(
      IntPtr eventdescription,
      EVENT_CALLBACK callback,
      EVENT_CALLBACK_TYPE callbackmask);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_GetUserData(
      IntPtr eventdescription,
      out IntPtr userdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_EventDescription_SetUserData(
      IntPtr eventdescription,
      IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid()
    {
      return this.hasHandle() && EventDescription.FMOD_Studio_EventDescription_IsValid(this.handle);
    }
  }
}
