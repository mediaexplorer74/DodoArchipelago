// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.DeviceOrientation
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;


namespace SharpRaven.Data.Context
{
  public enum DeviceOrientation
  {
    [JsonProperty(PropertyName = "portrait", NullValueHandling = NullValueHandling.Ignore)] Portrait,
    [JsonProperty(PropertyName = "landscape", NullValueHandling = NullValueHandling.Ignore)] Landscape,
  }
}
