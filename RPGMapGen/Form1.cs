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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void mapGenBtn_Click(object sender, EventArgs e)
        {
            int numRooms = (int)numRoomsDropDown.Value;
            Stage stage = new Stage(50,50, numRooms,"Medium");
            MapForm mForm = new MapForm(stage);
            //foreach(Room rm in stage.Rooms)
            //{
            //    listView1.Items.Add(rm.StartX.ToString());
            //    listView1.Items.Add(rm.StartY.ToString());
            //    listView1.Items.Add(rm.SizeX.ToString());
            //    listView1.Items.Add(rm.SizeY.ToString());
            //}
            mForm.Show();
        }
    }
}
