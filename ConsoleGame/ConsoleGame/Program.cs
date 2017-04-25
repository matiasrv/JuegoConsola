using System;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Mensaje.MensajeBienvenida();
            Game juego = new Game();
            juego.Play();
        }
    }
}
