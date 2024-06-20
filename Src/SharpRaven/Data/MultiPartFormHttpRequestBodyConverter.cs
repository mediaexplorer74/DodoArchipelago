// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.MultiPartFormHttpRequestBodyConverter
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;
using System.Collections.Generic;
using System.Linq;


namespace SharpRaven.Data
{
  public class MultiPartFormHttpRequestBodyConverter : FormHttpRequestBodyConverter
  {
    public override bool Matches(string contentType)
    {
      if (string.IsNullOrEmpty(contentType))
        return false;
      return ((IEnumerable<string>) contentType.Split(';')).First<string>().Equals("multipart/form-data", StringComparison.OrdinalIgnoreCase);
    }
  }
}
