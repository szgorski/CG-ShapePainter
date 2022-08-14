using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ShapePainter
{
    public partial class ShapePainter : Form
    {
        public ShapePainter()
        {
            InitializeComponent();
            InitializeBitmap();
        }

        public void InitializeBitmap()
        {
            Bitmap bmp = new Bitmap(Variables.bitmapWidth, Variables.bitmapHeight, PixelFormat.Format32bppArgb);
            BitmapData bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, bmp.PixelFormat);
            unsafe
            {
                for (int i = 0; i < Variables.bitmapHeight; i++)
                {
                    int* row = (int*)((byte*)bits.Scan0 + (i * bits.Stride));

                    for (int j = 0; j < Variables.bitmapWidth; j++)
                    {
                        row[j] = -1;
                        Variables.bitmapArray[j, i] = 4294967295;   // white
                    }
                }
            }
            bmp.UnlockBits(bits);
            Variables.bitmap = bmp;
            pictureBoxMain.Image = Variables.bitmap;
        }

        public void UpdateBitmap()
        {
            Variables.bitmap.Dispose();
            Bitmap bmp = new Bitmap(Variables.bitmapWidth, Variables.bitmapHeight, PixelFormat.Format32bppArgb);
            BitmapData bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadWrite, bmp.PixelFormat);
            unsafe
            {
                for (int i = 0; i < Variables.bitmapHeight; i++)
                {
                    for (int j = 0; j < Variables.bitmapWidth; j++)
                    {
                        Variables.bitmapArray[j, i] = 4294967295;   // white
                    }
                }

                for (int i = 0; i < Variables.shapes.Count; i++)
                {
                    Variables.shapes[i].DrawShape();
                }
                if (Variables.modeName == "radioButtonMovePoint")
                {
                    for (int i = 0; i < Variables.shapes.Count; i++)
                    {
                        Variables.shapes[i].DrawPoints();
                    }
                }
                if (Variables.isActive)
                {
                    Variables.activeShape.DrawActiveShape();
                }

                for (int i = 0; i < Variables.bitmapHeight; i++)
                {
                    uint* row = (uint*)((byte*)bits.Scan0 + (i * bits.Stride));

                    for (int j = 0; j < Variables.bitmapWidth; j++)
                        row[j] = Variables.bitmapArray[j, i];
                }
            }
            bmp.UnlockBits(bits);
            Variables.bitmap = bmp;
            pictureBoxMain.Image = Variables.bitmap;
        }

        public Bitmap generateImage(uint[,] image)
        {
            if (image is not null)
            {
                Bitmap bmp = new Bitmap(image.GetLength(1), image.GetLength(0));
                BitmapData bits = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
                    ImageLockMode.ReadWrite, bmp.PixelFormat);

                unsafe
                {
                    for (int i = 0; i < image.GetLength(0); i++)
                    {
                        uint* row = (uint*)((byte*)bits.Scan0 + (i * bits.Stride));
                        for (int j = 0; j < image.GetLength(1); j++)
                        {
                            row[j] = image[i, j];
                        }
                    }
                }

                bmp.UnlockBits(bits);
                return bmp;
            }
            else
                return null;
        }

        private int getPolygonMode()
        {
            if (radioButtonPolygonEmpty.Checked == true)
                return 0;
            else if (radioButtonPolygonColour.Checked == true)
                return 1;
            else
                return 2;
        }

        private int getObjectMode()
        {
            if (radioButtonObjectEmpty.Checked == true)
                return 0;
            else if (radioButtonObjectColour.Checked == true)
                return 1;
            else
                return 2;
        }

        private void disableObjectSettings()
        {
            numericUpDownObjectThickness.Enabled = false;
            buttonObjectColor.Enabled = false;
            buttonObjectImage.Enabled = false;
            buttonSaveObject.Enabled = false;
            labelObjectColor.BackColor = Color.Silver;

            radioButtonObjectEmpty.Checked = false;
            radioButtonObjectColour.Checked = false;
            radioButtonObjectImage.Checked = false;

            radioButtonObjectEmpty.Enabled = false;
            radioButtonObjectColour.Enabled = false;
            radioButtonObjectImage.Enabled = false;
            pictureBoxObjectImage.Image = null;
        }

        private void enableObjectSettings(Shape shape)
        {
            numericUpDownObjectThickness.Value = shape.thickness;
            labelObjectColor.BackColor = Color.FromArgb((int)shape.color);

            numericUpDownObjectThickness.Enabled = true;
            buttonObjectColor.Enabled = true;
            buttonSaveObject.Enabled = true;

            if (shape is Polygon)
            {
                radioButtonObjectColour.Enabled = true;
                radioButtonObjectEmpty.Enabled = true;
                radioButtonObjectImage.Enabled = true;

                if (((Polygon)shape).fillMode == 0)
                    radioButtonObjectEmpty.Checked = true;
                else if (((Polygon)shape).fillMode == 1)
                    radioButtonObjectColour.Checked = true;
                else
                    radioButtonObjectImage.Checked = true;

                buttonObjectImage.Enabled = true;
                pictureBoxObjectImage.Image = generateImage(((Polygon)shape).image);
                if (((Polygon)shape).image is not null)
                    Variables.objectImage = (uint[,])((Polygon)shape).image.Clone();
                else
                    Variables.objectImage = null;
            }
            else
            {
                buttonObjectImage.Enabled = false;
                radioButtonObjectEmpty.Checked = false;
                radioButtonObjectColour.Checked = false;
                radioButtonObjectImage.Checked = false;

                radioButtonObjectEmpty.Enabled = false;
                radioButtonObjectColour.Enabled = false;
                radioButtonObjectImage.Enabled = false;
                pictureBoxObjectImage.Image = null;
            }
        }


        private void numericUpDownLineThickness_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownLineThickness.Value % 2 == 0)
                numericUpDownLineThickness.Value -= 1;
        }

        private void numericUpDownObjectThickness_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownObjectThickness.Value % 2 == 0)
                numericUpDownObjectThickness.Value -= 1;
        }

        private void checkBoxAntiAliasing_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAntiAliasing.Checked) 
                Variables.isAntiAliased = true;
            else
                Variables.isAntiAliased = false;
            UpdateBitmap();
        }

        private void buttonBrushColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                labelBrushColor.BackColor = colorDialog.Color;
                Variables.brushColor = ((uint)colorDialog.Color.A << 24) + ((uint)colorDialog.Color.R << 16) 
                                     + ((uint)colorDialog.Color.G << 8) + (uint)colorDialog.Color.B;
            }
        }

        private void buttonObjectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
                labelObjectColor.BackColor = colorDialog.Color;
        }

        private void buttonSaveObject_Click(object sender, EventArgs e)
        {
            Shape shape = Variables.shapes.Find(x => x.ID == Variables.activeElement);
            shape.thickness = (int)numericUpDownObjectThickness.Value;
            shape.color = ((uint)labelObjectColor.BackColor.A << 24) + ((uint)labelObjectColor.BackColor.R << 16)
                        + ((uint)labelObjectColor.BackColor.G << 8) + (uint)labelObjectColor.BackColor.B;
            if (shape is Polygon)
            {
                ((Polygon)shape).fillMode = getObjectMode();
                if (Variables.objectImage is not null)
                    ((Polygon)shape).image = (uint[,])Variables.objectImage.Clone();
                else
                    ((Polygon)shape).image = null;
            }
            UpdateBitmap();
        }

        private void buttonClearAll_Click(object sender, EventArgs e)
        {
            Variables.shapes.Clear();
            Variables.isActive = false;
            Variables.lastID = 0;
            Variables.bitmap.Dispose();
            InitializeBitmap();
        }

        private void pictureBoxMain_MouseClick(object sender, MouseEventArgs e)
        {
            switch (Variables.modeName)
            {
                case "radioButtonAddLine":
                    if (Variables.isActive)
                    {
                        ((Line)Variables.activeShape).end2 = e.Location;
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                    }
                    else
                    {
                        Variables.activeShape = new Line(e.Location,
                            (int)numericUpDownLineThickness.Value);
                        Variables.isActive = true;
                    }
                    break;

                case "radioButtonAddCircle":
                    if (Variables.isActive)
                    {
                        ((Circle)Variables.activeShape).radius =
                            ((Circle)Variables.activeShape).CalculateRadius(e.Location);
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                    }
                    else
                    {
                        Variables.activeShape = new Circle(e.Location, (int)numericUpDownLineThickness.Value);
                        Variables.isActive = true;
                    }
                    break;

                case "radioButtonAddRectangle":
                    if (Variables.isActive)
                    {
                        ((Rectang)Variables.activeShape).end2 = e.Location;
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                    }
                    else
                    {
                        Variables.activeShape = new Rectang(e.Location,
                            (int)numericUpDownLineThickness.Value);
                        Variables.isActive = true;
                    }
                    break;

                case "radioButtonAddPolygon":
                    if (Variables.isActive)
                    {
                        if (CalculatePointToPointDistance(((Polygon)Variables.activeShape).vertices[0], e.Location) <= 5)
                        {
                            Variables.shapes.Add(Variables.activeShape);
                            Variables.isActive = false;
                            UpdateBitmap();
                        }
                        else
                            ((Polygon)Variables.activeShape).AddVertex(e.Location);
                    }
                    else
                    {
                        Variables.activeShape = new Polygon(e.Location, (int)numericUpDownLineThickness.Value, getPolygonMode());
                        Variables.isActive = true;
                    }
                    break;

                case "radioButtonBrush":
                    (int brushShapeID, int _ ) = GetClosestLine(e.Location);
                    Shape brushShape = Variables.shapes.Find(x => x.ID == brushShapeID);
                    if (brushShape is not null)
                    {
                        if (brushShape is ClippedPolygon)
                        {
                            (int _, float distance) = ((ClippedPolygon)brushShape).polygon.GetLineDistance(e.Location);
                            if (distance <= 5)
                            {
                                ((ClippedPolygon)brushShape).color = Variables.brushColor;
                                UpdateBitmap();
                            }
                        }
                        else
                        {
                            brushShape.color = Variables.brushColor;
                            UpdateBitmap();
                        }
                        
                    }
                    break;

                case "radioButtonErase":
                    (int eraseShapeID, _ ) = GetClosestLine(e.Location);
                    Shape eraseShape = Variables.shapes.Find(x => x.ID == eraseShapeID);
                    if (eraseShape is not null)
                    {
                        Variables.shapes.Remove(eraseShape);
                        UpdateBitmap();
                    }
                    break;

                case "radioButtonSelectObject":
                    (int changeShapeID, _ ) = GetClosestLine(e.Location);
                    Shape changeShape = Variables.shapes.Find(x => x.ID == changeShapeID);
                    if (changeShape is not null)
                    {
                        enableObjectSettings(changeShape);
                        Variables.activeElement = changeShapeID;
                    }
                    else
                    {
                        disableObjectSettings();
                        Variables.activeElement = 0;
                    }
                    break;

                case "radioButtonAddClipping":
                    if (Variables.isActive)
                    {
                        if (((ClippedPolygon)Variables.activeShape).activeMode == 1)
                        {
                            ((ClippedPolygon)Variables.activeShape).rectangle.end2 = e.Location;
                            ((ClippedPolygon)Variables.activeShape).activeMode = 2;
                        }
                        else if (((ClippedPolygon)Variables.activeShape).activeMode == 2)
                        {
                            ((ClippedPolygon)Variables.activeShape).polygon = 
                                new Polygon(e.Location, ((ClippedPolygon)Variables.activeShape).thickness, 0);
                            ((ClippedPolygon)Variables.activeShape).activeMode = 3;
                        }
                        else if (((ClippedPolygon)Variables.activeShape).activeMode == 3)
                        {
                            if (CalculatePointToPointDistance(((ClippedPolygon)Variables.activeShape).polygon.vertices[0], e.Location) <= 5)
                            {
                                ((ClippedPolygon)Variables.activeShape).activeMode = 0;
                                Variables.shapes.Add(Variables.activeShape);
                                Variables.isActive = false;
                                UpdateBitmap();
                            }
                            else
                                ((ClippedPolygon)Variables.activeShape).polygon.AddVertex(e.Location);
                        }
                    }
                    else
                    {
                        Variables.activeShape = new ClippedPolygon(e.Location, (int)numericUpDownLineThickness.Value);
                        Variables.isActive = true;
                    }
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            int index, shapeID;
            Shape shape;
            Variables.positionDown = CleanLocation(e.Location);
            switch (Variables.modeName)
            {
                case "radioButtonResizeCircle":
                    (shapeID, index) = GetClosestLine(e.Location);
                    shape = Variables.shapes.Find(x => x.ID == shapeID);
                    if (shape is not null && shape is Circle)
                    {
                        Variables.activeShape = shape;
                        Variables.shapes.Remove(shape);
                        Variables.isActive = true;
                        UpdateBitmap();
                    }
                    break;

                case "radioButtonMovePoint":
                    (shapeID, index) = GetClosestPoint(e.Location);
                    shape = Variables.shapes.Find(x => x.ID == shapeID);
                    if (shape is not null)
                    {
                        Variables.activeElement = index;
                        Variables.activeShape = shape;
                        Variables.shapes.Remove(shape);
                        Variables.isActive = true;
                        UpdateBitmap();
                    }
                    break;

                case "radioButtonMovePolygon":
                    (shapeID, index) = GetClosestLine(e.Location);
                    shape = Variables.shapes.Find(x => x.ID == shapeID);
                    if (shape is not null)
                    {
                        if (shape is Polygon or Rectang)
                        {
                            Variables.activeShape = shape;
                            Variables.shapes.Remove(shape);
                            Variables.isActive = true;
                            UpdateBitmap();
                        }
                        else if (shape is ClippedPolygon)
                        {
                            if (index < 0)
                                ((ClippedPolygon)Variables.activeShape).activeMode = -1;
                            else
                                ((ClippedPolygon)Variables.activeShape).activeMode = -2;
                            Variables.activeShape = shape;
                            Variables.shapes.Remove(shape);
                            Variables.isActive = true;
                            UpdateBitmap();
                        }
                    }
                    break;

                case "radioButtonMoveLine":
                    (shapeID, index) = GetClosestLine(e.Location);
                    shape = Variables.shapes.Find(x => x.ID == shapeID);
                    if (shape is not null)
                    {
                        if (shape is Line)
                        {
                            Variables.activeShape = shape;
                            Variables.shapes.Remove(shape);
                            Variables.isActive = true;
                            UpdateBitmap();
                        }
                        else if (shape is Polygon or Rectang or ClippedPolygon)
                        {
                            Variables.activeShape = shape;
                            Variables.activeElement = index;
                            Variables.shapes.Remove(shape);
                            Variables.isActive = true;
                            UpdateBitmap();
                        }
                    }
                    break;

                default:
                    break;
            }
        }

        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (Variables.isActive)
            {
                Variables.positionNow = CleanLocation(e.Location);
                switch (Variables.modeName)
                {
                    case "radioButtonAddLine":
                    case "radioButtonAddCircle":
                    case "radioButtonAddRectangle":
                    case "radioButtonAddPolygon":
                    case "radioButtonAddClipping":
                    case "radioButtonResizeCircle":
                        UpdateBitmap();
                        break;

                    case "radioButtonMovePoint":
                        Variables.activeShape.UpdatePoint(Variables.positionNow);
                        UpdateBitmap();
                        break;

                    case "radioButtonMovePolygon":
                        if (Variables.activeShape is ClippedPolygon)
                            ((ClippedPolygon)Variables.activeShape).MoveShape();
                        else if (Variables.activeShape is Polygon)
                            ((Polygon)Variables.activeShape).MoveShape();
                        else if (Variables.activeShape is Rectang)  // double-check
                            ((Rectang)Variables.activeShape).MoveShape();
                        UpdateBitmap();
                        break;

                    case "radioButtonMoveLine":
                        if (Variables.activeShape is ClippedPolygon)
                            ((ClippedPolygon)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Polygon)
                            ((Polygon)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Rectang)
                            ((Rectang)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Line)       // double-check
                            ((Line)Variables.activeShape).MoveLine();
                        UpdateBitmap();
                        break;

                    default:
                        break;
                }
            }
        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (Variables.isActive)
            {
                Point position = CleanLocation(e.Location);
                switch (Variables.modeName)
                {
                    case "radioButtonResizeCircle":
                        ((Circle)Variables.activeShape).radius =
                            ((Circle)Variables.activeShape).CalculateRadius(position);
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    case "radioButtonMovePoint":
                        Variables.activeShape.UpdatePoint(position);
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    case "radioButtonMovePolygon":
                        if (Variables.activeShape is ClippedPolygon)
                        {
                            ((ClippedPolygon)Variables.activeShape).MoveShape();
                            ((ClippedPolygon)Variables.activeShape).activeMode = 0;
                        }
                        else if (Variables.activeShape is Polygon)
                            ((Polygon)Variables.activeShape).MoveShape();
                        else if (Variables.activeShape is Rectang)
                            ((Rectang)Variables.activeShape).MoveShape();

                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    case "radioButtonMoveLine":
                        if (Variables.activeShape is ClippedPolygon)
                            ((ClippedPolygon)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Polygon)
                            ((Polygon)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Rectang)
                            ((Rectang)Variables.activeShape).MoveLine();
                        else if (Variables.activeShape is Line)
                            ((Line)Variables.activeShape).MoveLine();

                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    default:
                        break;
                }
            }
        }

        private void pictureBoxMain_MouseLeave(object sender, EventArgs e)
        {
            if (Variables.isActive)
            {
                switch (Variables.modeName)
                {
                    case "radioButtonResizeCircle":
                    case "radioButtonMovePoint":
                    case "radioButtonMoveLine":
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    case "radioButtonMovePolygon":
                        if (Variables.activeShape is ClippedPolygon)
                            ((ClippedPolygon)Variables.activeShape).activeMode = 0;
                        Variables.shapes.Add(Variables.activeShape);
                        Variables.isActive = false;
                        UpdateBitmap();
                        break;

                    default:
                        break;
                }
            }
        }

        private void mode_CheckedChanged(object sender, EventArgs e)
        {
            Variables.modeName = ((RadioButton)sender).Name;
            Variables.isActive = false;
            disableObjectSettings();
            UpdateBitmap();
        }

        private void buttonObjectImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(Image.FromFile(openFileDialog.FileName));
                Variables.objectImage = new uint[img.Height, img.Width];

                BitmapData bits = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                    ImageLockMode.ReadOnly, img.PixelFormat);

                unsafe
                {
                    uint conv; // this method allows to work with both RGB and ARGB files
                               // however, the alpha layer is not modified by the program
                    for (int i = 0; i < img.Height; i++)
                    {
                        uint* row = (uint*)((byte*)bits.Scan0 + (i * bits.Stride));
                        for (int j = 0; j < img.Width; j++)
                        {
                            conv = row[j];
                            Variables.objectImage[i, j] = conv;
                        }
                    }
                }

                img.UnlockBits(bits);

                pictureBoxObjectImage.Image = generateImage(Variables.objectImage);
                img.Dispose();
            }
        }

        private void buttonPolygonImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap img = new Bitmap(Image.FromFile(openFileDialog.FileName));
                Variables.drawingImage = new uint[img.Height, img.Width];

                BitmapData bits = img.LockBits(new Rectangle(0, 0, img.Width, img.Height),
                    ImageLockMode.ReadOnly, img.PixelFormat);

                unsafe
                {
                    uint conv; // this method allows to work with both RGB and ARGB files
                               // however, the alpha layer is not modified by the program
                    for (int i = 0; i < img.Height; i++)
                    {
                        uint* row = (uint*)((byte*)bits.Scan0 + (i * bits.Stride));
                        for (int j = 0; j < img.Width; j++)
                        {
                            conv = row[j];
                            Variables.drawingImage[i, j] = conv;
                        }
                    }
                }

                img.UnlockBits(bits);

                pictureBoxPolygonImage.Image = generateImage(Variables.drawingImage);
                img.Dispose();
            }
        }
    }

    public abstract class Shape
    {
        public int ID;
        public uint color;
        public int thickness;

        public Shape(int newThickness)
        {
            ID = Variables.lastID + 1;
            Variables.lastID = ID;
            color = Variables.brushColor;
            thickness = newThickness;
        }

        public Shape Clone()
        {
            return (Shape)this.MemberwiseClone();
        }

        public abstract unsafe void DrawShape();
        public abstract unsafe void DrawActiveShape();

        public abstract unsafe void DrawPoints();
        public abstract unsafe void UpdatePoint(Point point);

        public abstract unsafe (int, float) GetPointDistance(Point point);
        public abstract unsafe (int, float) GetLineDistance(Point point);
    }

    public unsafe static class Variables
    {
        public unsafe static Bitmap bitmap;
        public unsafe static Point positionDown;
        public unsafe static Point positionNow;
        public unsafe static uint brushColor = 4278190080;  // black
        public unsafe static string modeName = "radioButtonAddLine";
        public unsafe static string modePolygon = "Empty";
        public unsafe static string modeobject;
        public unsafe static bool isAntiAliased = false;
        public unsafe static bool isActive = false;
        public unsafe static int lastID = 0;

        public unsafe static List<Shape> shapes = new List<Shape>();
        public unsafe static Shape activeShape;
        public unsafe static int activeElement;

        public unsafe static int bitmapHeight = 800;
        public unsafe static int bitmapWidth = 600;
        public unsafe static uint[,] bitmapArray = new uint[bitmapWidth, bitmapHeight];
        public unsafe static uint[,] drawingImage;
        public unsafe static uint[,] objectImage;
        public unsafe static bool[,] pointsKernel = new bool[9, 9]
         {
            { false, false, true, true, true, true, true, false, false },
            { false, true, true, true, true, true, true, true, false },
            { true, true, true, true, true, true, true, true, true },
            { true, true, true, true, true, true, true, true, true },
            { true, true, true, true, true, true, true, true, true },
            { true, true, true, true, true, true, true, true, true },
            { true, true, true, true, true, true, true, true, true },
            { false, true, true, true, true, true, true, true, false },
            { false, false, true, true, true, true, true, false, false }
         };
    }
}
