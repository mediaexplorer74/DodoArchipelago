// Decompiled with JetBrains decompiler
// Type: SharpRaven.Utilities.RuntimeInfoHelper
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Microsoft.Win32;
using SharpRaven.Data.Context;
using System;
using System.Reflection;
using System.Runtime.InteropServices;


namespace SharpRaven.Utilities
{
  internal static class RuntimeInfoHelper
  {
    public static SharpRaven.Data.Context.Runtime GetRuntime()
    {
      SharpRaven.Data.Context.Runtime runtime1 = new SharpRaven.Data.Context.Runtime()
      {
        RawDescription = RuntimeInformation.FrameworkDescription
      };
      if (runtime1.IsNetFx())
      {
        SharpRaven.Data.Context.Runtime runtime2 = runtime1;
        int? nullable = RuntimeInfoHelper.Get45PlusLatestInstallationFromRegistry();
        ref int? local = ref nullable;
        string str = local.HasValue ? local.GetValueOrDefault().ToString() : (string) null;
        runtime2.Build = str;
      }
      return runtime1;
    }

    private static SharpRaven.Data.Context.Runtime GetFromMono()
    {
      if (!(Type.GetType("Mono.Runtime", false)?.GetMethod("GetDisplayName", BindingFlags.Static | BindingFlags.NonPublic)?.Invoke((object) null, (object[]) null) is string str))
        return (SharpRaven.Data.Context.Runtime) null;
      return new SharpRaven.Data.Context.Runtime()
      {
        RawDescription = "Mono " + str
      };
    }

    private static int? Get45PlusLatestInstallationFromRegistry()
    {
      using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Microsoft\\NET Framework Setup\\NDP\\v4\\Full\\"))
      {
        int result;
        return int.TryParse(registryKey?.GetValue("Release")?.ToString(), out result) ? new int?(result) : new int?();
      }
    }
  }
}
