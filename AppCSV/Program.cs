using ClassLibrary;
using ClassLibrary.FileIO;
using System;

namespace AppCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            FileMgr fileMgr = new FileMgr();
            //fileMgr.CleanOuSubtDir(LevelType.Easy);

            Service service = new Service(fileMgr);

            Console.WriteLine("Hello World!");
        }
    }
}
