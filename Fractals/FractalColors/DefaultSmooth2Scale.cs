using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.FractalColors
{
    public class DefaultSmooth2Scale : BaseColor
    {
        List<Color> _colors;

        public DefaultSmooth2Scale()
        {
            _colors = new List<Color>()
            {
                Color.Black,
                Color.Red,
                Color.FromArgb(255, 128, 0),
                Color.Yellow,
                Color.FromArgb(0, 192, 0),
                Color.Cyan,
                Color.Blue,
                Color.Purple
            };
        }

        public override Color GetColor(int maxIterations, int iteration, Complex z, Complex c)
        {
            Color color = Color.Black;
            if (iteration < maxIterations)
            {
                for (int i = 0; i < 3; i++)
                {
                    z = z * z + c;
                    iteration++;
                }

                double mu = iteration + 1 - Math.Log(Math.Log(z.Magnitude)) / Math.Log(2);
                mu = mu / maxIterations * _colors.Count;

                int clr1 = (int)mu;
                double t2 = mu - clr1;
                double t1 = 1 - t2;
                clr1 = clr1 % _colors.Count;
                int clr2 = (clr1 + 1) % _colors.Count;

                int r = (int)(_colors[clr1].R * t1 + _colors[clr2].R * t2);
                int g = (int)(_colors[clr1].G * t1 + _colors[clr2].G * t2);
                int b = (int)(_colors[clr1].B * t1 + _colors[clr2].B * t2);

                return Color.FromArgb(r, g, b);
            }

            return color;
        }
    }
}
