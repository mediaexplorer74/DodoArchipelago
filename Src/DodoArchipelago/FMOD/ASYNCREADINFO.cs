// Decompiled with JetBrains decompiler
// Type: FMOD.ASYNCREADINFO
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct ASYNCREADINFO
  {
    public IntPtr handle;
    public uint offset;
    public uint sizebytes;
    public int priority;
    public IntPtr userdata;
    public IntPtr buffer;
    public uint bytesread;
    public FILE_ASYNCDONE_FUNC done;
  }
}
