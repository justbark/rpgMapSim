using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGMapGen
{
    public partial class MapForm : Form
    {
        private int offsetX = 10;
        private int offsetY = 10;
        int cellSize = 10;

        private Stage lvl;

        public MapForm(Stage stage)
        {
            lvl = stage;
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);             //paint exterior of object
            SolidBrush brush = new SolidBrush(Color.Red);    //paint interior of object

            
            int x;
            int y;
            for(int i = 0; i< lvl.SizeX; i++)
            {
                x = i * cellSize + offsetX;
                for(int j = 0; j < lvl.SizeY; j++)
                {
                    y = j * cellSize + offsetY;

                    //if(lvl.Cells[i,j].RoomCell == true)
                    //{
                    //    g.FillRectangle(brush, x, y, x + cellSize, y + cellSize);
                    //}
                    if (lvl.Cells[i, j].Walls[0] == 1)
                    {
                        g.DrawLine(pen, x, y, x + cellSize, y);
                    }
                    if(lvl.Cells[i, j].Walls[1] == 1)
                    {
                        g.DrawLine(pen, x + cellSize, y, x + cellSize, y + cellSize);
                    }
                    if(lvl.Cells[i, j].Walls[2] == 1)
                    {
                        g.DrawLine(pen, x, y + cellSize, x + cellSize, y + cellSize);
                    }
                    if(lvl.Cells[i, j].Walls[3] == 1)
                    {
                        g.DrawLine(pen, x, y, x, y + cellSize);
                    }
                }
            }
            //draw rooms
            foreach (Room rm in lvl.Rooms)
            {
                Rectangle rect = new Rectangle((rm.StartX * cellSize) + offsetX, (rm.StartY * cellSize) + offsetY, rm.SizeX * cellSize, rm.SizeY * cellSize);
                g.FillRectangle(brush, rect);
            }
        }
    }
}
