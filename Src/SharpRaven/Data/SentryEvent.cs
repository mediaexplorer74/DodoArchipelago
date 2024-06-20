// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryEvent
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using SharpRaven.Data.Context;
using System;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public class SentryEvent
  {
    private readonly Exception exception;
    private IList<string> fingerprint;
    private SentryMessage message;
    private IDictionary<string, string> tags;

    public SentryEvent(Exception exception)
      : this()
    {
      this.exception = exception;
      this.Level = default;//ErrorLevel.Error;
    }

    public SentryEvent(SentryMessage message)
      : this()
    {
      this.Message = message;
    }

    private SentryEvent()
    {
      this.Tags = (IDictionary<string, string>) new Dictionary<string, string>();
      this.Fingerprint = (IList<string>) new List<string>();
      this.Contexts = Contexts.Create();
    }

    public Contexts Contexts { get; internal set; }

    public Exception Exception => this.exception;

    public object Extra { get; set; }

    public List<Breadcrumb> Breadcrumbs { get; set; }

    public IList<string> Fingerprint
    {
      get => this.fingerprint;
      internal set => this.fingerprint = value ?? (IList<string>) new List<string>();
    }

    public ErrorLevel Level { get; set; }

    public SentryMessage Message
    {
      get
      {
        return this.message ?? (SentryMessage) (this.Exception != null ? this.Exception.Message : (string) null);
      }
      set => this.message = value;
    }

    public IDictionary<string, string> Tags
    {
      get => this.tags;
      set => this.tags = value ?? (IDictionary<string, string>) new Dictionary<string, string>();
    }
  }
}
