// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.SentryRequestFactory
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll
/*
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using SharpRaven.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace SharpRaven.Data
{
  public class SentryRequestFactory : ISentryRequestFactory
  {
    private static bool checkedForHttpContextProperty;

    internal static object CurrentHttpContextProperty { get; set; }

    [JsonIgnore]
    internal static bool HasCurrentHttpContextProperty
    {
      get
      {
        if (SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__1 == null)
          SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (SentryRequestFactory)));
        Func<CallSite, object, bool> target = SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__1.Target;
        CallSite<Func<CallSite, object, bool>> p1 = SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__1;
        if (SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
          SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        object obj = SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__6.\u003C\u003Ep__0, SentryRequestFactory.CurrentHttpContextProperty, (object) null);
        return target((CallSite) p1, obj);
      }
    }

    [JsonIgnore]
    internal static bool HasHttpContext
    {
      get
      {
        if (SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__1 == null)
          SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (bool), typeof (SentryRequestFactory)));
        Func<CallSite, object, bool> target = SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__1.Target;
        CallSite<Func<CallSite, object, bool>> p1 = SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__1;
        if (SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__0 == null)
          SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        object obj = SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__8.\u003C\u003Ep__0, SentryRequestFactory.HttpContext, (object) null);
        return target((CallSite) p1, obj);
      }
    }

    internal static object HttpContext
    {
      get
      {
        SentryRequestFactory.TryGetHttpContextPropertyFromAppDomain();
        if (!SentryRequestFactory.HasCurrentHttpContextProperty)
          return (object) null;
        try
        {
          if (SentryRequestFactory.\u003C\u003Eo__10.\u003C\u003Ep__0 == null)
            SentryRequestFactory.\u003C\u003Eo__10.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "GetValue", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          return SentryRequestFactory.\u003C\u003Eo__10.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__10.\u003C\u003Ep__0, SentryRequestFactory.CurrentHttpContextProperty, (object) null, (object) null);
        }
        catch (Exception ex)
        {
          SystemUtil.WriteError(ex);
          return (object) null;
        }
      }
    }

    public ISentryRequest Create()
    {
      bool flag = !SentryRequestFactory.HasHttpContext;
      if (!flag)
      {
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__3 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, bool> target1 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__3.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, bool>> p3 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__3;
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__2 = CallSite<Func<CallSite, bool, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, bool, object, object> target2 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, bool, object, object>> p2 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__2;
        int num = flag ? 1 : 0;
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, object, object, object> target3 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__1.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, object, object, object>> p1 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__1;
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__0, SentryRequestFactory.HttpContext);
        object obj2 = target3((CallSite) p1, obj1, (object) null);
        object obj3 = target2((CallSite) p2, num != 0, obj2);
        if (!target1((CallSite) p3, obj3))
        {
          SentryRequest request = new SentryRequest();
          SentryRequest sentryRequest1 = request;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SentryRequestFactory)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target4 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__7.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p7 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__7;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__6 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target5 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__6.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p6 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__6;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__5 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Url", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target6 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__5.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p5 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__5;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj4 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__4.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__4, SentryRequestFactory.HttpContext);
          object obj5 = target6((CallSite) p5, obj4);
          object obj6 = target5((CallSite) p6, obj5);
          string str1 = target4((CallSite) p7, obj6);
          sentryRequest1.Url = str1;
          SentryRequest sentryRequest2 = request;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__10 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SentryRequestFactory)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target7 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__10.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p10 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__10;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__9 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "HttpMethod", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target8 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__9.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p9 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__9;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj7 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__8.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__8, SentryRequestFactory.HttpContext);
          object obj8 = target8((CallSite) p9, obj7);
          string str2 = target7((CallSite) p10, obj8);
          sentryRequest2.Method = str2;
          request.Environment = SentryRequestFactory.Convert((Func<object, NameObjectCollectionBase>) (x =>
          {
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__13 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__13 = CallSite<Func<CallSite, object, NameObjectCollectionBase>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (NameObjectCollectionBase), typeof (SentryRequestFactory)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, NameObjectCollectionBase> target9 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__13.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, NameObjectCollectionBase>> p13 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__13;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__12 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__12 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "ServerVariables", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, object> target10 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__12.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, object>> p12 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__12;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__11 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__11 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj9 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__11.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__11, x);
            object obj10 = target10((CallSite) p12, obj9);
            return target9((CallSite) p13, obj10);
          }));
          request.Headers = SentryRequestFactory.Convert((Func<object, NameObjectCollectionBase>) (x =>
          {
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__16 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__16 = CallSite<Func<CallSite, object, NameObjectCollectionBase>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (NameObjectCollectionBase), typeof (SentryRequestFactory)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, NameObjectCollectionBase> target11 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__16.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, NameObjectCollectionBase>> p16 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__16;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__15 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__15 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Headers", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, object> target12 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__15.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, object>> p15 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__15;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__14 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__14 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj11 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__14.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__14, x);
            object obj12 = target12((CallSite) p15, obj11);
            return target11((CallSite) p16, obj12);
          }));
          request.Cookies = SentryRequestFactory.Convert((Func<object, NameObjectCollectionBase>) (x =>
          {
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__19 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__19 = CallSite<Func<CallSite, object, NameObjectCollectionBase>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (NameObjectCollectionBase), typeof (SentryRequestFactory)));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, NameObjectCollectionBase> target13 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__19.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, NameObjectCollectionBase>> p19 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__19;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__18 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__18 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Cookies", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            Func<CallSite, object, object> target14 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__18.Target;
            // ISSUE: reference to a compiler-generated field
            CallSite<Func<CallSite, object, object>> p18 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__18;
            // ISSUE: reference to a compiler-generated field
            if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__17 == null)
            {
              // ISSUE: reference to a compiler-generated field
              SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__17 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            object obj13 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__17.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__17, x);
            object obj14 = target14((CallSite) p18, obj13);
            return target13((CallSite) p19, obj14);
          }));
          request.Data = SentryRequestFactory.BodyConvert();
          SentryRequest sentryRequest3 = request;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__23 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__23 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (SentryRequestFactory)));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string> target15 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__23.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string>> p23 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__23;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__22 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__22 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target16 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__22.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p22 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__22;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__21 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__21 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "QueryString", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object> target17 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__21.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object>> p21 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__21;
          // ISSUE: reference to a compiler-generated field
          if (SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__20 == null)
          {
            // ISSUE: reference to a compiler-generated field
            SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__20 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Request", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj15 = SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__20.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__11.\u003C\u003Ep__20, SentryRequestFactory.HttpContext);
          object obj16 = target17((CallSite) p21, obj15);
          object obj17 = target16((CallSite) p22, obj16);
          string str3 = target15((CallSite) p23, obj17);
          sentryRequest3.QueryString = str3;
          return (ISentryRequest) this.OnCreate(request);
        }
      }
      return (ISentryRequest) this.OnCreate((SentryRequest) null);
    }

    public virtual SentryRequest OnCreate(SentryRequest request) => request;

    private static object BodyConvert()
    {
      if (!SentryRequestFactory.HasHttpContext)
        return (object) null;
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__13.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__13.\u003C\u003Ep__0 = CallSite<Func<CallSite, Type, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Convert", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return SentryRequestFactory.\u003C\u003Eo__13.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__13.\u003C\u003Ep__0, typeof (HttpRequestBodyConverter), SentryRequestFactory.HttpContext);
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
      }
      return (object) null;
    }

    private static IDictionary<string, string> Convert(
      Func<object, NameObjectCollectionBase> collectionGetter)
    {
      if (!SentryRequestFactory.HasHttpContext)
        return (IDictionary<string, string>) null;
      IDictionary<string, string> dictionary1 = (IDictionary<string, string>) new Dictionary<string, string>();
      try
      {
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__0 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__0 = CallSite<Func<CallSite, Func<object, NameObjectCollectionBase>, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "Invoke", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj1 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__0.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__0, collectionGetter, SentryRequestFactory.HttpContext);
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__2 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__2 = CallSite<Func<CallSite, Type, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToArray", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        Func<CallSite, Type, object, object> target1 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__2.Target;
        // ISSUE: reference to a compiler-generated field
        CallSite<Func<CallSite, Type, object, object>> p2 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__2;
        Type type = typeof (Enumerable);
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__1 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__1 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "AllKeys", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
          {
            CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
          }));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        object obj2 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__1.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__1, obj1);
        object obj3 = target1((CallSite) p2, type, obj2);
        // ISSUE: reference to a compiler-generated field
        if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__6 == null)
        {
          // ISSUE: reference to a compiler-generated field
          SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof (IEnumerable), typeof (SentryRequestFactory)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        foreach (object obj4 in SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__6.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__6, obj3))
        {
          if (obj4 != null)
          {
            if (!(obj4 is string str1))
              str1 = obj4.ToString();
            string key = str1;
            if (!key.StartsWith("ALL_") && !key.StartsWith("HTTP_"))
            {
              // ISSUE: reference to a compiler-generated field
              if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__3 == null)
              {
                // ISSUE: reference to a compiler-generated field
                SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__3 = CallSite<Func<CallSite, object, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetIndex(CSharpBinderFlags.None, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              object obj5 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__3.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__3, obj1, key);
              if (obj5 is string str3)
              {
                dictionary1.Add(key, str3);
              }
              else
              {
                try
                {
                  // ISSUE: reference to a compiler-generated field
                  if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__5 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__5 = CallSite<Action<CallSite, IDictionary<string, string>, string, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Add", (IEnumerable<Type>) null, typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[3]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  Action<CallSite, IDictionary<string, string>, string, object> target2 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__5.Target;
                  // ISSUE: reference to a compiler-generated field
                  CallSite<Action<CallSite, IDictionary<string, string>, string, object>> p5 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__5;
                  IDictionary<string, string> dictionary2 = dictionary1;
                  string str2 = key;
                  // ISSUE: reference to a compiler-generated field
                  if (SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__4 == null)
                  {
                    // ISSUE: reference to a compiler-generated field
                    SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.GetMember(CSharpBinderFlags.None, "Value", typeof (SentryRequestFactory), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[1]
                    {
                      CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
                    }));
                  }
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  object obj6 = SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__4.Target((CallSite) SentryRequestFactory.\u003C\u003Eo__14.\u003C\u003Ep__4, obj5);
                  target2((CallSite) p5, dictionary2, str2, obj6);
                }
                catch (Exception ex)
                {
                  dictionary1.Add(key, ex.ToString());
                }
              }
            }
          }
        }
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
      }
      return dictionary1;
    }

    private static void TryGetHttpContextPropertyFromAppDomain()
    {
      if (SentryRequestFactory.checkedForHttpContextProperty)
        return;
      SentryRequestFactory.checkedForHttpContextProperty = true;
      try
      {
        Assembly assembly1 = ((IEnumerable<Assembly>) AppDomain.CurrentDomain.GetAssemblies()).FirstOrDefault<Assembly>((Func<Assembly, bool>) (assembly => assembly.FullName.StartsWith("System.Web,")));
        if (assembly1 == (Assembly) null)
          return;
        Type type1 = ((IEnumerable<Type>) assembly1.GetExportedTypes()).FirstOrDefault<Type>((Func<Type, bool>) (type => type.Name == "HttpContext"));
        if (type1 == (Type) null)
          return;
        PropertyInfo property = type1.GetProperty("Current", BindingFlags.Static | BindingFlags.Public);
        if (property == (PropertyInfo) null)
          return;
        SentryRequestFactory.CurrentHttpContextProperty = (object) property;
      }
      catch (Exception ex)
      {
        SystemUtil.WriteError(ex);
      }
    }
  }
}
*/
#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
#if NET35
using System.Web;
#endif
using Newtonsoft.Json;

using SharpRaven.Utilities;

namespace SharpRaven.Data
{
    /// <summary>
    /// A default implementation of <see cref="ISentryRequestFactory"/>. Override the <see cref="OnCreate"/>
    /// method to adjust the values of the <see cref="SentryRequest"/> before it is sent to Sentry.
    /// </summary>
    public class SentryRequestFactory : ISentryRequestFactory
    {
        private static bool checkedForHttpContextProperty;

        /// <summary>
        /// Gets or sets the CurrentHttpContextProperty
        /// </summary>
        /// <value>
        /// The current httpcontext property
        /// </value>
#if NET35
        internal static PropertyInfo CurrentHttpContextProperty { get; set; }
#else
        internal static dynamic CurrentHttpContextProperty { get; set; }
#endif

        [JsonIgnore]
        internal static bool HasCurrentHttpContextProperty
        {
            get { return CurrentHttpContextProperty != null; }
        }

        [JsonIgnore]
        internal static bool HasHttpContext
        {
            get { return HttpContext != null; }
        }

        /// <summary>
        /// Gets or sets the HTTP context.
        /// </summary>
        /// <value>
        /// The HTTP context.
        /// </value>
#if NET35
        internal static HttpContext HttpContext
#else
        internal static dynamic HttpContext
#endif

        {
            get
            {
                TryGetHttpContextPropertyFromAppDomain();

                // [Meilu] If the currentHttpcontext property is not available we couldnt retrieve it, dont continue
                if (!HasCurrentHttpContextProperty)
                    return null;

                try
                {
#if NET35
                    return CurrentHttpContextProperty.GetValue(null, null) as HttpContext;
#else
                    return CurrentHttpContextProperty.GetValue(null, null);
#endif
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                    return null;
                }
            }
        }


        /// <summary>
        /// Creates a new instance of <see cref="SentryRequest"/>
        /// for the current packet.
        /// </summary>
        /// <returns>A new instance of <see cref="SentryRequest"/> with information relating to the current HTTP request</returns>
        public ISentryRequest Create()
        {
            if (!HasHttpContext || HttpContext.Request == null)
                return OnCreate(null);

            var request = new SentryRequest
            {
                Url = HttpContext.Request.Url.ToString(),
                Method = HttpContext.Request.HttpMethod,
                Environment = Convert(x => x.Request.ServerVariables),
                Headers = Convert(x => x.Request.Headers),
#if NET35
                Cookies = ConvertHttpCookie(x => x.Request.Cookies),
#else
                Cookies = Convert(x => x.Request.Cookies),
#endif
                Data = BodyConvert(),
                QueryString = HttpContext.Request.QueryString.ToString()
            };

            return OnCreate(request);
        }


        /// <summary>
        /// Called when the <see cref="SentryRequest"/> has been created. Can be overridden to
        /// adjust the values of the <paramref name="request"/> before it is sent to Sentry.
        /// </summary>
        /// <param name="request">The HTTP request information.</param>
        /// <returns>
        /// The <see cref="SentryRequest"/>.
        /// </returns>
        public virtual SentryRequest OnCreate(SentryRequest request)
        {
            return request;
        }


        private static object BodyConvert()
        {
            if (!HasHttpContext)
                return null;

            try
            {
                return HttpRequestBodyConverter.Convert(HttpContext);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            return null;
        }

#if NET35
        private static IDictionary<string, string> ConvertHttpCookie(Func<HttpContext, HttpCookieCollection> collectionGetter)
        {
            if (!HasHttpContext)
                return null;

            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                var collection = collectionGetter.Invoke(HttpContext);
                var keys = Enumerable.ToArray(collection.AllKeys);

                foreach (object key in keys)
                {
                    if (key == null)
                        continue;

                    string stringKey = key as string ?? key.ToString();

                    // NOTE: Ignore these keys as they just add duplicate information. [asbjornu]
                    if (stringKey.StartsWith("ALL_") || stringKey.StartsWith("HTTP_"))
                        continue;

                    var value = collection[stringKey] != null ? collection[stringKey].Value : "";
                    string stringValue = value;

                    if (stringValue != null)
                    {
                        // Most dictionary values will be strings and go through this path.
                        dictionary.Add(stringKey, stringValue);
                    }
                    else
                    {
                        // HttpCookieCollection is an ugly, evil beast that needs to be treated with a sledgehammer.

                        try
                        {
                            // For whatever stupid reason, HttpCookie.ToString() doesn't return its Value, so we need to dive into the .Value property like this.
                            dictionary.Add(stringKey, value);
                        }
                        catch (Exception exception)
                        {
                            dictionary.Add(stringKey, exception.ToString());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return dictionary;
        }

#endif

#if NET35
        private static IDictionary<string, string> Convert(Func<HttpContext, NameValueCollection> collectionGetter)
#else
        private static IDictionary<string, string> Convert(Func<dynamic, NameObjectCollectionBase> collectionGetter)
#endif

        {
            if (!HasHttpContext)
                return null;

            IDictionary<string, string> dictionary = new Dictionary<string, string>();

            try
            {
                var collection = collectionGetter.Invoke(HttpContext);
                var keys = Enumerable.ToArray(collection.AllKeys);

                foreach (object key in keys)
                {
                    if (key == null)
                        continue;

                    var stringKey = key as string ?? key.ToString();

                    // NOTE: Ignore these keys as they just add duplicate information. [asbjornu]
                    if (stringKey.StartsWith("ALL_") || stringKey.StartsWith("HTTP_"))
                        continue;

                    var value = collection[stringKey];
                    var stringValue = value as string;

                    if (stringValue != null)
                    {
                        // Most dictionary values will be strings and go through this path.
                        dictionary.Add(stringKey, stringValue);
                    }
                    else
                    {
                        // HttpCookieCollection is an ugly, evil beast that needs to be treated with a sledgehammer.

                        try
                        {
                            // For whatever stupid reason, HttpCookie.ToString() doesn't return its Value, so we need to dive into the .Value property like this.
#if NET35
                            dictionary.Add(stringKey, value);
#else
                            dictionary.Add(stringKey, value.Value);
#endif
                        }
                        catch (Exception exception)
                        {
                            dictionary.Add(stringKey, exception.ToString());
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }

            return dictionary;
        }


        private static void TryGetHttpContextPropertyFromAppDomain()
        {
            if (checkedForHttpContextProperty)
                return;

            checkedForHttpContextProperty = true;

            try
            {
                var systemWeb = AppDomain.CurrentDomain;
                    //.GetAssemblies()
                    //.FirstOrDefault(assembly => assembly.FullName.StartsWith("System.Web,"));

                if (systemWeb == null)
                    return;

                Type httpContextType = default;//systemWeb.GetExportedTypes()
                    //.FirstOrDefault(type => type.Name == "HttpContext");

                if (httpContextType == null)
                    return;

                var currentHttpContextProperty = httpContextType.GetProperty("Current",
                                                                             BindingFlags.Static | BindingFlags.Public);

                if (currentHttpContextProperty == null)
                    return;

                CurrentHttpContextProperty = currentHttpContextProperty;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}
