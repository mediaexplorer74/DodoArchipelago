// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.System
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD.Studio
{
  public struct System
  {
    public IntPtr handle;

    public static RESULT create(out FMOD.Studio.System system)
    {
      return FMOD.Studio.System.FMOD_Studio_System_Create(out system.handle, 131077U);
    }

    public RESULT setAdvancedSettings(ADVANCEDSETTINGS settings)
    {
      settings.cbsize = Marshal.SizeOf(typeof (ADVANCEDSETTINGS));
      return FMOD.Studio.System.FMOD_Studio_System_SetAdvancedSettings(this.handle, ref settings);
    }

    public RESULT setAdvancedSettings(ADVANCEDSETTINGS settings, string encryptionKey)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        IntPtr encryptionkey = settings.encryptionkey;
        settings.encryptionkey = freeHelper.intptrFromStringUTF8(encryptionKey);
        int num = (int) this.setAdvancedSettings(settings);
        settings.encryptionkey = encryptionkey;
        return (RESULT) num;
      }
    }

    public RESULT getAdvancedSettings(out ADVANCEDSETTINGS settings)
    {
      settings.cbsize = Marshal.SizeOf(typeof (ADVANCEDSETTINGS));
      return FMOD.Studio.System.FMOD_Studio_System_GetAdvancedSettings(this.handle, out settings);
    }

    public RESULT initialize(
      int maxchannels,
      INITFLAGS studioflags,
      FMOD.INITFLAGS flags,
      IntPtr extradriverdata)
    {
      return FMOD.Studio.System.FMOD_Studio_System_Initialize(this.handle, maxchannels, studioflags, flags, extradriverdata);
    }

    public RESULT release() => FMOD.Studio.System.FMOD_Studio_System_Release(this.handle);

    public RESULT update() => FMOD.Studio.System.FMOD_Studio_System_Update(this.handle);

    public RESULT getCoreSystem(out FMOD.System coresystem)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetCoreSystem(this.handle, out coresystem.handle);
    }

    public RESULT getEvent(string path, out EventDescription _event)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetEvent(this.handle, freeHelper.byteFromStringUTF8(path), out _event.handle);
    }

    public RESULT getBus(string path, out Bus bus)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetBus(this.handle, freeHelper.byteFromStringUTF8(path), out bus.handle);
    }

    public RESULT getVCA(string path, out VCA vca)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetVCA(this.handle, freeHelper.byteFromStringUTF8(path), out vca.handle);
    }

    public RESULT getBank(string path, out Bank bank)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetBank(this.handle, freeHelper.byteFromStringUTF8(path), out bank.handle);
    }

    public RESULT getEventByID(Guid id, out EventDescription _event)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetEventByID(this.handle, ref id, out _event.handle);
    }

    public RESULT getBusByID(Guid id, out Bus bus)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetBusByID(this.handle, ref id, out bus.handle);
    }

    public RESULT getVCAByID(Guid id, out VCA vca)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetVCAByID(this.handle, ref id, out vca.handle);
    }

    public RESULT getBankByID(Guid id, out Bank bank)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetBankByID(this.handle, ref id, out bank.handle);
    }

    public RESULT getSoundInfo(string key, out SOUND_INFO info)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetSoundInfo(this.handle, freeHelper.byteFromStringUTF8(key), out info);
    }

    public RESULT getParameterDescriptionByName(string name, out PARAMETER_DESCRIPTION parameter)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetParameterDescriptionByName(this.handle, freeHelper.byteFromStringUTF8(name), out parameter);
    }

    public RESULT getParameterDescriptionByID(PARAMETER_ID id, out PARAMETER_DESCRIPTION parameter)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetParameterDescriptionByID(this.handle, id, out parameter);
    }

    public RESULT getParameterByID(PARAMETER_ID id, out float value)
    {
      return this.getParameterByID(id, out value, out float _);
    }

    public RESULT getParameterByID(PARAMETER_ID id, out float value, out float finalvalue)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetParameterByID(this.handle, id, out value, out finalvalue);
    }

    public RESULT setParameterByID(PARAMETER_ID id, float value, bool ignoreseekspeed = false)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetParameterByID(this.handle, id, value, ignoreseekspeed);
    }

    public RESULT setParametersByIDs(
      PARAMETER_ID[] ids,
      float[] values,
      int count,
      bool ignoreseekspeed = false)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetParametersByIDs(this.handle, ids, values, count, ignoreseekspeed);
    }

    public RESULT getParameterByName(string name, out float value)
    {
      return this.getParameterByName(name, out value, out float _);
    }

    public RESULT getParameterByName(string name, out float value, out float finalvalue)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_GetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), out value, out finalvalue);
    }

    public RESULT setParameterByName(string name, float value, bool ignoreseekspeed = false)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_SetParameterByName(this.handle, freeHelper.byteFromStringUTF8(name), value, ignoreseekspeed);
    }

    public RESULT lookupID(string path, out Guid id)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_LookupID(this.handle, freeHelper.byteFromStringUTF8(path), out id);
    }

    public RESULT lookupPath(Guid id, out string path)
    {
      path = (string) null;
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
      {
        IntPtr num = Marshal.AllocHGlobal(256);
        int retrieved = 0;
        RESULT result = FMOD.Studio.System.FMOD_Studio_System_LookupPath(this.handle, ref id, num, 256, out retrieved);
        if (result == RESULT.ERR_TRUNCATED)
        {
          Marshal.FreeHGlobal(num);
          num = Marshal.AllocHGlobal(retrieved);
          result = FMOD.Studio.System.FMOD_Studio_System_LookupPath(this.handle, ref id, num, retrieved, out retrieved);
        }
        if (result == RESULT.OK)
          path = freeHelper.stringFromNative(num);
        Marshal.FreeHGlobal(num);
        return result;
      }
    }

    public RESULT getNumListeners(out int numlisteners)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetNumListeners(this.handle, out numlisteners);
    }

    public RESULT setNumListeners(int numlisteners)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetNumListeners(this.handle, numlisteners);
    }

    public RESULT getListenerAttributes(int listener, out ATTRIBUTES_3D attributes)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetListenerAttributes(this.handle, listener, out attributes);
    }

    public RESULT setListenerAttributes(int listener, ATTRIBUTES_3D attributes)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetListenerAttributes(this.handle, listener, ref attributes);
    }

    public RESULT getListenerWeight(int listener, out float weight)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetListenerWeight(this.handle, listener, out weight);
    }

    public RESULT setListenerWeight(int listener, float weight)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetListenerWeight(this.handle, listener, weight);
    }

    public RESULT loadBankFile(string filename, LOAD_BANK_FLAGS flags, out Bank bank)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_LoadBankFile(this.handle, freeHelper.byteFromStringUTF8(filename), flags, out bank.handle);
    }

    public RESULT loadBankMemory(byte[] buffer, LOAD_BANK_FLAGS flags, out Bank bank)
    {
      GCHandle gcHandle = GCHandle.Alloc((object) buffer, GCHandleType.Pinned);
      int num = (int) FMOD.Studio.System.FMOD_Studio_System_LoadBankMemory(this.handle, gcHandle.AddrOfPinnedObject(), buffer.Length, LOAD_MEMORY_MODE.LOAD_MEMORY, flags, out bank.handle);
      gcHandle.Free();
      return (RESULT) num;
    }

    public RESULT loadBankCustom(BANK_INFO info, LOAD_BANK_FLAGS flags, out Bank bank)
    {
      info.size = Marshal.SizeOf((object) info);
      return FMOD.Studio.System.FMOD_Studio_System_LoadBankCustom(this.handle, ref info, flags, out bank.handle);
    }

    public RESULT unloadAll() => FMOD.Studio.System.FMOD_Studio_System_UnloadAll(this.handle);

    public RESULT flushCommands() => FMOD.Studio.System.FMOD_Studio_System_FlushCommands(this.handle);

    public RESULT flushSampleLoading() => FMOD.Studio.System.FMOD_Studio_System_FlushSampleLoading(this.handle);

    public RESULT startCommandCapture(string filename, COMMANDCAPTURE_FLAGS flags)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_StartCommandCapture(this.handle, freeHelper.byteFromStringUTF8(filename), flags);
    }

    public RESULT stopCommandCapture() => FMOD.Studio.System.FMOD_Studio_System_StopCommandCapture(this.handle);

    public RESULT loadCommandReplay(
      string filename,
      COMMANDREPLAY_FLAGS flags,
      out CommandReplay replay)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return FMOD.Studio.System.FMOD_Studio_System_LoadCommandReplay(this.handle, freeHelper.byteFromStringUTF8(filename), flags, out replay.handle);
    }

    public RESULT getBankCount(out int count)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetBankCount(this.handle, out count);
    }

    public RESULT getBankList(out Bank[] array)
    {
      array = (Bank[]) null;
      int count1;
      RESULT bankCount = FMOD.Studio.System.FMOD_Studio_System_GetBankCount(this.handle, out count1);
      if (bankCount != RESULT.OK)
        return bankCount;
      if (count1 == 0)
      {
        array = new Bank[0];
        return bankCount;
      }
      IntPtr[] array1 = new IntPtr[count1];
      int count2;
      RESULT bankList = FMOD.Studio.System.FMOD_Studio_System_GetBankList(this.handle, array1, count1, out count2);
      if (bankList != RESULT.OK)
        return bankList;
      if (count2 > count1)
        count2 = count1;
      array = new Bank[count2];
      for (int index = 0; index < count2; ++index)
        array[index].handle = array1[index];
      return RESULT.OK;
    }

    public RESULT getParameterDescriptionCount(out int count)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetParameterDescriptionCount(this.handle, out count);
    }

    public RESULT getParameterDescriptionList(out PARAMETER_DESCRIPTION[] array)
    {
      array = (PARAMETER_DESCRIPTION[]) null;
      int count1;
      RESULT descriptionCount = FMOD.Studio.System.FMOD_Studio_System_GetParameterDescriptionCount(this.handle, out count1);
      if (descriptionCount != RESULT.OK)
        return descriptionCount;
      if (count1 == 0)
      {
        array = new PARAMETER_DESCRIPTION[0];
        return RESULT.OK;
      }
      PARAMETER_DESCRIPTION[] array1 = new PARAMETER_DESCRIPTION[count1];
      int count2;
      RESULT parameterDescriptionList = FMOD.Studio.System.FMOD_Studio_System_GetParameterDescriptionList(this.handle, array1, count1, out count2);
      if (parameterDescriptionList != RESULT.OK)
        return parameterDescriptionList;
      if (count2 != count1)
        Array.Resize<PARAMETER_DESCRIPTION>(ref array1, count2);
      array = array1;
      return RESULT.OK;
    }

    public RESULT getCPUUsage(out CPU_USAGE usage)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetCPUUsage(this.handle, out usage);
    }

    public RESULT getBufferUsage(out BUFFER_USAGE usage)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetBufferUsage(this.handle, out usage);
    }

    public RESULT resetBufferUsage() => FMOD.Studio.System.FMOD_Studio_System_ResetBufferUsage(this.handle);

    public RESULT setCallback(SYSTEM_CALLBACK callback, SYSTEM_CALLBACK_TYPE callbackmask = SYSTEM_CALLBACK_TYPE.ALL)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetCallback(this.handle, callback, callbackmask);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return FMOD.Studio.System.FMOD_Studio_System_GetUserData(this.handle, out userdata);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return FMOD.Studio.System.FMOD_Studio_System_SetUserData(this.handle, userdata);
    }

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_Create(out IntPtr system, uint headerversion);

    [DllImport("fmodstudio")]
    private static extern bool FMOD_Studio_System_IsValid(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetAdvancedSettings(
      IntPtr system,
      ref ADVANCEDSETTINGS settings);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetAdvancedSettings(
      IntPtr system,
      out ADVANCEDSETTINGS settings);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_Initialize(
      IntPtr system,
      int maxchannels,
      INITFLAGS studioflags,
      FMOD.INITFLAGS flags,
      IntPtr extradriverdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_Release(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_Update(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetCoreSystem(
      IntPtr system,
      out IntPtr coresystem);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetEvent(
      IntPtr system,
      byte[] path,
      out IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBus(
      IntPtr system,
      byte[] path,
      out IntPtr bus);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetVCA(
      IntPtr system,
      byte[] path,
      out IntPtr vca);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBank(
      IntPtr system,
      byte[] path,
      out IntPtr bank);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetEventByID(
      IntPtr system,
      ref Guid id,
      out IntPtr _event);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBusByID(
      IntPtr system,
      ref Guid id,
      out IntPtr bus);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetVCAByID(
      IntPtr system,
      ref Guid id,
      out IntPtr vca);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBankByID(
      IntPtr system,
      ref Guid id,
      out IntPtr bank);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetSoundInfo(
      IntPtr system,
      byte[] key,
      out SOUND_INFO info);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterDescriptionByName(
      IntPtr system,
      byte[] name,
      out PARAMETER_DESCRIPTION parameter);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterDescriptionByID(
      IntPtr system,
      PARAMETER_ID id,
      out PARAMETER_DESCRIPTION parameter);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterByID(
      IntPtr system,
      PARAMETER_ID id,
      out float value,
      out float finalvalue);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetParameterByID(
      IntPtr system,
      PARAMETER_ID id,
      float value,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetParametersByIDs(
      IntPtr system,
      PARAMETER_ID[] ids,
      float[] values,
      int count,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterByName(
      IntPtr system,
      byte[] name,
      out float value,
      out float finalvalue);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetParameterByName(
      IntPtr system,
      byte[] name,
      float value,
      bool ignoreseekspeed);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LookupID(
      IntPtr system,
      byte[] path,
      out Guid id);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LookupPath(
      IntPtr system,
      ref Guid id,
      IntPtr path,
      int size,
      out int retrieved);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetNumListeners(
      IntPtr system,
      out int numlisteners);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetNumListeners(IntPtr system, int numlisteners);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetListenerAttributes(
      IntPtr system,
      int listener,
      out ATTRIBUTES_3D attributes);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetListenerAttributes(
      IntPtr system,
      int listener,
      ref ATTRIBUTES_3D attributes);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetListenerWeight(
      IntPtr system,
      int listener,
      out float weight);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetListenerWeight(
      IntPtr system,
      int listener,
      float weight);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LoadBankFile(
      IntPtr system,
      byte[] filename,
      LOAD_BANK_FLAGS flags,
      out IntPtr bank);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LoadBankMemory(
      IntPtr system,
      IntPtr buffer,
      int length,
      LOAD_MEMORY_MODE mode,
      LOAD_BANK_FLAGS flags,
      out IntPtr bank);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LoadBankCustom(
      IntPtr system,
      ref BANK_INFO info,
      LOAD_BANK_FLAGS flags,
      out IntPtr bank);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_UnloadAll(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_FlushCommands(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_FlushSampleLoading(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_StartCommandCapture(
      IntPtr system,
      byte[] filename,
      COMMANDCAPTURE_FLAGS flags);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_StopCommandCapture(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_LoadCommandReplay(
      IntPtr system,
      byte[] filename,
      COMMANDREPLAY_FLAGS flags,
      out IntPtr replay);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBankCount(IntPtr system, out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBankList(
      IntPtr system,
      IntPtr[] array,
      int capacity,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterDescriptionCount(
      IntPtr system,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetParameterDescriptionList(
      IntPtr system,
      [Out] PARAMETER_DESCRIPTION[] array,
      int capacity,
      out int count);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetCPUUsage(IntPtr system, out CPU_USAGE usage);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetBufferUsage(
      IntPtr system,
      out BUFFER_USAGE usage);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_ResetBufferUsage(IntPtr system);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetCallback(
      IntPtr system,
      SYSTEM_CALLBACK callback,
      SYSTEM_CALLBACK_TYPE callbackmask);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_GetUserData(IntPtr system, out IntPtr userdata);

    [DllImport("fmodstudio")]
    private static extern RESULT FMOD_Studio_System_SetUserData(IntPtr system, IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;

    public bool isValid() => this.hasHandle() && FMOD.Studio.System.FMOD_Studio_System_IsValid(this.handle);
  }
}
