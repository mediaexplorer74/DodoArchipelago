// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.Device
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Serialization;
using SharpRaven.Utilities;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace SharpRaven.Data.Context
{
  public class Device
  {
    [JsonProperty(PropertyName = "timezone", NullValueHandling = NullValueHandling.Ignore)]
    private string TimezoneSerializable => this.Timezone?.Id;

    [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "family", NullValueHandling = NullValueHandling.Ignore)]
    public string Family { get; set; }

    [JsonProperty(PropertyName = "model", NullValueHandling = NullValueHandling.Ignore)]
    public string Model { get; set; }

    [JsonProperty(PropertyName = "model_id", NullValueHandling = NullValueHandling.Ignore)]
    public string ModelId { get; set; }

    [JsonProperty(PropertyName = "arch", NullValueHandling = NullValueHandling.Ignore)]
    public string Architecture { get; set; }

    [JsonProperty(PropertyName = "battery_level", NullValueHandling = NullValueHandling.Ignore)]
    public short? BatteryLevel { get; set; }

    [JsonProperty(PropertyName = "orientation", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof (LowerInvariantStringEnumConverter))]
    public DeviceOrientation? Orientation { get; set; }

    [JsonProperty(PropertyName = "simulator", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Simulator { get; set; }

    [JsonProperty(PropertyName = "memory_size", NullValueHandling = NullValueHandling.Ignore)]
    public long? MemorySize { get; set; }

    [JsonProperty(PropertyName = "free_memory", NullValueHandling = NullValueHandling.Ignore)]
    public long? FreeMemory { get; set; }

    [JsonProperty(PropertyName = "usable_memory", NullValueHandling = NullValueHandling.Ignore)]
    public long? UsableMemory { get; set; }

    [JsonProperty(PropertyName = "storage_size", NullValueHandling = NullValueHandling.Ignore)]
    public long? StorageSize { get; set; }

    [JsonProperty(PropertyName = "free_storage", NullValueHandling = NullValueHandling.Ignore)]
    public long? FreeStorage { get; set; }

    [JsonProperty(PropertyName = "external_storage_size", NullValueHandling = NullValueHandling.Ignore)]
    public long? ExternalStorageSize { get; set; }

    [JsonProperty(PropertyName = "external_free_storage", NullValueHandling = NullValueHandling.Ignore)]
    public long? ExternalFreeStorage { get; set; }

    [JsonProperty(PropertyName = "boot_time", NullValueHandling = NullValueHandling.Ignore)]
    public DateTimeOffset? BootTime { get; set; }

    [JsonIgnore]
    public TimeZoneInfo Timezone { get; set; }

    internal Device Clone()
    {
      return new Device()
      {
        Name = this.Name,
        Architecture = this.Architecture,
        BatteryLevel = this.BatteryLevel,
        BootTime = this.BootTime,
        ExternalFreeStorage = this.ExternalFreeStorage,
        ExternalStorageSize = this.ExternalStorageSize,
        Family = this.Family,
        FreeMemory = this.FreeMemory,
        FreeStorage = this.FreeStorage,
        MemorySize = this.MemorySize,
        Model = this.Model,
        ModelId = this.ModelId,
        Orientation = this.Orientation,
        Simulator = this.Simulator,
        StorageSize = this.StorageSize,
        Timezone = this.Timezone,
        UsableMemory = this.UsableMemory
      };
    }

    internal static Device Create()
    {
      try
      {
        return new Device()
        {
          Name = "Name",//Environment.MachineName,
          Timezone = TimeZoneInfo.Local,
          Architecture = Device.GetArchitecture(),
          BootTime = new DateTimeOffset?(new DateTimeOffset(DateTime.UtcNow - TimeSpan.FromTicks(Stopwatch.GetTimestamp()), TimeSpan.Zero))
        };
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
        return (Device) null;
      }
    }

    internal static string GetArchitecture() => RuntimeInformation.ProcessArchitecture.ToString();
  }
}
