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
                    g.DrawRectangle(pen, i * 15, j * 15, 15, 15);
                }
            }
        }
    }
}
