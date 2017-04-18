using System;

namespace ConsoleGame
{
    class Game
    {
        public static bool gameRunning = true;
        public static int highScore = 0;
        public static int score = 0;

        public Game()
        {
            Console.SetCursorPosition(35, 9);
            Console.Write("Game Start");
            Console.SetCursorPosition(22, 12);
            Console.Write("Nuevo Juego = Enter   Salir = Escape");
        }
        private static void ChequearColisiones(Entidad _jugador, Entidad[] _obstaculos, Entidad[] _enemigos, Entidad[] _monedas)
        {
            for (int i = 0; i < _enemigos.Length; i++)
            {
                if (_jugador.getX() == _enemigos[i].getX() && _jugador.getY() == _enemigos[i].getY())
                {
                    gameRunning = false;
                }
            }
            for (int i = 0; i < _obstaculos.Length; i++)
            {
                if (_jugador.getX() == _obstaculos[i].getX() && _jugador.getY() == _obstaculos[i].getY())
                {
                    gameRunning = false;
                }
            }
            /*for (int i = 0; i < _monedas.Length; i++)
            {
                if (_jugador.getX() == _monedas[i].getX() && _jugador.getY() == _monedas[i].getY())
                {
                    score++;
                    _monedas[i].kill();
                }
            }*/
        }
        public void Play()
        {
            ConsoleKeyInfo userKey;
            do
            {
                userKey = Console.ReadKey();
                switch (userKey.Key)
                {
                    case ConsoleKey.Enter:
                        gameRunning = true;
                        break;
                    case ConsoleKey.Escape:
                        gameRunning = false;
                        break;
                }
            } while (userKey.Key != ConsoleKey.Enter && userKey.Key != ConsoleKey.Escape);

            while (gameRunning)
            {
                Jugador player = new Jugador();
                Obstaculo[] obstaculos = new Obstaculo[10];
                for(int i= 0;i < obstaculos.Length;i++)
                {
                    obstaculos[i] = new Obstaculo();
                }
                Enemigo[] enemigos = new Enemigo[10];
                for (int i = 0; i < enemigos.Length; i++)
                {
                    enemigos[i] = new Enemigo();
                }
                Coin[] monedas = new Coin[20];
                for (int i = 0; i < monedas.Length; i++)
                {
                    monedas[i] = new Coin();
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
                    for (int i = 0; i < monedas.Length; i++)
                        monedas[i].Dibujar();
                    player.Dibujar();
                    for (int i = 0; i < obstaculos.Length; i++)
                        obstaculos[i].Dibujar();
                    for (int i = 0; i < enemigos.Length; i++)
                        enemigos[i].Mover();

                    ChequearColisiones(player, obstaculos, enemigos, monedas);

                    System.Threading.Thread.Sleep(150);
                }
                if (score > highScore)
                {
                    highScore = score;
                    score = 0;
                }

                Console.Clear();
                Console.SetCursorPosition(37, 12);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(22, 13);
                Console.Write("Nuevo Juego = Enter   Salir = Escape");

                do
                {
                    userKey = Console.ReadKey();
                    switch (userKey.Key)
                    {
                        case ConsoleKey.Enter:
                            gameRunning = true;
                            break;
                        case ConsoleKey.Escape:
                            gameRunning = false;
                            break;
                    }
                } while (userKey.Key != ConsoleKey.Enter && userKey.Key != ConsoleKey.Escape);

            }
            Console.Clear();
            Console.SetCursorPosition(36, 12);
            Console.Write("saliendo");
            Console.ReadKey();
        }
    }
}
