
namespace ShapePainter
{
    partial class ShapePainter
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.labelCaptions2 = new System.Windows.Forms.Label();
            this.panelObejctFilling = new System.Windows.Forms.Panel();
            this.pictureBoxObjectImage = new System.Windows.Forms.PictureBox();
            this.radioButtonObjectImage = new System.Windows.Forms.RadioButton();
            this.labelObjectFilling = new System.Windows.Forms.Label();
            this.radioButtonObjectEmpty = new System.Windows.Forms.RadioButton();
            this.radioButtonObjectColour = new System.Windows.Forms.RadioButton();
            this.panelPolygonFilling = new System.Windows.Forms.Panel();
            this.pictureBoxPolygonImage = new System.Windows.Forms.PictureBox();
            this.radioButtonPolygonImage = new System.Windows.Forms.RadioButton();
            this.labelPolygonFilling = new System.Windows.Forms.Label();
            this.radioButtonPolygonEmpty = new System.Windows.Forms.RadioButton();
            this.radioButtonPolygonColour = new System.Windows.Forms.RadioButton();
            this.buttonPolygonImage = new System.Windows.Forms.Button();
            this.buttonObjectImage = new System.Windows.Forms.Button();
            this.buttonSaveObject = new System.Windows.Forms.Button();
            this.labelObjectColor = new System.Windows.Forms.Label();
            this.buttonObjectColor = new System.Windows.Forms.Button();
            this.numericUpDownObjectThickness = new System.Windows.Forms.NumericUpDown();
            this.labelObjectThickness = new System.Windows.Forms.Label();
            this.labelObject = new System.Windows.Forms.Label();
            this.labelGeneral = new System.Windows.Forms.Label();
            this.checkBoxAntiAliasing = new System.Windows.Forms.CheckBox();
            this.labelMode = new System.Windows.Forms.Label();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.labelBrushColor = new System.Windows.Forms.Label();
            this.buttonBrushColor = new System.Windows.Forms.Button();
            this.numericUpDownLineThickness = new System.Windows.Forms.NumericUpDown();
            this.labelLineThickness = new System.Windows.Forms.Label();
            this.panelMode = new System.Windows.Forms.Panel();
            this.labelCaptions1 = new System.Windows.Forms.Label();
            this.radioButtonAddClipping = new System.Windows.Forms.RadioButton();
            this.radioButtonAddRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonSelectObject = new System.Windows.Forms.RadioButton();
            this.radioButtonErase = new System.Windows.Forms.RadioButton();
            this.radioButtonBrush = new System.Windows.Forms.RadioButton();
            this.radioButtonResizeCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonMovePolygon = new System.Windows.Forms.RadioButton();
            this.radioButtonMoveLine = new System.Windows.Forms.RadioButton();
            this.radioButtonMovePoint = new System.Windows.Forms.RadioButton();
            this.radioButtonAddPolygon = new System.Windows.Forms.RadioButton();
            this.radioButtonAddCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonAddLine = new System.Windows.Forms.RadioButton();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            this.panelObejctFilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectImage)).BeginInit();
            this.panelPolygonFilling.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPolygonImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownObjectThickness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineThickness)).BeginInit();
            this.panelMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Location = new System.Drawing.Point(411, 27);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(600, 800);
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseLeave += new System.EventHandler(this.pictureBoxMain_MouseLeave);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.labelCaptions2);
            this.groupBoxSettings.Controls.Add(this.panelObejctFilling);
            this.groupBoxSettings.Controls.Add(this.panelPolygonFilling);
            this.groupBoxSettings.Controls.Add(this.buttonPolygonImage);
            this.groupBoxSettings.Controls.Add(this.buttonObjectImage);
            this.groupBoxSettings.Controls.Add(this.buttonSaveObject);
            this.groupBoxSettings.Controls.Add(this.labelObjectColor);
            this.groupBoxSettings.Controls.Add(this.buttonObjectColor);
            this.groupBoxSettings.Controls.Add(this.numericUpDownObjectThickness);
            this.groupBoxSettings.Controls.Add(this.labelObjectThickness);
            this.groupBoxSettings.Controls.Add(this.labelObject);
            this.groupBoxSettings.Controls.Add(this.labelGeneral);
            this.groupBoxSettings.Controls.Add(this.checkBoxAntiAliasing);
            this.groupBoxSettings.Controls.Add(this.labelMode);
            this.groupBoxSettings.Controls.Add(this.buttonClearAll);
            this.groupBoxSettings.Controls.Add(this.labelBrushColor);
            this.groupBoxSettings.Controls.Add(this.buttonBrushColor);
            this.groupBoxSettings.Controls.Add(this.numericUpDownLineThickness);
            this.groupBoxSettings.Controls.Add(this.labelLineThickness);
            this.groupBoxSettings.Controls.Add(this.panelMode);
            this.groupBoxSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBoxSettings.Location = new System.Drawing.Point(13, 16);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(392, 811);
            this.groupBoxSettings.TabIndex = 1;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // labelCaptions2
            // 
            this.labelCaptions2.AutoSize = true;
            this.labelCaptions2.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCaptions2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCaptions2.Location = new System.Drawing.Point(48, 769);
            this.labelCaptions2.MaximumSize = new System.Drawing.Size(292, 0);
            this.labelCaptions2.MinimumSize = new System.Drawing.Size(292, 0);
            this.labelCaptions2.Name = "labelCaptions2";
            this.labelCaptions2.Size = new System.Drawing.Size(292, 26);
            this.labelCaptions2.TabIndex = 22;
            this.labelCaptions2.Text = "Published under Apache-2.0 license\r\nby Szymon Górski (https://github.com/szgorski" +
    ").\r\n";
            this.labelCaptions2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelObejctFilling
            // 
            this.panelObejctFilling.Controls.Add(this.pictureBoxObjectImage);
            this.panelObejctFilling.Controls.Add(this.radioButtonObjectImage);
            this.panelObejctFilling.Controls.Add(this.labelObjectFilling);
            this.panelObejctFilling.Controls.Add(this.radioButtonObjectEmpty);
            this.panelObejctFilling.Controls.Add(this.radioButtonObjectColour);
            this.panelObejctFilling.Location = new System.Drawing.Point(207, 597);
            this.panelObejctFilling.Name = "panelObejctFilling";
            this.panelObejctFilling.Size = new System.Drawing.Size(176, 103);
            this.panelObejctFilling.TabIndex = 21;
            // 
            // pictureBoxObjectImage
            // 
            this.pictureBoxObjectImage.Location = new System.Drawing.Point(76, 34);
            this.pictureBoxObjectImage.MaximumSize = new System.Drawing.Size(100, 60);
            this.pictureBoxObjectImage.MinimumSize = new System.Drawing.Size(100, 60);
            this.pictureBoxObjectImage.Name = "pictureBoxObjectImage";
            this.pictureBoxObjectImage.Size = new System.Drawing.Size(100, 60);
            this.pictureBoxObjectImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxObjectImage.TabIndex = 4;
            this.pictureBoxObjectImage.TabStop = false;
            // 
            // radioButtonObjectImage
            // 
            this.radioButtonObjectImage.AutoSize = true;
            this.radioButtonObjectImage.Enabled = false;
            this.radioButtonObjectImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonObjectImage.Location = new System.Drawing.Point(3, 70);
            this.radioButtonObjectImage.Name = "radioButtonObjectImage";
            this.radioButtonObjectImage.Size = new System.Drawing.Size(65, 23);
            this.radioButtonObjectImage.TabIndex = 3;
            this.radioButtonObjectImage.TabStop = true;
            this.radioButtonObjectImage.Text = "Image";
            this.radioButtonObjectImage.UseVisualStyleBackColor = true;
            // 
            // labelObjectFilling
            // 
            this.labelObjectFilling.AutoSize = true;
            this.labelObjectFilling.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelObjectFilling.Location = new System.Drawing.Point(0, 5);
            this.labelObjectFilling.Name = "labelObjectFilling";
            this.labelObjectFilling.Size = new System.Drawing.Size(88, 15);
            this.labelObjectFilling.TabIndex = 0;
            this.labelObjectFilling.Text = "Polygon filling:";
            // 
            // radioButtonObjectEmpty
            // 
            this.radioButtonObjectEmpty.AutoSize = true;
            this.radioButtonObjectEmpty.Enabled = false;
            this.radioButtonObjectEmpty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonObjectEmpty.Location = new System.Drawing.Point(3, 29);
            this.radioButtonObjectEmpty.Name = "radioButtonObjectEmpty";
            this.radioButtonObjectEmpty.Size = new System.Drawing.Size(66, 23);
            this.radioButtonObjectEmpty.TabIndex = 1;
            this.radioButtonObjectEmpty.TabStop = true;
            this.radioButtonObjectEmpty.Text = "Empty";
            this.radioButtonObjectEmpty.UseVisualStyleBackColor = true;
            // 
            // radioButtonObjectColour
            // 
            this.radioButtonObjectColour.AutoSize = true;
            this.radioButtonObjectColour.Enabled = false;
            this.radioButtonObjectColour.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonObjectColour.Location = new System.Drawing.Point(3, 50);
            this.radioButtonObjectColour.Name = "radioButtonObjectColour";
            this.radioButtonObjectColour.Size = new System.Drawing.Size(68, 23);
            this.radioButtonObjectColour.TabIndex = 2;
            this.radioButtonObjectColour.TabStop = true;
            this.radioButtonObjectColour.Text = "Colour";
            this.radioButtonObjectColour.UseVisualStyleBackColor = true;
            // 
            // panelPolygonFilling
            // 
            this.panelPolygonFilling.Controls.Add(this.pictureBoxPolygonImage);
            this.panelPolygonFilling.Controls.Add(this.radioButtonPolygonImage);
            this.panelPolygonFilling.Controls.Add(this.labelPolygonFilling);
            this.panelPolygonFilling.Controls.Add(this.radioButtonPolygonEmpty);
            this.panelPolygonFilling.Controls.Add(this.radioButtonPolygonColour);
            this.panelPolygonFilling.Location = new System.Drawing.Point(207, 401);
            this.panelPolygonFilling.Name = "panelPolygonFilling";
            this.panelPolygonFilling.Size = new System.Drawing.Size(176, 103);
            this.panelPolygonFilling.TabIndex = 20;
            // 
            // pictureBoxPolygonImage
            // 
            this.pictureBoxPolygonImage.Location = new System.Drawing.Point(76, 34);
            this.pictureBoxPolygonImage.MaximumSize = new System.Drawing.Size(100, 60);
            this.pictureBoxPolygonImage.MinimumSize = new System.Drawing.Size(100, 60);
            this.pictureBoxPolygonImage.Name = "pictureBoxPolygonImage";
            this.pictureBoxPolygonImage.Size = new System.Drawing.Size(100, 60);
            this.pictureBoxPolygonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPolygonImage.TabIndex = 4;
            this.pictureBoxPolygonImage.TabStop = false;
            // 
            // radioButtonPolygonImage
            // 
            this.radioButtonPolygonImage.AutoSize = true;
            this.radioButtonPolygonImage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPolygonImage.Location = new System.Drawing.Point(3, 70);
            this.radioButtonPolygonImage.Name = "radioButtonPolygonImage";
            this.radioButtonPolygonImage.Size = new System.Drawing.Size(65, 23);
            this.radioButtonPolygonImage.TabIndex = 3;
            this.radioButtonPolygonImage.Text = "Image";
            this.radioButtonPolygonImage.UseVisualStyleBackColor = true;
            // 
            // labelPolygonFilling
            // 
            this.labelPolygonFilling.AutoSize = true;
            this.labelPolygonFilling.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPolygonFilling.Location = new System.Drawing.Point(0, 5);
            this.labelPolygonFilling.Name = "labelPolygonFilling";
            this.labelPolygonFilling.Size = new System.Drawing.Size(88, 15);
            this.labelPolygonFilling.TabIndex = 0;
            this.labelPolygonFilling.Text = "Polygon filling:";
            // 
            // radioButtonPolygonEmpty
            // 
            this.radioButtonPolygonEmpty.AutoSize = true;
            this.radioButtonPolygonEmpty.Checked = true;
            this.radioButtonPolygonEmpty.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPolygonEmpty.Location = new System.Drawing.Point(3, 29);
            this.radioButtonPolygonEmpty.Name = "radioButtonPolygonEmpty";
            this.radioButtonPolygonEmpty.Size = new System.Drawing.Size(66, 23);
            this.radioButtonPolygonEmpty.TabIndex = 1;
            this.radioButtonPolygonEmpty.TabStop = true;
            this.radioButtonPolygonEmpty.Text = "Empty";
            this.radioButtonPolygonEmpty.UseVisualStyleBackColor = true;
            // 
            // radioButtonPolygonColour
            // 
            this.radioButtonPolygonColour.AutoSize = true;
            this.radioButtonPolygonColour.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioButtonPolygonColour.Location = new System.Drawing.Point(3, 50);
            this.radioButtonPolygonColour.Name = "radioButtonPolygonColour";
            this.radioButtonPolygonColour.Size = new System.Drawing.Size(68, 23);
            this.radioButtonPolygonColour.TabIndex = 2;
            this.radioButtonPolygonColour.Text = "Colour";
            this.radioButtonPolygonColour.UseVisualStyleBackColor = true;
            // 
            // buttonPolygonImage
            // 
            this.buttonPolygonImage.Location = new System.Drawing.Point(9, 472);
            this.buttonPolygonImage.Name = "buttonPolygonImage";
            this.buttonPolygonImage.Size = new System.Drawing.Size(182, 32);
            this.buttonPolygonImage.TabIndex = 19;
            this.buttonPolygonImage.Text = "Set background image";
            this.buttonPolygonImage.UseVisualStyleBackColor = true;
            this.buttonPolygonImage.Click += new System.EventHandler(this.buttonPolygonImage_Click);
            // 
            // buttonObjectImage
            // 
            this.buttonObjectImage.Enabled = false;
            this.buttonObjectImage.Location = new System.Drawing.Point(9, 668);
            this.buttonObjectImage.Name = "buttonObjectImage";
            this.buttonObjectImage.Size = new System.Drawing.Size(182, 32);
            this.buttonObjectImage.TabIndex = 18;
            this.buttonObjectImage.Text = "Set background image";
            this.buttonObjectImage.UseVisualStyleBackColor = true;
            this.buttonObjectImage.Click += new System.EventHandler(this.buttonObjectImage_Click);
            // 
            // buttonSaveObject
            // 
            this.buttonSaveObject.Enabled = false;
            this.buttonSaveObject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonSaveObject.Location = new System.Drawing.Point(9, 706);
            this.buttonSaveObject.Name = "buttonSaveObject";
            this.buttonSaveObject.Size = new System.Drawing.Size(374, 32);
            this.buttonSaveObject.TabIndex = 17;
            this.buttonSaveObject.Text = "Save changes";
            this.buttonSaveObject.UseVisualStyleBackColor = true;
            this.buttonSaveObject.Click += new System.EventHandler(this.buttonSaveObject_Click);
            // 
            // labelObjectColor
            // 
            this.labelObjectColor.AutoSize = true;
            this.labelObjectColor.BackColor = System.Drawing.Color.Silver;
            this.labelObjectColor.Location = new System.Drawing.Point(9, 631);
            this.labelObjectColor.MaximumSize = new System.Drawing.Size(30, 30);
            this.labelObjectColor.MinimumSize = new System.Drawing.Size(30, 30);
            this.labelObjectColor.Name = "labelObjectColor";
            this.labelObjectColor.Size = new System.Drawing.Size(30, 30);
            this.labelObjectColor.TabIndex = 16;
            this.labelObjectColor.Text = "   ";
            // 
            // buttonObjectColor
            // 
            this.buttonObjectColor.Enabled = false;
            this.buttonObjectColor.Location = new System.Drawing.Point(48, 630);
            this.buttonObjectColor.Name = "buttonObjectColor";
            this.buttonObjectColor.Size = new System.Drawing.Size(143, 32);
            this.buttonObjectColor.TabIndex = 15;
            this.buttonObjectColor.Text = "Set brush colour";
            this.buttonObjectColor.UseVisualStyleBackColor = true;
            this.buttonObjectColor.Click += new System.EventHandler(this.buttonObjectColor_Click);
            // 
            // numericUpDownObjectThickness
            // 
            this.numericUpDownObjectThickness.Enabled = false;
            this.numericUpDownObjectThickness.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownObjectThickness.Location = new System.Drawing.Point(122, 595);
            this.numericUpDownObjectThickness.Maximum = new decimal(new int[] {
            49,
            0,
            0,
            0});
            this.numericUpDownObjectThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownObjectThickness.Name = "numericUpDownObjectThickness";
            this.numericUpDownObjectThickness.Size = new System.Drawing.Size(69, 29);
            this.numericUpDownObjectThickness.TabIndex = 14;
            this.numericUpDownObjectThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownObjectThickness.ValueChanged += new System.EventHandler(this.numericUpDownObjectThickness_ValueChanged);
            // 
            // labelObjectThickness
            // 
            this.labelObjectThickness.AutoSize = true;
            this.labelObjectThickness.Location = new System.Drawing.Point(9, 597);
            this.labelObjectThickness.Name = "labelObjectThickness";
            this.labelObjectThickness.Size = new System.Drawing.Size(107, 21);
            this.labelObjectThickness.TabIndex = 13;
            this.labelObjectThickness.Text = "Line thickness";
            // 
            // labelObject
            // 
            this.labelObject.AutoSize = true;
            this.labelObject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelObject.Location = new System.Drawing.Point(9, 570);
            this.labelObject.Name = "labelObject";
            this.labelObject.Size = new System.Drawing.Size(91, 15);
            this.labelObject.TabIndex = 12;
            this.labelObject.Text = "Object settings";
            // 
            // labelGeneral
            // 
            this.labelGeneral.AutoSize = true;
            this.labelGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGeneral.Location = new System.Drawing.Point(9, 341);
            this.labelGeneral.Name = "labelGeneral";
            this.labelGeneral.Size = new System.Drawing.Size(98, 15);
            this.labelGeneral.TabIndex = 11;
            this.labelGeneral.Text = "General settings";
            // 
            // checkBoxAntiAliasing
            // 
            this.checkBoxAntiAliasing.AutoSize = true;
            this.checkBoxAntiAliasing.Location = new System.Drawing.Point(12, 368);
            this.checkBoxAntiAliasing.Name = "checkBoxAntiAliasing";
            this.checkBoxAntiAliasing.Size = new System.Drawing.Size(179, 25);
            this.checkBoxAntiAliasing.TabIndex = 10;
            this.checkBoxAntiAliasing.Text = "Enable AA (lines only)";
            this.checkBoxAntiAliasing.UseVisualStyleBackColor = true;
            this.checkBoxAntiAliasing.CheckedChanged += new System.EventHandler(this.checkBoxAntiAliasing_CheckedChanged);
            // 
            // labelMode
            // 
            this.labelMode.AutoSize = true;
            this.labelMode.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelMode.Location = new System.Drawing.Point(6, 34);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(39, 15);
            this.labelMode.TabIndex = 9;
            this.labelMode.Text = "Mode";
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClearAll.Location = new System.Drawing.Point(9, 510);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(374, 32);
            this.buttonClearAll.TabIndex = 0;
            this.buttonClearAll.Text = "Clear the board";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // labelBrushColor
            // 
            this.labelBrushColor.AutoSize = true;
            this.labelBrushColor.BackColor = System.Drawing.Color.Black;
            this.labelBrushColor.Location = new System.Drawing.Point(9, 435);
            this.labelBrushColor.MaximumSize = new System.Drawing.Size(30, 30);
            this.labelBrushColor.MinimumSize = new System.Drawing.Size(30, 30);
            this.labelBrushColor.Name = "labelBrushColor";
            this.labelBrushColor.Size = new System.Drawing.Size(30, 30);
            this.labelBrushColor.TabIndex = 6;
            this.labelBrushColor.Text = "   ";
            // 
            // buttonBrushColor
            // 
            this.buttonBrushColor.Location = new System.Drawing.Point(48, 434);
            this.buttonBrushColor.Name = "buttonBrushColor";
            this.buttonBrushColor.Size = new System.Drawing.Size(143, 32);
            this.buttonBrushColor.TabIndex = 5;
            this.buttonBrushColor.Text = "Set brush colour";
            this.buttonBrushColor.UseVisualStyleBackColor = true;
            this.buttonBrushColor.Click += new System.EventHandler(this.buttonBrushColor_Click);
            // 
            // numericUpDownLineThickness
            // 
            this.numericUpDownLineThickness.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownLineThickness.Location = new System.Drawing.Point(122, 399);
            this.numericUpDownLineThickness.Maximum = new decimal(new int[] {
            49,
            0,
            0,
            0});
            this.numericUpDownLineThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineThickness.Name = "numericUpDownLineThickness";
            this.numericUpDownLineThickness.Size = new System.Drawing.Size(69, 29);
            this.numericUpDownLineThickness.TabIndex = 3;
            this.numericUpDownLineThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLineThickness.ValueChanged += new System.EventHandler(this.numericUpDownLineThickness_ValueChanged);
            // 
            // labelLineThickness
            // 
            this.labelLineThickness.AutoSize = true;
            this.labelLineThickness.Location = new System.Drawing.Point(9, 401);
            this.labelLineThickness.Name = "labelLineThickness";
            this.labelLineThickness.Size = new System.Drawing.Size(107, 21);
            this.labelLineThickness.TabIndex = 2;
            this.labelLineThickness.Text = "Line thickness";
            // 
            // panelMode
            // 
            this.panelMode.Controls.Add(this.labelCaptions1);
            this.panelMode.Controls.Add(this.radioButtonAddClipping);
            this.panelMode.Controls.Add(this.radioButtonAddRectangle);
            this.panelMode.Controls.Add(this.radioButtonSelectObject);
            this.panelMode.Controls.Add(this.radioButtonErase);
            this.panelMode.Controls.Add(this.radioButtonBrush);
            this.panelMode.Controls.Add(this.radioButtonResizeCircle);
            this.panelMode.Controls.Add(this.radioButtonMovePolygon);
            this.panelMode.Controls.Add(this.radioButtonMoveLine);
            this.panelMode.Controls.Add(this.radioButtonMovePoint);
            this.panelMode.Controls.Add(this.radioButtonAddPolygon);
            this.panelMode.Controls.Add(this.radioButtonAddCircle);
            this.panelMode.Controls.Add(this.radioButtonAddLine);
            this.panelMode.Location = new System.Drawing.Point(6, 52);
            this.panelMode.Name = "panelMode";
            this.panelMode.Size = new System.Drawing.Size(380, 286);
            this.panelMode.TabIndex = 1;
            // 
            // labelCaptions1
            // 
            this.labelCaptions1.AutoSize = true;
            this.labelCaptions1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelCaptions1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.labelCaptions1.Location = new System.Drawing.Point(42, 239);
            this.labelCaptions1.MaximumSize = new System.Drawing.Size(292, 0);
            this.labelCaptions1.MinimumSize = new System.Drawing.Size(292, 0);
            this.labelCaptions1.Name = "labelCaptions1";
            this.labelCaptions1.Size = new System.Drawing.Size(292, 26);
            this.labelCaptions1.TabIndex = 14;
            this.labelCaptions1.Text = "Icons based on \'Icon Pack: Vector Editing Tools\'\r\nby Freepik (https://www.freepik" +
    ".com).";
            this.labelCaptions1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radioButtonAddClipping
            // 
            this.radioButtonAddClipping.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAddClipping.AutoSize = true;
            this.radioButtonAddClipping.Image = global::ShapePainter.Properties.Resources.add_clipped_polygon;
            this.radioButtonAddClipping.Location = new System.Drawing.Point(268, 79);
            this.radioButtonAddClipping.MinimumSize = new System.Drawing.Size(70, 70);
            this.radioButtonAddClipping.Name = "radioButtonAddClipping";
            this.radioButtonAddClipping.Size = new System.Drawing.Size(70, 70);
            this.radioButtonAddClipping.TabIndex = 13;
            this.radioButtonAddClipping.TabStop = true;
            this.radioButtonAddClipping.UseVisualStyleBackColor = true;
            this.radioButtonAddClipping.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonAddRectangle
            // 
            this.radioButtonAddRectangle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAddRectangle.AutoSize = true;
            this.radioButtonAddRectangle.Image = global::ShapePainter.Properties.Resources.add_rectangle;
            this.radioButtonAddRectangle.Location = new System.Drawing.Point(116, 79);
            this.radioButtonAddRectangle.MinimumSize = new System.Drawing.Size(70, 70);
            this.radioButtonAddRectangle.Name = "radioButtonAddRectangle";
            this.radioButtonAddRectangle.Size = new System.Drawing.Size(70, 70);
            this.radioButtonAddRectangle.TabIndex = 12;
            this.radioButtonAddRectangle.TabStop = true;
            this.radioButtonAddRectangle.UseVisualStyleBackColor = true;
            this.radioButtonAddRectangle.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonSelectObject
            // 
            this.radioButtonSelectObject.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonSelectObject.AutoSize = true;
            this.radioButtonSelectObject.Image = global::ShapePainter.Properties.Resources.settings;
            this.radioButtonSelectObject.Location = new System.Drawing.Point(192, 155);
            this.radioButtonSelectObject.Name = "radioButtonSelectObject";
            this.radioButtonSelectObject.Size = new System.Drawing.Size(70, 70);
            this.radioButtonSelectObject.TabIndex = 11;
            this.radioButtonSelectObject.TabStop = true;
            this.radioButtonSelectObject.UseVisualStyleBackColor = true;
            this.radioButtonSelectObject.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonErase
            // 
            this.radioButtonErase.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonErase.AutoSize = true;
            this.radioButtonErase.Image = global::ShapePainter.Properties.Resources.trash;
            this.radioButtonErase.Location = new System.Drawing.Point(268, 155);
            this.radioButtonErase.Name = "radioButtonErase";
            this.radioButtonErase.Size = new System.Drawing.Size(70, 70);
            this.radioButtonErase.TabIndex = 9;
            this.radioButtonErase.TabStop = true;
            this.radioButtonErase.UseVisualStyleBackColor = true;
            this.radioButtonErase.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonBrush
            // 
            this.radioButtonBrush.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonBrush.AutoSize = true;
            this.radioButtonBrush.Image = global::ShapePainter.Properties.Resources.colour;
            this.radioButtonBrush.Location = new System.Drawing.Point(116, 155);
            this.radioButtonBrush.Name = "radioButtonBrush";
            this.radioButtonBrush.Size = new System.Drawing.Size(70, 70);
            this.radioButtonBrush.TabIndex = 8;
            this.radioButtonBrush.UseVisualStyleBackColor = true;
            this.radioButtonBrush.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonResizeCircle
            // 
            this.radioButtonResizeCircle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonResizeCircle.AutoSize = true;
            this.radioButtonResizeCircle.Image = global::ShapePainter.Properties.Resources.resize_circle;
            this.radioButtonResizeCircle.Location = new System.Drawing.Point(40, 79);
            this.radioButtonResizeCircle.Name = "radioButtonResizeCircle";
            this.radioButtonResizeCircle.Size = new System.Drawing.Size(70, 70);
            this.radioButtonResizeCircle.TabIndex = 7;
            this.radioButtonResizeCircle.UseVisualStyleBackColor = true;
            this.radioButtonResizeCircle.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonMovePolygon
            // 
            this.radioButtonMovePolygon.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonMovePolygon.AutoSize = true;
            this.radioButtonMovePolygon.Image = global::ShapePainter.Properties.Resources.move_polygon;
            this.radioButtonMovePolygon.Location = new System.Drawing.Point(40, 155);
            this.radioButtonMovePolygon.Name = "radioButtonMovePolygon";
            this.radioButtonMovePolygon.Size = new System.Drawing.Size(70, 70);
            this.radioButtonMovePolygon.TabIndex = 6;
            this.radioButtonMovePolygon.UseVisualStyleBackColor = true;
            this.radioButtonMovePolygon.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonMoveLine
            // 
            this.radioButtonMoveLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonMoveLine.AutoSize = true;
            this.radioButtonMoveLine.Image = global::ShapePainter.Properties.Resources.move_line;
            this.radioButtonMoveLine.Location = new System.Drawing.Point(116, 3);
            this.radioButtonMoveLine.Name = "radioButtonMoveLine";
            this.radioButtonMoveLine.Size = new System.Drawing.Size(70, 70);
            this.radioButtonMoveLine.TabIndex = 5;
            this.radioButtonMoveLine.UseVisualStyleBackColor = true;
            this.radioButtonMoveLine.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonMovePoint
            // 
            this.radioButtonMovePoint.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonMovePoint.AutoSize = true;
            this.radioButtonMovePoint.Image = global::ShapePainter.Properties.Resources.move_edge;
            this.radioButtonMovePoint.Location = new System.Drawing.Point(268, 3);
            this.radioButtonMovePoint.Name = "radioButtonMovePoint";
            this.radioButtonMovePoint.Size = new System.Drawing.Size(70, 70);
            this.radioButtonMovePoint.TabIndex = 4;
            this.radioButtonMovePoint.UseVisualStyleBackColor = true;
            this.radioButtonMovePoint.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonAddPolygon
            // 
            this.radioButtonAddPolygon.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAddPolygon.AutoSize = true;
            this.radioButtonAddPolygon.Image = global::ShapePainter.Properties.Resources.add_polygon;
            this.radioButtonAddPolygon.Location = new System.Drawing.Point(192, 80);
            this.radioButtonAddPolygon.Name = "radioButtonAddPolygon";
            this.radioButtonAddPolygon.Size = new System.Drawing.Size(70, 70);
            this.radioButtonAddPolygon.TabIndex = 3;
            this.radioButtonAddPolygon.UseVisualStyleBackColor = true;
            this.radioButtonAddPolygon.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonAddCircle
            // 
            this.radioButtonAddCircle.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAddCircle.AutoSize = true;
            this.radioButtonAddCircle.Image = global::ShapePainter.Properties.Resources.add_circle;
            this.radioButtonAddCircle.Location = new System.Drawing.Point(192, 3);
            this.radioButtonAddCircle.Name = "radioButtonAddCircle";
            this.radioButtonAddCircle.Size = new System.Drawing.Size(70, 70);
            this.radioButtonAddCircle.TabIndex = 2;
            this.radioButtonAddCircle.UseVisualStyleBackColor = true;
            this.radioButtonAddCircle.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // radioButtonAddLine
            // 
            this.radioButtonAddLine.Appearance = System.Windows.Forms.Appearance.Button;
            this.radioButtonAddLine.AutoSize = true;
            this.radioButtonAddLine.Image = global::ShapePainter.Properties.Resources.add_line;
            this.radioButtonAddLine.Location = new System.Drawing.Point(40, 3);
            this.radioButtonAddLine.Name = "radioButtonAddLine";
            this.radioButtonAddLine.Size = new System.Drawing.Size(70, 70);
            this.radioButtonAddLine.TabIndex = 0;
            this.radioButtonAddLine.UseVisualStyleBackColor = true;
            this.radioButtonAddLine.CheckedChanged += new System.EventHandler(this.mode_CheckedChanged);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // ShapePainter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 836);
            this.Controls.Add(this.groupBoxSettings);
            this.Controls.Add(this.pictureBoxMain);
            this.Name = "ShapePainter";
            this.Text = "ShapePainter";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            this.panelObejctFilling.ResumeLayout(false);
            this.panelObejctFilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectImage)).EndInit();
            this.panelPolygonFilling.ResumeLayout(false);
            this.panelPolygonFilling.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPolygonImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownObjectThickness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLineThickness)).EndInit();
            this.panelMode.ResumeLayout(false);
            this.panelMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMain;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.Panel panelMode;
        private System.Windows.Forms.RadioButton radioButtonAddCircle;
        private System.Windows.Forms.RadioButton radioButtonAddLine;
        private System.Windows.Forms.Button buttonClearAll;
        private System.Windows.Forms.RadioButton radioButtonBrush;
        private System.Windows.Forms.RadioButton radioButtonResizeCircle;
        private System.Windows.Forms.RadioButton radioButtonMovePolygon;
        private System.Windows.Forms.RadioButton radioButtonMoveLine;
        private System.Windows.Forms.RadioButton radioButtonMovePoint;
        private System.Windows.Forms.RadioButton radioButtonAddPolygon;
        private System.Windows.Forms.RadioButton radioButtonErase;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Label labelBrushColor;
        private System.Windows.Forms.Button buttonBrushColor;
        private System.Windows.Forms.NumericUpDown numericUpDownLineThickness;
        private System.Windows.Forms.Label labelLineThickness;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.CheckBox checkBoxAntiAliasing;
        private System.Windows.Forms.Button buttonSaveObject;
        private System.Windows.Forms.Label labelObjectColor;
        private System.Windows.Forms.Button buttonObjectColor;
        private System.Windows.Forms.NumericUpDown numericUpDownObjectThickness;
        private System.Windows.Forms.Label labelObjectThickness;
        private System.Windows.Forms.Label labelObject;
        private System.Windows.Forms.Label labelGeneral;
        private System.Windows.Forms.RadioButton radioButtonSelectObject;
        private System.Windows.Forms.RadioButton radioButtonAddRectangle;
        private System.Windows.Forms.Button buttonPolygonImage;
        private System.Windows.Forms.Button buttonObjectImage;
        private System.Windows.Forms.Panel panelPolygonFilling;
        private System.Windows.Forms.RadioButton radioButtonPolygonImage;
        private System.Windows.Forms.RadioButton radioButtonPolygonColour;
        private System.Windows.Forms.RadioButton radioButtonPolygonEmpty;
        private System.Windows.Forms.Label labelPolygonFilling;
        private System.Windows.Forms.PictureBox pictureBoxPolygonImage;
        private System.Windows.Forms.Panel panelObejctFilling;
        private System.Windows.Forms.PictureBox pictureBoxObjectImage;
        private System.Windows.Forms.RadioButton radioButtonObjectImage;
        private System.Windows.Forms.Label labelObjectFilling;
        private System.Windows.Forms.RadioButton radioButtonObjectEmpty;
        private System.Windows.Forms.RadioButton radioButtonObjectColour;
        private System.Windows.Forms.RadioButton radioButtonAddClipping;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label labelCaptions2;
        private System.Windows.Forms.Label labelCaptions1;
    }
}

