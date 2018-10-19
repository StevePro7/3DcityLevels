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
            CsvToXml csvToXml = new CsvToXml();

            Service service = new Service(fileMgr, csvToXml);
            Console.WriteLine("Hello World!");
        }
    }
}
