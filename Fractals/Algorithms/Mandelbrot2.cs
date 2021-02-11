using System.Numerics;

namespace Fractals.Algorithms
{
    public class Mandelbrot2 : Fractal
    {
        public Mandelbrot2()
        {
            MinX = -0.848423;
            MaxX =-0.661672;
            MinY = -0.172275;
            MaxY = -0.012921;

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
