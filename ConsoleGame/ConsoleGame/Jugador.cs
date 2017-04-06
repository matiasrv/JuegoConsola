﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Dibujar();
                    break;
                case ConsoleKey.RightArrow:
                    // Si se puede mover a la derecha
                    if (locationX < 78)
                    {
                        locationX = locationX + 1;
                    }
                    Dibujar();
                    break;
                case ConsoleKey.UpArrow:
                    // Si se puede mover arriba
                    if (locationY > 0)
                    {
                        locationY = locationY - 1;
                    }
                    Dibujar();
                    break;
                case ConsoleKey.DownArrow:
                    // Si se puede mover abajo
                    if (locationY < 24)
                    {
                        locationY = locationY + 1;
                    }
                    Dibujar();
                    break;
                case ConsoleKey.Escape:
                    // Salir del juego al presionar escape
                    Program.gameRunning = false;
                    break;
            }
        }
    }
}