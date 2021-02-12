using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.FractalColors
{
    public class GreenWhiteScale : BaseColor
    {
        public override Color GetColor(int maxIterations, int iteration, Complex z, Complex c)
        {
            Color color = Color.Black;
            if (iteration < maxIterations)
            {
                double quotient = iteration / (double)maxIterations;
                int rgb = (int) (quotient * 255);
                if (rgb < 0) rgb = 0;
                if (rgb > 255) rgb = 255;

                if (quotient > 0.5)
                {
                    color = Color.FromArgb(rgb, 255, rgb);
                }
                else
                {
                    color = Color.FromArgb(0, rgb, 0);
                }
            }

            return color;
        }
    }
}
