using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public class Rectang : Shape
    {
        public Point end1;
        public Point end2;

        public Rectang(Point newEnd, int newThickness) : base(newThickness)
        {
            end1 = newEnd;
        }

        public Rectang(Point newEnd, int newThickness, uint newColor) : base(newThickness)
        {
            end1 = newEnd;
            color = newColor;
        }

        public override unsafe void DrawShape()
        {
            if (Variables.isAntiAliased)
            {
                ShapePainter.AntialiasedLine(end1, new Point(end1.X, end2.Y), color, thickness);
                ShapePainter.AntialiasedLine(end1, new Point(end2.X, end1.Y), color, thickness);
                ShapePainter.AntialiasedLine(end2, new Point(end1.X, end2.Y), color, thickness);
                ShapePainter.AntialiasedLine(end2, new Point(end2.X, end1.Y), color, thickness);
            }
            else if (thickness == 1)
            {
                ShapePainter.MidpointLine(end1, new Point(end1.X, end2.Y), color);
                ShapePainter.MidpointLine(end1, new Point(end2.X, end1.Y), color);
                ShapePainter.MidpointLine(end2, new Point(end1.X, end2.Y), color);
                ShapePainter.MidpointLine(end2, new Point(end2.X, end1.Y), color);
            }
            else
            {
                ShapePainter.BrushLine(end1, new Point(end1.X, end2.Y), color, thickness);
                ShapePainter.BrushLine(end1, new Point(end2.X, end1.Y), color, thickness);
                ShapePainter.BrushLine(end2, new Point(end1.X, end2.Y), color, thickness);
                ShapePainter.BrushLine(end2, new Point(end2.X, end1.Y), color, thickness);
            }
        }

        public override unsafe void DrawActiveShape()
        {
            if (Variables.modeName == "radioButtonMovePoint"
                || Variables.modeName == "radioButtonMoveLine"
                || Variables.modeName == "radioButtonMovePolygon")
            {
                DrawShape();
            }
            else
            {
                if (Variables.isAntiAliased)
                {
                    ShapePainter.AntialiasedLine(end1, new Point(end1.X, Variables.positionNow.Y), color, thickness);
                    ShapePainter.AntialiasedLine(end1, new Point(Variables.positionNow.X, end1.Y), color, thickness);
                    ShapePainter.AntialiasedLine(Variables.positionNow, new Point(end1.X, Variables.positionNow.Y), color, thickness);
                    ShapePainter.AntialiasedLine(Variables.positionNow, new Point(Variables.positionNow.X, end1.Y), color, thickness);
                }
                else if (thickness == 1)
                {
                    ShapePainter.MidpointLine(end1, new Point(end1.X, Variables.positionNow.Y), color);
                    ShapePainter.MidpointLine(end1, new Point(Variables.positionNow.X, end1.Y), color);
                    ShapePainter.MidpointLine(Variables.positionNow, new Point(end1.X, Variables.positionNow.Y), color);
                    ShapePainter.MidpointLine(Variables.positionNow, new Point(Variables.positionNow.X, end1.Y), color);
                }
                else
                {
                    ShapePainter.BrushLine(end1, new Point(end1.X, Variables.positionNow.Y), color, thickness);
                    ShapePainter.BrushLine(end1, new Point(Variables.positionNow.X, end1.Y), color, thickness);
                    ShapePainter.BrushLine(Variables.positionNow, new Point(end1.X, Variables.positionNow.Y), color, thickness);
                    ShapePainter.BrushLine(Variables.positionNow, new Point(Variables.positionNow.X, end1.Y), color, thickness);
                }
            }
        }

        public override unsafe void DrawPoints()
        {
            ShapePainter.DrawPoint(end1);
            ShapePainter.DrawPoint(end2);
        }

        public override unsafe void UpdatePoint(Point point)
        {
            if (Variables.activeElement == 1 || Variables.activeElement == -1)
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
            int bestVertex = 0;
            float distance, bestDistance = float.PositiveInfinity;

            distance = ShapePainter.CalculatePointToSegmentDistance(point, end1, new Point(end1.X, end2.Y), thickness);
            if (distance < bestDistance)
            {
                bestVertex = 0;
                bestDistance = distance;
            }
            distance = ShapePainter.CalculatePointToSegmentDistance(point, end2, new Point(end1.X, end2.Y), thickness);
            if (distance < bestDistance)
            {
                bestVertex = 1;
                bestDistance = distance;
            }
            distance = ShapePainter.CalculatePointToSegmentDistance(point, end2, new Point(end2.X, end1.Y), thickness);
            if (distance < bestDistance)
            {
                bestVertex = 2;
                bestDistance = distance;
            }
            distance = ShapePainter.CalculatePointToSegmentDistance(point, end1, new Point(end2.X, end1.Y), thickness);
            if (distance < bestDistance)
            {
                bestVertex = 3;
                bestDistance = distance;
            }

            return (bestVertex, bestDistance);
        }

        public unsafe void MoveLine()
        {
            int shift, index = Variables.activeElement;
            if (index < 0)
                index = -1 - index;
            if (index == 0 || index == 2)
                shift = Variables.positionNow.X - Variables.positionDown.X;
            else
                shift = Variables.positionNow.Y - Variables.positionDown.Y;

            bool cases = false;
            switch (index)
            {
                case 0:
                    if (end1.X + shift >= 0 && end1.X + shift < Variables.bitmapWidth) cases = true;
                    break;
                case 1:
                    if (end2.Y + shift >= 0 && end2.Y + shift < Variables.bitmapHeight) cases = true;
                    break;
                case 2:
                    if (end2.X + shift >= 0 && end2.X + shift < Variables.bitmapWidth) cases = true;
                    break;
                case 3:
                    if (end1.Y + shift >= 0 && end1.Y + shift < Variables.bitmapHeight) cases = true;
                    break;
            }

            if (cases)
            {
                switch (index)
                {
                    case 0:
                        end1 = new Point(end1.X + shift, end1.Y);
                        break;
                    case 1:
                        end2 = new Point(end2.X, end2.Y + shift);
                        break;
                    case 2:
                        end2 = new Point(end2.X + shift, end2.Y);
                        break;
                    case 3:
                        end1 = new Point(end1.X, end1.Y + shift);
                        break;
                }
                Variables.positionDown.X = Variables.positionNow.X;
                Variables.positionDown.Y = Variables.positionNow.Y;
            }
        }

        public unsafe void MoveShape()
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
}
