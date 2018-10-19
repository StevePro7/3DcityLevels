using System;
using System.Collections.Generic;
using System.Reflection;
using WindowsGame.Common.Data;

namespace ClassLibrary.Helper
{
    public class Functions
    {
        char[] DELIM = new char[] { ',' };

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
