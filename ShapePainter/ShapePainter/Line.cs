using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public class Line : Shape
    {
        public Point end1;
        public Point end2;

        public Line(Point newEnd, int newThickness) : base(newThickness)
        {
            end1 = newEnd;
        }

        public override unsafe void DrawShape()
        {
            if (Variables.isAntiAliased)
                ShapePainter.AntialiasedLine(end1, end2, color, thickness);
            else if (thickness == 1)
                ShapePainter.MidpointLine(end1, end2, color);
            else
                ShapePainter.BrushLine(end1, end2, color, thickness);
        }

        public override unsafe void DrawActiveShape()
        {
            if (Variables.modeName == "radioButtonMovePoint"
                || Variables.modeName == "radioButtonMoveLine")
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(end1, end2, color, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(end1, end2, color);
                else
                    ShapePainter.BrushLine(end1, end2, color, thickness);
            }
            else
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(end1, Variables.positionNow, color, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(end1, Variables.positionNow, color);
                else
                    ShapePainter.BrushLine(end1, Variables.positionNow, color, thickness);
            }
        }

        public override unsafe void DrawPoints()
        {
            ShapePainter.DrawPoint(end1);
            ShapePainter.DrawPoint(end2);
        }

        public override unsafe void UpdatePoint(Point point)
        {
            if (Variables.activeElement == 1)
                end1 = point;
            else
                end2 = point;
        }

        public override unsafe (int, float) GetPointDistance(Point point)
        {
            float distance1 = ShapePainter.CalculatePointToPointDistance(point, end1);
            float distance2 = ShapePainter.CalculatePointToPointDistance(point, end2);
            if (distance1 < distance2)
                return (1, distance1);
            else
                return (2, distance2);
        }

        public override unsafe (int, float) GetLineDistance(Point point)
        {
            return (1, ShapePainter.CalculatePointToSegmentDistance(point, end1, end2, thickness));
        }

        public unsafe void MoveLine()
        {
            int xShift = Variables.positionNow.X - Variables.positionDown.X;
            int yShift = Variables.positionNow.Y - Variables.positionDown.Y;
            bool caseA = false, caseB = false;
            if (end1.X + xShift >= 0 && end1.X + xShift < Variables.bitmapWidth
                && end1.Y + yShift >= 0 && end1.Y + yShift < Variables.bitmapHeight) caseA = true;
            if (end2.X + xShift >= 0 && end2.X + xShift < Variables.bitmapWidth
                && end2.Y + yShift >= 0 && end2.Y + yShift < Variables.bitmapHeight) caseB = true;
            if (caseA && caseB)
            {
                end1.X += xShift;
                end1.Y += yShift;
                end2.X += xShift;
                end2.Y += yShift;
                Variables.positionDown.X = Variables.positionNow.X;
                Variables.positionDown.Y = Variables.positionNow.Y;
            }
        }
    }

    public partial class ShapePainter
    {
        public unsafe static void MidpointHorizontalLine(int x1, int y1, int x2, int y2, uint colour)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int ys = 1;
            if (dy < 0)
            {
                ys = -1;
                dy = -dy;
            }
            int d = 2 * dy - dx;
            int dI = 2 * dy;            // identity axis
            int dD = 2 * (dy - dx);     // diagonal axis
            int x = x1;
            int y = y1;
            Variables.bitmapArray[x, y] = colour;

            while (x < x2)
            {
                if (d < 0)
                {
                    d += dI;
                    x++;
                }
                else
                {
                    d += dD;
                    y += ys;
                    x++;
                }
                Variables.bitmapArray[x, y] = colour;
            }
        }

        public unsafe static void MidpointVerticalLine(int x1, int y1, int x2, int y2, uint colour)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int xs = 1;
            if (dx < 0)
            {
                xs = -1;
                dx = -dx;
            }
            int d = 2 * dx - dy;
            int dI = 2 * dx;            // identity axis
            int dD = 2 * (dx - dy);     // diagonal axis
            int x = x1;
            int y = y1;
            Variables.bitmapArray[x, y] = colour;

            while (y < y2)
            {
                if (d < 0)
                {
                    d += dI;
                    y++;
                }
                else
                {
                    d += dD;
                    x += xs;
                    y++;
                }
                Variables.bitmapArray[x, y] = colour;
            }
        }

        public unsafe static void MidpointLine(Point point1, Point point2, uint colour)
        {
            if (FastAbs(point2.X - point1.X) > FastAbs(point2.Y - point1.Y))
            {
                if (point2.X > point1.X)
                    MidpointHorizontalLine(point1.X, point1.Y, point2.X, point2.Y, colour);
                else
                    MidpointHorizontalLine(point2.X, point2.Y, point1.X, point1.Y, colour);
            }
            else
            {
                if (point2.Y > point1.Y)
                    MidpointVerticalLine(point1.X, point1.Y, point2.X, point2.Y, colour);
                else
                    MidpointVerticalLine(point2.X, point2.Y, point1.X, point1.Y, colour);
            }
        }

        public unsafe static void BrushHorizontalLine(int x1, int y1, int x2, int y2, uint colour, int thickness)
        {
            bool[,] brush = CreateBrush(thickness);
            int dx = x2 - x1;
            int dy = y2 - y1;
            int ys = 1;
            if (dy < 0)
            {
                ys = -1;
                dy = -dy;
            }
            int d = 2 * dy - dx;
            int dI = 2 * dy;            // identity axis
            int dD = 2 * (dy - dx);     // diagonal axis
            int x = x1;
            int y = y1;
            ApplyBrush(x, y, brush, colour, thickness);
            while (x < x2)
            {
                if (d < 0)
                {
                    d += dI;
                    x++;
                }
                else
                {
                    d += dD;
                    y += ys;
                    x++;
                }
                ApplyBrush(x, y, brush, colour, thickness);
            }
        }

        public unsafe static void BrushVerticalLine(int x1, int y1, int x2, int y2, uint colour, int thickness)
        {
            bool[,] brush = CreateBrush(thickness);
            int dx = x2 - x1;
            int dy = y2 - y1;
            int xs = 1;
            if (dx < 0)
            {
                xs = -1;
                dx = -dx;
            }
            int d = 2 * dx - dy;
            int dI = 2 * dx;            // identity axis
            int dD = 2 * (dx - dy);     // diagonal axis
            int x = x1;
            int y = y1;
            ApplyBrush(x, y, brush, colour, thickness);
            while (y < y2)
            {
                if (d < 0)
                {
                    d += dI;
                    y++;
                }
                else
                {
                    d += dD;
                    x += xs;
                    y++;
                }
                ApplyBrush(x, y, brush, colour, thickness);
            }
        }

        public unsafe static void BrushLine(Point point1, Point point2, uint colour, int thickness)
        {
            if (FastAbs(point2.X - point1.X) > FastAbs(point2.Y - point1.Y))
            {
                if (point2.X > point1.X)
                    BrushHorizontalLine(point1.X, point1.Y, point2.X, point2.Y, colour, thickness);
                else
                    BrushHorizontalLine(point2.X, point2.Y, point1.X, point1.Y, colour, thickness);
            }
            else
            {
                if (point2.Y > point1.Y)
                    BrushVerticalLine(point1.X, point1.Y, point2.X, point2.Y, colour, thickness);
                else
                    BrushVerticalLine(point2.X, point2.Y, point1.X, point1.Y, colour, thickness);
            }
        }

        public unsafe static uint InterpolateColour(uint backColour, uint frontColour, float coverage)
        {   // assuming coverage belongs to [0, 1]
            uint backA = (backColour >> 24);
            uint backR = (backColour >> 16) - ((backColour >> 24) << 8);
            uint backG = (backColour >> 8) - ((backColour >> 16) << 8);
            uint backB = backColour - ((backColour >> 8) << 8);

            uint frontA = (frontColour >> 24);
            uint frontR = (frontColour >> 16) - ((frontColour >> 24) << 8);
            uint frontG = (frontColour >> 8) - ((frontColour >> 16) << 8);
            uint frontB = frontColour - ((frontColour >> 8) << 8);

            uint A = (uint)(coverage * frontA + (1 - coverage) * backA);
            uint R = (uint)(coverage * frontR + (1 - coverage) * backR);
            uint G = (uint)(coverage * frontG + (1 - coverage) * backG);
            uint B = (uint)(coverage * frontB + (1 - coverage) * backB);

            return (A << 24) + (R << 16) + (G << 8) + B;
        }

        public unsafe static float CoverageFunction(float distance)
        {
            if (distance < 0.5)
            {   // assuming radius is always 0.5
                float coverage = 0.31830988f * (float)Math.Acos(distance * 2f) - distance * 1.27323954f
                    * (float)Math.Sqrt(0.25f - distance * distance);

                if (coverage > 1f)
                    return 1f;
                else if (coverage < 0f)
                    return 0f;
                else
                    return coverage;
            }
            else
                return 0f;
        }

        public unsafe static float CalculateLineCoverage(int thickness, float distance)
        {   // assuming all lines are at least one pixel thick
            if (0.5f * thickness < distance)
                return CoverageFunction(distance - 0.5f * thickness);
            else
                return 1f - CoverageFunction(0.5f * thickness - distance);

        }

        public unsafe static float AddPixelIntensity(int x, int y, uint colour, int thickness, float distance)
        {
            float coverage = CalculateLineCoverage(thickness, distance);
            if (coverage > 0)
                Variables.bitmapArray[x, y] = InterpolateColour(Variables.bitmapArray[x, y], colour, coverage);

            return coverage;
        }

        public unsafe static void AntialiasedHorizontalLine(int x1, int y1, int x2, int y2, uint colour, int thickness)
        {
            int radius = thickness / 2;
            int dx = x2 - x1;
            int dy = y2 - y1;
            int xs = 1;
            int ys = 1;
            if (dy < 0)
            {
                ys = -1;
                dy = -dy;
            }
            if (dx < 0)
                xs = -1;
            int d = 2 * dy - dx;
            int dI = 2 * dy;
            int dD = 2 * (dy - dx);
            int two_v_dx;                                               // numerator
            float invDenominator = 1f / (2f * (float)Math.Sqrt(dx * dx + dy * dy));
                                                                        // inverted denominator
            if (invDenominator < float.PositiveInfinity)
            {
                float two_dx_invDenominator = 2 * dx * invDenominator;
                int x = x1;
                int y = y1;
                AddPixelIntensity(x, y, colour, thickness, 0);
                for (int i = 1; y + i < Variables.bitmapHeight &&
                    AddPixelIntensity(x, y + i, colour, thickness, i * two_dx_invDenominator) > 0; ++i) ;
                for (int i = 1; y - i >= 0 &&
                    AddPixelIntensity(x, y - i, colour, thickness, i * two_dx_invDenominator) > 0; ++i) ;
                if (xs != ys)
                {
                    while (x < x2)
                    {
                        x++;
                        if (d < 0)
                        {
                            two_v_dx = d + dx;
                            d += dI;
                        }
                        else
                        {
                            two_v_dx = d - dx;
                            d += dD;
                            y += ys;
                        }
                        AddPixelIntensity(x, y, colour, thickness, two_v_dx * invDenominator);
                        for (int i = 1; y + i < Variables.bitmapHeight && AddPixelIntensity(x, y + i, colour, thickness,
                            i * two_dx_invDenominator + two_v_dx * invDenominator) > 0; ++i) ;
                        for (int i = 1; y - i >= 0 && AddPixelIntensity(x, y - i, colour, thickness,
                            i * two_dx_invDenominator - two_v_dx * invDenominator) > 0; ++i) ;
                    }
                }
                else
                {
                    while (x < x2)
                    {
                        x++;
                        if (d < 0)
                        {
                            two_v_dx = d + dx;
                            d += dI;
                        }
                        else
                        {
                            two_v_dx = d - dx;
                            d += dD;
                            y += ys;
                        }
                        AddPixelIntensity(x, y, colour, thickness, two_v_dx * invDenominator);
                        for (int i = 1; y + i < Variables.bitmapHeight && AddPixelIntensity(x, y + i, colour, thickness,
                            i * two_dx_invDenominator - two_v_dx * invDenominator) > 0; ++i) ;
                        for (int i = 1; y - i >= 0 && AddPixelIntensity(x, y - i, colour, thickness,
                            i * two_dx_invDenominator + two_v_dx * invDenominator) > 0; ++i) ;
                    }
                }

            }
        }

        public unsafe static void AntialiasedVerticalLine(int x1, int y1, int x2, int y2, uint colour, int thickness)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int xs = 1;
            int ys = 1;
            if (dx < 0)
            {
                xs = -1;
                dx = -dx;
            }
            if (dy < 0)
                ys = -1;
            int d = 2 * dx - dy;
            int dI = 2 * dx;
            int dD = 2 * (dx - dy);
            int two_v_dy;                                               // numerator
            float invDenominator = 1f / (2f * (float)Math.Sqrt(dx * dx + dy * dy));
                                                                        // inverted denominator
            if (invDenominator < float.PositiveInfinity)
            {
                float two_dy_invDenominator = 2 * dy * invDenominator;
                int x = x1;
                int y = y1;
                AddPixelIntensity(x, y, colour, thickness, 0);
                for (int i = 1; x + i < Variables.bitmapWidth &&
                    AddPixelIntensity(x + i, y, colour, thickness, i * two_dy_invDenominator) > 0; ++i) ;
                for (int i = 1; x - i >= 0 &&
                    AddPixelIntensity(x - i, y, colour, thickness, i * two_dy_invDenominator) > 0; ++i) ;
                if (xs != ys)
                {
                    while (y < y2)
                    {
                        y++;
                        if (d < 0)
                        {
                            two_v_dy = d + dy;
                            d += dI;
                        }
                        else
                        {
                            two_v_dy = d - dy;
                            d += dD;
                            x += xs;
                        }
                        AddPixelIntensity(x, y, colour, thickness, two_v_dy * invDenominator);
                        for (int i = 1; x + i < Variables.bitmapWidth && AddPixelIntensity(x + i, y, colour, thickness,
                            i * two_dy_invDenominator + two_v_dy * invDenominator) > 0; ++i) ;
                        for (int i = 1; x - i >= 0 && AddPixelIntensity(x - i, y, colour, thickness,
                            i * two_dy_invDenominator - two_v_dy * invDenominator) > 0; ++i) ;
                    }
                }
                else
                {
                    while (y < y2)
                    {
                        y++;
                        if (d < 0)
                        {
                            two_v_dy = d + dy;
                            d += dI;
                        }
                        else
                        {
                            two_v_dy = d - dy;
                            d += dD;
                            x += xs;
                        }
                        AddPixelIntensity(x, y, colour, thickness, two_v_dy * invDenominator);
                        for (int i = 1; x + i < Variables.bitmapWidth && AddPixelIntensity(x + i, y, colour, thickness,
                            i * two_dy_invDenominator - two_v_dy * invDenominator) > 0; ++i) ;
                        for (int i = 1; x - i >= 0 && AddPixelIntensity(x - i, y, colour, thickness,
                            i * two_dy_invDenominator + two_v_dy * invDenominator) > 0; ++i) ;
                    }
                }
            }
        }

        public unsafe static void AntialiasedLine(Point point1, Point point2, uint colour, int thickness)
        {
            if (FastAbs(point2.X - point1.X) > FastAbs(point2.Y - point1.Y))
            {
                if (point2.X > point1.X)
                    AntialiasedHorizontalLine(point1.X, point1.Y, point2.X, point2.Y, colour, thickness);
                else
                    AntialiasedHorizontalLine(point2.X, point2.Y, point1.X, point1.Y, colour, thickness);
            }
            else
            {
                if (point2.Y > point1.Y)
                    AntialiasedVerticalLine(point1.X, point1.Y, point2.X, point2.Y, colour, thickness);
                else
                    AntialiasedVerticalLine(point2.X, point2.Y, point1.X, point1.Y, colour, thickness);
            }
        }
    }
}
