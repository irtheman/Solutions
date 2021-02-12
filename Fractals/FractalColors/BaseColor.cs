using System.Drawing;
using System.Numerics;

namespace Fractals.FractalColors
{
    public abstract class BaseColor
    {
        public abstract Color GetColor(int maxIterations, int iteration, Complex z, Complex c);
    }
}
