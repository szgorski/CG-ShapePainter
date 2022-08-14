using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapePainter
{
    public class Polygon : Shape
    {
        public List<Point> vertices;
        public uint[,] image;
        public int fillMode;

        public Polygon(Point newPoint, int newThickness, int fillMode = 0) : base(newThickness)
        {
            vertices = new List<Point>();
            vertices.Add(newPoint);

            this.fillMode = fillMode;
            if (fillMode == 2)
            {
                if (Variables.drawingImage is not null)
                    image = (uint[,])Variables.drawingImage.Clone();
                else
                    image = null;
            }
        }

        public void AddVertex(Point newPoint)
        {
            vertices.Add(newPoint);
        }

        public override unsafe void DrawShape()
        {
            if (Variables.isAntiAliased)
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.AntialiasedLine(vertices[i], vertices[i + 1], color, thickness);
            }
            else if (thickness == 1)
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.MidpointLine(vertices[i], vertices[i + 1], color);
            }
            else
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.BrushLine(vertices[i], vertices[i + 1], color, thickness);
            }

            if (Variables.isAntiAliased)
                ShapePainter.AntialiasedLine(vertices[vertices.Count() - 1], vertices[0], color, thickness);
            else if (thickness == 1)
                ShapePainter.MidpointLine(vertices[vertices.Count() - 1], vertices[0], color);
            else
                ShapePainter.BrushLine(vertices[vertices.Count() - 1], vertices[0], color, thickness);

            if (fillMode > 0)
            {
                ShapePainter.fillPolygon(this);
            }
        }

        public override unsafe void DrawActiveShape()
        {
            if (Variables.isAntiAliased)
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.AntialiasedLine(vertices[i], vertices[i + 1], color, thickness);
            }
            else if (thickness == 1)
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.MidpointLine(vertices[i], vertices[i + 1], color);
            }
            else
            {
                for (int i = 0; i < vertices.Count() - 1; i++)
                    ShapePainter.BrushLine(vertices[i], vertices[i + 1], color, thickness);
            }

            if (Variables.modeName == "radioButtonMovePoint"
                || Variables.modeName == "radioButtonMoveLine"
                || Variables.modeName == "radioButtonMovePolygon")
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(vertices[vertices.Count() - 1], vertices[0], color, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(vertices[vertices.Count() - 1], vertices[0], color);
                else
                    ShapePainter.BrushLine(vertices[vertices.Count() - 1], vertices[0], color, thickness);

                if (fillMode > 0)
                {
                    ShapePainter.fillPolygon(this);
                }
            }
            else
            {
                if (Variables.isAntiAliased)
                    ShapePainter.AntialiasedLine(vertices[vertices.Count() - 1], Variables.positionNow, color, thickness);
                else if (thickness == 1)
                    ShapePainter.MidpointLine(vertices[vertices.Count() - 1], Variables.positionNow, color);
                else
                    ShapePainter.BrushLine(vertices[vertices.Count() - 1], Variables.positionNow, color, thickness);

                ShapePainter.DrawPoint(vertices[0]);
            }
        }

        public override unsafe void DrawPoints()
        {
            for (int i = 0; i < vertices.Count(); i++)
            {
                ShapePainter.DrawPoint(vertices[i]);
            }
        }

        public override unsafe void UpdatePoint(Point point)
        {
            vertices[Variables.activeElement] = point;
        }

        public override unsafe (int, float) GetPointDistance(Point point)
        {
            int bestVertex = 0;
            float distance;
            float bestDistance = float.PositiveInfinity;
            for (int i = 0; i < vertices.Count; i++)
            {
                distance = ShapePainter.CalculatePointToPointDistance(point, vertices[i]);
                if (distance < bestDistance)
                {
                    bestVertex = i;
                    bestDistance = distance;
                }
            }
            return (bestVertex, bestDistance);
        }

        public override unsafe (int, float) GetLineDistance(Point point)
        {
            int bestVertex = 0;
            float distance;
            float bestDistance = float.PositiveInfinity;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                distance = ShapePainter.CalculatePointToSegmentDistance(point, vertices[i], vertices[i + 1], thickness);
                if (distance < bestDistance)
                {
                    bestVertex = i;
                    bestDistance = distance;
                }
            }

            distance = ShapePainter.CalculatePointToSegmentDistance(point, vertices[vertices.Count - 1], vertices[0], thickness);
            if (distance < bestDistance)
            {
                bestVertex = vertices.Count - 1;
                bestDistance = distance;
            }
            return (bestVertex, bestDistance);
        }

        public unsafe void MoveLine()
        {
            int xShift = Variables.positionNow.X - Variables.positionDown.X;
            int yShift = Variables.positionNow.Y - Variables.positionDown.Y;
            int indexA = Variables.activeElement;
            int indexB;
            if (indexA == vertices.Count() - 1)
                indexB = 0;
            else indexB = indexA + 1;

            bool caseA = false, caseB = false;
            if (vertices[indexA].X + xShift >= 0 && vertices[indexA].X + xShift < Variables.bitmapWidth
                && vertices[indexA].Y + yShift >= 0 && vertices[indexA].Y + yShift < Variables.bitmapHeight) caseA = true;
            if (vertices[indexB].X + xShift >= 0 && vertices[indexB].X + xShift < Variables.bitmapWidth
                && vertices[indexB].Y + yShift >= 0 && vertices[indexB].Y + yShift < Variables.bitmapHeight) caseB = true;
            if (caseA && caseB)
            {
                vertices[indexA] = new Point(vertices[indexA].X + xShift, vertices[indexA].Y + yShift);
                vertices[indexB] = new Point(vertices[indexB].X + xShift, vertices[indexB].Y + yShift);
                Variables.positionDown.X = Variables.positionNow.X;
                Variables.positionDown.Y = Variables.positionNow.Y;
            }
        }

        public unsafe void MoveShape()
        {
            int xShift = Variables.positionNow.X - Variables.positionDown.X;
            int yShift = Variables.positionNow.Y - Variables.positionDown.Y;
            bool cases = true;
            for (int i = 0; i < vertices.Count(); i++)
            {
                if (vertices[i].X + xShift < 0 || vertices[i].X + xShift >= Variables.bitmapWidth
                    || vertices[i].Y + yShift < 0 || vertices[i].Y + yShift >= Variables.bitmapHeight)
                {
                    cases = false;
                    break;
                }
            }
            if (cases)
            {
                for (int i = 0; i < vertices.Count(); i++)
                {
                    vertices[i] = new Point(vertices[i].X + xShift, vertices[i].Y + yShift);
                }
                Variables.positionDown.X = Variables.positionNow.X;
                Variables.positionDown.Y = Variables.positionNow.Y;
            }
        }
    }

    public partial class ShapePainter
    {
        public unsafe class AET
        {
            public int x;
            public int yMax;
            public float xFloat;
            public float mInverse;

            public AET(int x, int yMax, float mInverse)
            {
                this.x = x;
                this.xFloat = (float)x;
                this.yMax = yMax;
                this.mInverse = mInverse;
            }
        }

        public unsafe static void sortAET(ref List<AET> aet)
        {
            aet = aet.OrderBy(aet => aet.xFloat).ToList();
        }

        public unsafe static void cleanAET(ref List<AET> aet, int y)
        {
            for (int i = 0; i < aet.Count; i++)
            {
                if (aet[i].yMax == y)
                {
                    aet.RemoveAt(i);
                    i--;
                }
            }
        }

        public unsafe static void updateAET(ref List<AET> aet)
        {
            for (int i = 0; i < aet.Count; i++)
            {
                AET copy = aet[i];
                copy.xFloat += copy.mInverse;
                copy.x = FastRound(copy.xFloat);
                aet[i] = copy;
            }
        }

        public unsafe static Point calculateOrigin(Polygon polygon)
        {
            int xMin = int.MaxValue;
            int yMin = int.MaxValue;
            for (int i = 0; i < polygon.vertices.Count; i++)
            {
                if (polygon.vertices[i].X < xMin)
                    xMin = polygon.vertices[i].X;
                if (polygon.vertices[i].Y < yMin)
                    yMin = polygon.vertices[i].Y;
            }
            return new Point(xMin, yMin);
        }

        public unsafe static void fillLineWithImage(List<AET> aet, int y, Point origin, int xSize, int ySize, uint[,] image)
        {
            int yMod = (y - origin.Y) - ((y - origin.Y) / ySize) * ySize;
            int count = aet.Count;
            for (int i = 0; i <= count - 2; i += 2)
            {
                for (int j = aet[i].x; j <= aet[i + 1].x; j++)
                {
                    Variables.bitmapArray[j, y] = image[yMod, ((j - origin.X) - ((j - origin.X) / xSize) * xSize)];
                }
            }
        }

        public unsafe static void fillLineWithColor(List<AET> aet, int y, uint color)
        {
            int count = aet.Count;
            for (int i = 0; i <= count - 2; i += 2)
            {
                MidpointLine(new Point(aet[i].x, y), new Point(aet[i + 1].x, y), color);
            }
        }

        public unsafe static int[] getSortedVertices(Polygon polygon)
        {
            int[] vertices = new int[polygon.vertices.Count];
            List<Point> sortedPoints = polygon.vertices.OrderBy(vertices => vertices.Y).ToList();
            for (int i = 0; i < polygon.vertices.Count; i++)
            {
                vertices[i] = polygon.vertices.IndexOf(sortedPoints[i]);
            }
            return vertices;
        }

        public unsafe static void fillPolygon(Polygon polygon)
        {
            Point origin = calculateOrigin(polygon);
            List<AET> aet = new List<AET>();

            int[] vSorted = getSortedVertices(polygon);
            int y, yMin, yMax, i = 0;
            int vBefore, vAfter, vNumber = vSorted[i];
            y = yMin = polygon.vertices[vSorted[0]].Y;
            yMax = polygon.vertices[vSorted[vSorted.Length - 1]].Y;

            while (y < yMax)
            {
                while (polygon.vertices[vNumber].Y == y)
                {
                    if (vNumber == 0)
                        vBefore = polygon.vertices.Count - 1;
                    else
                        vBefore = vNumber - 1;

                    if (vNumber == polygon.vertices.Count - 1)
                        vAfter = 0;
                    else
                        vAfter = vNumber + 1;

                    if (polygon.vertices[vBefore].Y > polygon.vertices[vNumber].Y)
                    {
                        float inverse = (float)(polygon.vertices[vBefore].X - polygon.vertices[vNumber].X) /
                            (float)(polygon.vertices[vBefore].Y - polygon.vertices[vNumber].Y);
                        AET newAET = new AET(polygon.vertices[vNumber].X, polygon.vertices[vBefore].Y, inverse);
                        aet.Add(newAET);
                    }

                    if (polygon.vertices[vAfter].Y > polygon.vertices[vNumber].Y)
                    {
                        float inverse = (float)(polygon.vertices[vAfter].X - polygon.vertices[vNumber].X) /
                            (float)(polygon.vertices[vAfter].Y - polygon.vertices[vNumber].Y);
                        AET newAET = new AET(polygon.vertices[vNumber].X, polygon.vertices[vAfter].Y, inverse);
                        aet.Add(newAET);
                    }

                    i++;
                    vNumber = vSorted[i];
                }

                sortAET(ref aet);
                if (polygon.fillMode == 2 && polygon.image is not null)
                    fillLineWithImage(aet, y, origin, polygon.image.GetLength(1), polygon.image.GetLength(0), polygon.image);
                else
                    fillLineWithColor(aet, y, polygon.color);

                y++;
                cleanAET(ref aet, y);
                updateAET(ref aet);
            }
        }
    }
}
