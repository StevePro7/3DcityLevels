using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;

namespace AppCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            String fileName = "AppToCSV.dll.config";
            logger.Initialize(fileName);
            logger.Info(fileName);

            FileMgr fileMgr = new FileMgr();
            XmlToCsv xmlToCsv = new XmlToCsv();
            Validate validate = new Validate();

            Service service = new Service(logger, fileMgr, xmlToCsv, validate);
            service.Init();
            service.Process(LevelType.Easy);
			service.Process(LevelType.Hard);

			Console.WriteLine("Hello World!");
        }
    }
}
