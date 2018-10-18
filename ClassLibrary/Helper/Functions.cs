using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class Functions
    {
        char[] DELIM = new char[] { ',' };

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
                var conv = Convert.ChangeType(item, field.FieldType);
                fields[idx].SetValue(data, conv);
            }
            
            //{
            //    FieldInfo field = fields[idx];
            //    string name = field.Name;
            //}


            return data;
        }

        public IDictionary<string, int> GetHeaders()
        {
            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            FieldInfo[] fields = typeof(LevelConfigData).GetFields();
            for (Byte index = 0; index < fields.Length; index++)
            {
                FieldInfo field = fields[index];
                dictionary.Add(field.Name, index);
            }

            return dictionary;
        }
    }
}
