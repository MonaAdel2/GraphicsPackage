using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewGraphicsPackage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //**** print the results of the points in table

        public Point center = new Point(370, 255);

        // Draw the x axis and y axis
        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            var g = DrawingPanel.CreateGraphics();
            Pen pen = new Pen(Color.Black);


            Point p1 = new Point(center.X + 400, center.Y);
            Point p2 = new Point(center.X - 400, center.Y);
            Point p3 = new Point(center.X, center.Y + 400);
            Point p4 = new Point(center.X, center.Y - 400);

            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
        }

        private void AddPoint(int x, int y)
        {
            var brush = Brushes.Black;
            var P = DrawingPanel.CreateGraphics();

            P.FillRectangle(brush, center.X + x, center.Y - y, 2, 2);

        }
        private int round(float a)
        {
            return Convert.ToInt32(a + 0.5);
        }

        private void ClearDrawingPanel_Click(object sender, EventArgs e)
        {
            DrawingPanel.Controls.Clear();
            this.Refresh();
        }

        // ************** Draw line by DDA *****************************
        private void DrawLineDDA_Click(object sender, EventArgs e)
        {
            List<List<float>> points = new List<List<float>>();

            int x1 = Convert.ToInt32(txtBox_line_x1.Text);
            int y1 = Convert.ToInt32(txtBox_line_y1.Text);

            int x2 = Convert.ToInt32(txtBox_line_x2.Text);
            int y2 = Convert.ToInt32(txtBox_line_y2.Text);

            DrawingPanel.Controls.Clear();
            this.Refresh();

            points = DrawLineWithDDA(x1, y1, x2, y2);
            Points_Results results = new Points_Results(points, 'D');
            results.Show();

        }

        private List<List<float>> DrawLineWithDDA(int x0, int y0, int xEnd, int yEnd)
        {
            int dx = xEnd - x0, dy = yEnd - y0, steps, k;
            float xIncrement, yIncrement, x = x0, y = y0;
            
            List<List<float>> AllPoints = new List<List<float>>();

            if (Math.Abs(dx) > Math.Abs(dy))
                steps = Math.Abs(dx);
            else
                steps = Math.Abs(dy);
            xIncrement = (float)dx / (float)steps;
            yIncrement = (float)dy / (float)steps;

            AddPoint(round(x), round(y));
            for (k = 0; k < steps; k++)
            {
                x += xIncrement;
                y += yIncrement;
                try
                {
                    AddPoint(round(x), round(y));
                    AllPoints.Add(new List<float> { x, y, round(x), round(y) });
                    //Debug.Write(AllPoints.ElementAt(k).ElementAt(2)+"   ");
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            }
            return AllPoints;
        }



        // ************** Draw line by Breshmen *****************************

        private void DrawLineBresenham_Click(object sender, EventArgs e)
        {
            List<List<float>> points = new List<List<float>>();

            int x1 = Convert.ToInt32(txtBox_line_x1.Text);
            int y1 = Convert.ToInt32(txtBox_line_y1.Text);

            int x2 = Convert.ToInt32(txtBox_line_x2.Text);
            int y2 = Convert.ToInt32(txtBox_line_y2.Text);

            DrawingPanel.Controls.Clear();
            this.Refresh();

            points = DrawLineWithBresenham22(x1, y1, x2, y2);
            Points_Results results = new Points_Results(points, 'B');
            results.Show();
        }

        private void swap(ref int x0, ref int y0, ref int xEnd, ref int yEnd)
        {
            int temp1, temp2;
            temp1 = x0;
            x0 = y0;
            y0 = temp1;

            temp2 = xEnd;
            xEnd = yEnd;
            yEnd = temp2;
        }
        private List<List<float>> DrawLineWithBresenham(int x0, int y0, int xEnd, int yEnd)
        {

            float deltaX, deltaY, p;
            deltaX = (xEnd - x0);
            deltaY = (yEnd - y0);
            var brush = Brushes.Black;
            List<List<float>> AllPoints = new List<List<float>>();

            var g = DrawingPanel.CreateGraphics();

            float slope = deltaY / deltaX;
            if (deltaX == 0) { slope = 99999; }
            
            // First Ocstant
            if (x0 < xEnd && slope >= 0 && slope <= 1)
            {
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        AllPoints.Add(new List<float> { p, ++X ,  Y });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (++Y), 2, 2);
                        AllPoints.Add(new List<float> { p, ++X, ++Y });
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }
            
            // Second Ocstant
            else if (y0 < yEnd && slope > 1 && slope < 999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                deltaX = xEnd - x0;

                deltaY = yEnd - y0;

                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
                        AllPoints.Add(new List<float> { p, Y, ++X });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Third Ocstant
            else if (y0 < yEnd && slope < -1 && slope > -999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
                        AllPoints.Add(new List<float> { p, Y, ++X });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--Y), center.Y - (++X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Fourth Ocstant
            else if (x0 > xEnd && slope <= 0 && slope >= -1)
            {
                deltaX = -deltaX;
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        AllPoints.Add(new List<float> { p, --X, Y });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (++Y), 2, 2);
                        AllPoints.Add(new List<float> { p, --X, ++Y });
                        p += (2 * deltaY) - (2 * deltaX);
                    }

                }
            }

            // Fifth Ocstant
            else if (x0 > xEnd && slope > 0 && slope <= 1)
            {
                deltaX = -deltaX; deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        AllPoints.Add(new List<float> { p, --X, Y });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (--Y), 2, 2);
                        AllPoints.Add(new List<float> { p, --X, --Y });
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Sixth Ocstant
            else if (y0 > yEnd && slope > 1 && slope < 999999)
            {
                // Swap x1 and y1 ,,, Swap x2 and y2
                swap(ref x0, ref y0, ref xEnd, ref yEnd);

                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaX = -deltaX; deltaY = -deltaY;

                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
                        AllPoints.Add(new List<float> { p, Y, --X });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Seventh Ocstant
            else if (y0 > yEnd && slope < -1 && slope < 999999)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);

                deltaX = xEnd - x0;
                deltaY = yEnd - y0;
                deltaX = -deltaX;
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
                        AllPoints.Add(new List<float> { p, Y, --X });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++Y), center.Y - (--X), 2, 2);
                        AllPoints.Add(new List<float> { p, ++Y, --X });
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Eighth Ocstant
            else if (x0 < xEnd && slope <= 0 && slope >= -1)
            {
                deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                int X = x0, Y = y0;

                for (int i = x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        AllPoints.Add(new List<float> { p, ++X, Y });
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (--Y), 2, 2);
                        AllPoints.Add(new List<float> { p, ++X, --Y });
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            
            return AllPoints;

        }


        private List<List<float>> DrawLineWithBresenham22(int x0, int y0, int xEnd, int yEnd)
        {
            List<List<float>> AllPoints = new List<List<float>>();

            var brush = Brushes.Black;
            var g = DrawingPanel.CreateGraphics();

            int dx = xEnd - x0;
            int dy = yEnd - y0;
            int stepsX;
            int stepsY;
            int p;
            bool isSwapped = false;

            float m = dy / dx;

            if (Math.Abs(m) > 1)
            {
                swap(ref x0, ref y0, ref xEnd, ref yEnd);
                isSwapped = true;
            }
            dx = xEnd - x0;
            dy = yEnd - y0;

            stepsX = dx > 0 ? 1 : -1;
            stepsY = dy > 0 ? 1 : -1;

            dy = Math.Abs(dy);
            dx = Math.Abs(dx);

            p = 2 * dy - dx;

            int i = 0;
            while (i <= (dx - 1))
            {
                if (p < 0)
                {
                    x0 = x0 + stepsX;
                    if (isSwapped)
                    {
                        g.FillRectangle(brush, center.X + y0, center.Y - x0, 2, 2);
                        AllPoints.Add(new List<float> { p, y0, x0 });
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + x0, center.Y - y0, 2, 2);
                        AllPoints.Add(new List<float> { p, x0, y0 });
                    }
                    
                    p = p + (2 * dy);
                }
                else
                {
                    x0 = x0 + stepsX;
                    y0 = y0 + stepsY;
                    if (isSwapped)
                    {
                        g.FillRectangle(brush, center.X + y0, center.Y - x0, 2, 2);
                        AllPoints.Add(new List<float> { p, y0, x0 });
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + x0, center.Y - y0, 2, 2);
                        AllPoints.Add(new List<float> { p, x0, y0 });
                    }
                    p = p + (2 * dy)-(2 * dx);
                 
                }
                i++;
            }

            return AllPoints;
        }


        // ************** Draw Circle  **************************************
        private void DrawCircle_Click(object sender, EventArgs e)
        {
            List<List<float>> points = new List<List<float>>();

            int xc = Convert.ToInt32(txtBox_circle_xc.Text);
            int yc = Convert.ToInt32(txtBox_circle_yc.Text);
            int radius = Convert.ToInt32(txtBox_circle_r.Text);

            DrawingPanel.Controls.Clear();
            this.Refresh();

            points = DrawCircleByMidPoint(xc, yc, radius);
            Points_Results results = new Points_Results(points, 'C');
            results.Show();

        }

        private List<List<float>> DrawCircleByMidPoint(int XCenter, int YCenter, int radius)
        {
            var drawingBrush = Brushes.Black;
            var g = DrawingPanel.CreateGraphics();

            List<List<float>> AllPoints = new List<List<float>>();

            int x = 0;
            int y = radius;
            int p = 1 - radius;

            while (x < y)
            {
                x++;

                if (p < 0)
                {
                    AllPoints.Add(new List<float> { p, XCenter + x, YCenter + y });
                    p += 2 * x + 1;
                }

                else
                {
                    y--;
                    AllPoints.Add(new List<float> { p, XCenter + x, YCenter + y });
                    p += 2 * (x - y) + 1;
                }
                CirclePlotPoints(XCenter, YCenter, x, y);
                

            }
            return AllPoints;
        }

        private void CirclePlotPoints(int XCenter, int YCenter, int x, int y)
        {
            AddPoint(XCenter + x, YCenter + y);
            AddPoint(XCenter - x, YCenter + y);
            AddPoint(XCenter + x, YCenter - y);
            AddPoint(XCenter - x, YCenter - y);
            AddPoint(XCenter + y, YCenter + x);
            AddPoint(XCenter - y, YCenter + x);
            AddPoint(XCenter + y, YCenter - x);
            AddPoint(XCenter - y, YCenter - x);

        }




        // ************** Draw Ellips  *****************************************
        private void DrawEllipse_Click(object sender, EventArgs e)
        {
            List<List<float>> points = new List<List<float>>();

            int xc = Convert.ToInt32(txtBox_ellipse_xc.Text);
            int yc = Convert.ToInt32(txtBox_ellipse_yc.Text);
            int radiusX = Convert.ToInt32(txtBox_ellipse_rx.Text);
            int radiusY = Convert.ToInt32(txtBox_ellipse_ry.Text);

            DrawingPanel.Controls.Clear();
            this.Refresh();

            points = DrawEllipseWithMidpoint(xc, yc, radiusX, radiusY);
            Points_Results results = new Points_Results(points, 'E');
            results.Show();
        }

        private List<List<float>> DrawEllipseWithMidpoint(int xCenter, int yCenter, int Rx, int Ry)
        {
            List<List<float>> AllPoints = new List<List<float>>();

            int Rx2 = Rx * Rx;
            int Ry2 = Ry * Ry;
            int twoRx2 = 2 * Rx2;
            int twoRy2 = 2 * Ry2;
            int p;
            int x = 0;
            int y = Ry;
            int px = 0;
            int py = twoRx2 * y;


            /* Plot the initial point in each quadrant. */
            EllipsePlotPoints(xCenter, yCenter, x, y);
            

            /* Region 1 */
            p = (int)Math.Round(Ry2 - (Rx2 * Ry) + (0.25 * Rx2));
            while (px < py)
            {
                x++;
                px += twoRy2;
                if (p < 0) 
                {
                    AllPoints.Add(new List<float> { p, xCenter + x, yCenter + y });
                    p += Ry2 + px;
                }
                    
                else
                {
                    y--;
                    py -= twoRx2;
                    AllPoints.Add(new List<float> { p, xCenter + x, yCenter + y });
                    p += Ry2 + px - py;
                }
                EllipsePlotPoints(xCenter, yCenter, x, y);
                
            }
            /* Region 2 */
            p = (int)Math.Round(Ry2 * (x + 0.5) * (x + 0.5) + Rx2 * (y - 1) * (y - 1) - Rx2 * Ry2);
            while (y > 0)
            {
                y--;
                py -= twoRx2;
                if (p > 0) 
                {
                    AllPoints.Add(new List<float> { p, xCenter + x, yCenter + y });
                    p += Rx2 - py;
                }
                    
                else
                {
                    x++;
                    px += twoRy2;
                    AllPoints.Add(new List<float> { p, xCenter + x, yCenter + y });
                    p += Rx2 - py + px;
                }
                EllipsePlotPoints(xCenter, yCenter, x, y);
                
            }
            return AllPoints;
        }
        void EllipsePlotPoints(int XCenter, int YCenter, int x, int y)
        {
            AddPoint(XCenter + x, YCenter + y);
            AddPoint(XCenter - x, YCenter + y);
            AddPoint(XCenter + x, YCenter - y);
            AddPoint(XCenter - x, YCenter - y); 
        }

      
        // Move to another form
        private void MoveToTransformation_Click(object sender, EventArgs e)
        {
            Transformation transformation = new Transformation();
            transformation.ShowDialog();
        }
    }
}
