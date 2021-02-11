using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Algorithms
{
    public class BurningShip2 : Fractal
    {
        public BurningShip2()
        {
            MinX = -1.807363;
            MaxX = -1.700509;
            MinY = -0.081611;
            MaxY = 0.0006102;

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

        protected override Complex Formula(Complex z, Complex c)
        {
            Complex temp = base.Formula(z, c);
            return new Complex(Math.Abs(temp.Real), Math.Abs(temp.Imaginary));
        }
    }
}
