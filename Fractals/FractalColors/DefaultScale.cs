using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Fractals.FractalColors
{
    public class DefaultScale : BaseColor
    {
        List<Color> _colors;

        public DefaultScale()
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
                color = _colors[iteration % _colors.Count];
            }

            return color;
        }
    }
}
