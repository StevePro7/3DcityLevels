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
        private readonly Logger logger;
        private readonly FileMgr fileMgr;
        private readonly XmlToCsv xmlToCsv;
        private readonly Validate validate;

        public Service(Logger logger, FileMgr fileMgr, XmlToCsv xmlToCsv, Validate validate)
        {
            this.logger = logger;
            this.fileMgr = fileMgr;
            this.xmlToCsv = xmlToCsv;
            this.validate = validate;
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

            Boolean isValid = true;
            foreach (string file in files)
            {
                LevelConfigData data = xmlToCsv.XmlToObj(file);
                //ErrorType errorType = validate.ValidLevelConfigData(data);
                String error = validate.ValidLevelConfigData(data);
                if (!String.IsNullOrEmpty(error))
                {
                    String msg = String.Format("{0} [{1}] => {2}", file, data.LevelNo.ToString().PadLeft(2, '0'), error);
                    logger.Error(msg);
                    isValid = false;
                }

                string line = xmlToCsv.ObjToCsv(dict, data);
                lines.Add(line);
            }

            if (isValid)
            {
                string[] contents = lines.ToArray();
                fileMgr.WriteCSV(levelType, contents);
            }
        }
    }
}
