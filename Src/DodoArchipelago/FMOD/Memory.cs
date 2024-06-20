// Decompiled with JetBrains decompiler
// Type: FMOD.Memory
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System;
using System.Runtime.InteropServices;


namespace FMOD
{
  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct Memory
  {
    public static RESULT Initialize(
      IntPtr poolmem,
      int poollen,
      MEMORY_ALLOC_CALLBACK useralloc,
      MEMORY_REALLOC_CALLBACK userrealloc,
      MEMORY_FREE_CALLBACK userfree,
      MEMORY_TYPE memtypeflags = MEMORY_TYPE.ALL)
    {
      return Memory.FMOD5_Memory_Initialize(poolmem, poollen, useralloc, userrealloc, userfree, memtypeflags);
    }

    public static RESULT GetStats(out int currentalloced, out int maxalloced, bool blocking = true)
    {
      return Memory.FMOD5_Memory_GetStats(out currentalloced, out maxalloced, blocking);
    }

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Memory_Initialize(
      IntPtr poolmem,
      int poollen,
      MEMORY_ALLOC_CALLBACK useralloc,
      MEMORY_REALLOC_CALLBACK userrealloc,
      MEMORY_FREE_CALLBACK userfree,
      MEMORY_TYPE memtypeflags);

    [DllImport("fmod")]
    private static extern RESULT FMOD5_Memory_GetStats(
      out int currentalloced,
      out int maxalloced,
      bool blocking);
  }
}
