using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter_v2
{
    internal class Pivo
    {
        public string name;
        public string type;
        public int crepcost;
        public int plotnost;

        public Pivo(string n, string t, int c, int p)
        {
            name = n;
            type = t;
            crepcost = c;
            plotnost = p;
        }

        public Pivo() { }
        public void Getter()
        {
            Console.WriteLine(this.name);
            Console.WriteLine(this.type);
            Console.WriteLine(this.crepcost);
            Console.WriteLine(this.plotnost);
        }
        public void Writer(string path)
        {
            File.AppendAllText(path, this.name + "\n");
            File.AppendAllText(path, this.type + "\n");
            File.AppendAllText(path, this.crepcost.ToString() + "\n");
            File.AppendAllText(path, this.plotnost.ToString() + "\n");
        }

        public string[] Lister()
        {
            return new string[] { this.name, this.type, Convert.ToString(this.crepcost), Convert.ToString(this.plotnost) };
        }
    }
}
