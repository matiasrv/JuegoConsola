using System;

namespace ConsoleGame
{
    class Entidad
    {
        protected int locationX = 0;
        protected int locationY = 0;

        virtual public void Dibujar()
        {
            Console.SetCursorPosition(locationX, locationY);
        }
        public int getX()
        {
            return locationX;
        }
        public int getY()
        {
            return locationY;
        }
        public void setX(int x)
        {
            locationX = x;
        }
        public void setY(int y)
        {
            locationY = y;
        }
    }
}
