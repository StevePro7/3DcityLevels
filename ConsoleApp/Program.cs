﻿using ClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using WindowsGame.Common.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlToCsv xmlToCsv = new XmlToCsv();
            Type type = typeof(LevelConfigData);
            string title = xmlToCsv.GetTitle(type);
            var dict = xmlToCsv.GetHeaders(type);
            string file = "01-MOOT.xml";
            LevelConfigData data = xmlToCsv.XmlToObj(file);
            string line = xmlToCsv.ObjToCsv(dict, data);

            int x = 7;

            /*
            CsvToXml csvToXml = new CsvToXml();
            var dict = csvToXml.GetHeaders("LevelNo,LevelName,BonusLevel,GridDelay,BulletMaxim");
            String line = "01,MOOT,true,250,10";
            LevelConfigData data = csvToXml.CsvToObj(dict, line);
            csvToXml.ObjToXml(data);
            */


            //LevelConfigData source = new LevelConfigData { LevelNo = "01" };
            //Object obj = (Object)source;
            ////LevelConfigData dst = new LevelConfigData();

            //// ORIGINALLY code did not set the value
            //// actually did set bu=t LevelConfigData is a value type struct
            //// so makes the copy on the value type struct
            //// Solution is to either make LevelConfigData a class and works first time
            //// OR box LevelConfigData as an object and set all the fields on the object
            //// then when finished unbox back to value type struct LevelConfigData
            //// Reference : https://social.msdn.microsoft.com/Forums/vstudio/en-US/33284e33-d004-4b76-bc0f-50100ec46bf1/fieldinfosetvalue-dont-work-in-struct?forum=csharpgeneral


            //FieldInfo[] fields = source.GetType().GetFields();
            ////fields[0].SetValue(source, (Byte)2);
            //fields[0].SetValue(obj, (Byte)2);

            //source = (LevelConfigData)obj;

            //FieldInfo[] fields = typeof(LevelConfigData).GetFields();
            //foreach (FieldInfo field in fields)
            //{
            //    string name = field.Name;
            //    if ("LevelNo" == name)
            //    {
            //        const Byte levelNo = 5;
            //        var blah = Convert.ChangeType(levelNo, field.FieldType);
            //        field.SetValue(data, blah);
            //    }

            //    Console.WriteLine(name);
            //}

            //char[] DELIM = new char[] { ',' };
            //string[] lines = File.ReadAllLines("Levels.csv");

            //string line = lines[0];
            //string[] headers = line.Split(DELIM);

            //IDictionary<string, int> dictionary = new Dictionary<string, int>();
            //for (int index = 0; index < headers.Length; index++)
            //{
            //    string header = headers[index];
            //    if (!dictionary.ContainsKey(header))
            //    {
            //        dictionary.Add(header, index);
            //    }
            //}


            Console.WriteLine("Hello World!");
        }
    }
}
