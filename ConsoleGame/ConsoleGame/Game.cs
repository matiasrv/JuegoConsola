using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Game
    {
        public static bool gameRunning = true;

        public Game()
        {
            Console.SetCursorPosition(35, 9);
            Console.Write("Game Start");
            Console.SetCursorPosition(30, 12);
            Console.Write("Presione cualquier tecla");
            Console.ReadKey();
            Console.Clear();
        }
        public static void CheckGameOver(Entidad jugador, Entidad o, Entidad e1, Entidad e2, Entidad e3)
        {
            if (jugador.getX() == e1.getX() && jugador.getY() == e1.getY())
            {
                gameRunning = false;
            }
            else if (jugador.getX() == e2.getX() && jugador.getY() == e2.getY())
            {
                gameRunning = false;
            }
            else if (jugador.getX() == e3.getX() && jugador.getY() == e3.getY())
            {
                gameRunning = false;
            }
            else if (jugador.getX() == o.getX() && jugador.getY() == o.getY())
            {
                gameRunning = false;
            }
        }
        public void Play()
        {
            ConsoleKeyInfo userKey;
            Jugador player = new Jugador();
            Obstaculo obs1 = new Obstaculo();
            Enemigo ene1 = new Enemigo();
            Enemigo ene2 = new Enemigo(30,15);
            Enemigo ene3 = new Enemigo(40,10);
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
                obs1.Dibujar();
                ene1.Mover();
                ene2.Mover();
                ene3.Mover();
                //incluir todas las entidades como parametros
                CheckGameOver(player, obs1, ene1, ene2, ene3);

                System.Threading.Thread.Sleep(150);
            }
            Console.Clear();
            Console.SetCursorPosition(37, 12);
            Console.Write("Game Over");
            Console.ReadKey();
        }
    }
}
