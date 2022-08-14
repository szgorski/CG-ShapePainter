using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public partial class ShapePainter
    {
        public static unsafe void DrawPoint(Point point)
        {
            for (int i = FastMax(point.X - 4, 0); i <= FastMin(point.X + 4, Variables.bitmapWidth - 1); i++)
            {
                for (int j = FastMax(point.Y - 4, 0); j <= FastMin(point.Y + 4, Variables.bitmapHeight - 1); j++)
                {
                    if (Variables.pointsKernel[i - point.X + 4, j - point.Y + 4])
                    {
                        Variables.bitmapArray[i, j] = 4294901760;   // red
                    }
                }
            }
        }

        public unsafe static bool[,] CreateBrush(int diagonal)
        {   // assuming diagonal is odd
            int radius = diagonal / 2;
            bool[,] circle = new bool[diagonal, diagonal];

            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (FastRound((float)Math.Sqrt(i * i + j * j)) <= radius)
                        circle[radius + i, radius + j] = true;
                }
            }
            return circle;
        }

        public unsafe static void ApplyBrush(int x, int y, bool[,] brush, uint colour, int thickness)
        {
            int radius = thickness / 2;
            for (int i = FastMax(x - radius, 0); i <= FastMin(x + radius, Variables.bitmapWidth - 1); i++)
            {
                for (int j = FastMax(y - radius, 0); j <= FastMin(y + radius, Variables.bitmapHeight - 1); j++)
                {
                    if (brush[i - x + radius, j - y + radius])
                        Variables.bitmapArray[i, j] = colour;
                }
            }
        }
    }
}
