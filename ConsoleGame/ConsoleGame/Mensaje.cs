using System;
using System.IO;

namespace ConsoleGame
{
    class Mensaje
    {
        public static void MensajeBienvenida()
        {
            if (!File.Exists("mensajeBienvenida.txt"))
            {
                Console.WriteLine("Escriba un mensaje de bienvenida");

                FileStream fs = File.Create("mensajeBienvenida.txt");
                StreamWriter sw = new StreamWriter(fs);

                sw.Write(Console.ReadLine());

                sw.Close();

                fs.Close();
            }
            else
            {
                FileStream fs = File.OpenRead("mensajeBienvenida.txt");
                StreamReader sr = new StreamReader(fs);

                Console.SetCursorPosition(0, 12);
                Console.WriteLine(sr.ReadLine());

                sr.Close();

                fs.Close();
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}
