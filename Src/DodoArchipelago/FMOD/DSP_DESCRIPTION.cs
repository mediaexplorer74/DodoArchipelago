// Decompiled with JetBrains decompiler
// Type: FMOD.DSP_DESCRIPTION
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  public struct DSP_DESCRIPTION
  {
    public uint pluginsdkversion;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public char[] name;
    public uint version;
    public int numinputbuffers;
    public int numoutputbuffers;
    public DSP_CREATECALLBACK create;
    public DSP_RELEASECALLBACK release;
    public DSP_RESETCALLBACK reset;
    public DSP_READCALLBACK read;
    public DSP_PROCESS_CALLBACK process;
    public DSP_SETPOSITIONCALLBACK setposition;
    public int numparameters;
    public IntPtr paramdesc;
    public DSP_SETPARAM_FLOAT_CALLBACK setparameterfloat;
    public DSP_SETPARAM_INT_CALLBACK setparameterint;
    public DSP_SETPARAM_BOOL_CALLBACK setparameterbool;
    public DSP_SETPARAM_DATA_CALLBACK setparameterdata;
    public DSP_GETPARAM_FLOAT_CALLBACK getparameterfloat;
    public DSP_GETPARAM_INT_CALLBACK getparameterint;
    public DSP_GETPARAM_BOOL_CALLBACK getparameterbool;
    public DSP_GETPARAM_DATA_CALLBACK getparameterdata;
    public DSP_SHOULDIPROCESS_CALLBACK shouldiprocess;
    public IntPtr userdata;
    public DSP_SYSTEM_REGISTER_CALLBACK sys_register;
    public DSP_SYSTEM_DEREGISTER_CALLBACK sys_deregister;
    public DSP_SYSTEM_MIX_CALLBACK sys_mix;
  }
}
