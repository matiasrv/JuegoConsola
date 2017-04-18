﻿using System;

namespace ConsoleGame
{
    class Obstaculo : Entidad
    {
        private static Random num = new Random();

        public Obstaculo()
        {
            locationX = num.Next(1,80);
            locationY = num.Next(1,25);
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write("O");
        }
    }
}
