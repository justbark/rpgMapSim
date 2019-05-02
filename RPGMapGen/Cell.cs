using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMapGen
{
    class Cell
    {
        private byte[] walls = { 1, 1, 1, 1 };
        private byte[] borders = { 0, 0, 0, 0 };
        private int x;
        private int y;

        public bool checkWalls()
        {
            if(walls[0] == 1 && walls[1] == 1 && walls[2] == 1 && walls[3] == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public byte[] Walls { get => walls; set => walls = value; }
        public byte[] Borders { get => borders; set => borders = value; }
    }
}
