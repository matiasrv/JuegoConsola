using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Coin : Entidad
    {
        private static Random num = new Random();

        public Coin()
        {
            locationX = num.Next(1,80);
            locationY = num.Next(1,25);
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write(".");
        }
    }
}
