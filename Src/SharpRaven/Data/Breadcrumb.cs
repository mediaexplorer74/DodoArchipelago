// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Breadcrumb
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Serialization;
using System;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public class Breadcrumb
  {
    private readonly DateTime timestamp;

    public Breadcrumb(string category)
    {
      this.Category = category;
      this.timestamp = DateTime.UtcNow;
    }

    public Breadcrumb(string category, BreadcrumbType type)
      : this(category)
    {
      this.Type = new BreadcrumbType?(type);
    }

    [JsonProperty(PropertyName = "type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof (LowerInvariantStringEnumConverter))]
    public BreadcrumbType? Type { get; set; }

    [JsonProperty(PropertyName = "category", NullValueHandling = NullValueHandling.Ignore)]
    public string Category { get; set; }

    [JsonProperty(PropertyName = "timestamp", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime Timestamp => this.timestamp;

    [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
    public string Message { get; set; }

    [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Data { get; set; }

    [JsonProperty(PropertyName = "level", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof (LowerInvariantStringEnumConverter))]
    public BreadcrumbLevel? Level { get; set; }
  }
}
