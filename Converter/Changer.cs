using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    internal class Changer
    {
        public Changer(int m, List<Pivo> l) 
        {
            int min = m;
            int max = l.Count;

            string[] list = Changer.Changer_l(l);
        }
        static string[] Changer_l(List<Pivo> l)
        {
            string[] s = new string[l.Count * 4];
            foreach (Pivo pivo in l)
            {
                s.Append(pivo.name);
                s.Append(pivo.type);
                s.Append(Convert.ToString(pivo.crepcost));
                s.Append(Convert.ToString(pivo.plotnost));
            }
            return s;
        }

        public void Show(string[] list)
        {
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
