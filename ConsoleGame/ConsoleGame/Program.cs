using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Program
    {

        public static bool gameRunning = true;

       /* public static void CheckGameOver()
        {
            if (locationX == ObstacleX && locationY == ObstacleY)
            {
                Console.Clear();
                Console.SetCursorPosition(55, 13);
                Console.Write("Game Over");
                Console.ReadKey();
                gameRunning = false;
            }
        }*/
        static void Main(string[] args)
        {
            ConsoleKeyInfo userKey;
            Jugador player = new Jugador();
            while (gameRunning)
            {
                Console.Clear();
                // Proceso de input para movimiento del jugador
                if (Console.KeyAvailable)
                {
                    userKey = Console.ReadKey(true);
                    player.Mover(userKey);
                }
                //dibujar todas las entidades
                player.Dibujar();
                System.Threading.Thread.Sleep(100);        
            }
        }
    }
}
