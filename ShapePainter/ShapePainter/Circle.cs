using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public class Circle : Shape
    {
        public Point center;
        public int radius;

        public Circle(Point newCenter, int newThickness) : base(newThickness)
        {
            center = newCenter;
        }

        public Circle(Point newCenter, Point radiusPoint, int newThickness) : base(newThickness)
        {
            center = newCenter;
            radius = CalculateRadius(radiusPoint);
        }

        public unsafe int CalculateRadius(Point radiusPoint)
        {
            return (int)Math.Sqrt((center.X - radiusPoint.X) * (center.X - radiusPoint.X)
                + (center.Y - radiusPoint.Y) * (center.Y - radiusPoint.Y));
        }

        public override unsafe void DrawShape()
        {
            if (thickness == 1)
                ShapePainter.MidpointCircle(center, radius, color);
            else
                ShapePainter.BrushCircle(center, radius, color, thickness);
        }

        public override unsafe void DrawActiveShape()
        {
            if (Variables.modeName == "radioButtonMovePoint")
            {
                if (thickness == 1)
                    ShapePainter.MidpointCircle(center, radius, color);
                else
                    ShapePainter.BrushCircle(center, radius, color, thickness);
            }
            else
            {
                int currentRadius = CalculateRadius(Variables.positionNow);
                if (thickness == 1)
                    ShapePainter.MidpointCircle(center, currentRadius, color);
                else
                    ShapePainter.BrushCircle(center, currentRadius, color, thickness);
            }
        }

        public override unsafe void DrawPoints()
        {
            ShapePainter.DrawPoint(center);
        }

        public override unsafe void UpdatePoint(Point point)
        {
            center = point;
        }

        public override unsafe (int, float) GetPointDistance(Point point)
        {
            return (1, ShapePainter.CalculatePointToPointDistance(point, center));
        }

        public override unsafe (int, float) GetLineDistance(Point point)
        {
            return (1, ShapePainter.CalculatePointToCircleDistance(point, this));
        }
    }

    public partial class ShapePainter
    {
        public unsafe static void MidpointCircle(Point point, int radius, uint colour)
        {
            int x = point.X;
            int y = point.Y;
            int d = 1 - radius;
            int dI = 3;                  // identity axis
            int dD = 5 - 2 * radius;     // diagonal axis
            int xc = 0;         // relative circumference position
            int yc = radius;    // relative circumference position

            bool caseA, caseB, caseC, caseD, caseE, caseF, caseG, caseH;
            caseA = false; if (x + xc >= 0 && x + xc < Variables.bitmapWidth) caseA = true;
            caseB = false; if (x - xc >= 0 && x - xc < Variables.bitmapWidth) caseB = true;
            caseC = false; if (x + yc >= 0 && x + yc < Variables.bitmapWidth) caseC = true;
            caseD = false; if (x - yc >= 0 && x - yc < Variables.bitmapWidth) caseD = true;
            caseE = false; if (y + xc >= 0 && y + xc < Variables.bitmapHeight) caseE = true;
            caseF = false; if (y - xc >= 0 && y - xc < Variables.bitmapHeight) caseF = true;
            caseG = false; if (y + yc >= 0 && y + yc < Variables.bitmapHeight) caseG = true;
            caseH = false; if (y - yc >= 0 && y - yc < Variables.bitmapHeight) caseH = true;

            if (caseA && caseG)
                Variables.bitmapArray[x + xc, y + yc] = colour;
            if (caseA && caseH)
                Variables.bitmapArray[x + xc, y - yc] = colour;
            if (caseB && caseG)
                Variables.bitmapArray[x - xc, y + yc] = colour;
            if (caseB && caseH)
                Variables.bitmapArray[x - xc, y - yc] = colour;
            if (caseC && caseE)
                Variables.bitmapArray[x + yc, y + xc] = colour;
            if (caseC && caseF)
                Variables.bitmapArray[x + yc, y - xc] = colour;
            if (caseD && caseE)
                Variables.bitmapArray[x - yc, y + xc] = colour;
            if (caseD && caseF)
                Variables.bitmapArray[x - yc, y - xc] = colour;

            while (yc > xc)
            {
                if (d < 0)
                {
                    d += dI;
                    dI += 2;
                    dD += 2;
                }
                else
                {
                    d += dD;
                    dI += 2;
                    dD += 4;
                    yc--;
                }
                xc++;

                caseA = false; if (x + xc >= 0 && x + xc < Variables.bitmapWidth) caseA = true;
                caseB = false; if (x - xc >= 0 && x - xc < Variables.bitmapWidth) caseB = true;
                caseC = false; if (x + yc >= 0 && x + yc < Variables.bitmapWidth) caseC = true;
                caseD = false; if (x - yc >= 0 && x - yc < Variables.bitmapWidth) caseD = true;
                caseE = false; if (y + xc >= 0 && y + xc < Variables.bitmapHeight) caseE = true;
                caseF = false; if (y - xc >= 0 && y - xc < Variables.bitmapHeight) caseF = true;
                caseG = false; if (y + yc >= 0 && y + yc < Variables.bitmapHeight) caseG = true;
                caseH = false; if (y - yc >= 0 && y - yc < Variables.bitmapHeight) caseH = true;

                if (caseA && caseG)
                    Variables.bitmapArray[x + xc, y + yc] = colour;
                if (caseA && caseH)
                    Variables.bitmapArray[x + xc, y - yc] = colour;
                if (caseB && caseG)
                    Variables.bitmapArray[x - xc, y + yc] = colour;
                if (caseB && caseH)
                    Variables.bitmapArray[x - xc, y - yc] = colour;
                if (caseC && caseE)
                    Variables.bitmapArray[x + yc, y + xc] = colour;
                if (caseC && caseF)
                    Variables.bitmapArray[x + yc, y - xc] = colour;
                if (caseD && caseE)
                    Variables.bitmapArray[x - yc, y + xc] = colour;
                if (caseD && caseF)
                    Variables.bitmapArray[x - yc, y - xc] = colour;
            }
        }

        public unsafe static void BrushCircle(Point point, int radius, uint colour, int thickness)
        {
            bool[,] brush = CreateBrush(thickness);

            int x = point.X;
            int y = point.Y;
            int d = 1 - radius;
            int dI = 3;                  // identity axis
            int dD = 5 - 2 * radius;     // diagonal axis
            int xc = 0;         // relative circumference position
            int yc = radius;    // relative circumference position

            ApplyBrush(x + xc, y + yc, brush, colour, thickness);
            ApplyBrush(x + xc, y - yc, brush, colour, thickness);
            ApplyBrush(x - xc, y + yc, brush, colour, thickness);
            ApplyBrush(x - xc, y - yc, brush, colour, thickness);
            ApplyBrush(x + yc, y + xc, brush, colour, thickness);
            ApplyBrush(x + yc, y - xc, brush, colour, thickness);
            ApplyBrush(x - yc, y + xc, brush, colour, thickness);
            ApplyBrush(x - yc, y - xc, brush, colour, thickness);

            while (yc > xc)
            {
                if (d < 0)
                {
                    d += dI;
                    dI += 2;
                    dD += 2;
                }
                else
                {
                    d += dD;
                    dI += 2;
                    dD += 4;
                    yc--;
                }
                xc++;

                ApplyBrush(x + xc, y + yc, brush, colour, thickness);
                ApplyBrush(x + xc, y - yc, brush, colour, thickness);
                ApplyBrush(x - xc, y + yc, brush, colour, thickness);
                ApplyBrush(x - xc, y - yc, brush, colour, thickness);
                ApplyBrush(x + yc, y + xc, brush, colour, thickness);
                ApplyBrush(x + yc, y - xc, brush, colour, thickness);
                ApplyBrush(x - yc, y + xc, brush, colour, thickness);
                ApplyBrush(x - yc, y - xc, brush, colour, thickness);
            }
        }
    }
}
