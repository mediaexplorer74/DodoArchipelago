﻿
// Type: FMOD.Sound

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct Sound
  {
    public IntPtr handle;

    public RESULT release() => Sound.FMOD5_Sound_Release(this.handle);

    public RESULT getSystemObject(out FMOD.System system)
    {
      return Sound.FMOD5_Sound_GetSystemObject(this.handle, out system.handle);
    }

    public RESULT @lock(
      uint offset,
      uint length,
      out IntPtr ptr1,
      out IntPtr ptr2,
      out uint len1,
      out uint len2)
    {
      return Sound.FMOD5_Sound_Lock(this.handle, offset, length, out ptr1, out ptr2, out len1, out len2);
    }

    public RESULT unlock(IntPtr ptr1, IntPtr ptr2, uint len1, uint len2)
    {
      return Sound.FMOD5_Sound_Unlock(this.handle, ptr1, ptr2, len1, len2);
    }

    public RESULT setDefaults(float frequency, int priority)
    {
      return Sound.FMOD5_Sound_SetDefaults(this.handle, frequency, priority);
    }

    public RESULT getDefaults(out float frequency, out int priority)
    {
      return Sound.FMOD5_Sound_GetDefaults(this.handle, out frequency, out priority);
    }

    public RESULT set3DMinMaxDistance(float min, float max)
    {
      return Sound.FMOD5_Sound_Set3DMinMaxDistance(this.handle, min, max);
    }

    public RESULT get3DMinMaxDistance(out float min, out float max)
    {
      return Sound.FMOD5_Sound_Get3DMinMaxDistance(this.handle, out min, out max);
    }

    public RESULT set3DConeSettings(
      float insideconeangle,
      float outsideconeangle,
      float outsidevolume)
    {
      return Sound.FMOD5_Sound_Set3DConeSettings(this.handle, insideconeangle, outsideconeangle, outsidevolume);
    }

    public RESULT get3DConeSettings(
      out float insideconeangle,
      out float outsideconeangle,
      out float outsidevolume)
    {
      return Sound.FMOD5_Sound_Get3DConeSettings(this.handle, out insideconeangle, out outsideconeangle, out outsidevolume);
    }

    public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
    {
      return Sound.FMOD5_Sound_Set3DCustomRolloff(this.handle, ref points, numpoints);
    }

    public RESULT get3DCustomRolloff(out IntPtr points, out int numpoints)
    {
      return Sound.FMOD5_Sound_Get3DCustomRolloff(this.handle, out points, out numpoints);
    }

    public RESULT getSubSound(int index, out Sound subsound)
    {
      return Sound.FMOD5_Sound_GetSubSound(this.handle, index, out subsound.handle);
    }

    public RESULT getSubSoundParent(out Sound parentsound)
    {
      return Sound.FMOD5_Sound_GetSubSoundParent(this.handle, out parentsound.handle);
    }

    public RESULT getName(out string name, int namelen)
    {
      IntPtr num = Marshal.AllocHGlobal(namelen);
      RESULT name1 = Sound.FMOD5_Sound_GetName(this.handle, num, namelen);
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        name = freeHelper.stringFromNative(num);
      Marshal.FreeHGlobal(num);
      return name1;
    }

    public RESULT getLength(out uint length, TIMEUNIT lengthtype)
    {
      return Sound.FMOD5_Sound_GetLength(this.handle, out length, lengthtype);
    }

    public RESULT getFormat(
      out SOUND_TYPE type,
      out SOUND_FORMAT format,
      out int channels,
      out int bits)
    {
      return Sound.FMOD5_Sound_GetFormat(this.handle, out type, out format, out channels, out bits);
    }

    public RESULT getNumSubSounds(out int numsubsounds)
    {
      return Sound.FMOD5_Sound_GetNumSubSounds(this.handle, out numsubsounds);
    }

    public RESULT getNumTags(out int numtags, out int numtagsupdated)
    {
      return Sound.FMOD5_Sound_GetNumTags(this.handle, out numtags, out numtagsupdated);
    }

    public RESULT getTag(string name, int index, out TAG tag)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return Sound.FMOD5_Sound_GetTag(this.handle, freeHelper.byteFromStringUTF8(name), index, out tag);
    }

    public RESULT getOpenState(
      out OPENSTATE openstate,
      out uint percentbuffered,
      out bool starving,
      out bool diskbusy)
    {
      return Sound.FMOD5_Sound_GetOpenState(this.handle, out openstate, out percentbuffered, out starving, out diskbusy);
    }

    public RESULT readData(IntPtr buffer, uint length, out uint read)
    {
      return Sound.FMOD5_Sound_ReadData(this.handle, buffer, length, out read);
    }

    public RESULT seekData(uint pcm) => Sound.FMOD5_Sound_SeekData(this.handle, pcm);

    public RESULT setSoundGroup(SoundGroup soundgroup)
    {
      return Sound.FMOD5_Sound_SetSoundGroup(this.handle, soundgroup.handle);
    }

    public RESULT getSoundGroup(out SoundGroup soundgroup)
    {
      return Sound.FMOD5_Sound_GetSoundGroup(this.handle, out soundgroup.handle);
    }

    public RESULT getNumSyncPoints(out int numsyncpoints)
    {
      return Sound.FMOD5_Sound_GetNumSyncPoints(this.handle, out numsyncpoints);
    }

    public RESULT getSyncPoint(int index, out IntPtr point)
    {
      return Sound.FMOD5_Sound_GetSyncPoint(this.handle, index, out point);
    }

    public RESULT getSyncPointInfo(
      IntPtr point,
      out string name,
      int namelen,
      out uint offset,
      TIMEUNIT offsettype)
    {
      IntPtr num = Marshal.AllocHGlobal(namelen);
      RESULT syncPointInfo = Sound.FMOD5_Sound_GetSyncPointInfo(this.handle, point, num, namelen, out offset, offsettype);
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        name = freeHelper.stringFromNative(num);
      Marshal.FreeHGlobal(num);
      return syncPointInfo;
    }

    public RESULT getSyncPointInfo(IntPtr point, out uint offset, TIMEUNIT offsettype)
    {
      return Sound.FMOD5_Sound_GetSyncPointInfo(this.handle, point, IntPtr.Zero, 0, out offset, offsettype);
    }

    public RESULT addSyncPoint(uint offset, TIMEUNIT offsettype, string name, out IntPtr point)
    {
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        return Sound.FMOD5_Sound_AddSyncPoint(this.handle, offset, offsettype, freeHelper.byteFromStringUTF8(name), out point);
    }

    public RESULT deleteSyncPoint(IntPtr point)
    {
      return Sound.FMOD5_Sound_DeleteSyncPoint(this.handle, point);
    }

    public RESULT setMode(MODE mode) => Sound.FMOD5_Sound_SetMode(this.handle, mode);

    public RESULT getMode(out MODE mode) => Sound.FMOD5_Sound_GetMode(this.handle, out mode);

    public RESULT setLoopCount(int loopcount)
    {
      return Sound.FMOD5_Sound_SetLoopCount(this.handle, loopcount);
    }

    public RESULT getLoopCount(out int loopcount)
    {
      return Sound.FMOD5_Sound_GetLoopCount(this.handle, out loopcount);
    }

    public RESULT setLoopPoints(
      uint loopstart,
      TIMEUNIT loopstarttype,
      uint loopend,
      TIMEUNIT loopendtype)
    {
      return Sound.FMOD5_Sound_SetLoopPoints(this.handle, loopstart, loopstarttype, loopend, loopendtype);
    }

    public RESULT getLoopPoints(
      out uint loopstart,
      TIMEUNIT loopstarttype,
      out uint loopend,
      TIMEUNIT loopendtype)
    {
      return Sound.FMOD5_Sound_GetLoopPoints(this.handle, out loopstart, loopstarttype, out loopend, loopendtype);
    }

    public RESULT getMusicNumChannels(out int numchannels)
    {
      return Sound.FMOD5_Sound_GetMusicNumChannels(this.handle, out numchannels);
    }

    public RESULT setMusicChannelVolume(int channel, float volume)
    {
      return Sound.FMOD5_Sound_SetMusicChannelVolume(this.handle, channel, volume);
    }

    public RESULT getMusicChannelVolume(int channel, out float volume)
    {
      return Sound.FMOD5_Sound_GetMusicChannelVolume(this.handle, channel, out volume);
    }

    public RESULT setMusicSpeed(float speed) => Sound.FMOD5_Sound_SetMusicSpeed(this.handle, speed);

    public RESULT getMusicSpeed(out float speed)
    {
      return Sound.FMOD5_Sound_GetMusicSpeed(this.handle, out speed);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return Sound.FMOD5_Sound_SetUserData(this.handle, userdata);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return Sound.FMOD5_Sound_GetUserData(this.handle, out userdata);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Release(IntPtr sound);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSystemObject(IntPtr sound, out IntPtr system);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Lock(
      IntPtr sound,
      uint offset,
      uint length,
      out IntPtr ptr1,
      out IntPtr ptr2,
      out uint len1,
      out uint len2);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Unlock(
      IntPtr sound,
      IntPtr ptr1,
      IntPtr ptr2,
      uint len1,
      uint len2);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetDefaults(
      IntPtr sound,
      float frequency,
      int priority);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetDefaults(
      IntPtr sound,
      out float frequency,
      out int priority);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Set3DMinMaxDistance(
      IntPtr sound,
      float min,
      float max);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Get3DMinMaxDistance(
      IntPtr sound,
      out float min,
      out float max);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Set3DConeSettings(
      IntPtr sound,
      float insideconeangle,
      float outsideconeangle,
      float outsidevolume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Get3DConeSettings(
      IntPtr sound,
      out float insideconeangle,
      out float outsideconeangle,
      out float outsidevolume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Set3DCustomRolloff(
      IntPtr sound,
      ref VECTOR points,
      int numpoints);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_Get3DCustomRolloff(
      IntPtr sound,
      out IntPtr points,
      out int numpoints);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSubSound(
      IntPtr sound,
      int index,
      out IntPtr subsound);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSubSoundParent(IntPtr sound, out IntPtr parentsound);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetName(IntPtr sound, IntPtr name, int namelen);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetLength(
      IntPtr sound,
      out uint length,
      TIMEUNIT lengthtype);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetFormat(
      IntPtr sound,
      out SOUND_TYPE type,
      out SOUND_FORMAT format,
      out int channels,
      out int bits);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetNumSubSounds(IntPtr sound, out int numsubsounds);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetNumTags(
      IntPtr sound,
      out int numtags,
      out int numtagsupdated);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetTag(
      IntPtr sound,
      byte[] name,
      int index,
      out TAG tag);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetOpenState(
      IntPtr sound,
      out OPENSTATE openstate,
      out uint percentbuffered,
      out bool starving,
      out bool diskbusy);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_ReadData(
      IntPtr sound,
      IntPtr buffer,
      uint length,
      out uint read);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SeekData(IntPtr sound, uint pcm);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetSoundGroup(IntPtr sound, IntPtr soundgroup);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSoundGroup(IntPtr sound, out IntPtr soundgroup);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetNumSyncPoints(IntPtr sound, out int numsyncpoints);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSyncPoint(
      IntPtr sound,
      int index,
      out IntPtr point);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetSyncPointInfo(
      IntPtr sound,
      IntPtr point,
      IntPtr name,
      int namelen,
      out uint offset,
      TIMEUNIT offsettype);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_AddSyncPoint(
      IntPtr sound,
      uint offset,
      TIMEUNIT offsettype,
      byte[] name,
      out IntPtr point);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_DeleteSyncPoint(IntPtr sound, IntPtr point);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetMode(IntPtr sound, MODE mode);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetMode(IntPtr sound, out MODE mode);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetLoopCount(IntPtr sound, int loopcount);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetLoopCount(IntPtr sound, out int loopcount);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetLoopPoints(
      IntPtr sound,
      uint loopstart,
      TIMEUNIT loopstarttype,
      uint loopend,
      TIMEUNIT loopendtype);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetLoopPoints(
      IntPtr sound,
      out uint loopstart,
      TIMEUNIT loopstarttype,
      out uint loopend,
      TIMEUNIT loopendtype);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetMusicNumChannels(IntPtr sound, out int numchannels);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetMusicChannelVolume(
      IntPtr sound,
      int channel,
      float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetMusicChannelVolume(
      IntPtr sound,
      int channel,
      out float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetMusicSpeed(IntPtr sound, float speed);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetMusicSpeed(IntPtr sound, out float speed);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_SetUserData(IntPtr sound, IntPtr userdata);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Sound_GetUserData(IntPtr sound, out IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;
  }
}
