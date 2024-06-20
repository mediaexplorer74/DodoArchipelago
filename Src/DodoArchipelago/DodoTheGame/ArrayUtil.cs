// Decompiled with JetBrains decompiler
// Type: DodoTheGame.ArrayUtil
// Assembly: TheDodoArchipelago, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4C2A9301-38B7-4D1C-ADF1-1FDC2897A3B5
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\TheDodoArchipelago.exe

using System.Text;


namespace DodoTheGame
{
  public static class ArrayUtil
  {
    public static string ToString<T>(T[] array, string format = "")
    {
      StringBuilder stringBuilder = new StringBuilder();
      string format1 = "{0" + format + "}";
      for (int index = 0; index < array.Length; ++index)
      {
        if (index < array.Length - 1)
          stringBuilder.AppendFormat(format1 + ", ", (object) array[index]);
        else
          stringBuilder.AppendFormat(format1, (object) array[index]);
      }
      return stringBuilder.ToString();
    }
  }
}
