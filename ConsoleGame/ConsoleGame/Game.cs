using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ConsoleGame
{
    class Game
    {
        public static bool gameRunning = true;
        private static int highScore = 0;
        private static int score = 0;
        private static ConsoleKeyInfo userKey;
        private static string nameHighscore;

        [Serializable]
        struct Posicion
        {
            public int x;
            public int y;
        }

        public Game()
        {
            switch (Clima.GetClima())
            {
                case "Cloudy":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    break;
                case "Sunny":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    break;
            }

            if (File.Exists("Highscore.txt"))
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
        private void Menu()
        {
            Console.Clear();
            if(highScore != 0)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Highscore = " + highScore + "  " + nameHighscore);
            }

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
            Posicion p1;
            p1.x = p1.y = 0;
            FileStream fs;
            BinaryFormatter formatter;
            

            while (gameRunning)
            {
                if (File.Exists("pos1.dat"))
                {
                    fs = File.OpenRead("pos1.dat");
                    formatter = new BinaryFormatter();
                    p1 = (Posicion)formatter.Deserialize(fs);
                    fs.Close();
                }

                player = new Jugador(p1.x, p1.y);
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
                    //dibujando todas las entidades y caracteres.
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
                //Pantalla game over
                Console.Clear();
                Console.SetCursorPosition(37, 12);
                Console.WriteLine("Game Over");
                Console.ReadKey();

                //guardado de la posicion del jugador
                p1.x = player.getX();
                p1.y = player.getY();
                if (!File.Exists("pos1.dat"))
                    fs = File.Create("pos1.dat");
                else
                    fs = File.OpenWrite("pos1.dat");
                formatter = new BinaryFormatter();
                formatter.Serialize(fs, p1);
                fs.Close();

                //guardado del highscore
                if (score > highScore)
                {
                    highScore = score;
                    fs = File.Create("Highscore.txt");
                    BinaryWriter br = new BinaryWriter(fs);
                    br.Write(highScore);
                    Console.SetCursorPosition(23, 14);
                    Console.Write("Nuevo Highscore! Ingresar nombre: ");
                    nameHighscore = Console.ReadLine();
                    br.Write(nameHighscore);
                    br.Close();
                    fs.Close();
                } score = 0;

                Console.Clear();
                Menu();
            }
        }
    }
}
