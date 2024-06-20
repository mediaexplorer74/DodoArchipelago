// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.BANK_INFO
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD.Studio
{
  public struct BANK_INFO
  {
    public int size;
    public IntPtr userdata;
    public int userdatalength;
    public FILE_OPEN_CALLBACK opencallback;
    public FILE_CLOSE_CALLBACK closecallback;
    public FILE_READ_CALLBACK readcallback;
    public FILE_SEEK_CALLBACK seekcallback;
  }
}
