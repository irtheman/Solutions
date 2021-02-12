using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.FractalColors
{
    public class CyanScale : BaseColor
    {
        public override Color GetColor(int maxIterations, int iteration, Complex z, Complex c)
        {
            Color color = Color.Black;
            if (iteration < maxIterations)
            {
                color = Color.FromArgb(0, iteration % 255, iteration % 255);
            }

            return color;
        }
    }
}
