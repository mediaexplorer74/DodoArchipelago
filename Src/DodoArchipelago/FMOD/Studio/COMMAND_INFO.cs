// Decompiled with JetBrains decompiler
// Type: FMOD.Studio.COMMAND_INFO
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace FMOD.Studio
{
  public struct COMMAND_INFO
  {
    public StringWrapper commandname;
    public int parentcommandindex;
    public int framenumber;
    public float frametime;
    public INSTANCETYPE instancetype;
    public INSTANCETYPE outputtype;
    public uint instancehandle;
    public uint outputhandle;
  }
}
