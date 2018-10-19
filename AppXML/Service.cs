using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
