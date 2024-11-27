
// Type: DodoTheGame.ArrayUtil

//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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
