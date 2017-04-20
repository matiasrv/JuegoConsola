using System;
using System.IO;

namespace ConsoleGame
{
    class Game
    {
        public static bool gameRunning = true;
        public static int highScore = 0;
        public static int score = 0;
        private static ConsoleKeyInfo userKey;
        private static string nameHighscore;

        /*[Serializable]
        struct player1
        {
            public static int pX;
            public static int pY;
        }*/

        public Game()
        {
            if(File.Exists("Highscore.txt"))
            {
                FileStream fs = File.OpenRead("Highscore.txt");
                BinaryReader br = new BinaryReader(fs);

                highScore = br.ReadInt32();
                nameHighscore = br.ReadString();
                br.Close();
                fs.Close();
            }
            Menu();
        }
        public void Menu()
        {
            if(highScore != 0)
                Console.Write("Highscore = " + highScore + "  " + nameHighscore);

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
        private static void ChequearColisiones(Jugador _jugador, Obstaculo[] _obstaculos, Enemigo[] _enemigos, ref Coin[] _monedas)
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
            for (int i = 0; i < _monedas.Length; i++)
            {
                if(_monedas[i] != null)
                {
                    if (_jugador.getX() == _monedas[i].getX() && _jugador.getY() == _monedas[i].getY())
                    {
                        score++;
                        _monedas[i] = null;
                    }
                }
            }
        }
        public void Play()
        {
            Jugador player;
            Obstaculo[] obstaculos;
            Enemigo[] enemigos;
            Coin[] monedas;

            while (gameRunning)
            {
                player = new Jugador();
                obstaculos = new Obstaculo[10];
                for(int i= 0;i < obstaculos.Length;i++)
                    obstaculos[i] = new Obstaculo();
                enemigos = new Enemigo[10];
                for (int i = 0; i < enemigos.Length; i++)
                    enemigos[i] = new Enemigo();
                monedas = new Coin[20];
                for (int i = 0; i < monedas.Length; i++)
                    monedas[i] = new Coin();

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
                    {
                        if(monedas[i] != null)
                        monedas[i].Dibujar();
                    }
                    player.Dibujar();
                    for (int i = 0; i < obstaculos.Length; i++)
                        obstaculos[i].Dibujar();
                    for (int i = 0; i < enemigos.Length; i++)
                        enemigos[i].Mover();
                    Console.SetCursorPosition(69, 0);
                    Console.Write("SCORE: " + score);

                    ChequearColisiones(player, obstaculos, enemigos, ref monedas);

                    System.Threading.Thread.Sleep(150);
                }

                Console.Clear();
                Console.SetCursorPosition(37, 12);
                Console.WriteLine("Game Over");
                Console.ReadKey();
                if (score > highScore)
                {
                    highScore = score;
                    FileStream fs = File.Create("Highscore.txt");
                    BinaryWriter br = new BinaryWriter(fs);
                    br.Write(highScore);
                    Console.SetCursorPosition(23, 14);
                    Console.Write("Nuevo Highscore! Ingresar nombre: ");
                    nameHighscore = Console.ReadLine();
                    br.Write(nameHighscore);
                    br.Close();
                    fs.Close();
                }
                Console.Clear();
                score = 0;
                Menu();

            }
        }
    }
}
