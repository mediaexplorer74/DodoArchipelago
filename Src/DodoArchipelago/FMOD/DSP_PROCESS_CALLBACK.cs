// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_PROCESS_CALLBACK
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe


namespace FMOD
{
  public delegate RESULT DSP_PROCESS_CALLBACK(
    ref DSP_STATE dsp_state,
    uint length,
    ref DSP_BUFFER_ARRAY inbufferarray,
    ref DSP_BUFFER_ARRAY outbufferarray,
    bool inputsidle,
    DSP_PROCESS_OPERATION op);
}
