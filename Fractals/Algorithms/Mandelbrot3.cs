using System.Numerics;

namespace Fractals.Algorithms
{
    public class Mandelbrot3 : Fractal
    {
        public Mandelbrot3()
        {
            MinX = 0.247407;
            MaxX = 0.348148;
            MinY = -0.041602;
            MaxY = 0.041602;

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
