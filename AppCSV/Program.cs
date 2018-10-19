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

            Service service = new Service(fileMgr, xmlToCsv);
            service.Process(LevelType.Easy);

            Console.WriteLine("Hello World!");
        }
    }
}
