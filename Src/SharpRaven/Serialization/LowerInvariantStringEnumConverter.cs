// Decompiled with JetBrains decompiler
// Type: SharpRaven.Serialization.LowerInvariantStringEnumConverter
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;


namespace SharpRaven.Serialization
{
  public class LowerInvariantStringEnumConverter : StringEnumConverter
  {
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
      if (!(value is Enum))
        return;
      string lowerInvariant = value.ToString().ToLowerInvariant();
      writer.WriteValue(lowerInvariant);
    }
  }
}
