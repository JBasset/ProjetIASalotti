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

        static int[,] cart = { { 0, 3 }, { 7, 9 }, { 19, 7 }, { 24, 7 }, { 13, 10 }, { 12, 14 }, { 11, 18 }, { 9, 19 }, { 19, 19 }, { 1, 21 }, { 9, 23 }, { 19, 23 }, { 18, 24 } };


        public WarehouseForm()
        {
            InitializeComponent();
        }

        private void WarehouseForm_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            pen = new Pen(Color.Chartreuse,15);
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
                        g.DrawRectangle(pen, i * 15, j * 15, 15, 15);
                    }
                    else if (warehouse[j, i] == 1)
                    {
                        pen.Color = Color.White;
                        g.DrawRectangle(pen, i * 15, j * 15, 15, 15);
                    }
                    else if (warehouse[j, i] == -1)
                    {
                        pen.Color = Color.Blue;
                        g.DrawRectangle(pen, i * 15, j * 15, 15, 15);
                    }

                    if (cartInLocation(j,i))
                    {
                        pen.Width = 5;
                        pen.Color = Color.Black;
                        g.DrawRectangle(pen, i * 15, j * 15, 10, 10);
                        pen.Width = 15;
                    }
                }
            }
        }

        private bool cartInLocation(int x, int y)
        {
            for (int i = 0; i < cart.Length/2; i++)
            {
                if (y == cart[i, 0] && x == cart[i, 1])
                    return true;
            }
            return false;
        }

        public void InsertCart()
        {
            int xLength = cart.GetLength(0);

            for (int i = 0; i < xLength; i++)
            {
                warehouse[cart[i, 0], cart[i, 1]] = 0;
            }
        }
    }
}
