using System;
using System.IO;

namespace ConsoleGame
{
    class Program
    {
        static void MensajeBienvenida()
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
                FileStream fs = File.OpenRead("mensajeBienvenida");
                StreamReader sr = new StreamReader(fs);

                Console.WriteLine(sr.Read());

                sr.Close();

                fs.Close();
            }
        }
        static void Main(string[] args)
        {


            MensajeBienvenida();
            Game juego = new Game();
            juego.Play();
        }
    }
}
