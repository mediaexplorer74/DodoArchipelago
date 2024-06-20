// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryRequest
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public class SentryRequest : ISentryRequest
  {
    [JsonProperty(PropertyName = "cookies", NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Cookies { get; set; }

    [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
    public object Data { get; set; }

    [JsonProperty(PropertyName = "env", NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Environment { get; set; }

    [JsonProperty(PropertyName = "headers", NullValueHandling = NullValueHandling.Ignore)]
    public IDictionary<string, string> Headers { get; set; }

    [JsonProperty(PropertyName = "method", NullValueHandling = NullValueHandling.Ignore)]
    public string Method { get; set; }

    [JsonProperty(PropertyName = "query_string", NullValueHandling = NullValueHandling.Ignore)]
    public string QueryString { get; set; }

    [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
    public string Url { get; set; }

    public static ISentryRequest GetRequest(ISentryRequestFactory factory) => factory?.Create();
  }
}
