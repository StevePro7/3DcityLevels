using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using WindowsGame.Common.Data;

namespace ClassLibrary.FileIO
{
    public class FileMgr
    {
        public void CleanOutDir()
        {
            string path = String.Format("{0}", OutDir);
            CleanOut(path);
        }
        public void CleanOuSubtDir(LevelType levelType)
        {
            string path = String.Format("{0}/{1}", OutDir, levelType.ToString());
            CleanOut(path);
        }
        private void CleanOut(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }

        public string GetCSVFile(LevelType levelType)
        {
            return String.Format("{0}/{1}.{2}", InpDir, levelType.ToString(), CsvExt);
        }

        public string[] GetFiles(LevelType levelType)
        {
            string path = String.Format("{0}/{1}", InpDir, levelType.ToString());
            return Directory.GetFiles(path);
        }

        public string[] ReadCSV(string file)
        {
            return File.ReadAllLines(file);
        }

        public void WriteCSV(LevelType levelType, string[] contents)
        {
            string path = String.Format("{0}/{1}.{2}", OutDir, levelType.ToString(), CsvExt);
            File.WriteAllLines(path, contents);
        }

        public void WriteXML(LevelType levelType, LevelConfigData data)
        {
            string levelNo = data.LevelNo.ToString().PadLeft(2, '0');
            string file = String.Format("{0}-{1}.{2}", levelNo, levelType, XmlExt);
            string path = String.Format("{0}/{1}/{2}", OutDir, levelType, file);
                
            // UTF8
            // https://stackoverflow.com/questions/3862063/serializing-an-object-as-utf-8-xml-in-net

            // Namespace
            // https://stackoverflow.com/questions/625927/omitting-all-xsi-and-xsd-namespaces-when-serializing-an-object-in-net

            using (Stream stream = new FileStream(path, FileMode.Create))
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

        public const string InpDir = "Inp";
        public const string OutDir = "Out";
        public const string CsvExt = ".csv";
        public const string XmlExt = ".xml";
    }
}
