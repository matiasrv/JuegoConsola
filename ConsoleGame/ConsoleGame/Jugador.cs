using System;

namespace ConsoleGame
{
    class Jugador : Entidad
    {
        public Jugador()
        {
            Dibujar();
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write("@");
        }
        public void Mover(ConsoleKeyInfo userKey)
        {
            switch (userKey.Key)
            {
                case ConsoleKey.LeftArrow:
                    // Si se puede mover a la izquierda
                    if (locationX > 0)
                    {
                        locationX = locationX - 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    // Si se puede mover a la derecha
                    if (locationX < 78)
                    {
                        locationX = locationX + 1;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    // Si se puede mover arriba
                    if (locationY > 0)
                    {
                        locationY = locationY - 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    // Si se puede mover abajo
                    if (locationY < 24)
                    {
                        locationY = locationY + 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    // Salir del juego al presionar escape
                    Game.gameRunning = false;
                    break;
            }
        }
    }
}
