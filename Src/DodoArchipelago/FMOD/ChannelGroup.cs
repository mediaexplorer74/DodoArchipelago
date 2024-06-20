// Decompiled with JetBrains decompiler
// Type: FMOD.ChannelGroup
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct ChannelGroup : IChannelControl
  {
    public IntPtr handle;

    public RESULT release() => ChannelGroup.FMOD5_ChannelGroup_Release(this.handle);

    public RESULT addGroup(ChannelGroup group, bool propagatedspclock = true)
    {
      return ChannelGroup.FMOD5_ChannelGroup_AddGroup(this.handle, group.handle, propagatedspclock, IntPtr.Zero);
    }

    public RESULT addGroup(
      ChannelGroup group,
      bool propagatedspclock,
      out DSPConnection connection)
    {
      return ChannelGroup.FMOD5_ChannelGroup_AddGroup(this.handle, group.handle, propagatedspclock, out connection.handle);
    }

    public RESULT getNumGroups(out int numgroups)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetNumGroups(this.handle, out numgroups);
    }

    public RESULT getGroup(int index, out ChannelGroup group)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetGroup(this.handle, index, out group.handle);
    }

    public RESULT getParentGroup(out ChannelGroup group)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetParentGroup(this.handle, out group.handle);
    }

    public RESULT getName(out string name, int namelen)
    {
      IntPtr num = Marshal.AllocHGlobal(namelen);
      RESULT name1 = ChannelGroup.FMOD5_ChannelGroup_GetName(this.handle, num, namelen);
      using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
        name = freeHelper.stringFromNative(num);
      Marshal.FreeHGlobal(num);
      return name1;
    }

    public RESULT getNumChannels(out int numchannels)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetNumChannels(this.handle, out numchannels);
    }

    public RESULT getChannel(int index, out Channel channel)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetChannel(this.handle, index, out channel.handle);
    }

    public RESULT getSystemObject(out FMOD.System system)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetSystemObject(this.handle, out system.handle);
    }

    public RESULT stop() => ChannelGroup.FMOD5_ChannelGroup_Stop(this.handle);

    public RESULT setPaused(bool paused)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetPaused(this.handle, paused);
    }

    public RESULT getPaused(out bool paused)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetPaused(this.handle, out paused);
    }

    public RESULT setVolume(float volume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetVolume(this.handle, volume);
    }

    public RESULT getVolume(out float volume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetVolume(this.handle, out volume);
    }

    public RESULT setVolumeRamp(bool ramp)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetVolumeRamp(this.handle, ramp);
    }

    public RESULT getVolumeRamp(out bool ramp)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetVolumeRamp(this.handle, out ramp);
    }

    public RESULT getAudibility(out float audibility)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetAudibility(this.handle, out audibility);
    }

    public RESULT setPitch(float pitch)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetPitch(this.handle, pitch);
    }

    public RESULT getPitch(out float pitch)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetPitch(this.handle, out pitch);
    }

    public RESULT setMute(bool mute) => ChannelGroup.FMOD5_ChannelGroup_SetMute(this.handle, mute);

    public RESULT getMute(out bool mute)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetMute(this.handle, out mute);
    }

    public RESULT setReverbProperties(int instance, float wet)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetReverbProperties(this.handle, instance, wet);
    }

    public RESULT getReverbProperties(int instance, out float wet)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetReverbProperties(this.handle, instance, out wet);
    }

    public RESULT setLowPassGain(float gain)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetLowPassGain(this.handle, gain);
    }

    public RESULT getLowPassGain(out float gain)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetLowPassGain(this.handle, out gain);
    }

    public RESULT setMode(MODE mode) => ChannelGroup.FMOD5_ChannelGroup_SetMode(this.handle, mode);

    public RESULT getMode(out MODE mode)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetMode(this.handle, out mode);
    }

    public RESULT setCallback(CHANNELCONTROL_CALLBACK callback)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetCallback(this.handle, callback);
    }

    public RESULT isPlaying(out bool isplaying)
    {
      return ChannelGroup.FMOD5_ChannelGroup_IsPlaying(this.handle, out isplaying);
    }

    public RESULT setPan(float pan) => ChannelGroup.FMOD5_ChannelGroup_SetPan(this.handle, pan);

    public RESULT setMixLevelsOutput(
      float frontleft,
      float frontright,
      float center,
      float lfe,
      float surroundleft,
      float surroundright,
      float backleft,
      float backright)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetMixLevelsOutput(this.handle, frontleft, frontright, center, lfe, surroundleft, surroundright, backleft, backright);
    }

    public RESULT setMixLevelsInput(float[] levels, int numlevels)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetMixLevelsInput(this.handle, levels, numlevels);
    }

    public RESULT setMixMatrix(float[] matrix, int outchannels, int inchannels, int inchannel_hop)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetMixMatrix(this.handle, matrix, outchannels, inchannels, inchannel_hop);
    }

    public RESULT getMixMatrix(
      float[] matrix,
      out int outchannels,
      out int inchannels,
      int inchannel_hop)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetMixMatrix(this.handle, matrix, out outchannels, out inchannels, inchannel_hop);
    }

    public RESULT getDSPClock(out ulong dspclock, out ulong parentclock)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetDSPClock(this.handle, out dspclock, out parentclock);
    }

    public RESULT setDelay(ulong dspclock_start, ulong dspclock_end, bool stopchannels)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetDelay(this.handle, dspclock_start, dspclock_end, stopchannels);
    }

    public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetDelay(this.handle, out dspclock_start, out dspclock_end, IntPtr.Zero);
    }

    public RESULT getDelay(out ulong dspclock_start, out ulong dspclock_end, out bool stopchannels)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetDelay(this.handle, out dspclock_start, out dspclock_end, out stopchannels);
    }

    public RESULT addFadePoint(ulong dspclock, float volume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_AddFadePoint(this.handle, dspclock, volume);
    }

    public RESULT setFadePointRamp(ulong dspclock, float volume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetFadePointRamp(this.handle, dspclock, volume);
    }

    public RESULT removeFadePoints(ulong dspclock_start, ulong dspclock_end)
    {
      return ChannelGroup.FMOD5_ChannelGroup_RemoveFadePoints(this.handle, dspclock_start, dspclock_end);
    }

    public RESULT getFadePoints(ref uint numpoints, ulong[] point_dspclock, float[] point_volume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetFadePoints(this.handle, ref numpoints, point_dspclock, point_volume);
    }

    public RESULT getDSP(int index, out DSP dsp)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetDSP(this.handle, index, out dsp.handle);
    }

    public RESULT addDSP(int index, DSP dsp)
    {
      return ChannelGroup.FMOD5_ChannelGroup_AddDSP(this.handle, index, dsp.handle);
    }

    public RESULT removeDSP(DSP dsp)
    {
      return ChannelGroup.FMOD5_ChannelGroup_RemoveDSP(this.handle, dsp.handle);
    }

    public RESULT getNumDSPs(out int numdsps)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetNumDSPs(this.handle, out numdsps);
    }

    public RESULT setDSPIndex(DSP dsp, int index)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetDSPIndex(this.handle, dsp.handle, index);
    }

    public RESULT getDSPIndex(DSP dsp, out int index)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetDSPIndex(this.handle, dsp.handle, out index);
    }

    public RESULT set3DAttributes(ref VECTOR pos, ref VECTOR vel)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DAttributes(this.handle, ref pos, ref vel);
    }

    public RESULT get3DAttributes(out VECTOR pos, out VECTOR vel)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DAttributes(this.handle, out pos, out vel);
    }

    public RESULT set3DMinMaxDistance(float mindistance, float maxdistance)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DMinMaxDistance(this.handle, mindistance, maxdistance);
    }

    public RESULT get3DMinMaxDistance(out float mindistance, out float maxdistance)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DMinMaxDistance(this.handle, out mindistance, out maxdistance);
    }

    public RESULT set3DConeSettings(
      float insideconeangle,
      float outsideconeangle,
      float outsidevolume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DConeSettings(this.handle, insideconeangle, outsideconeangle, outsidevolume);
    }

    public RESULT get3DConeSettings(
      out float insideconeangle,
      out float outsideconeangle,
      out float outsidevolume)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DConeSettings(this.handle, out insideconeangle, out outsideconeangle, out outsidevolume);
    }

    public RESULT set3DConeOrientation(ref VECTOR orientation)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DConeOrientation(this.handle, ref orientation);
    }

    public RESULT get3DConeOrientation(out VECTOR orientation)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DConeOrientation(this.handle, out orientation);
    }

    public RESULT set3DCustomRolloff(ref VECTOR points, int numpoints)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DCustomRolloff(this.handle, ref points, numpoints);
    }

    public RESULT get3DCustomRolloff(out IntPtr points, out int numpoints)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DCustomRolloff(this.handle, out points, out numpoints);
    }

    public RESULT set3DOcclusion(float directocclusion, float reverbocclusion)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DOcclusion(this.handle, directocclusion, reverbocclusion);
    }

    public RESULT get3DOcclusion(out float directocclusion, out float reverbocclusion)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DOcclusion(this.handle, out directocclusion, out reverbocclusion);
    }

    public RESULT set3DSpread(float angle)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DSpread(this.handle, angle);
    }

    public RESULT get3DSpread(out float angle)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DSpread(this.handle, out angle);
    }

    public RESULT set3DLevel(float level)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DLevel(this.handle, level);
    }

    public RESULT get3DLevel(out float level)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DLevel(this.handle, out level);
    }

    public RESULT set3DDopplerLevel(float level)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DDopplerLevel(this.handle, level);
    }

    public RESULT get3DDopplerLevel(out float level)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DDopplerLevel(this.handle, out level);
    }

    public RESULT set3DDistanceFilter(bool custom, float customLevel, float centerFreq)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Set3DDistanceFilter(this.handle, custom, customLevel, centerFreq);
    }

    public RESULT get3DDistanceFilter(out bool custom, out float customLevel, out float centerFreq)
    {
      return ChannelGroup.FMOD5_ChannelGroup_Get3DDistanceFilter(this.handle, out custom, out customLevel, out centerFreq);
    }

    public RESULT setUserData(IntPtr userdata)
    {
      return ChannelGroup.FMOD5_ChannelGroup_SetUserData(this.handle, userdata);
    }

    public RESULT getUserData(out IntPtr userdata)
    {
      return ChannelGroup.FMOD5_ChannelGroup_GetUserData(this.handle, out userdata);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Release(IntPtr channelgroup);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_AddGroup(
      IntPtr channelgroup,
      IntPtr group,
      bool propagatedspclock,
      IntPtr zero);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_AddGroup(
      IntPtr channelgroup,
      IntPtr group,
      bool propagatedspclock,
      out IntPtr connection);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetNumGroups(
      IntPtr channelgroup,
      out int numgroups);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetGroup(
      IntPtr channelgroup,
      int index,
      out IntPtr group);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetParentGroup(
      IntPtr channelgroup,
      out IntPtr group);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetName(
      IntPtr channelgroup,
      IntPtr name,
      int namelen);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetNumChannels(
      IntPtr channelgroup,
      out int numchannels);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetChannel(
      IntPtr channelgroup,
      int index,
      out IntPtr channel);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetSystemObject(
      IntPtr channelgroup,
      out IntPtr system);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Stop(IntPtr channelgroup);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetPaused(IntPtr channelgroup, bool paused);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetPaused(IntPtr channelgroup, out bool paused);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetVolume(IntPtr channelgroup, float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetVolume(IntPtr channelgroup, out float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetVolumeRamp(IntPtr channelgroup, bool ramp);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetVolumeRamp(
      IntPtr channelgroup,
      out bool ramp);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetAudibility(
      IntPtr channelgroup,
      out float audibility);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetPitch(IntPtr channelgroup, float pitch);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetPitch(IntPtr channelgroup, out float pitch);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetMute(IntPtr channelgroup, bool mute);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetMute(IntPtr channelgroup, out bool mute);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetReverbProperties(
      IntPtr channelgroup,
      int instance,
      float wet);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetReverbProperties(
      IntPtr channelgroup,
      int instance,
      out float wet);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetLowPassGain(IntPtr channelgroup, float gain);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetLowPassGain(
      IntPtr channelgroup,
      out float gain);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetMode(IntPtr channelgroup, MODE mode);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetMode(IntPtr channelgroup, out MODE mode);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetCallback(
      IntPtr channelgroup,
      CHANNELCONTROL_CALLBACK callback);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_IsPlaying(
      IntPtr channelgroup,
      out bool isplaying);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetPan(IntPtr channelgroup, float pan);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetMixLevelsOutput(
      IntPtr channelgroup,
      float frontleft,
      float frontright,
      float center,
      float lfe,
      float surroundleft,
      float surroundright,
      float backleft,
      float backright);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetMixLevelsInput(
      IntPtr channelgroup,
      float[] levels,
      int numlevels);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetMixMatrix(
      IntPtr channelgroup,
      float[] matrix,
      int outchannels,
      int inchannels,
      int inchannel_hop);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetMixMatrix(
      IntPtr channelgroup,
      float[] matrix,
      out int outchannels,
      out int inchannels,
      int inchannel_hop);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetDSPClock(
      IntPtr channelgroup,
      out ulong dspclock,
      out ulong parentclock);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetDelay(
      IntPtr channelgroup,
      ulong dspclock_start,
      ulong dspclock_end,
      bool stopchannels);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetDelay(
      IntPtr channelgroup,
      out ulong dspclock_start,
      out ulong dspclock_end,
      IntPtr zero);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetDelay(
      IntPtr channelgroup,
      out ulong dspclock_start,
      out ulong dspclock_end,
      out bool stopchannels);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_AddFadePoint(
      IntPtr channelgroup,
      ulong dspclock,
      float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetFadePointRamp(
      IntPtr channelgroup,
      ulong dspclock,
      float volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_RemoveFadePoints(
      IntPtr channelgroup,
      ulong dspclock_start,
      ulong dspclock_end);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetFadePoints(
      IntPtr channelgroup,
      ref uint numpoints,
      ulong[] point_dspclock,
      float[] point_volume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetDSP(
      IntPtr channelgroup,
      int index,
      out IntPtr dsp);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_AddDSP(
      IntPtr channelgroup,
      int index,
      IntPtr dsp);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_RemoveDSP(IntPtr channelgroup, IntPtr dsp);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetNumDSPs(IntPtr channelgroup, out int numdsps);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetDSPIndex(
      IntPtr channelgroup,
      IntPtr dsp,
      int index);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetDSPIndex(
      IntPtr channelgroup,
      IntPtr dsp,
      out int index);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DAttributes(
      IntPtr channelgroup,
      ref VECTOR pos,
      ref VECTOR vel);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DAttributes(
      IntPtr channelgroup,
      out VECTOR pos,
      out VECTOR vel);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DMinMaxDistance(
      IntPtr channelgroup,
      float mindistance,
      float maxdistance);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DMinMaxDistance(
      IntPtr channelgroup,
      out float mindistance,
      out float maxdistance);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DConeSettings(
      IntPtr channelgroup,
      float insideconeangle,
      float outsideconeangle,
      float outsidevolume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DConeSettings(
      IntPtr channelgroup,
      out float insideconeangle,
      out float outsideconeangle,
      out float outsidevolume);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DConeOrientation(
      IntPtr channelgroup,
      ref VECTOR orientation);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DConeOrientation(
      IntPtr channelgroup,
      out VECTOR orientation);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DCustomRolloff(
      IntPtr channelgroup,
      ref VECTOR points,
      int numpoints);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DCustomRolloff(
      IntPtr channelgroup,
      out IntPtr points,
      out int numpoints);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DOcclusion(
      IntPtr channelgroup,
      float directocclusion,
      float reverbocclusion);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DOcclusion(
      IntPtr channelgroup,
      out float directocclusion,
      out float reverbocclusion);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DSpread(IntPtr channelgroup, float angle);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DSpread(
      IntPtr channelgroup,
      out float angle);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DLevel(IntPtr channelgroup, float level);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DLevel(IntPtr channelgroup, out float level);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DDopplerLevel(
      IntPtr channelgroup,
      float level);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DDopplerLevel(
      IntPtr channelgroup,
      out float level);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Set3DDistanceFilter(
      IntPtr channelgroup,
      bool custom,
      float customLevel,
      float centerFreq);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_Get3DDistanceFilter(
      IntPtr channelgroup,
      out bool custom,
      out float customLevel,
      out float centerFreq);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_SetUserData(
      IntPtr channelgroup,
      IntPtr userdata);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_ChannelGroup_GetUserData(
      IntPtr channelgroup,
      out IntPtr userdata);

    public bool hasHandle() => this.handle != IntPtr.Zero;

    public void clearHandle() => this.handle = IntPtr.Zero;
  }
}
