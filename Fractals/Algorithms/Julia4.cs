﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Algorithms
{
    public class Julia4 : Fractal
    {
        public Julia4()
        {
            MinX = -1;
            MaxX = 1;
            MinY = -1.2;
            MaxY = 1.2;

            Z0 = new Complex(-0.4, 0.6);
        }
        protected override Complex GenerateZ(double real, double imaginary)
        {
            return new Complex(real, imaginary);
        }

        protected override Complex GenerateC(double real, double imaginary)
        {
            return Z0;
        }

    }
}
