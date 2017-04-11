using System;

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
        public static void CheckGameOver(Entidad jugador, Entidad o, Entidad e1, Entidad e2, Entidad e3)//modificar
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

            Enemigo[] enemigos = new Enemigo[3];
            for(int i=0;i<enemigos.Length;i++)
            {
                enemigos[i] = new Enemigo();
            }
            for (int i = 0; i < enemigos.Length; i++)
            {
                enemigos[i].Dibujar();
            }

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
                for (int i = 0; i < enemigos.Length; i++)
                    enemigos[i].Mover();
                //incluir todas las entidades como parametros
                CheckGameOver(player, obs1, enemigos[0], enemigos[1], enemigos[2]);//modificar

                System.Threading.Thread.Sleep(150);
            }
            Console.Clear();
            Console.SetCursorPosition(37, 12);
            Console.Write("Game Over");
            Console.ReadKey();
        }
    }
}
