// Type: DodoTheGame.Localization.LocalizationManager

using Newtonsoft.Json;
using System;
using System.Diagnostics;

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
            //
        }

        internal string Serialize(object o)
        {
            string json = "unrecognized";
            try
            {
                json = JsonConvert.SerializeObject(o);
            }
            catch (Exception ex) 
            {
                Debug.WriteLine("[ex] JavaScriptSerializer - JsonConvert.SerializeObject error: " 
                    + ex.Message);
            }

            return json;
        }
    }
}