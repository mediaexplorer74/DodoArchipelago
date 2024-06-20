// Decompiled with JetBrains decompiler
// Type: SharpRaven.NoOpRavenClient
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using SharpRaven.Data;
using SharpRaven.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SharpRaven
{
  public class NoOpRavenClient : IRavenClient
  {
    private readonly Dsn currentDsn;
    private readonly IDictionary<string, string> defaultTags;

    public NoOpRavenClient()
    {
      this.currentDsn = new Dsn("http://sentry-dsn.invalid");
      this.defaultTags = (IDictionary<string, string>) new Dictionary<string, string>();
    }

    public Func<IRequester, IRequester> BeforeSend { get; set; }

    public Action<Exception> ErrorOnCapture { get; set; }

    public bool Compression { get; set; }

    public Dsn CurrentDsn => this.currentDsn;

    public IScrubber LogScrubber { get; set; }

    public string Logger { get; set; }

    public string Release { get; set; }

    public string Environment { get; set; }

    public IDictionary<string, string> Tags => this.defaultTags;

    public TimeSpan Timeout { get; set; }

    public bool IgnoreBreadcrumbs { get; set; }

    public void AddTrail(Breadcrumb breadcrumb)
    {
    }

    public void RestartTrails()
    {
    }

    public string Capture(SentryEvent @event) => Guid.NewGuid().ToString("n");

    [Obsolete("Use CaptureException() instead.", true)]
    public string CaptureEvent(Exception e)
    {
      return this.CaptureException(e, (SentryMessage) null, /*ErrorLevel.Error,*/
          (IDictionary<string, string>) null, (string[]) null, (object) null);
    }

    //[Obsolete("Use CaptureException() instead.", true)]
    //public string CaptureEvent(Exception e, Dictionary<string, string> tags)
    //{
    //  return this.CaptureException(e, (SentryMessage) null, /*ErrorLevel.Error,*/
    //      (IDictionary<string, string>) tags, (string[]) null, (object) null);
    //}

    //[Obsolete("Use Capture(SentryEvent) instead")]
    //public string CaptureException(
    //  Exception exception,
    //  SentryMessage message = null,
      //ErrorLevel level = ErrorLevel.Error,
    //  IDictionary<string, string> tags = null,
    //  string[] fingerprint = null,
    //  object extra = null)
    //{
    //  return Guid.NewGuid().ToString("n");
    //}

    //[Obsolete("Use Capture(SentryEvent) instead")]
    //public string CaptureMessage(
    //  SentryMessage message,
      //ErrorLevel level = ErrorLevel.Info,
    //  IDictionary<string, string> tags = null,
    //  string[] fingerprint = null,
    //  object extra = null)
    //{
    //  return Guid.NewGuid().ToString("n");
    //}

    public string SendUserFeedback(SentryUserFeedback feedback) => string.Empty;

    public async Task<string> CaptureAsync(SentryEvent @event)
    {
      return await Task.FromResult<string>(Guid.NewGuid().ToString("n"));
    }

    [Obsolete("Use CaptureAsync(SentryEvent) instead.")]
    public async Task<string> CaptureExceptionAsync(
      Exception exception,
      SentryMessage message = null,
      //ErrorLevel level = ErrorLevel.Error,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null)
    {
      return await Task.FromResult<string>(Guid.NewGuid().ToString("n"));
    }

    [Obsolete("Use CaptureAsync(SentryEvent) instead.")]
    public async Task<string> CaptureMessageAsync(
      SentryMessage message,
      //ErrorLevel level = ErrorLevel.Info,
      IDictionary<string, string> tags = null,
      string[] fingerprint = null,
      object extra = null)
    {
      return await Task.FromResult<string>(Guid.NewGuid().ToString("n"));
    }

    public async Task<string> SendUserFeedbackAsync(SentryUserFeedback feedback)
    {
      return await Task.FromResult<string>(string.Empty);
    }

        public string CaptureException(Exception exception, SentryMessage message = null, 
            IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        {
            throw new NotImplementedException();
        }

        public string CaptureMessage(SentryMessage message, 
            IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        {
            throw new NotImplementedException();
        }

        //public Task<string> CaptureExceptionAsync(Exception exception, SentryMessage message = null, 
        //    IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<string> CaptureMessageAsync(SentryMessage message, IDictionary<string, string> tags = null, string[] fingerprint = null, object extra = null)
        //{
        //    throw new NotImplementedException();
        //}

        public string CaptureEvent(Exception e, Dictionary<string, string> tags)
        {
            throw new NotImplementedException();
        }
    }
}
