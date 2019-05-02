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
            Stage stage = new Stage(50,50,5,"Medium");
            MapForm mForm = new MapForm(stage);
            mForm.Show();
        }
    }
}
