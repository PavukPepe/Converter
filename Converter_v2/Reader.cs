using Converter_v2;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Converter_v2
{
    internal class Reader
    {

        static List<Pivo> prom = new List<Pivo>();

        static void Get(List<Pivo> l)
        {
            int j = 0;
            var c = new Changer(0, l);
            var n = new Menu(2, l.Count() * 4 + 1);
            do
            {
                Console.Clear();
                Console.WriteLine("F1, esc");
                Console.WriteLine("------------------------------------------------------");
                c.Pock();
                j = n.Show();
                if (j == -1)
                {
                    break;
                }
                Console.SetCursorPosition(2, j + 2);
                Changer.list[j] = Console.ReadLine();
            }
            while (j != -1);
            prom = new List<Pivo>();
            for (int i  = 0; i < Changer.list.Count(); i += 4)
            {
                prom.Add(new Pivo(Changer.list[i], Changer.list[i + 1], int.Parse(Changer.list[i + 2]), int.Parse(Changer.list[i + 3])));
            }

        }
        public Reader(string path)
        {
            string line;
            if (path.EndsWith(".xml"))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Pivo>));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    prom = (List<Pivo>)xml.Deserialize(fs);
                }
                Get(prom);
            }
            if (path.EndsWith(".json"))
            {
                string sod = File.ReadAllText(path);
                prom = JsonConvert.DeserializeObject<List<Pivo>>(sod);
                Get(prom);
            }
            if (path.EndsWith(".txt"))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i += 4)
                {
                    try
                    {
                        prom.Add(new Pivo(lines[i], lines[i + 1], int.Parse(lines[i + 2]), int.Parse(lines[i + 3])));
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка чтения данных из файла!");
                    }
                }
                Get(prom);
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
