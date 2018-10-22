using ClassLibrary;
using ClassLibrary.FileIO;
using ClassLibrary.Helper;
using System;

namespace AppXML
{
    class Program
    {
        static void Main(string[] args)
        {
            FileMgr fileMgr = new FileMgr();
            Validate validate = new Validate();
            CsvToXml csvToXml = new CsvToXml();

            Service service = new Service(fileMgr, csvToXml, validate);
            service.Init();
            service.Process(LevelType.Easy);
            service.Process(LevelType.Hard);

            Console.WriteLine("Hello World!");
        }
    }
}
