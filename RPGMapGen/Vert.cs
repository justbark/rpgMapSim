using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGMapGen
{
    class Vert
    {
        private int x1;
        private int y1;

        private int x2;
        private int y2;

        private int wall1;
        private int wall2;

        public int X1 { get => x1; set => x1 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        public int Wall1 { get => wall1; set => wall1 = value; }
        public int Wall2 { get => wall2; set => wall2 = value; }
    }
}
