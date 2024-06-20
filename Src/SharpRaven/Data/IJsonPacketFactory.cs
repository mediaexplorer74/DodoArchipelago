// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.IJsonPacketFactory
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public interface IJsonPacketFactory
  {
    [Obsolete("Use Create(string, SentryEvent) instead.")]
    JsonPacket Create(
      string project,
      SentryMessage message,
      //ErrorLevel level = ErrorLevel.Info,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null);

    [Obsolete("Use Create(string, SentryEvent) instead.")]
    JsonPacket Create(
      string project,
      Exception exception,
      SentryMessage message = null,
      //ErrorLevel level = ErrorLevel.Error,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null);

    JsonPacket Create(string project, SentryEvent @event);
  }
}
