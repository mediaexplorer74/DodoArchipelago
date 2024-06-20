// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.Browser
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;


namespace SharpRaven.Data.Context
{
  public class Browser
  {
    [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty(PropertyName = "version", NullValueHandling = NullValueHandling.Ignore)]
    public string Version { get; set; }
  }
}
