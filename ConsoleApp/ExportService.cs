using System;
using System.IO;
using System.Xml.Serialization;
using WindowsGame.Common.Data;

namespace ConsoleApp
{
    public class ExportService
    {
        public void Process()
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
                EnemyFrameDelay = 100,
            };

            const string fileName = "steve.xml";

            // UTF8
            https://stackoverflow.com/questions/3862063/serializing-an-object-as-utf-8-xml-in-net

            // Namespace
            //https://stackoverflow.com/questions/625927/omitting-all-xsi-and-xsd-namespaces-when-serializing-an-object-in-net

            using (Stream stream = new FileStream(fileName, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, System.Text.Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(LevelConfigData));
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add(String.Empty, String.Empty);

                    serializer.Serialize(writer, data, ns);
                }

            }

            //using (Stream stream = new FileStream("steve.xml", FileMode.Create))
            //{

            //    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(LevelConfigData));
            //    //https://stackoverflow.com/questions/625927/omitting-all-xsi-and-xsd-namespaces-when-serializing-an-object-in-net
            //    System.Xml.Serialization.XmlSerializerNamespaces ns = new System.Xml.Serialization.XmlSerializerNamespaces();
            //    ns.Add(String.Empty, String.Empty);
            //    serializer.Serialize(stream, data, ns);
            //}
        }
    }
}
