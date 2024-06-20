// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryUser
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using System.Security.Principal;


namespace SharpRaven.Data
{
  public class SentryUser
  {
    public SentryUser(IPrincipal principal)
    {
      if (principal == null)
        return;
      this.Username = principal.Identity.Name;
    }

    public SentryUser(IIdentity identity)
    {
      if (identity == null)
        return;
      this.Username = identity.Name;
    }

    public SentryUser(string username) => this.Username = username;

    [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    [JsonProperty(PropertyName = "ip_address", NullValueHandling = NullValueHandling.Ignore)]
    public string IpAddress { get; set; }

    [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
    public string Username { get; set; }

    public static SentryUser GetUser(ISentryUserFactory factory) => factory?.Create();
  }
}
