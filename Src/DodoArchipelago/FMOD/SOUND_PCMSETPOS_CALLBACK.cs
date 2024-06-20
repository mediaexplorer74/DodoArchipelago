// Decompiled with JetBrains decompiler
// Type: FMOD.SOUND_PCMSETPOS_CALLBACK
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;


namespace FMOD
{
  public delegate RESULT SOUND_PCMSETPOS_CALLBACK(
    IntPtr sound,
    int subsound,
    uint position,
    TIMEUNIT postype);
}
