using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using WindowsGame.Common.Data;

namespace AppCSV
{
    public class Service
    {
        private readonly FileMgr fileMgr;
        private readonly XmlToCsv xmlToCsv;

        public Service(FileMgr fileMgr, XmlToCsv xmlToCsv)
        {
            this.fileMgr = fileMgr;
            this.xmlToCsv = xmlToCsv;
        }

        public void Init()
        {
            fileMgr.CleanOutDir();
        }

        public void Process(LevelType levelType)
        {
            IList<string> lines = new List<string>();

            Type dataType = typeof(LevelConfigData);
            string title = xmlToCsv.GetTitle(dataType);
            lines.Add(title);

            var dict = xmlToCsv.GetHeaders(dataType);
            string[] files = fileMgr.GetFiles(levelType);
            foreach (string file in files)
            {
                LevelConfigData data = xmlToCsv.XmlToObj(file);
                string line = xmlToCsv.ObjToCsv(dict, data);
                lines.Add(line);
            }

            string[] contents = lines.ToArray();
            fileMgr.WriteCSV(levelType, contents);
        }
    }
}
