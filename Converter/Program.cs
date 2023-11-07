using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Converter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                ConsoleKey key = ConsoleKey.Enter;
                Console.WriteLine("Введите имя файла (.json, .txt, .xml)");
                Console.WriteLine("------------------------------------------------------");
                string path = Console.ReadLine();
                try
                {
                    if (key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        Console.WriteLine("F1, esc");
                        Console.WriteLine("------------------------------------------------------");
                        var a = new Reader(path);
                        key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Escape)
                        {
                            Console.Clear();
                            continue;
                        }
                        if (key == ConsoleKey.F1)
                        {
                            Console.Clear();
                            Console.WriteLine("Куда");
                            Console.WriteLine("------------------------------------------------------");
                            a.Saver(Console.ReadLine());
                            Console.WriteLine("------------------------------------------------------");
                            Console.WriteLine("Сяб");
                            break;
                        }
                        if (key == ConsoleKey.F2)
                        {

                        } 
                    }
                    if (key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                catch 
                {
                    Console.Clear() ;
                    continue;
                }           
            }
        }
    }
}