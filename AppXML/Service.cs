using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsGame.Common.Data;

namespace AppXML
{
    public class Service
    {
        private readonly FileMgr fileMgr;
        CsvToXml csvToXml = new CsvToXml();

        public Service(FileMgr fileMgr, CsvToXml csvToXml)
        {
            this.fileMgr = fileMgr;
            this.csvToXml = csvToXml;
        }

        public void Init()
        {
            fileMgr.CleanOuSubtDir(LevelType.Easy);
            fileMgr.CleanOuSubtDir(LevelType.Hard);
        }

        public void Process(LevelType levelType)
        {
            string file = fileMgr.GetCSVFile(levelType);
            string[] lines = fileMgr.ReadCSV(file);

            string title = lines[0];
            var dict = csvToXml.GetHeaders(title);

            //int index = 1;
            for (int index = 1; index < lines.Length; index++)
            {
                string line = lines[index];
                LevelConfigData data = csvToXml.CsvToObj(dict, line);
                fileMgr.WriteXML(levelType, data);
            }
        }

    }
}
