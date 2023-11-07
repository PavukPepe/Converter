using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Converter_v2
{
    internal class Changer
    {
        static public List<string> list = new List<string>();
        public Changer(int m, List<Pivo> l) 
        {
            int min = m;
            int max = l.Count;
            Changer_l(l);
        }
        
        static void Changer_l(List<Pivo> l)
        {
            foreach (Pivo pivo in l)
            {
                list.Add(pivo.name);
                list.Add(pivo.type);
                list.Add(Convert.ToString(pivo.crepcost));
                list.Add(Convert.ToString(pivo.plotnost));
            }
            
        }

        public void Pock()
        {
            foreach (var i in list)
            {
                Console.WriteLine("  " + i);
            }
        }
    }
}
