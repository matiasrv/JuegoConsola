using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {
        private static int locationX = 0;
        private static int locationY = 0;
        private static int ObstacleX = 20;
        private static int ObstacleY = 20;
        private static bool gameRunning = true;


        public static void DrawEntity()
        {
            // Dibujar al jugador
            Console.Clear();
            Console.SetCursorPosition(locationX, locationY);
            Console.Write("@");
            Console.SetCursorPosition(ObstacleX, ObstacleY);
            Console.Write("O");
        }
        public static void CheckGameOver()
        {
            if (locationX == ObstacleX && locationY == ObstacleY)
            {
                Console.Clear();
                Console.SetCursorPosition(55, 13);
                Console.Write("Game Over");
                Console.ReadKey();
                gameRunning = false;
            }
        }
        static void Main(string[] args)
        {
            ConsoleKeyInfo userKey;
            DrawEntity();
            while (gameRunning)
            {
                CheckGameOver();
                // Proceso de input
                if (Console.KeyAvailable)
                {
                    userKey = Console.ReadKey(true);
                    switch (userKey.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            // Si se puede mover a la izquierda
                            if (locationX > 0)
                            {
                                locationX = locationX - 1;
                            }
                            DrawEntity();
                            break;
                        case ConsoleKey.RightArrow:
                            // Si se puede mover a la derecha
                            if (locationX < 78)
                            {
                                locationX = locationX + 1;
                            }
                            DrawEntity();
                            break;
                        case ConsoleKey.UpArrow:
                            // Si se puede mover arriba
                            if (locationY > 0)
                            {
                                locationY = locationY - 1;
                            }
                            DrawEntity();
                            break;
                        case ConsoleKey.DownArrow:
                            // Si se puede mover abajo
                            if (locationY < 24)
                            {
                                locationY = locationY + 1;
                            }
                            DrawEntity();
                            break;
                        case ConsoleKey.Escape:
                            // Salir del juego al presionar escape
                            gameRunning = false;
                            break;
                    }
                }           
            }
        }
    }
}
