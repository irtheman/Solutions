using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Algorithms
{
    public class Julia3 : Fractal
    {
        private readonly Complex C0;

        public Julia3()
        {
            MinX = -1;
            MaxX = 1;
            MinY = -1.2;
            MaxY = 1.2;

            C0 = new Complex(-0.8, 0.156);
        }
        protected override Complex GenerateZ(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }

        protected override Complex GenerateC(double real, double imaginary)
        {
            return C0;
        }

    }
}
