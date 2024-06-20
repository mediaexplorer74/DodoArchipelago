// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.App
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Utilities;
using System;
using System.Diagnostics;
using System.Reflection;


namespace SharpRaven.Data.Context
{
  public class App
  {
    [JsonProperty(PropertyName = "app_identifier", NullValueHandling = NullValueHandling.Ignore)]
    public string Identifier { get; set; }

    [JsonProperty(PropertyName = "app_start_time", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? StartTime { get; set; }

    [JsonProperty(PropertyName = "device_app_hash", NullValueHandling = NullValueHandling.Ignore)]
    public string Hash { get; set; }

    [JsonProperty(PropertyName = "build_type", NullValueHandling = NullValueHandling.Ignore)]
    public string BuildType { get; set; }

    [JsonProperty(PropertyName = "app_name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "app_version", NullValueHandling = NullValueHandling.Ignore)]
    public string Version { get; set; }

    [JsonProperty(PropertyName = "app_build", NullValueHandling = NullValueHandling.Ignore)]
    public string Build { get; set; }

    [JsonIgnore]
    public static AssemblyName ApplicationName { get; set; }

    internal App Clone()
    {
      return new App()
      {
        Build = this.Build,
        Version = this.Version,
        Name = this.Name,
        BuildType = this.BuildType,
        Hash = this.Hash,
        Identifier = this.Identifier,
        StartTime = this.StartTime
      };
    }

    internal static App Create()
    {
      try
      {
        App app = new App();
        AssemblyName assemblyName = default;//App.ApplicationName ?? EntryAssemblyNameLocator.GetAssemblyName();
        if (assemblyName != null)
        {
          app.Name = assemblyName.Name;
          app.Version = assemblyName.Version?.ToString();
        }
        using (Process currentProcess = Process.GetCurrentProcess())
          app.StartTime = new DateTimeOffset?(
              (DateTimeOffset) currentProcess.StartTime.ToUniversalTime());
        return app;
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
        return (App) null;
      }
    }
  }
}
