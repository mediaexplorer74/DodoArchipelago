// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.Runtime
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Utilities;
using System;


namespace SharpRaven.Data.Context
{
  public class Runtime
  {
    [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
    public string Version { get; set; }

    [JsonProperty(PropertyName = "raw_description", NullValueHandling = NullValueHandling.Ignore)]
    public string RawDescription { get; set; }

    [JsonProperty(PropertyName = "build", NullValueHandling = NullValueHandling.Ignore)]
    public string Build { get; set; }

    internal Runtime Clone()
    {
      return new Runtime()
      {
        Name = this.Name,
        Version = this.Version,
        Build = this.Build,
        RawDescription = this.RawDescription
      };
    }

    public static Runtime Create()
    {
      try
      {
        return RuntimeInfoHelper.GetRuntime();
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
        return (Runtime) null;
      }
    }
  }
}
