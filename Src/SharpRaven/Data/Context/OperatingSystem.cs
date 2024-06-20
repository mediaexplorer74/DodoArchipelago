// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.OperatingSystem
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Utilities;
using System;
using System.Runtime.InteropServices;


namespace SharpRaven.Data.Context
{
  public class OperatingSystem
  {
    [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
    public string Version { get; set; }

    [JsonProperty(PropertyName = "raw_description", NullValueHandling = NullValueHandling.Ignore)]
    public string RawDescription { get; set; }

    [JsonProperty(PropertyName = "build", NullValueHandling = NullValueHandling.Ignore)]
    public string Build { get; set; }

    [JsonProperty(PropertyName = "kernel_version", NullValueHandling = NullValueHandling.Ignore)]
    public string KernelVersion { get; set; }

    [JsonProperty(PropertyName = "rooted", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Rooted { get; set; }

    internal OperatingSystem Clone()
    {
      return new OperatingSystem()
      {
        Version = this.Version,
        Name = this.Name,
        RawDescription = this.RawDescription,
        Build = this.Build,
        KernelVersion = this.KernelVersion,
        Rooted = this.Rooted
      };
    }

    internal static OperatingSystem Create()
    {
      try
      {
        string osDescription = RuntimeInformation.OSDescription;
        return new OperatingSystem()
        {
          RawDescription = osDescription
        };
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
        return (OperatingSystem) null;
      }
    }
  }
}
