// Decompiled with JetBrains decompiler
// Type: SharpRaven.Configuration
// Assembly: SharpRaven, Version=2.4.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9D0D9023-551F-4804-A710-4EBBC1F9BFAE
// Assembly location: C:\Users\Admin\Desktop\Portable\Dodo\SharpRaven.dll

using System;//.Configuration;


namespace SharpRaven
{
  public class Configuration : ConfigurationSection
  {
    private const string DsnKey = "dsn";
    private static readonly SharpRaven.Configuration settings 
            = ConfigurationManager.GetSection("sharpRaven") as SharpRaven.Configuration;

        //[ConfigurationProperty("dsn", IsKey = true)]
        public SharpRaven.Configuration.DsnElement Dsn
        {
            get
            {
                return default;//(SharpRaven.Configuration.DsnElement)this["dsn"];
            }
        }

        public static SharpRaven.Configuration Settings => SharpRaven.Configuration.settings;

    public class DsnElement : ConfigurationElement
    {
      [ConfigurationProperty("value")]
      public string Value
            {
                get
                {
                    return default;//return (string)this["value"];
                }

                set
                {
                    //this[nameof(value)] = (object)value;
                }
            }
        }
  }
}
