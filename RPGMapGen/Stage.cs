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
            sizeX = width;
            sizeY = height;
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
                    if(i == SizeY - 1)
                    {
                        Cells[i, j].Borders[2] = 1;
                    }
                    if(j == SizeX - 1)
                    {
                        Cells[i, j].Borders[1] = 1;
                    }
                    //north border = 0
                    //east border = 1
                    //south border = 2
                    //west border = 3
                }
            }
        }

        private void genRooms(int totalRooms)
        {
            //function to add rooms to the stage before the maze/corridor generation
            Random rand = new Random();
            rooms = new List<Room>();
            

            //if using borders:
            //north border = 0
            //east border = 1
            //south border = 2
            //west border = 3

            //try by setting the entire cell (roomCell) to true?
            int roomCount = 0;
            while(roomCount < totalRooms)
            {
                //try to make a room 
                int maxRoomSize = 10;
                int x = rand.Next(sizeX);
                int y = rand.Next(sizeY);

                if (roomSize == "Large")
                {
                    maxRoomSize = 12;
                }
                else if (roomSize == "Medium")
                {
                    maxRoomSize = 10;
                }
                else if (roomSize == "Small")
                {
                    maxRoomSize = 8;
                }

                int roomSizeX = rand.Next(3, maxRoomSize);
                int roomSizeY = rand.Next(3, maxRoomSize);
                //1.) make sure the room will fit on the map
                if (x + roomSizeX > sizeX || y + roomSizeY > sizeY)
                    continue;
                //1.) make sure that none of the cells that would make the room
                //    are taken
                bool interupt = false;
                for(int i = x; i < x + roomSizeX; i++)
                {
                    for( int j = y; j < y + roomSizeY; j++)
                    {
                        if (cells[i, j].RoomCell)
                        {
                            //this cell is a room cell. 
                            //cant place a room here
                            interupt = true;
                            break;
                        }
                    }
                }
                if(!interupt)
                {
                    Room newRoom = new Room(x, y, roomSizeX, roomSizeY);
                    //set all the cells roomCell bool that correspond with the room
                    //to true
                    for (int i = x; i < x + roomSizeX; i++)
                    {
                        for (int j = y; j < y + roomSizeY; j++)
                        {
                            cells[i, j].RoomCell = true;
                        }
                    }
                    rooms.Add(newRoom);
                    roomCount++;
                }
            }
        }

        private void genMaze()
        {
            Random rand = new Random();
            int x = 0;
            int y = 0;
            do
            {
                x = rand.Next(SizeX);
                y = rand.Next(SizeY);
            }
            while (cells[x, y].RoomCell);


            //stack for cells
            Stack<Cell> cStack = new Stack<Cell>();

            int totalCells = SizeX * SizeY;
            int visitedCells = 1;
            Cell currCell = cells[x, y];

            List<Vert> neighbors = new List<Vert>();
            Vert tempVert = new Vert();

            while (visitedCells < totalCells)
            {
                //clear the list because we are at a different point
                neighbors.Clear();

                //look south of current for a neighbor
                tempVert = new Vert();
                if (y - 1 >= 0 && cells[x, y - 1].checkWalls() == true && !cells[x, y - 1].RoomCell)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x;
                    tempVert.Y2 = y - 1;
                    tempVert.Wall1 = 0;
                    tempVert.Wall2 = 2;
                    neighbors.Add(tempVert);
                }
                //look north of current for a neighbor
                tempVert = new Vert();
                if (y+1 < SizeY && cells[x, y+1].checkWalls() == true && !cells[x, y + 1].RoomCell)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x;
                    tempVert.Y2 = y + 1;
                    tempVert.Wall1 = 2;
                    tempVert.Wall2 = 0;
                    neighbors.Add(tempVert);
                }
                //look west of current for a neighbor
                tempVert = new Vert();
                if (x - 1 >= 0 && cells[x - 1, y].checkWalls() == true && !cells[x - 1, y].RoomCell)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x - 1;
                    tempVert.Y2 = y;
                    tempVert.Wall1 = 3;
                    tempVert.Wall2 = 1;
                    neighbors.Add(tempVert);
                }
                //look east of current for a neighbor
                tempVert = new Vert();
                if (x + 1 < SizeX && cells[x + 1, y].checkWalls() == true && !cells[x + 1, y].RoomCell)
                {
                    tempVert.X1 = x;
                    tempVert.Y1 = y;
                    tempVert.X2 = x + 1;
                    tempVert.Y2 = y;
                    tempVert.Wall1 = 1;
                    tempVert.Wall2 = 3;
                    neighbors.Add(tempVert);
                }

                //if we found an unvisited neighbor cell
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
                    try
                    {
                        currCell = cStack.Pop();
                        x = currCell.X;
                        y = currCell.Y;
                    }
                    catch(InvalidOperationException e)
                    {
                        //do nothing?
                        visitedCells = totalCells;
                    }

                }
            }
        }
    }
}
