using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Fractals.Algorithms;

namespace Fractals
{
    public partial class Form1 : Form
    {
        private Fractal _fractal;
        private Bitmap _bm;
        private double _xMin, _xMax, _yMin, _yMax;

        public Form1()
        {
            InitializeComponent();

            mnuFractal.SelectedIndex = 0;

            MaxIterations = 100;

            _fractal = new Mandelbrot();
            _fractal.MaxIterations = MaxIterations;

            mnuRefresh_Click(null, null);
        }

        public int MaxIterations { get; set; }

        private void DrawFractal()
        {
            _bm = new Bitmap(Canvas.ClientSize.Width, Canvas.ClientSize.Height);
            Graphics gr = Graphics.FromImage(_bm);

            // Clear.
            gr.Clear(Canvas.BackColor);
            Canvas.Image = _bm;
            Application.DoEvents();

            double hgt, wid, mid;
            double want_aspect = (_yMax - _yMin) / (_xMax - _xMin);
            double Canvas_aspect = Canvas.ClientSize.Height / (double)Canvas.ClientSize.Width;
            if (want_aspect > Canvas_aspect)
            {
                wid = (_yMax - _yMin) / Canvas_aspect;
                mid = (_xMin + _xMax) / 2;
                _xMin = mid - wid / 2;
                _xMax = mid + wid / 2;
            }
            else
            {
                hgt = (_xMax - _xMin) * Canvas_aspect;
                mid = (_yMin + _yMax) / 2;
                _yMin = mid - hgt / 2;
                _yMax = mid + hgt / 2;
            }

            int width = Canvas.ClientRectangle.Width;
            int hight = Canvas.ClientRectangle.Height;
            double realDiv = (_xMax - _xMin) / (width - 1);
            double imaginaryDiv = (_yMax - _yMin) / (hight - 1);

            double real = _xMin;
            for (int X = 0; X < width; X++)
            {
                double imaginary = _yMin;
                for (int Y = 0; Y < hight; Y++)
                {
                    int iteration = _fractal.Calculate(real, imaginary);

                    if (iteration >= MaxIterations)
                    {
                        _bm.SetPixel(X, Y, Color.Black);
                    }
                    else
                    {
                        Color color = Color.FromArgb(iteration % 255, iteration % 255, iteration % 255);
                        _bm.SetPixel(X, Y, color);
                    }

                    imaginary += imaginaryDiv;
                }
                real += realDiv;

                if (X % 10 == 0) Canvas.Refresh();
            }

            Text = "Mandelbrot (" +
                _xMin.ToString("0.000000") + ", " +
                _yMin.ToString("0.000000") + ")-(" +
                _xMax.ToString("0.000000") + ", " +
                _yMax.ToString("0.000000") + ")";
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            mnuRefresh_Click(null, null);
        }

        private void mnuFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fractal chosen = null;
            ToolStripComboBox cbo = sender as ToolStripComboBox;

            switch (cbo.SelectedItem.ToString())
            {
                case "Mandelbrot":
                    chosen = new Mandelbrot();
                    break;
                case "Burning Ship":
                    chosen = new BurningShip();
                    break;
                case "Julia 1":
                    chosen = new Julia1();
                    break;
                case "Julia 2":
                    chosen = new Julia2();
                    break;
                case "Julia 3":
                    chosen = new Julia3();
                    break;
                case "Julia 4":
                    chosen = new Julia4();
                    break;
                default:
                    chosen = new Mandelbrot();
                    break;
            }

            chosen.MaxIterations = MaxIterations;
            _fractal = chosen;

            mnuRefresh_Click(null, null);
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            _xMin = _fractal.MinX;
            _xMax = _fractal.MaxX;
            _yMin = _fractal.MinY;
            _yMax = _fractal.MaxY;

            DrawFractal();
        }
    }
}
