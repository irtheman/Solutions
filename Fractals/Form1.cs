﻿using System;
using System.Collections.Generic;
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
        private Stack<double> _xMin, _xMax, _yMin, _yMax;
        private bool _drawingBox;
        private int _startX, _startY, _endX, _endY;


        public Form1()
        {
            InitializeComponent();
            
            _xMin = new Stack<double>();
            _xMax = new Stack<double>();
            _yMin = new Stack<double>();
            _yMax = new Stack<double>();

            mnuFractal.SelectedIndex = 0;

            MaxIterations = 100;

            _fractal = new Mandelbrot1();
            _fractal.MaxIterations = MaxIterations;

            mnuFullScale_Click(null, null);
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
            double want_aspect = (_yMax.Peek() - _yMin.Peek()) / (_xMax.Peek() - _xMin.Peek());
            double Canvas_aspect = Canvas.ClientSize.Height / (double)Canvas.ClientSize.Width;
            if (want_aspect > Canvas_aspect)
            {
                wid = (_yMax.Peek() - _yMin.Peek()) / Canvas_aspect;
                mid = (_xMin.Peek() + _xMax.Peek()) / 2;
                _xMin.Push(mid - wid / 2);
                _xMax.Push(mid + wid / 2);
            }
            else
            {
                hgt = (_xMax.Peek() - _xMin.Peek()) * Canvas_aspect;
                mid = (_yMin.Peek() + _yMax.Peek()) / 2;
                _yMin.Push(mid - hgt / 2);
                _yMax.Push(mid + hgt / 2);
            }

            int width = Canvas.ClientRectangle.Width;
            int hight = Canvas.ClientRectangle.Height;
            double realDiv = (_xMax.Peek() - _xMin.Peek()) / (width - 1);
            double imaginaryDiv = (_yMax.Peek() - _yMin.Peek()) / (hight - 1);

            double real = _xMin.Peek();
            for (int X = 0; X < width; X++)
            {
                double imaginary = _yMin.Peek();
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

            Text = "Fractals (" +
                _xMin.Peek().ToString("0.000000") + ", " +
                _yMin.Peek().ToString("0.000000") + ")-(" +
                _xMax.Peek().ToString("0.000000") + ", " +
                _yMax.Peek().ToString("0.000000") + ")";
        }

        private void ScaleMap(double scaleFactor)
        {
            double size = scaleFactor * (_xMax.Peek() - _xMin.Peek());
            if (size > 3.2)
            {
                mnuFullScale_Click(null, null);
                return;
            }

            double mid = (_xMin.Peek() + _xMax.Peek()) / 2;
            _xMin.Push(mid - size / 2);
            _xMax.Push(mid + size / 2);

            size = scaleFactor * (_yMax.Peek() - _yMin.Peek());
            if (size > 2.4)
            {
                mnuFullScale_Click(null, null);
                return;
            }

            mid = (_yMin.Peek() + _yMax.Peek()) / 2;
            _yMin.Push(mid - size / 2);
            _yMax.Push(mid + size / 2);

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DrawFractal();

            this.Cursor = Cursors.Default;
            Canvas.Cursor = Cursors.Cross;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            mnuFullScale_Click(null, null);
        }

        private void mnuFractal_SelectedIndexChanged(object sender, EventArgs e)
        {
            Fractal chosen = null;
            ToolStripComboBox cbo = sender as ToolStripComboBox;

            switch (cbo.SelectedItem.ToString())
            {
                case "Mandelbrot 1":
                    chosen = new Mandelbrot1();
                    break;
                case "Mandelbrot 2":
                    chosen = new Mandelbrot2();
                    break;
                case "Mandelbrot 3":
                    chosen = new Mandelbrot3();
                    break;
                case "Burning Ship 1":
                    chosen = new BurningShip1();
                    break;
                case "Burning Ship 2":
                    chosen = new BurningShip2();
                    break;
                case "Burning Ship 3":
                    chosen = new BurningShip3();
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
                    chosen = new Mandelbrot1();
                    break;
            }

            chosen.MaxIterations = MaxIterations;
            _fractal = chosen;

            mnuFullScale_Click(null, null);
        }

        private void mnuUndo_Click(object sender, EventArgs e)
        {
            if (_xMin.Count < 2) return;

            _xMin.Pop();
            _xMax.Pop();
            _yMin.Pop();
            _yMax.Pop();

            DrawFractal();
        }

        private void mnuRefresh_Click(object sender, EventArgs e)
        {
            ScaleMap(1.0);
        }

        private void mnuScale_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mnu = sender as ToolStripMenuItem;
            ScaleMap((double) mnu.Tag);
        }

        private void mnuFullScale_Click(object sender, EventArgs e)
        {
            _xMin.Push(_fractal.MinX);
            _xMax.Push(_fractal.MaxX);
            _yMin.Push(_fractal.MinY);
            _yMax.Push(_fractal.MaxY);

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DrawFractal();

            this.Cursor = Cursors.Default;
            Canvas.Cursor = Cursors.Cross;
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            _drawingBox = true;

            _startX = e.X;
            _startY = e.Y;
            _endX = e.X;
            _endY = e.Y;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_drawingBox) return;

            _endX = e.X;
            _endY = e.Y;

            int left = (int)(Math.Min(_startX, _endX));
            int top = (int)(Math.Min(_startY, _endY));
            int right = (int)(Math.Abs(_startX - _endX));
            int bottom = (int)(Math.Abs(_startY - _endY));

            Bitmap bm = new Bitmap(_bm);
            Graphics gr = Graphics.FromImage(bm);
            gr.DrawRectangle(Pens.Yellow, left, top, right, bottom);
            Canvas.Image = bm;
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!_drawingBox) return;

            _drawingBox = false;
            Canvas.Image = _bm;

            _endX = e.X;
            _endY = e.Y;

            // Arrange top left to bottom right
            double x1 = Math.Min(_startX, _endX);
            double x2 = Math.Max(_startX, _endX);
            if (x1 == x2) x2 = x1 + 1;

            double y1 = Math.Min(_startY, _endY);
            double y2 = Math.Max(_startY, _endY);
            if (y1 == y2) y2 = y1 + 1;

            // Convert to drawing coordinates
            double factor = (_xMax.Peek() - _xMin.Peek()) / Canvas.ClientSize.Width;
            _xMax.Push(_xMin.Peek() + x2 * factor);
            _xMin.Push(_xMin.Peek() + x1 * factor);

            factor = (_yMax.Peek() - _yMin.Peek()) / Canvas.ClientSize.Height;
            _yMax.Push(_yMin.Peek() + y2 * factor);
            _yMin.Push(_yMin.Peek() + y1 * factor);

            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            DrawFractal();

            this.Cursor = Cursors.Default;
            Canvas.Cursor = Cursors.Cross;
        }
    }
}
