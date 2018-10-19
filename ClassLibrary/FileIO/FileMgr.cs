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
            //string[] files = Directory.GetFiles(path);
            //foreach (string file in files)
            //{
            //    File.Delete(file);
            //}
        }
        public void CleanOuSubtDir(LevelType type)
        {
            string path = String.Format("{0}/{1}", OutDir, type.ToString());
            CleanOut(path);
            //string[] files = Directory.GetFiles(path);
            //foreach (string file in files)
            //{
            //    File.Delete(file);
            //}
        }
        private void CleanOut(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                File.Delete(file);
            }
        }
        public const string InpDir = "Inp";
        public const string OutDir = "Out";
        public const string EasySub = "Easy";
        public const string HardSub = "Hard";
    }
}
