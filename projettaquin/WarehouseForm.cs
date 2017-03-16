using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projettaquin
{
    public partial class WarehouseForm : Form
    {
        static Graphics g;
        static Pen pen;

        /* Creating warehouse */

        #region warehouse and carts
        static int[,] warehouse =
        {
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //0
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //1
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //2
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //3
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //4
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //5
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //6
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //7
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //8
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //9
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //10
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //11
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //12
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //13
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //14
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //15
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //16
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //17
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //18
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //19
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //20
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //21
            {2,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1,1,-1,-1,-1,-1,-1,-1,-1,-1,-1,1,1},  //22
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //23
            {2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},                    //24
        };

        static List<int[]> cart = new List<int[]> { };
        #endregion

        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            pen = new Pen(Color.Chartreuse, (float)7.5);
        }

        private void WarehouseForm_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 24; j++)
                {
                    if (warehouse[j, i] == 2)
                    {
                        pen.Color = Color.Chartreuse;
                        g.DrawRectangle(pen, (i + 1) * 15, (j + 1) * 15, (float)7.5, (float)7.5);
                    }
                    else if (warehouse[j, i] == 1)
                    {
                        pen.Color = Color.White;
                        g.DrawRectangle(pen, (i + 1) * 15, (j + 1) * 15, (float)7.5, (float)7.5);
                    }
                    else if (warehouse[j, i] == -1)
                    {
                        pen.Color = Color.Blue;
                        g.DrawRectangle(pen, (i + 1) * 15, (j + 1) * 15, (float)7.5, (float)7.5);
                    }

                    if (cartInLocation(j, i))
                    {
                        pen.Color = Color.Black;
                        g.DrawRectangle(pen, (i + 1) * 15, (j + 1) * 15, (float)7.5, (float)7.5);
                    }
                }
            }
        }

        private bool cartInLocation(int x, int y)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (y == cart[i][0] && x == cart[i][1])
                    return true;
            }
            return false;
        }

        public void InsertCart()
        {
            
        }
    }
}
