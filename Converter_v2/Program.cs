using System.Threading.Channels;

namespace Converter_v2
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
                    else if (key == ConsoleKey.F1)
                    {
                        Console.Clear();
                        Console.WriteLine("Куда");
                        Console.WriteLine("------------------------------------------------------");
                        a.Saver(Console.ReadLine());
                        Console.WriteLine("------------------------------------------------------");
                        Console.WriteLine("Сяб");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Че понажмал");
                        key = Console.ReadKey().Key;
                        key = ConsoleKey.Enter;
                        continue;
                    }
                }
                if (key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }
    }
}