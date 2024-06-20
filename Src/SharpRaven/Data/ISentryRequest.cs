// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.ISentryRequest
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System.Collections.Generic;


namespace SharpRaven.Data
{
  public interface ISentryRequest
  {
    IDictionary<string, string> Cookies { get; set; }

    object Data { get; set; }

    IDictionary<string, string> Environment { get; set; }

    IDictionary<string, string> Headers { get; set; }

    string Method { get; set; }

    string QueryString { get; set; }

    string Url { get; set; }
  }
}
