using System;

namespace ConsoleGame
{
    class Enemigo : Entidad
    {
        private static Random num = new Random();

        public Enemigo()
        {
            locationX = num.Next(10,78);
            locationY = num.Next(7,22);
        }
        public override void Dibujar()
        {
            base.Dibujar();
            Console.Write("X");
        }
        public void Mover()
        {
            switch(num.Next(1,5))
            {
                case 1:
                    if (locationX > 0)
                        locationX = locationX - 1;
                    else
                        locationX = locationX + 1;
                    Dibujar();
                    break;
                case 2:
                    if (locationX < 78)
                        locationX = locationX + 1;
                    else
                        locationX = locationX - 1;
                    Dibujar();
                    break;
                case 3:
                    if (locationY > 0)
                        locationY = locationY - 1;
                    else
                        locationY = locationY + 1;
                    Dibujar();
                    break;
                case 4:
                    if (locationY < 24)
                        locationY = locationY + 1;
                    else
                        locationY = locationY - 1;
                    Dibujar();
                    break;
            }
        }
    }
}
