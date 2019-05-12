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
            genDoors();
            removeDeadEnds();
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

            int roomCount = 0;
            while(roomCount < totalRooms)
            {
                //try to make a room 
                int maxRoomSize = 10;
                int x = rand.Next(sizeX);
                int y = rand.Next(sizeY);

                // we want rooms placed in odd numbered locations to ensure that
                // rooms arent placed next to one another
                //if x is even
                if (x % 2 == 0)
                    x++;
                //if y is even
                if (y % 2 == 0)
                    y++;

                if (roomSize == "Large")
                {
                    maxRoomSize = 11;
                }
                else if (roomSize == "Medium")
                {
                    maxRoomSize = 9;
                }
                else if (roomSize == "Small")
                {
                    maxRoomSize = 7;
                }

                int roomSizeX = rand.Next(3, maxRoomSize);
                int roomSizeY = rand.Next(3, maxRoomSize);

                //make sure the rooms are an odd size.
                if (roomSizeX % 2 == 0)
                    roomSizeX++;
                if (roomSizeY % 2 == 0)
                    roomSizeY++;

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
                            for( int k = 0; k < 4; k++)
                            {
                                cells[i, j].Walls[k] = 0;
                            }
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

            //start somewhere outside of a room to generate the corridor
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

                //look north of current for a neighbor
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

        private void genDoors()
        {
            Random rand = new Random();
            List<Tuple<int, int>> potentialDoorCell = new List<Tuple<int,int>>();
            foreach (Room rm in rooms)
            {
                potentialDoorCell.Clear();
                //pick a cell along the wall of the room and set make it a door
                for(int i = rm.StartX; i < rm.StartX + rm.SizeX; i++)
                {
                    for(int j = rm.StartY; j < rm.StartY + rm.SizeY; j++)
                    {
                        //if the current cell we are looking at is a corner cell, move on
                        if (i == rm.StartX && j == rm.StartY || i == rm.StartX + rm.SizeX && j == rm.StartY + rm.SizeY || i == rm.StartX && j == rm.StartY + rm.SizeY || i == rm.StartX + rm.SizeX && j == rm.StartY)
                            continue;
                        //The below if statement is only looking for cells in the room that are touching a wall (excluding the corner cells)
                        //I'm SURE there is a better way to do this...
                        if(((i > rm.StartX && i < rm.StartX + rm.SizeX) && (j == rm.StartY || j == rm.StartY + rm.SizeY)) || ((j > rm.StartY && j < rm.StartY + rm.SizeY) && (i == rm.StartX || i == rm.StartX + sizeX)))
                        {
                            Tuple<int, int> tuple = new Tuple<int, int>(i, j);
                            potentialDoorCell.Add(tuple);
                        }
                    }
                }

                //now randomly choose a tuple from the potentialDoorCell list
                int randomListIndex = rand.Next(potentialDoorCell.Count());
                cells[potentialDoorCell[randomListIndex].Item1, potentialDoorCell[randomListIndex].Item2].IsDoorCell = true;

                //determine what wall the DoorCell is located, and open that wall in the coridor
                if(potentialDoorCell[randomListIndex].Item2 == rm.StartY)
                {
                    //north wall
                    cells[potentialDoorCell[randomListIndex].Item1, (potentialDoorCell[randomListIndex].Item2) - 1].Walls[2] = 0;
                }
                else if(potentialDoorCell[randomListIndex].Item2 == rm.StartY + rm.SizeY)
                {
                    //south wall
                    cells[potentialDoorCell[randomListIndex].Item1, (potentialDoorCell[randomListIndex].Item2) + 1].Walls[0] = 0;
                }
                else if(potentialDoorCell[randomListIndex].Item1 == rm.StartX)
                {
                    //west wall
                    cells[(potentialDoorCell[randomListIndex].Item1) - 1, potentialDoorCell[randomListIndex].Item2].Walls[1] = 0;
                }
                else
                {
                    //east wall
                    cells[(potentialDoorCell[randomListIndex].Item1) + 1, potentialDoorCell[randomListIndex].Item2].Walls[3] = 0;
                }
            }
        }

        private void removeDeadEnds()
        {
            bool done = false;
            int deadCount;
            while (!done)
            {
                deadCount = 0;
                for(int i = 0; i < sizeX; i++)
                {
                    for(int j = 0; j < sizeY; j++)
                    {
                        int sum = 0;
                        for(int k = 0; k < 4; k++)
                        {
                            sum += cells[i, j].Walls[k];
                        }
                        if(sum == 3)
                        {
                            //close walls, so there are more dead ends to look for
                            deadCount++;
                            if(cells[i,j].Walls[0] == 1 && cells[i,j].Walls[1] == 1 && cells[i,j].Walls[3] == 1 && cells[i,j].Walls[2] == 0)
                            {
                                //north wall
                                cells[i, j + 1].Walls[0] = 1;
                            }
                            else if(cells[i,j].Walls[0] == 1 && cells[i,j].Walls[1] == 1 && cells[i,j].Walls[2] == 1 && cells[i,j].Walls[3] == 0)
                            {
                                //east wall
                                cells[i - 1, j].Walls[1] = 1;
                            }
                            else if(cells[i,j].Walls[1] == 1 && cells[i,j].Walls[2] == 1 && cells[i,j].Walls[3] == 1 && cells[i,j].Walls[0] == 0)
                            {
                                //south wall
                                cells[i, j - 1].Walls[2] = 1;
                            }
                            else if(cells[i,j].Walls[0] == 1 && cells[i,j].Walls[2] == 1 && cells[i,j].Walls[3] == 1 && cells[i,j].Walls[1] == 0)
                            {
                                //west wall
                                cells[i + 1, j].Walls[3] = 1;
                            }

                            cells[i, j].IsNonCell = true;
                            for(int q = 0; q < 4; q++)
                            {
                                cells[i, j].Walls[q] = 1;
                            }
                        }
                    }
                }
                if (deadCount == 0)
                    done = true;
            }
        }
    }
}
