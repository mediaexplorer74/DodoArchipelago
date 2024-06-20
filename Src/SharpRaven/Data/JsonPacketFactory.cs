// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.JsonPacketFactory
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public class JsonPacketFactory : IJsonPacketFactory
  {
    [Obsolete("Use Create(string, SentryEvent) instead.")]
    public JsonPacket Create(
      string project,
      SentryMessage message,
      //ErrorLevel level = ErrorLevel.Info,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null)
    {
      SentryEvent @event = new SentryEvent(message)
      {
        //Level = level,
        Extra = extra,
        Tags = tags,
        Fingerprint = (IList<string>) fingerprint
      };
      return this.Create(project, @event);
    }

    [Obsolete("Use Create(string, SentryEvent) instead.")]
    public JsonPacket Create(
      string project,
      Exception exception,
      SentryMessage message = null,
      //ErrorLevel level = ErrorLevel.Error,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null)
    {
      SentryEvent @event = new SentryEvent(exception)
      {
        Message = message,
        //Level = level,
        Extra = extra,
        Tags = tags,
        Fingerprint = (IList<string>) fingerprint
      };
      return this.Create(project, @event);
    }

    public JsonPacket Create(string project, SentryEvent @event)
    {
      return this.OnCreate(new JsonPacket(project, @event)
      {
        Breadcrumbs = @event.Breadcrumbs
      });
    }

        public JsonPacket Create(string project, SentryMessage message, ErrorLevel level = null, IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        {
            throw new NotImplementedException();
        }

        public JsonPacket Create(string project, Exception exception, SentryMessage message = null, ErrorLevel level = null, IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        {
            throw new NotImplementedException();
        }

        protected virtual JsonPacket OnCreate(JsonPacket jsonPacket) => jsonPacket;
  }
}
