using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Algorithms
{
    public class BurningShip1 : Fractal
    {
        private readonly Complex Z0;

        public BurningShip1()
        {
            MinX = -2.5;
            MaxX = 1.5;
            MinY = -2;
            MaxY = 1;

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
