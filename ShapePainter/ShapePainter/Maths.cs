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
        public unsafe static int FastMin(int a, int b)
        {
            unsafe
            {
                if (a > b) return b;
                else return a;
            }
        }

        public unsafe static int FastMax(int a, int b)
        {
            unsafe
            {
                if (a > b) return a;
                else return b;
            }
        }

        public unsafe static int FastRound(float number)
        {
            int floor = (int)number;
            if (number - floor < 0.5)
                return floor;
            else
                return floor + 1;
        }

        public unsafe static int FastAbs(int a)
        {
            if (a < 0)
                return -a;
            else
                return a;
        }

        public unsafe static Point CleanLocation(Point mouse)
        {
            if (mouse.X < 0) mouse.X = 0;
            else if (mouse.X >= Variables.bitmapWidth)
                mouse.X = Variables.bitmapWidth - 1;

            if (mouse.Y < 0) mouse.Y = 0;
            else if (mouse.Y >= Variables.bitmapHeight)
                mouse.Y = Variables.bitmapHeight - 1;

            return mouse;
        }

        public unsafe static float CalculatePointToSegmentDistance(Point point, Point seg1, Point seg2, int thickness)
        {
            float thick = 0;
            int ps1x = point.X - seg1.X;
            int ps1y = point.Y - seg1.Y;
            int dx = seg2.X - seg1.X;
            int dy = seg2.Y - seg1.Y;

            int dot = ps1x * dx + ps1y * dy;
            int len2 = dx * dx + dy * dy;
            float param = -1;

            if (len2 != 0)
                param = (float)dot / len2;

            float projx, projy;
            if (param < 0)
            {
                projx = seg1.X;
                projy = seg1.Y;
            }
            else if (param > 1)
            {
                projx = seg2.X;
                projy = seg2.Y;
            }
            else
            {
                projx = param * dx + seg1.X;
                projy = param * dy + seg1.Y;
                thick = (float)thickness / 2;
            }

            float distx = point.X - projx;
            float disty = point.Y - projy;
            float dist = (float)Math.Sqrt(distx * distx + disty * disty) - thick;
            if (dist < 0)
                dist = 0;

            return dist;
        }

        public unsafe static float CalculatePointToCircleDistance(Point point, Circle circle)
        {
            float rad = CalculatePointToPointDistance(point, circle.center);
            float dist = (float)circle.radius - rad;

            if (dist < 0)
                dist = -dist;
            dist -= (float)circle.thickness / 2;

            if (dist < 0)
                dist = 0;
            return dist;
        }

        public unsafe static float CalculatePointToPointDistance(Point point1, Point point2)
        {
            return (float)Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X)
                    + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }

        public unsafe static (int, int) GetClosestPoint(Point point)
        {
            int index, bestIndex = 0, bestObject = 0;
            float distance, bestDistance = float.PositiveInfinity;
            for (int i = 0; i < Variables.shapes.Count; i++)
            {
                (index, distance) = Variables.shapes[i].GetPointDistance(point);
                if (distance < bestDistance)
                {
                    bestIndex = index;
                    bestObject = Variables.shapes[i].ID;
                    bestDistance = distance;
                }
            }

            if (bestDistance <= 5)
                return (bestObject, bestIndex);
            else
                return (0, 0);
        }

        public unsafe static (int, int) GetClosestLine(Point point)
        {
            int index, bestIndex = 0, bestObject = 0;
            float distance, bestDistance = float.PositiveInfinity;
            for (int i = 0; i < Variables.shapes.Count; i++)
            {
                (index, distance) = Variables.shapes[i].GetLineDistance(point);
                if (distance < bestDistance)
                {
                    bestIndex = index;
                    bestObject = Variables.shapes[i].ID;
                    bestDistance = distance;
                }
            }

            if (bestDistance <= 5)
                return (bestObject, bestIndex);
            else
                return (0, 0);
        }
    }
}
