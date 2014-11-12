using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractalsCS
{
    public partial class Form1 : Form
    {
        private int sleepTime=10;
        SolidBrush br = new SolidBrush(Color.White);
        Pen pen1 = new Pen(Color.Black);
        Pen penWhite = new Pen(Color.White);

        double frac3RatioMultiplier = 1.2;

        public Form1()
        {
            InitializeComponent();
        }

        private void star(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                star(g,  x - newRatio, y + newRatio, newRatio);                
                
                star(g, x - newRatio, y - newRatio, newRatio);

                star(g,  x + newRatio, y - newRatio, newRatio);                
                                                
                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }

        private void starFigure2(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                double ratioMultiplier = 1.4;

                // figure top left
                int newX1 = (int)(x - newRatio * ratioMultiplier);
                int newY1 = (int)(y - newRatio * ratioMultiplier);
                starFigure2(g, newX1, newY1, newRatio);

                // figure top right
                int newX2 = (int)(newRatio + x + newRatio * ratioMultiplier);
                int newY2 = (int)(y - newRatio * ratioMultiplier);
                starFigure2(g, newX2, newY2, newRatio);

                // figure bottom left
                int newX3 = (int)(x - newRatio * ratioMultiplier);
                int newY3 = (int)(newRatio + y + newRatio * ratioMultiplier);
                starFigure2(g, newX3, newY3, newRatio);

                // figure bottom right
                int newX4 = (int)(newRatio + x + newRatio * ratioMultiplier);
                int newY4 = (int)(newRatio + y + newRatio * ratioMultiplier);
                starFigure2(g, newX4, newY4, newRatio);

                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                //System.Threading.Thread.Sleep(sleepTime);
            }
        }

        private void starFigure3(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = (int) (ratioRects / 2);
                int ratioScaled = (int) (ratioRects * frac3RatioMultiplier);
                int xScaled = (int) (x - x * frac3RatioMultiplier);
                int yScaled = (int) (y  - y * frac3RatioMultiplier);

                double ratioMultiplier = 0.8;            

                // figure top left
                int newX1 = (int)(x - newRatio * ratioMultiplier);
                int newY1 = (int)(y - newRatio * ratioMultiplier);
                starFigure3(g, newX1, newY1, newRatio);

                // figure top right
                int newX2 = (int)(ratioRects + x - ((0.95 - ratioMultiplier) * newRatio));
                int newY2 = (int)(y - newRatio * ratioMultiplier);
                starFigure3(g, newX2, newY2, newRatio);

                // figure bottom left
                int newX3 = (int)(x - newRatio * ratioMultiplier);
                int newY3 = (int)(ratioRects + y - ((0.95 - ratioMultiplier) * newRatio));
                starFigure3(g, newX3, newY3, newRatio);

                // figure bottom right
                int newX4 = (int)(ratioRects + x - ((0.95 - ratioMultiplier) * newRatio));
                int newY4 = (int)(ratioRects + y - ((0.95 - ratioMultiplier) * newRatio));
                starFigure3(g, newX4, newY4, newRatio);

                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(penWhite, x, y, ratioRects, ratioRects);
                //System.Threading.Thread.Sleep(sleepTime);
            }
        }

        /**
         * Draw Sierpinsky Triangle 
         */
        private void starFigure4(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = (int)(ratioRects / 2);

                // left
                int newX1 = (int)(x - newRatio / 2);
                int newY1 = (int)(y + newRatio);
                starFigure4(g, newX1, newY1, newRatio);

                // right
                int newX2 = (int)(x + ratioRects - newRatio / 2);
                int newY2 = (int)(y + newRatio);
                starFigure4(g, newX2, newY2, newRatio);

                // top
                int newX3 = (int)(x + newRatio / 2);
                int newY3 = (int)(y - newRatio);
                starFigure4(g, newX3, newY3, newRatio);

                Point[] points = new Point[3];
                points[0] = new Point(x, y);
                points[1] = new Point(x + ratioRects / 2, y + ratioRects);
                points[2] = new Point(x + ratioRects, y);

                g.FillPolygon(br, points);
                g.DrawPolygon(pen1, points);
                //System.Threading.Thread.Sleep(sleepTime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();


            g.Clear(Color.White);
            
            int ratioRects = int.Parse(textBox2.Text);

            star(g,100, 100, ratioRects);


            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            int startX = pictureBox1.Size.Width / 2 - ratioRects / 2;
            int startY = pictureBox1.Size.Height / 2 - ratioRects / 2;

            starFigure2(g, startX, startY, ratioRects);

            pictureBox1.Update();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnFrac3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.Black);

            int ratioRects = (int) (int.Parse(textBox2.Text) * frac3RatioMultiplier);

            int startX = pictureBox1.Size.Width / 2 - ratioRects / 2;
            int startY = pictureBox1.Size.Height / 2 - ratioRects / 2;

            starFigure3(g, startX, startY, ratioRects);

            pictureBox1.Update();
        }

        private void btnFrac4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            int startX = pictureBox1.Size.Width / 2 - ratioRects / 2;
            int startY = pictureBox1.Size.Height / 2 - ratioRects / 2;

            starFigure4(g, startX, startY, ratioRects);

            pictureBox1.Update();
        }
    }
}