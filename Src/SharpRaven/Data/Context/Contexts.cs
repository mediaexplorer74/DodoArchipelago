// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.Contexts
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;


namespace SharpRaven.Data.Context
{
  public class Contexts
  {
    [JsonProperty(PropertyName = "app", NullValueHandling = NullValueHandling.Ignore)]
    private App app;
    [JsonProperty(PropertyName = "browser", NullValueHandling = NullValueHandling.Ignore)]
    private Browser browser;
    [JsonProperty(PropertyName = "device", NullValueHandling = NullValueHandling.Ignore)]
    private Device device;
    [JsonProperty(PropertyName = "os", NullValueHandling = NullValueHandling.Ignore)]
    private OperatingSystem operatingSystem;
    [JsonProperty(PropertyName = "runtime", NullValueHandling = NullValueHandling.Ignore)]
    private Runtime runtime;
    private static Contexts root;

    [JsonIgnore]
    public App App => this.app ?? (this.app = new App());

    [JsonIgnore]
    public Browser Browser => this.browser ?? (this.browser = new Browser());

    [JsonIgnore]
    public Device Device => this.device ?? (this.device = new Device());

    [JsonIgnore]
    public OperatingSystem OperatingSystem
    {
      get => this.operatingSystem ?? (this.operatingSystem = new OperatingSystem());
    }

    [JsonIgnore]
    public Runtime Runtime => this.runtime ?? (this.runtime = new Runtime());

    internal Contexts Clone()
    {
      return new Contexts()
      {
        app = this.app?.Clone(),
        device = this.device?.Clone(),
        operatingSystem = this.operatingSystem?.Clone(),
        runtime = this.runtime?.Clone()
      };
    }

    internal static Contexts Create()
    {
      return (Contexts.root = Contexts.root ?? Contexts.CreateNew()).Clone();
    }

    private static Contexts CreateNew()
    {
      return new Contexts()
      {
        app = App.Create(),
        device = Device.Create(),
        operatingSystem = OperatingSystem.Create(),
        runtime = Runtime.Create()
      };
    }
  }
}
