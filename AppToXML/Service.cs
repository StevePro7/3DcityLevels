using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;
using System.Collections.Generic;
using WindowsGame.Common.Data;

namespace AppXML
{
    public class Service
    {
        private readonly FileMgr fileMgr;
        private readonly CsvToXml csvToXml = new CsvToXml();
        private readonly Validate validate;

        public Service(FileMgr fileMgr, CsvToXml csvToXml, Validate validate)
        {
            this.fileMgr = fileMgr;
            this.csvToXml = csvToXml;
            this.validate = validate;
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

            Boolean isValid = true;
            IList<LevelConfigData> items = new List<LevelConfigData>();
            for (int index = 1; index < lines.Length; index++)
            {
                string line = lines[index];
                LevelConfigData data = csvToXml.CsvToObj(dict, line);
                ErrorType errorType = validate.ValidLevelConfigData(data);
                if (ErrorType.None != errorType)
                {
                    Console.WriteLine(file + " => " + errorType);
                    isValid = false;
                }

                items.Add(data);
            }

            if (isValid)
            {
                foreach (LevelConfigData data in items)
                {
                    fileMgr.WriteXML(levelType, data);
                }
            }
        }

    }
}
