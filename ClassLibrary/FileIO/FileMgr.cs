using System;
using System.Collections.Generic;
using System.IO;

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

        public string[] GetFiles(LevelType levelType)
        {
            string path = String.Format("{0}/{1}", InpDir, levelType.ToString());
            return Directory.GetFiles(path);
        }

        public void WriteCSV(LevelType levelType, string[] contents)
        {
            string path = String.Format("{0}/{1}.{2}", OutDir, levelType.ToString(), CsvExt);
            File.WriteAllLines(path, contents);
        }

        public const string InpDir = "Inp";
        public const string OutDir = "Out";
        public const string CsvExt = ".csv";
        public const string XmlExt = ".xml";
    }
}
