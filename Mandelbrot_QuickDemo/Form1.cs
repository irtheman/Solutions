using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        private const int MAXCOUNT = 30;

        Rectangle rect;
        Point locationXY;
        Point locationX1Y1;
        bool isMouseDown = false;

        Stack<double> left;
        Stack<double> top;
        Stack<double> xside;
        Stack<double> yside;

        List<Brush> brush;

        public Form1()
        {
            InitializeComponent();

            left = new Stack<double>();
            top = new Stack<double>();
            xside = new Stack<double>();
            yside = new Stack<double>();

            left.Push(-1.75);
            top.Push(-0.25);
            xside.Push(0.25);
            yside.Push(0.45);

            brush = GetBrushes();

            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            double xscale, yscale, zx, zy, cx, tempx, cy;
            int x, y, i, j;
            int count;

            if (isMouseDown)
            {
                e.Graphics.DrawRectangle(Pens.Black, GetRect());
                return;
            }

            xscale = xside.Peek() / Width;
            yscale = yside.Peek() / Height;

            e.Graphics.FillRectangle(brush[0], 0, 0, Width, Height);

            for (y = 1; y < Height; y++)
            {
                for (x = 1; x < Width; x++)
                {
                    cx = x * xscale + left.Peek();
                    cy = y * yscale + top.Peek();
                    zx = 0;
                    zy = 0;
                    count = 0;

                    // z = z*z + c where z is a complex number
                    while ((zx * zx + zy * zy < 4) && (count < brush.Count - 1))
                    {
                        // tempx = zReal * zReal - zImaginary * zImaginary + cReal
                        tempx = zx * zx - zy * zy + cx;

                        // 2 * zReal * zImaginary + cImaginary
                        zy = 2 * zx * zy + cy;

                        // zReal = tempx
                        zx = tempx;

                        count += 1;
                    }

                    e.Graphics.FillRectangle(brush[count], x, y, 1, 1);
                }
            }
        }

        private List<Brush> GetBrushes()
        {
            var colors = GetColorList();
            var brushes = new List<Brush>();

            foreach (var color in colors)
            {
                brushes.Add(new SolidBrush(color));
            }

            return brushes;
        }

        private List<Color> GetColorList()
        {
            List<Color> colors = new List<Color>();
            string[] colorNames = Enum.GetNames(typeof(KnownColor));

            foreach (string colorName in colorNames)
            {
                KnownColor knownColor = (KnownColor) Enum.Parse(typeof(KnownColor), colorName);

                if ((knownColor > KnownColor.Transparent) &&
                     (knownColor < KnownColor.ButtonFace))
                {
                    colors.Add(Color.FromName(colorName));
                }
            }

            return colors;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            locationXY = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                locationX1Y1 = e.Location;
                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                locationX1Y1 = e.Location;
                isMouseDown = false;

                // Put the coordinates in proper order.
                double x1 = Math.Min(locationXY.X, locationX1Y1.X);
                double x2 = Math.Max(locationXY.X, locationX1Y1.X);
                if (x1 == x2) x2 = x1 + 1;

                double y1 = Math.Min(locationXY.Y, locationX1Y1.Y);
                double y2 = Math.Max(locationXY.Y, locationX1Y1.Y);
                if (y1 == y2) y2 = y1 + 1;

                // Convert screen coords into drawing coords.
                double xMin = left.Peek(), xMax = xMin + xside.Peek();
                double yMin = top.Peek(), yMax = yMin + yside.Peek();

                double factor = (xMax - xMin) / Width;
                xMax = xMin + x2 * factor;
                xMin = xMin + x1 * factor;

                factor = (yMax - yMin) / Height;
                yMax = yMin + y2 * factor;
                yMin = yMin + y1 * factor;

                left.Push(xMin);
                top.Push(yMin);
                xside.Push(xMax - xMin);
                yside.Push(yMax - yMin);

                Refresh();
            }
        }

        private Rectangle GetRect()
        {
            rect = new Rectangle();
            rect.X = Math.Min(locationXY.X, locationX1Y1.X);
            rect.Y = Math.Min(locationXY.Y, locationX1Y1.Y);
            rect.Width = Math.Abs(locationXY.X - locationX1Y1.X);
            rect.Height = Math.Abs(locationXY.Y - locationX1Y1.Y);

            return rect;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.Z))
            {
                if (left.Count > 1)
                {
                    left.Pop();
                    top.Pop();
                    xside.Pop();
                    yside.Pop();

                    Refresh();
                }
            }
        }
    }
}
