// Decompiled with JetBrains decompiler
// Type: FMOD.DEBUG_CALLBACK
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace FMOD
{
  public delegate RESULT DEBUG_CALLBACK(
    DEBUG_FLAGS flags,
    StringWrapper file,
    int line,
    StringWrapper func,
    StringWrapper message);
}
