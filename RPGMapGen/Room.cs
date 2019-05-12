using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMapGen
{
    class Room
    {
        private int sizeX;
        private int sizeY;
        private int startX;
        private int startY;
        private int entrances;
        private bool hasStairs;
        private int numStairs;
        private int roomNum;
        private int doorX;
        private int doorY;

        public Room(int sX, int sY, int randSizeX, int randSizeY)
        {
            SizeX = randSizeX;
            SizeY = randSizeY;
            startX = sX;
            startY = sY;
        }

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        public int Entrances { get => entrances; set => entrances = value; }
        public bool HasStairs { get => hasStairs; set => hasStairs = value; }
        public int NumStairs { get => numStairs; set => numStairs = value; }
        public int RoomNum { get => roomNum; set => roomNum = value; }
        public int StartX { get => startX; set => startX = value; }
        public int StartY { get => startY; set => startY = value; }
        public int DoorX { get => doorX; set => doorX = value; }
        public int DoorY { get => doorY; set => doorY = value; }
    }
}
