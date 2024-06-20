// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.ExceptionData
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using Newtonsoft.Json;
using SharpRaven.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;


namespace SharpRaven.Data
{
  public class ExceptionData : Dictionary<string, object>
  {
    private readonly string exceptionType;

    public ExceptionData(Exception exception)
    {
      this.exceptionType = exception != null ? exception.GetType().FullName : throw new ArgumentNullException(nameof (exception));
      foreach (object key1 in (IEnumerable) exception.Data.Keys)
      {
        try
        {
          object obj = exception.Data[key1];
          if (!(key1 is string key2))
            key2 = key1.ToString();
          this.Add(key2, obj);
        }
        catch (Exception ex)
        {
          SystemUtil.WriteError(ex);
        }
      }
      if (exception.InnerException == null)
        return;
      ExceptionData exceptionData = new ExceptionData(exception.InnerException);
      if (exceptionData.Count == 0)
        return;
      exceptionData.AddTo((IDictionary<string, object>) this);
    }

    [JsonProperty("type")]
    public string ExceptionType => this.exceptionType;

    private void AddTo(IDictionary<string, object> dictionary)
    {
      string key1 = this.ExceptionType + (object) '.' + "Data";
      string key2 = ExceptionData.UniqueKey(dictionary, (object) key1);
      dictionary.Add(key2, (object) this);
    }

    private static string UniqueKey(IDictionary<string, object> dictionary, object key)
    {
      if (!(key is string str))
        str = key.ToString();
      string key1 = str;
      if (!dictionary.ContainsKey(key1))
        return key1;
      for (int index = 0; index < 10000; ++index)
      {
        string key2 = key1 + (object) index;
        if (!dictionary.ContainsKey(key2))
          return key2;
      }
      throw new ArgumentException(string.Format("Unable to find a unique key for '{0}'.", (object) key1), nameof (key));
    }
  }
}
