using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public class ClippedPolygon : Shape
    {
        public Rectang rectangle;
        public Polygon polygon;
        public int activeMode;

        public ClippedPolygon(Point newPoint, int newThickness) : base(newThickness)
        {
            rectangle = new Rectang(newPoint, 1, 4278190335);
            activeMode = 1;
        }

        public unsafe (List<(Point, Point)>, List<(Point, Point)>) GetCSLines()
        {
            Point point1, point2;
            List<(Point, Point)> inside = new List<(Point, Point)>();
            List<(Point, Point)> outside = new List<(Point, Point)>();

            for (int i = 0; i < polygon.vertices.Count - 1; i++)
            {
                (point1, point2) = ShapePainter.DrawCohenSutherlandLine(polygon.vertices[i], polygon.vertices[i + 1], rectangle);
                if (point1.X == -1)
                    outside.Add((polygon.vertices[i], polygon.vertices[i + 1]));
                else
                {
                    if (!point1.Equals(polygon.vertices[i]))
                        outside.Add((polygon.vertices[i], point1));
                    if (!point2.Equals(polygon.vertices[i + 1]))
                        outside.Add((polygon.vertices[i + 1], point2));
                    inside.Add((point1, point2));
                }
            }

            (point1, point2) = ShapePainter.DrawCohenSutherlandLine(polygon.vertices[polygon.vertices.Count - 1],
                polygon.vertices[0], rectangle);
            if (point1.X == -1)
                outside.Add((polygon.vertices[polygon.vertices.Count - 1], polygon.vertices[0]));
            else
            {
                if (!point1.Equals(polygon.vertices[polygon.vertices.Count - 1]))
                    outside.Add((polygon.vertices[polygon.vertices.Count - 1], point1));
                if (!point2.Equals(polygon.vertices[0]))
                    outside.Add((polygon.vertices[0], point2));
                inside.Add((point1, point2));
            }

            return (inside, outside);
        }

        public override unsafe void DrawShape()
        {
            polygon.thickness = thickness;
            polygon.color = color;
            rectangle.DrawShape();

            List<(Point, Point)> inside;
            List<(Point, Point)> outside;
            (inside, outside) = GetCSLines();

            foreach ((Point point1, Point point2) in outside)
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(point1, point2, color, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(point1, point2, color);
                else
                    ShapePainter.BrushLine(point1, point2, color, thickness);
            }

            foreach ((Point point1, Point point2) in inside)
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(point1, point2, 4278190335, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(point1, point2, 4278190335);
                else
                    ShapePainter.BrushLine(point1, point2, 4278190335, thickness);  // blue
            }

        }

        public override unsafe void DrawActiveShape()
        {
            switch (activeMode)
            {
                case -2:
                case -1:
                case 0:
                    DrawShape();
                    break;
                case 1:
                    rectangle.DrawActiveShape();
                    break;
                case 2:
                    rectangle.DrawShape();
                    break;
                case 3:
                    rectangle.DrawShape();

                    polygon.color = color;
                    polygon.DrawActiveShape();
                    break;
            }
        }

        public override unsafe void DrawPoints()
        {
            rectangle.DrawPoints();
            polygon.DrawPoints();
        }

        public override unsafe void UpdatePoint(Point point)
        {
            if (Variables.activeElement < 0)
                rectangle.UpdatePoint(point);
            else
                polygon.UpdatePoint(point);
        }

        public override unsafe (int, float) GetPointDistance(Point point)
        {
            (int rIndex, float rDistance) = rectangle.GetPointDistance(point);
            (int pIndex, float pDistance) = polygon.GetPointDistance(point);
            if (rDistance < pDistance)
                return (-rIndex, rDistance);
            else
                return (pIndex, pDistance);
        }

        public override unsafe (int, float) GetLineDistance(Point point)
        {
            (int rIndex, float rDistance) = rectangle.GetLineDistance(point);
            (int pIndex, float pDistance) = polygon.GetLineDistance(point);
            if (rDistance < pDistance)
                return (-rIndex - 1, rDistance);
            else
                return (pIndex, pDistance);
        }

        public unsafe void MoveLine()
        {
            int index = Variables.activeElement;
            if (index < 0)
                rectangle.MoveLine();
            else
                polygon.MoveLine();
        }

        public unsafe void MoveShape()
        {
            if (activeMode == -1)
                rectangle.MoveShape();
            else if (activeMode == -2)
                polygon.MoveShape();
        }
    }
}
