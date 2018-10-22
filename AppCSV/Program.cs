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
            FileMgr fileMgr = new FileMgr();
            XmlToCsv xmlToCsv = new XmlToCsv();
            Validate validate = new Validate();

            Service service = new Service(fileMgr, xmlToCsv, validate);
            service.Init();
            service.Process(LevelType.Easy);
			service.Process(LevelType.Hard);

			Console.WriteLine("Hello World!");
        }
    }
}
