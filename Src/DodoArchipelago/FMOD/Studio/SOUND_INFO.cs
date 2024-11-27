
// Type: FMOD.Studio.SOUND_INFO

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;


namespace FMOD.Studio
{
  public struct SOUND_INFO
  {
    public IntPtr name_or_data;
    public MODE mode;
    public CREATESOUNDEXINFO exinfo;
    public int subsoundindex;

    public string name
    {
      get
      {
        using (StringHelper.ThreadSafeEncoding freeHelper = StringHelper.GetFreeHelper())
          return (this.mode & (MODE.OPENMEMORY | MODE.OPENMEMORY_POINT)) == MODE.DEFAULT ? freeHelper.stringFromNative(this.name_or_data) : string.Empty;
      }
    }
  }
}
