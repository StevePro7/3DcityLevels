using System;
using System.IO;
using WindowsGame.Common.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LevelConfigData data = new LevelConfigData
            {
                LevelNo = 1,
                LevelName = "MOOT",
                BonusLevel = false,
                GridDelay = 200,
                BulletMaxim = 5,
                BulletFrame = 10,
                BulletShoot = 50,
                EnemySpawn = 1,
                EnemyTotal = 5,
            };

            using (Stream stream = new FileStream("steve.xml", FileMode.Create))
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LevelConfigData));
                serializer.Serialize(stream, data);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
