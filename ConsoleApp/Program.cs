﻿using System;
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
                //https://stackoverflow.com/questions/625927/omitting-all-xsi-and-xsd-namespaces-when-serializing-an-object-in-net
                System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
                ns.Add(String.Empty, String.Empty);
                serializer.Serialize(stream, data, ns);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
