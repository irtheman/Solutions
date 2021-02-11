using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.Algorithms
{
    public class Fractal
    {
        private const double EscapeSquared = EscapeRadius * EscapeRadius;

        public const double EscapeRadius = 2.0;

        public double MinX { get; protected set; }
        public double MaxX { get; protected set; }
        public double MinY { get; protected set; }
        public double MaxY { get; protected set; }
        public int MaxIterations { get; set; }

        public int Calculate(double real, double imaginary)
        {
            Complex z = GenerateZ(real, imaginary);
            Complex c = GenerateC(real, imaginary);

            return Calculate(ref z, ref c);
        }

        protected virtual Complex GenerateZ(double real, double imaginary)
        {
            return 0;
        }

        protected virtual Complex GenerateC(double real, double imaginary)
        {
            return 0;
        }

        protected virtual Complex Formula(Complex z, Complex c)
        {
            return z * z + c;
        }

        protected virtual int Calculate(ref Complex z, ref Complex c)
        {
            int iteration = 0;
            while ((iteration < MaxIterations) && ((z.Magnitude * z.Magnitude) < EscapeSquared))
            {
                z = Formula(z, c);
                iteration++;
            }

            return iteration;
        }
    }
}
