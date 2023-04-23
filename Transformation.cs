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
    public partial class Transformation : Form
    {
        public Transformation()
        {
            InitializeComponent();
        }

        public Point center = new Point(370, 255);

        // Draw the x axis and y axis

        private void DrawingPanel2_Paint(object sender, PaintEventArgs e)
        {
            var g = DrawingPanel2.CreateGraphics();
            Pen pen = new Pen(Color.Black);


            Point p1 = new Point(center.X + 400, center.Y);
            Point p2 = new Point(center.X - 400, center.Y);
            Point p3 = new Point(center.X, center.Y + 400);
            Point p4 = new Point(center.X, center.Y - 400);

            g.DrawLine(pen, p1, p2);
            g.DrawLine(pen, p3, p4);
        }

        private void ClearDrawingPanel2_Click(object sender, EventArgs e)
        {
            DrawingPanel2.Controls.Clear();
            this.Refresh();
        }

        private float[] MultiplyMatrixVector(float[,] matrix, float[] vector)
        {
            float[] result = new float[3];
            for (int i = 0; i < 3; i++)
            {
                result[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }
            return result;
        }
        private float[] MultiplyMatrixVector2(float[,] matrix, float[] vector)
        {
            float[] result = new float[3];
            for (int i = 0; i < 2; i++)
            {
                result[i] = 0;
                for (int j = 0; j < 2; j++)
                {
                    result[i] += matrix[i, j] * vector[j];
                }
            }
            return result;
        }

        // *************** Draw a Triangle ****************************
        private void DrawTriangle_Click(object sender, EventArgs e)
        {
            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);

            DrawLineWithBresenham(x1, y1, x2, y2, "Black");
            DrawLineWithBresenham(x2, y2, x3, y3, "Black");
            DrawLineWithBresenham(x3, y3, x1, y1, "Black");


        }

        // ************ Draw Line *******************************************
        private void swap(ref float x0, ref float y0, ref float xEnd, ref float yEnd)
        {
            float temp1, temp2;
            temp1 = x0;
            x0 = y0;
            y0 = temp1;

            temp2 = xEnd;
            xEnd = yEnd;
            yEnd = temp2;
        }
        private void DrawLineWithBresenham(float x0, float y0, float xEnd, float yEnd, String color)
        {

            float deltaX, deltaY, p;
            deltaX = (xEnd - x0);
            deltaY = (yEnd - y0);
            var brush = Brushes.Black;

            if (color == "DarkRed") { brush = Brushes.DarkRed; }

            var g = DrawingPanel2.CreateGraphics();

            float slope = deltaY / deltaX;
            if (deltaX == 0) { slope = 99999; }
            // First Ocstant
            if (x0 < xEnd && slope >= 0 && slope <= 1)
            {
                p = (2 * deltaY) - deltaX;
                float X = x0, Y = y0;

                for (int i = (int)x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (++Y), 2, 2);
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
                float X = x0, Y = y0;

                for (int i = (int)x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
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
                float X = x0, Y = y0;

                for (int i = (int)x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (++X), 2, 2);
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
                float X = x0, Y = y0;

                for (int i = (int)xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (++Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }

                }
            }

            // Fifth Ocstant
            else if (x0 > xEnd && slope > 0 && slope <= 1)
            {
                deltaX = -deltaX; deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                float X = x0, Y = y0;

                for (int i = (int)xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (--X), center.Y - (--Y), 2, 2);
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
                float X = x0, Y = y0;

                for (int i = (int)xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
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
                float X = x0, Y = y0;

                for (int i = (int)xEnd; i < x0; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++Y), center.Y - (--X), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

            // Eighth Ocstant
            else if (x0 < xEnd && slope <= 0 && slope >= -1)
            {
                deltaY = -deltaY;
                p = (2 * deltaY) - deltaX;
                float X = x0, Y = y0;

                for (int i = (int)x0; i < xEnd; i++)
                {

                    if (p < 0)
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (Y), 2, 2);
                        p += (2 * deltaY);
                    }
                    else
                    {
                        g.FillRectangle(brush, center.X + (++X), center.Y - (--Y), 2, 2);
                        p += (2 * deltaY) - (2 * deltaX);
                    }
                }
            }

        }



        // ************ Translation Function ***************************
        private void Translation_Click(object sender, EventArgs e)
        {
            float tx = (float)Convert.ToDouble(txtBox_translation_x.Text);
            float ty = (float)Convert.ToDouble(txtBox_translation_y.Text);

            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);

            float[] point1 = Translate(x1, y1, tx, ty);
            float[] point2 = Translate(x2, y2, tx, ty);
            float[] point3 = Translate(x3, y3, tx, ty);

            DrawLineWithBresenham(point1[0], point1[1], point2[0], point2[1], "DarkRed");
            DrawLineWithBresenham(point2[0], point2[1], point3[0], point3[1], "DarkRed");
            DrawLineWithBresenham(point3[0], point3[1], point1[0], point1[1], "DarkRed");

        }
        private float[] Translate(float x, float y, float tx, float ty)
        {
            // Translation matrix
            float[,] translationMatrix = {
                {1, 0, tx},
                {0, 1, ty},
                {0, 0, 1 }
            };

            // Input vector
            float[] vector = { x, y, 1 };

            // Multiply vector by translation matrix
            float[] result = MultiplyMatrixVector(translationMatrix, vector);

            return new float[] { result[0], result[1] };
        }

        // ************ Scaling Function *********************************
        private void Scaling_Click(object sender, EventArgs e)
        {
            float sx = (float)Convert.ToDouble(txtBox_scaling_x.Text);
            float sy = (float)Convert.ToDouble(txtBox_scaling_y.Text);

            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);

            float[] point1;
            float[] point2;
            float[] point3;

            if (checkBoxScalingOrigin.Checked)
            {
                point1 = Scale(x1, y1, sx, sy);
                point2 = Scale(x2, y2, sx, sy);
                point3 = Scale(x3, y3, sx, sy);
            }
            else
            {
                float xP = (float)Convert.ToDouble(txtBox_scaling_xP.Text);
                float yP = (float)Convert.ToDouble(txtBox_scaling_xP.Text);

                point1 = ScaleAboutPoint(x1, y1, sx, sy, xP, yP);
                point2 = ScaleAboutPoint(x2, y2, sx, sy, xP, yP);
                point3 = ScaleAboutPoint(x3, y3, sx, sy, xP, yP);
            }

            
            DrawLineWithBresenham(point1[0], point1[1], point2[0], point2[1], "DarkRed");
            DrawLineWithBresenham(point2[0], point2[1], point3[0], point3[1], "DarkRed");
            DrawLineWithBresenham(point3[0], point3[1], point1[0], point1[1], "DarkRed");

        }
        private float[] Scale(float x, float y, float sx, float sy)
        {
            // Scaling matrix
            float[,] scalingMatrix = {
                {sx, 0, 0},
                {0, sy, 0},
                {0, 0, 1}
            };

            // Input vector
            float[] vector = { x, y, 1 };

            // Multiply vector by scaling matrix
            float[] result = MultiplyMatrixVector(scalingMatrix, vector);

            return new float[] { result[0], result[1] };
        }

        private float[] ScaleAboutPoint(float x, float y, float sx, float sy, float centerX, float centerY)
        {
            // Translate to the origin
            float[] translated = Translate(x, y, -centerX, -centerY);

            // Scaling matrix
            float[,] scalingMatrix = {
                {sx, 0, 0},
                {0, sy, 0},
                {0, 0, 1}
            };

            // Input vector
            float[] vector = { x, y, 1 };

            // Multiply vector by scaling matrix
            float[] result = MultiplyMatrixVector(scalingMatrix, vector);


            // Translate back to the original center
            result = Translate(result[0], result[1], centerX, centerY);

            return new float[] { result[0], result[1] };
        }

        // *********** Rotation Function *********************************
        private void Rotation_Click(object sender, EventArgs e)
        {
            float angle = (float)Convert.ToDouble(txtBox_rotation_angle.Text);
            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);

            float[] point1;
            float[] point2;
            float[] point3;

            if (checkBoxRotationOrigin.Checked)
            {
                point1 = Rotate(x1, y1, angle);
                point2 = Rotate(x2, y2, angle);
                point3 = Rotate(x3, y3, angle);
            }
            else
            {
                float xP = (float)Convert.ToDouble(txtBox_rotation_xP.Text);
                float yP = (float)Convert.ToDouble(txtBox_rotation_yP.Text);

                point1 = RotateAboutPoint(x1, y1, angle, xP, yP);
                point2 = RotateAboutPoint(x2, y2, angle, xP, yP);
                point3 = RotateAboutPoint(x3, y3, angle, xP, yP);
            }

            DrawLineWithBresenham(point1[0], point1[1], point2[0], point2[1], "DarkRed");
            DrawLineWithBresenham(point2[0], point2[1], point3[0], point3[1], "DarkRed");
            DrawLineWithBresenham(point3[0], point3[1], point1[0], point1[1], "DarkRed");

        }
        private float[] Rotate(float x, float y, float angle)
        {
            // Convert angle to radians
            float radians = (float)(angle * Math.PI / 180.0);

            // Rotation matrix
            float[,] rotationMatrix = {
                { (float)Math.Cos(radians), -(float)Math.Sin(radians) },
                { (float)Math.Sin(radians), (float)Math.Cos(radians) }
            };

            // Input vector
            float[] vector = { x, y };

            // Multiply vector by rotation matrix
            float[] result = MultiplyMatrixVector2(rotationMatrix, vector);

            return new float[] { result[0], result[1] };
        }

        private float[] RotateAboutPoint(float x, float y, float angle, float centerX, float centerY)
        {
            // Convert angle to radians
            float radians = (float)(angle * Math.PI / 180.0);


            // Translate to the origin
            float[] translated = Translate(x, y, -centerX, -centerY);


            // Rotation matrix
            float[,] rotationMatrix = {
                { (float)Math.Cos(radians), -(float)Math.Sin(radians) },
                { (float)Math.Sin(radians), (float)Math.Cos(radians) }
            };

            // Input vector
            float[] vector = { x, y };

            // Multiply vector by rotation matrix
            float[] result = MultiplyMatrixVector2(rotationMatrix, vector);

            result = Translate(result[0], result[1], centerX, centerY);

            return new float[] { result[0], result[1] };
        }
        
        
        // ********** Shearing Function *********************************
        private void Shaering_Click(object sender, EventArgs e)
        {

            float shX = (float)Convert.ToDouble(txtBox_shearing_shx.Text);
            float shY = (float)Convert.ToDouble(txtBox_shearing_shy.Text);

            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);

            float[] point1 = Shear(x1, y1, shX, shY);
            float[] point2 = Shear(x2, y2, shX, shY);
            float[] point3 = Shear(x3, y3, shX, shY);

            DrawLineWithBresenham(point1[0], point1[1], point2[0], point2[1], "DarkRed");
            DrawLineWithBresenham(point2[0], point2[1], point3[0], point3[1], "DarkRed");
            DrawLineWithBresenham(point3[0], point3[1], point1[0], point1[1], "DarkRed");

        }

        private float[] Shear(float x, float y, float shx, float shy)
        {
            // Shearing matrix
            float[,] shearingMatrix = {
                { 1, shx },
                { shy, 1 }
            };

            // Input vector
            float[] vector = { x, y };

            // Multiply vector by shearing matrix
            float[] result = MultiplyMatrixVector2(shearingMatrix, vector);

            return new float[] { result[0], result[1] };
        }


        // ********** Reflection Function *********************************

        private void Reflection_Click(object sender, EventArgs e)
        {
            bool reflectX = checkBoxReflectX.Checked;
            bool reflectY = checkBoxReflectY.Checked;

            float x1 = (float)Convert.ToDouble(txtBox_triangle_x1.Text);
            float y1 = (float)Convert.ToDouble(txtBox_triangle_y1.Text);

            float x2 = (float)Convert.ToDouble(txtBox_triangle_x2.Text);
            float y2 = (float)Convert.ToDouble(txtBox_triangle_y2.Text);

            float x3 = (float)Convert.ToDouble(txtBox_triangle_x3.Text);
            float y3 = (float)Convert.ToDouble(txtBox_triangle_y3.Text);


            float[] point1 = Reflect(x1, y1, reflectX, reflectY);
            float[] point2 = Reflect(x2, y2, reflectX, reflectY);
            float[] point3 = Reflect(x3, y3, reflectX, reflectY);

            DrawLineWithBresenham(point1[0], point1[1], point2[0], point2[1], "DarkRed");
            DrawLineWithBresenham(point2[0], point2[1], point3[0], point3[1], "DarkRed");
            DrawLineWithBresenham(point3[0], point3[1], point1[0], point1[1], "DarkRed");

        }

        private float[] Reflect(float x, float y, bool reflectX, bool reflectY)
        {
            int sx = 1, sy = 1;
            // reflect about x only
            if (reflectX && !reflectY) {
                sx = 1;
                sy = -1;
            }
            // reflect about y only
            if (reflectY && !reflectX)
            {
                sy = 1;
                sx = -1;
            }
            if(reflectX && reflectY)
            {
                sx = -1;
                sy = -1;
            }

            // Reflection matrix
            //float[,] reflectionMatrix = {
            //    { reflectX ? 1 : -1, 0 },
            //    { 0, reflectY ? 1 : -1 }
            //};

            float[,] reflectionMatrix = {
                { sx, 0 },
                { 0, sy }
            };

            // Multiply vector by reflection matrix
            float[] result = MultiplyMatrixVector2(reflectionMatrix, new float[] { x, y });

            return new float[] { result[0], result[1] };
        }

        
    }
}
