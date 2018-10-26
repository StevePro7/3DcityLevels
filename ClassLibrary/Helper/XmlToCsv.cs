using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class XmlToCsv
    {
        const string DELIM = ",";

        public string GetTitle(Type type)
        {
            StringBuilder sb = new StringBuilder();

            FieldInfo[] fields = type.GetFields();
            for (Byte index = 0; index < fields.Length; index++)
            {
                FieldInfo field = fields[index];
                sb.Append(field.Name);
                sb.Append(DELIM);
            }

            string header = sb.ToString();
            return header.Substring(0, header.Length - 1);
        }

        public IDictionary<string, int> GetHeaders(Type type)
        {
            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            FieldInfo[] fields = type.GetFields();
            for (Byte index = 0; index < fields.Length; index++)
            {
                FieldInfo field = fields[index];
                dictionary.Add(field.Name, index);
            }

            return dictionary;
        }

        public LevelConfigData XmlToObj(string file)
        {
            LevelConfigData data;

            using (Stream stream = new FileStream(file, FileMode.Open))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(LevelConfigData));
                data = (LevelConfigData)serializer.Deserialize(stream);
            }

            return data;
        }

        public string ObjToCsv(IDictionary<string, int> dict, LevelConfigData data)
        {
            string[] items = new string[dict.Count];
            FieldInfo[] fields = data.GetType().GetFields();

            //int idx = 0;
            for (int idx = 0; idx < fields.Length; idx++)
            {
                FieldInfo field = fields[idx];
                string key = field.Name;
                object val = field.GetValue(data);
                string txt = val.ToString();
                if (field.FieldType == typeof(Boolean))
                {
                    txt = txt.ToUpper();
                }
                int lookd = dict[key];
                items[lookd] = txt;
            }

            return String.Join(DELIM, items);
        }

    }
}
