using ClassLibrary;
using ClassLibrary.FileIO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCSV
{
    public class Service
    {
        private readonly FileMgr fileMgr;

        public Service(FileMgr fileMgr)
        {
            this.fileMgr = fileMgr;
        }

        public void Process(LevelType type)
        {
            fileMgr.CleanOuSubtDir(type);
        }
    }
}
