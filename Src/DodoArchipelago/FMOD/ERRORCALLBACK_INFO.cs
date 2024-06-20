// Decompiled with JetBrains decompiler
// Type: FMOD.ERRORCALLBACK_INFO
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public struct ERRORCALLBACK_INFO
  {
    public RESULT result;
    public ERRORCALLBACK_INSTANCETYPE instancetype;
    public IntPtr instance;
    public StringWrapper functionname;
    public StringWrapper functionparams;
  }
}
