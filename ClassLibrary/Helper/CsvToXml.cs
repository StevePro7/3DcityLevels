using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class CsvToXml
    {
        char[] DELIM = new char[] { ',' };

        public IDictionary<string, int> GetHeaders(string title)
        {
            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] headers = title.Split(DELIM);
            for (int idx = 0; idx < headers.Length; idx++)
            {
                string header = headers[idx];
                dictionary.Add(header, idx);
            }
           
            return dictionary;
        }

        public LevelConfigData CsvToObj(IDictionary<string, int> dict, string line)
        {
            string[] items = line.Split(DELIM);

            LevelConfigData data = new LevelConfigData();
            FieldInfo[] fields = data.GetType().GetFields();

            //int idx = 0;
            for (int idx = 0; idx < fields.Length; idx++)
            {
                string item = items[idx];
                FieldInfo field = fields[idx];
                string key = field.Name;
                int value = dict[key];

                // TODO pad LevelNo with '0' when build CSV
                var conv = Convert.ChangeType(item, field.FieldType);
                fields[idx].SetValue(data, conv);
            }

            return data;
        }

        public void ObjToXml(LevelConfigData data)
        {
            string fileName = String.Format("{0}-{1}.xml", data.LevelNo, data.LevelName);

            // UTF8
            // https://stackoverflow.com/questions/3862063/serializing-an-object-as-utf-8-xml-in-net

            // Namespace
            // https://stackoverflow.com/questions/625927/omitting-all-xsi-and-xsd-namespaces-when-serializing-an-object-in-net

            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(LevelConfigData));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, String.Empty);

                    serializer.Serialize(writer, data, ns);
                }

            }
        }

    }
}
