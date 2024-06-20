// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryUserFeedback
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System.Net;


namespace SharpRaven.Data
{
  public class SentryUserFeedback
  {
    public string Name { get; set; }

    public string Email { get; set; }

    public string Comments { get; set; }

    public string EventID { get; set; }

    public override string ToString()
    {
      return string.Format("eventId={0}&name={1}&email={2}&comments={3}", (object) WebUtility.UrlEncode(this.EventID), (object) WebUtility.UrlEncode(this.Name), (object) WebUtility.UrlEncode(this.Email), (object) WebUtility.UrlEncode(this.Comments));
    }
  }
}
