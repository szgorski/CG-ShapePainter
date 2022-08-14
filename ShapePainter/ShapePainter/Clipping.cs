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
        [Flags]
        public enum csCode
        {
            LEFT = 1,
            RIGHT = 2,
            BOTTOM = 4,
            TOP = 8
        };

        public unsafe static csCode ComputeCohenSutherlandCodes(Point point, Rectang rectangle)
        {
            csCode outcode = 0;
            if (point.X > FastMax(rectangle.end1.X, rectangle.end2.X))
                outcode |= csCode.RIGHT;
            else if (point.X < FastMin(rectangle.end1.X, rectangle.end2.X))
                outcode |= csCode.LEFT;

            if (point.Y > FastMax(rectangle.end1.Y, rectangle.end2.Y))
                outcode |= csCode.TOP;
            else if (point.Y < FastMin(rectangle.end1.Y, rectangle.end2.Y))
                outcode |= csCode.BOTTOM;  // reversed meaning

            return outcode;
        }

        public unsafe static (Point, Point) DrawCohenSutherlandLine(Point point1, Point point2, Rectang rectangle)
        {
            bool accept = false, done = false;
            csCode outcode1 = ComputeCohenSutherlandCodes(point1, rectangle);
            csCode outcode2 = ComputeCohenSutherlandCodes(point2, rectangle);
            do
            {
                if ((outcode1 | outcode2) == 0)
                {
                    accept = true;
                    done = true;
                }
                else if ((outcode1 & outcode2) != 0)
                {
                    accept = false;
                    done = true;
                }
                else
                {
                    csCode outcodeOut = (outcode1 != 0) ? outcode1 : outcode2;
                    Point point = new Point();

                    if ((outcodeOut & csCode.TOP) != 0)
                    {
                        point.X = point1.X + (point2.X - point1.X) * (FastMax(rectangle.end1.Y, rectangle.end2.Y) - point1.Y) / (point2.Y - point1.Y);
                        point.Y = FastMax(rectangle.end1.Y, rectangle.end2.Y);
                    }
                    else if ((outcodeOut & csCode.BOTTOM) != 0)
                    {
                        point.X = point1.X + (point2.X - point1.X) * (FastMin(rectangle.end1.Y, rectangle.end2.Y) - point1.Y) / (point2.Y - point1.Y);
                        point.Y = FastMin(rectangle.end1.Y, rectangle.end2.Y);
                    }
                    else if ((outcodeOut & csCode.RIGHT) != 0)
                    {
                        point.Y = point1.Y + (point2.Y - point1.Y) * (FastMax(rectangle.end1.X, rectangle.end2.X) - point1.X) / (point2.X - point1.X);
                        point.X = FastMax(rectangle.end1.X, rectangle.end2.X);
                    }
                    else if ((outcodeOut & csCode.LEFT) != 0)
                    {
                        point.Y = point1.Y + (point2.Y - point1.Y) * (FastMin(rectangle.end1.X, rectangle.end2.X) - point1.X) / (point2.X - point1.X);
                        point.X = FastMin(rectangle.end1.X, rectangle.end2.X);
                    }

                    if (outcodeOut == outcode1)
                    {
                        point1 = point;
                        outcode1 = ComputeCohenSutherlandCodes(point1, rectangle);
                    }
                    else
                    {
                        point2 = point;
                        outcode2 = ComputeCohenSutherlandCodes(point2, rectangle);
                    }
                }
            } while (!done);
            if (accept)
                return (point1, point2);
            else
                return (new Point(-1, -1), new Point(-1, -1));
        }
    }
}
