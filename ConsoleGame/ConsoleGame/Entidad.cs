using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
