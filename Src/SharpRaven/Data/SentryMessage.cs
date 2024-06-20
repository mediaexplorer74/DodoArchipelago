// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryMessage
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace SharpRaven.Data
{
  public class SentryMessage
  {
    private readonly string message;
    private readonly object[] parameters;

    public SentryMessage(string format, params object[] parameters)
      : this(format)
    {
      this.parameters = parameters;
    }

    public SentryMessage(string message) => this.message = message;

    [JsonProperty(PropertyName = "message", NullValueHandling = NullValueHandling.Ignore)]
    public string Message => this.message;

    [JsonProperty(PropertyName = "params", NullValueHandling = NullValueHandling.Ignore)]
    public object[] Parameters => this.parameters;

    public override string ToString()
    {
      if (this.message != null && this.parameters != null)
      {
        if (((IEnumerable<object>) this.parameters).Any<object>())
        {
          try
          {
            return string.Format(this.message, this.parameters);
          }
          catch
          {
            return this.message;
          }
        }
      }
      return this.message ?? string.Empty;
    }

    public static implicit operator SentryMessage(string message)
    {
      return message == null ? (SentryMessage) null : new SentryMessage(message);
    }

    public static implicit operator string(SentryMessage message) => message?.ToString();
  }
}
