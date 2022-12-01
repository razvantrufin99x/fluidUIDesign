using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace fluidUIDesign
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Graphics g;
        public Pen pen0 = new Pen(Color.Black, 1);
        public Pen pen2 = new Pen(Color.Red, 1);
        public Brush brush0 = new SolidBrush(Color.Red);
        public int cx = 400;
        public int cy = 10;
        public int ismd = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
            drawall();
        }

        public void drawall()
        {
            g.Clear(BackColor);
            try
            {

                g.DrawArc(pen0, 5 + cx, 0, cx, cy, 135, 120);
                g.DrawArc(pen2, cx - cx - 5, 0, cx, cy, 285, 120);
                //g.DrawRectangle(pen0, 5 + cx, 0, cx, cy);
                //g.DrawRectangle(pen2, cx - cx - 5, 0, cx, cy);
                g.DrawEllipse(pen0, 0 + cx - (cx / 5) - 12, cy - (cy / 5), cx / 2, cy / 2);
                g.FillEllipse(brush0, 0 + cx - (cx / 5) - 12, cy - (cy / 5), cx / 2, cy / 2);
                //g.DrawRectangle(pen0, cx - (cx / 5) - 10, cy - (cy / 5),cx / 2, cy / 2);
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cx = e.X;
            cy = e.Y;
            if (ismd == 1)
            {
                drawall();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = 0;
            if (ismd == 0)
            {
                while (cy > 30)
                {
                    cy -= 20;
                    drawall();
                    Thread.Sleep(20);
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = 1;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawall();
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            ismd = 1;
            drawall();
        }
    }
}
