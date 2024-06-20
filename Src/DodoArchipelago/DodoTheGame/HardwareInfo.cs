// Type: DodoTheGame.HardwareInfo


using System;
using System.Collections.Generic;
//using System.Management;
using System.Security.Cryptography;
using System.Text;


namespace DodoTheGame
{
  internal class HardwareInfo
  {
    private static string GetDiskVolumeSerialNumber()
    {
      try
      {
        ManagementObject managementObject = new ManagementObject("Win32_LogicalDisk.deviceid=\"c:\"");
        managementObject.Get();
        return default;//managementObject["VolumeSerialNumber"].ToString();
      }
      catch
      {
        return string.Empty;
      }
    }

    private static string GetProcessorId()
    {
      try
      {
        ManagementObjectCollection objectCollection = new ManagementObjectSearcher("Select ProcessorId From Win32_processor").Get();
        string empty = string.Empty;
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = objectCollection.GetEnumerator())
        {
                    if (enumerator.MoveNext())
                        empty = "";//enumerator.Current["ProcessorId"].ToString();
        }
        return empty;
      }
      catch
      {
        return string.Empty;
      }
    }

    private static string GetMotherboardID()
    {
      try
      {
        ManagementObjectCollection objectCollection = new ManagementObjectSearcher("Select SerialNumber From Win32_BaseBoard").Get();
        string empty = string.Empty;
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = objectCollection.GetEnumerator())
        {
                    if (enumerator.MoveNext())
                        empty = "";// enumerator.Current["SerialNumber"].ToString();
        }
        return empty;
      }
      catch
      {
        return string.Empty;
      }
    }

    private static IEnumerable<string> SplitInParts(string input, int partLength)
    {
      if (input == null)
        throw new ArgumentNullException(nameof (input));
      if (partLength <= 0)
        throw new ArgumentException("Part length has to be positive.", nameof (partLength));
      for (int i = 0; i < input.Length; i += partLength)
        yield return input.Substring(i, Math.Min(partLength, input.Length - i));
    }

    public static string GenerateUID()
    {
      byte[] bytes = Encoding.UTF8.GetBytes(HardwareInfo.GetProcessorId() 
          + HardwareInfo.GetMotherboardID() + HardwareInfo.GetDiskVolumeSerialNumber() 
          + "dfVWmInaMyUOrimYj9GLCcPL5N7XG81dnIHamtJabMkYmyTFuf");
      return HardwareInfo.ByteArrayToString(SHA256.Create().ComputeHash(bytes));
    }

    private static string ByteArrayToString(byte[] ba)
    {
      StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
      foreach (byte num in ba)
        stringBuilder.AppendFormat("{0:x2}", (object) num);
      return stringBuilder.ToString();
    }
  }
}
