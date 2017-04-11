using System;

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
        public Obstaculo(int x, int y)
        {
            locationX = x;
            locationY = y;
            Dibujar();
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write("O");
        }
    }
}
