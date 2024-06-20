// Decompiled with JetBrains decompiler
// Type: SharpRaven.Data.Context.RuntimeExtensions
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll


namespace SharpRaven.Data.Context
{
  internal static class RuntimeExtensions
  {
    public static bool IsNetFx(this Runtime runtime) => runtime.IsRuntime(".NET Framework");

    public static bool IsNetCore(this Runtime runtime) => runtime.IsRuntime(".NET Core");

    private static bool IsRuntime(this Runtime runtime, string runtimeName)
    {
      if (runtime != null)
      {
        bool? nullable = runtime.Name?.StartsWith(runtimeName);
        bool flag = true;
        if ((nullable.GetValueOrDefault() == flag ? (nullable.HasValue ? 1 : 0) : 0) != 0)
          return true;
      }
      if (runtime == null)
        return false;
      bool? nullable1 = runtime.RawDescription?.StartsWith(runtimeName);
      bool flag1 = true;
      return nullable1.GetValueOrDefault() == flag1 && nullable1.HasValue;
    }
  }
}
