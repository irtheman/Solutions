﻿using System.Numerics;

namespace Fractals.Algorithms
{
    public class Mandelbrot1 : Fractal
    {
        public Mandelbrot1()
        {
            MinX = -2.2;
            MaxX = 1;
            MinY = -1.2;
            MaxY = 1.2;

            Z0 = new Complex(0, 0);
        }
        protected override Complex GenerateZ(double real, double imaginary)
        {
            return Z0;
        }

        protected override Complex GenerateC(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }
    }
}
