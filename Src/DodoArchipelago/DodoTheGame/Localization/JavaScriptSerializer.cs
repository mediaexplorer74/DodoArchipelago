// Type: DodoTheGame.Localization.LocalizationManager

using Newtonsoft.Json;
using System;

namespace DodoTheGame.Localization
{
    public class JavaScriptSerializer
    {
        internal int MaxJsonLength;

        public object ConvertToType(object v, Type type)
        {
            //TODO
            return v;
        }

        internal T Deserialize<T>(string json)
        {
            T m = JsonConvert.DeserializeObject<T>(json);
            return m;
        }

        internal void RegisterConverters(
            System.Collections.Generic.IEnumerable<JavaScriptConverter> enumerable)
        {
            //TODO
        }

        internal string Serialize(object o)
        {
            string json = JsonConvert.SerializeObject(o);
            return json;
        }
    }
}