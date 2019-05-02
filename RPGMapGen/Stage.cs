using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMapGen
{
    public class Stage
    {
        private int sizeX;
        private int sizeY;
        private Cell[,] cells;
        private List<Room> rooms;
        private string roomSize;

        public int SizeX { get => sizeX; set => sizeX = value; }
        public int SizeY { get => sizeY; set => sizeY = value; }
        internal Cell[,] Cells { get => cells; set => cells = value; }
        internal List<Room> Rooms { get => rooms; set => rooms = value; }

        public Stage(int width, int height, int numRooms, string rSize)
        {
            SizeX = width;
            SizeY = height;
            Cells = new Cell[SizeX, SizeY];
            roomSize = rSize;
            initCells();
            genRooms(numRooms);
            genMaze();
        }

        private void initCells()
        {
            for(int i = 0; i<SizeX; i++)
            {
                for(int j = 0; j<SizeY; j++)
                {
                    Cells[i, j] = new Cell();
                    Cells[i, j].X = i;
                    Cells[i, j].Y = j;
                    if(i == 0)
                    {
                        Cells[i, j].Borders[0] = 1;
                    }
                    if(j == 0)
                    {
                        Cells[i, j].Borders[3] = 1;
                    }
                    if(i == SizeX - 1)
                    {
                        Cells[i, j].Borders[2] = 1;
                    }
                    if(j == SizeY - 1)
                    {
                        Cells[i, j].Borders[1] = 1;
                    }
                }
            }
        }

        private void genRooms(int totalRooms)
        {
            //function to add rooms to the stage before the maze/corridor generation
            Random rand = new Random();
            rooms = new List<Room>();
            int maxRoomSize = 10;
            int x = rand.Next(sizeX);
            int y = rand.Next(sizeY);

            if(roomSize == "Large")
            {
                maxRoomSize = 30;
            }else if(roomSize == "Medium")
            {
                maxRoomSize = 20;
            }else if(roomSize == "Small")
            {
                maxRoomSize = 10;
            }
            int roomSizeX = rand.Next(maxRoomSize);
            int roomSizeY = rand.Next(maxRoomSize);

            for(int i = 0; i < totalRooms; i++)
            {
                //try to make a room 
                
                Room newRoom = new Room(x, y, roomSizeX, roomSizeY);
            }

        }

        private void genMaze()
        {
            Random rand = new Random();
            int x = rand.Next(SizeX);
            int y = rand.Next(SizeY);

            //stack for cells
            Stack<Cell> cStack = new Stack<Cell>();

            int totalCells = SizeX * SizeY;
            int visitedCells = 1;
            Cell currCell = Cells[x, y];

            List<Vert> neighbors = new List<Vert>();
            Vert tempVert = new Vert();

            while (visitedCells < totalCells)
            {
                //clear the list because we are at a different point
                neighbors.Clear();

                tempVert = new Vert();
                if (y - 1 >= 0 && Cells[x, y - 1].checkWalls() == true)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x;
                    tempVert.Y2 = y - 1;
                    tempVert.Wall1 = 0;
                    tempVert.Wall2 = 2;
                    neighbors.Add(tempVert);
                }
                tempVert = new Vert();
                if (y+1 < SizeY && Cells[x, y+1].checkWalls() == true)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x;
                    tempVert.Y2 = y + 1;
                    tempVert.Wall1 = 2;
                    tempVert.Wall2 = 0;
                    neighbors.Add(tempVert);
                }
                tempVert = new Vert();
                if (x - 1 >= 0 && Cells[x - 1, y].checkWalls() == true)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x - 1;
                    tempVert.Y2 = y;
                    tempVert.Wall1 = 3;
                    tempVert.Wall2 = 1;
                    neighbors.Add(tempVert);
                }
                tempVert = new Vert();
                if (x + 1 < SizeX && Cells[x + 1, y].checkWalls() == true)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x + 1;
                    tempVert.Y2 = y;
                    tempVert.Wall1 = 1;
                    tempVert.Wall2 = 3;
                    neighbors.Add(tempVert);
                }

                //if we found an uncisited neighbor cell
                if(neighbors.Count() >= 1)
                {
                    //randomnly choose a neighbor
                    int random1 = rand.Next(neighbors.Count());
                    tempVert = neighbors[random1];

                    //knock down walls
                    Cells[tempVert.X1, tempVert.Y1].Walls[tempVert.Wall1] = 0;
                    Cells[tempVert.X2, tempVert.Y2].Walls[tempVert.Wall2] = 0;

                    //push currentcell to stack
                    cStack.Push(currCell);

                    //make the new cell the current cell
                    currCell = Cells[tempVert.X2, tempVert.Y2];

                    //update x and y
                    x = currCell.X;
                    y = currCell.Y;

                    visitedCells++;
                }
                else
                {
                    currCell = cStack.Pop();
                    x = currCell.X;
                    y = currCell.Y;
                }
            }
        }
    }
}
