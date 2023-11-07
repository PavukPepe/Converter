using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;

namespace Converter
{
    internal class Reader
    {

        string sod = null;
        static List<Pivo> prom = new List<Pivo>();
        static void Get(string path)
        {
            foreach (var p in prom)
            {
                p.Getter();
            }
        }
        public Reader(string path)
        {
            string line;
            sod = File.ReadAllText(path);
            if (path.EndsWith(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Pivo>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    prom = (List<Pivo>)xml.Deserialize(fs);
                }
                Get(path);
            }
            if (path.EndsWith(".json"))
            {
                prom = JsonConvert.DeserializeObject<List<Pivo>>(sod);
                Get(path);
            }
            if (path.EndsWith(".txt"))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i+=4)
                {
                    try
                    {
                        prom.Add(new Pivo(lines[i], lines[i + 1], int.Parse(lines[ i + 2]), int.Parse(lines[ i + 3])));
                    }
                    catch
                    {
                        Console.WriteLine("jib,");
                    }
                }
                Get(path);
            }
        }

        public void Saver(string path)
        {
            if (path.EndsWith(".json"))
            {
                string json = JsonConvert.SerializeObject(prom);
                File.WriteAllText(path, json);
            }
            if (path.EndsWith(".txt"))
            {
                foreach (var item in prom)
                {
                    item.Writer(path);
                }
            }
            if (path.EndsWith(".xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Pivo>));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    xmlSerializer.Serialize(fs, prom); 
                }
            }
        }

        


    }
}
