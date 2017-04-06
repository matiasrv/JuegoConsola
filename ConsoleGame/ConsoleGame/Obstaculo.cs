using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    class Obstaculo : Entidad
    {
        public Obstaculo()
        {
            locationX = 20;
            locationY = 20;
            Dibujar();
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write("O");
        }
    }
}
