namespace OsuHelperTool.Classes.Miscellaneous
{
    partial class PreferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FormBorder = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Border = new System.Windows.Forms.Label();
            this.BackgroundColorButton = new System.Windows.Forms.Button();
            this.SubButtoncolorbutton = new System.Windows.Forms.Button();
            this.MainButtonColorbutton = new System.Windows.Forms.Button();
            this.FormBorderColorButton = new System.Windows.Forms.Button();
            this.BackgroundColorTextbox = new System.Windows.Forms.TextBox();
            this.SubButtonColorTextBox = new System.Windows.Forms.TextBox();
            this.MainButtonColorTextbox = new System.Windows.Forms.TextBox();
            this.FormBorderTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenPathFinder = new System.Windows.Forms.Button();
            this.MapsetPathTextBox = new System.Windows.Forms.TextBox();
            this.SavePreferences = new System.Windows.Forms.Button();
            this.ButtonOrder = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Orientation = new System.Windows.Forms.GroupBox();
            this.Horizontal = new System.Windows.Forms.RadioButton();
            this.SqareMini = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.splitter = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.PreviewFormBorder = new System.Windows.Forms.Button();
            this.PreviewMainButtons = new System.Windows.Forms.Button();
            this.PreviewSubButtons = new System.Windows.Forms.Button();
            this.PreviewBackground = new System.Windows.Forms.Button();
            this.FormBorder.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ButtonOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.Orientation.SuspendLayout();
            this.splitter.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormBorder
            // 
            this.FormBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.FormBorder.Controls.Add(this.CloseButton);
            this.FormBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.FormBorder.Location = new System.Drawing.Point(0, 0);
            this.FormBorder.Name = "FormBorder";
            this.FormBorder.Size = new System.Drawing.Size(502, 24);
            this.FormBorder.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Image = global::OsuHelperTool.Properties.Resources.Close;
            this.CloseButton.Location = new System.Drawing.Point(458, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(44, 24);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = " ";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Border);
            this.groupBox1.Controls.Add(this.BackgroundColorButton);
            this.groupBox1.Controls.Add(this.SubButtoncolorbutton);
            this.groupBox1.Controls.Add(this.MainButtonColorbutton);
            this.groupBox1.Controls.Add(this.FormBorderColorButton);
            this.groupBox1.Controls.Add(this.BackgroundColorTextbox);
            this.groupBox1.Controls.Add(this.SubButtonColorTextBox);
            this.groupBox1.Controls.Add(this.MainButtonColorTextbox);
            this.groupBox1.Controls.Add(this.FormBorderTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Location = new System.Drawing.Point(10, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 104);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theme";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(281, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Background";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(281, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Sub Objects";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Main Button";
            // 
            // Border
            // 
            this.Border.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Border.AutoSize = true;
            this.Border.Location = new System.Drawing.Point(45, 15);
            this.Border.Name = "Border";
            this.Border.Size = new System.Drawing.Size(64, 13);
            this.Border.TabIndex = 8;
            this.Border.Text = "Form Border";
            // 
            // BackgroundColorButton
            // 
            this.BackgroundColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundColorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundColorButton.Location = new System.Drawing.Point(380, 66);
            this.BackgroundColorButton.Name = "BackgroundColorButton";
            this.BackgroundColorButton.Size = new System.Drawing.Size(75, 20);
            this.BackgroundColorButton.TabIndex = 7;
            this.BackgroundColorButton.Text = "Select Color";
            this.BackgroundColorButton.UseVisualStyleBackColor = true;
            this.BackgroundColorButton.Click += new System.EventHandler(this.BackgroundColorButton_Click);
            // 
            // SubButtoncolorbutton
            // 
            this.SubButtoncolorbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubButtoncolorbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SubButtoncolorbutton.Location = new System.Drawing.Point(380, 31);
            this.SubButtoncolorbutton.Name = "SubButtoncolorbutton";
            this.SubButtoncolorbutton.Size = new System.Drawing.Size(75, 20);
            this.SubButtoncolorbutton.TabIndex = 6;
            this.SubButtoncolorbutton.Text = "Select Color";
            this.SubButtoncolorbutton.UseVisualStyleBackColor = true;
            this.SubButtoncolorbutton.Click += new System.EventHandler(this.SubButtoncolorbutton_Click);
            // 
            // MainButtonColorbutton
            // 
            this.MainButtonColorbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainButtonColorbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainButtonColorbutton.Location = new System.Drawing.Point(145, 68);
            this.MainButtonColorbutton.Name = "MainButtonColorbutton";
            this.MainButtonColorbutton.Size = new System.Drawing.Size(75, 19);
            this.MainButtonColorbutton.TabIndex = 5;
            this.MainButtonColorbutton.Text = "Select Color";
            this.MainButtonColorbutton.UseVisualStyleBackColor = true;
            this.MainButtonColorbutton.Click += new System.EventHandler(this.MainButtonColorbutton_Click);
            // 
            // FormBorderColorButton
            // 
            this.FormBorderColorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormBorderColorButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderColorButton.Location = new System.Drawing.Point(145, 30);
            this.FormBorderColorButton.Name = "FormBorderColorButton";
            this.FormBorderColorButton.Size = new System.Drawing.Size(75, 20);
            this.FormBorderColorButton.TabIndex = 4;
            this.FormBorderColorButton.Text = "Select Color";
            this.FormBorderColorButton.UseVisualStyleBackColor = true;
            this.FormBorderColorButton.Click += new System.EventHandler(this.FormBorderColorButton_Click);
            // 
            // BackgroundColorTextbox
            // 
            this.BackgroundColorTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackgroundColorTextbox.Location = new System.Drawing.Point(262, 68);
            this.BackgroundColorTextbox.Name = "BackgroundColorTextbox";
            this.BackgroundColorTextbox.ReadOnly = true;
            this.BackgroundColorTextbox.Size = new System.Drawing.Size(100, 20);
            this.BackgroundColorTextbox.TabIndex = 3;
            // 
            // SubButtonColorTextBox
            // 
            this.SubButtonColorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubButtonColorTextBox.Location = new System.Drawing.Point(262, 31);
            this.SubButtonColorTextBox.Name = "SubButtonColorTextBox";
            this.SubButtonColorTextBox.ReadOnly = true;
            this.SubButtonColorTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubButtonColorTextBox.TabIndex = 2;
            // 
            // MainButtonColorTextbox
            // 
            this.MainButtonColorTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainButtonColorTextbox.Location = new System.Drawing.Point(28, 67);
            this.MainButtonColorTextbox.Name = "MainButtonColorTextbox";
            this.MainButtonColorTextbox.ReadOnly = true;
            this.MainButtonColorTextbox.Size = new System.Drawing.Size(102, 20);
            this.MainButtonColorTextbox.TabIndex = 1;
            // 
            // FormBorderTextBox
            // 
            this.FormBorderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FormBorderTextBox.Location = new System.Drawing.Point(28, 31);
            this.FormBorderTextBox.Name = "FormBorderTextBox";
            this.FormBorderTextBox.ReadOnly = true;
            this.FormBorderTextBox.Size = new System.Drawing.Size(102, 20);
            this.FormBorderTextBox.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.SavePreferences, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.ButtonOrder, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitter, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.72727F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 515);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.OpenPathFinder);
            this.groupBox2.Controls.Add(this.MapsetPathTextBox);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox2.Location = new System.Drawing.Point(10, 120);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(10, 3, 10, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(482, 104);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mapset Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current Mapset Path";
            // 
            // OpenPathFinder
            // 
            this.OpenPathFinder.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OpenPathFinder.Location = new System.Drawing.Point(326, 44);
            this.OpenPathFinder.Name = "OpenPathFinder";
            this.OpenPathFinder.Size = new System.Drawing.Size(104, 25);
            this.OpenPathFinder.TabIndex = 1;
            this.OpenPathFinder.Text = "Open Folder...";
            this.OpenPathFinder.UseVisualStyleBackColor = true;
            this.OpenPathFinder.Click += new System.EventHandler(this.OpenPathFinder_Click);
            // 
            // MapsetPathTextBox
            // 
            this.MapsetPathTextBox.Location = new System.Drawing.Point(28, 47);
            this.MapsetPathTextBox.Name = "MapsetPathTextBox";
            this.MapsetPathTextBox.ReadOnly = true;
            this.MapsetPathTextBox.Size = new System.Drawing.Size(274, 20);
            this.MapsetPathTextBox.TabIndex = 0;
            // 
            // SavePreferences
            // 
            this.SavePreferences.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SavePreferences.Location = new System.Drawing.Point(3, 471);
            this.SavePreferences.Name = "SavePreferences";
            this.SavePreferences.Size = new System.Drawing.Size(496, 41);
            this.SavePreferences.TabIndex = 3;
            this.SavePreferences.Text = "Save Changes";
            this.SavePreferences.UseVisualStyleBackColor = true;
            this.SavePreferences.Click += new System.EventHandler(this.SavePreferences_Click);
            // 
            // ButtonOrder
            // 
            this.ButtonOrder.Controls.Add(this.label8);
            this.ButtonOrder.Controls.Add(this.label7);
            this.ButtonOrder.Controls.Add(this.label6);
            this.ButtonOrder.Controls.Add(this.label5);
            this.ButtonOrder.Controls.Add(this.numericUpDown4);
            this.ButtonOrder.Controls.Add(this.numericUpDown3);
            this.ButtonOrder.Controls.Add(this.numericUpDown2);
            this.ButtonOrder.Controls.Add(this.numericUpDown1);
            this.ButtonOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOrder.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.ButtonOrder.Location = new System.Drawing.Point(3, 237);
            this.ButtonOrder.Name = "ButtonOrder";
            this.ButtonOrder.Size = new System.Drawing.Size(496, 111);
            this.ButtonOrder.TabIndex = 4;
            this.ButtonOrder.TabStop = false;
            this.ButtonOrder.Text = "Button Order";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Mapping tool";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(249, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Map Setup Tool";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(149, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Hitsound Tool";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Collab Tool";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(354, 51);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.ReadOnly = true;
            this.numericUpDown4.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown4.TabIndex = 3;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(269, 51);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.ReadOnly = true;
            this.numericUpDown3.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown3.TabIndex = 2;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(156, 51);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.ReadOnly = true;
            this.numericUpDown2.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown2.TabIndex = 1;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(65, 51);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.ReadOnly = true;
            this.numericUpDown1.Size = new System.Drawing.Size(34, 20);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Orientation
            // 
            this.Orientation.Controls.Add(this.Horizontal);
            this.Orientation.Controls.Add(this.SqareMini);
            this.Orientation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Orientation.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Orientation.Location = new System.Drawing.Point(3, 3);
            this.Orientation.Name = "Orientation";
            this.Orientation.Size = new System.Drawing.Size(242, 105);
            this.Orientation.TabIndex = 5;
            this.Orientation.TabStop = false;
            this.Orientation.Text = "Orientation";
            // 
            // Horizontal
            // 
            this.Horizontal.AutoSize = true;
            this.Horizontal.Location = new System.Drawing.Point(133, 53);
            this.Horizontal.Name = "Horizontal";
            this.Horizontal.Size = new System.Drawing.Size(72, 17);
            this.Horizontal.TabIndex = 1;
            this.Horizontal.TabStop = true;
            this.Horizontal.Text = "Horizontal";
            this.Horizontal.UseVisualStyleBackColor = true;
            // 
            // SqareMini
            // 
            this.SqareMini.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SqareMini.AutoSize = true;
            this.SqareMini.Location = new System.Drawing.Point(32, 53);
            this.SqareMini.Name = "SqareMini";
            this.SqareMini.Size = new System.Drawing.Size(59, 17);
            this.SqareMini.TabIndex = 0;
            this.SqareMini.TabStop = true;
            this.SqareMini.Text = "Sqared";
            this.SqareMini.UseVisualStyleBackColor = true;
            // 
            // splitter
            // 
            this.splitter.ColumnCount = 2;
            this.splitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.splitter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.splitter.Controls.Add(this.Orientation, 0, 0);
            this.splitter.Controls.Add(this.groupBox3, 1, 0);
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Location = new System.Drawing.Point(3, 354);
            this.splitter.Name = "splitter";
            this.splitter.RowCount = 1;
            this.splitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.splitter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.splitter.Size = new System.Drawing.Size(496, 111);
            this.splitter.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox3.Location = new System.Drawing.Point(251, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 105);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Theme Preview";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.PreviewBackground, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.PreviewSubButtons, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.PreviewMainButtons, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.PreviewFormBorder, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(236, 86);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // PreviewFormBorder
            // 
            this.PreviewFormBorder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewFormBorder.FlatAppearance.BorderSize = 0;
            this.PreviewFormBorder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewFormBorder.Location = new System.Drawing.Point(0, 0);
            this.PreviewFormBorder.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewFormBorder.Name = "PreviewFormBorder";
            this.PreviewFormBorder.Size = new System.Drawing.Size(236, 7);
            this.PreviewFormBorder.TabIndex = 0;
            this.PreviewFormBorder.UseVisualStyleBackColor = true;
            // 
            // PreviewMainButtons
            // 
            this.PreviewMainButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewMainButtons.FlatAppearance.BorderSize = 0;
            this.PreviewMainButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewMainButtons.Location = new System.Drawing.Point(0, 7);
            this.PreviewMainButtons.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewMainButtons.Name = "PreviewMainButtons";
            this.PreviewMainButtons.Size = new System.Drawing.Size(236, 23);
            this.PreviewMainButtons.TabIndex = 1;
            this.PreviewMainButtons.UseVisualStyleBackColor = true;
            // 
            // PreviewSubButtons
            // 
            this.PreviewSubButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewSubButtons.FlatAppearance.BorderSize = 0;
            this.PreviewSubButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewSubButtons.Location = new System.Drawing.Point(0, 30);
            this.PreviewSubButtons.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewSubButtons.Name = "PreviewSubButtons";
            this.PreviewSubButtons.Size = new System.Drawing.Size(236, 15);
            this.PreviewSubButtons.TabIndex = 2;
            this.PreviewSubButtons.UseVisualStyleBackColor = true;
            // 
            // PreviewBackground
            // 
            this.PreviewBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewBackground.FlatAppearance.BorderSize = 0;
            this.PreviewBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PreviewBackground.Location = new System.Drawing.Point(0, 45);
            this.PreviewBackground.Margin = new System.Windows.Forms.Padding(0);
            this.PreviewBackground.Name = "PreviewBackground";
            this.PreviewBackground.Size = new System.Drawing.Size(236, 41);
            this.PreviewBackground.TabIndex = 3;
            this.PreviewBackground.UseVisualStyleBackColor = true;
            // 
            // PreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.ClientSize = new System.Drawing.Size(502, 539);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.FormBorder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PreferencesForm";
            this.Text = "PreferencesForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PreferencesForm_FormClosed);
            this.Load += new System.EventHandler(this.PreferencesForm_Load);
            this.FormBorder.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ButtonOrder.ResumeLayout(false);
            this.ButtonOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.Orientation.ResumeLayout(false);
            this.Orientation.PerformLayout();
            this.splitter.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel FormBorder;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button OpenPathFinder;
        private System.Windows.Forms.TextBox MapsetPathTextBox;
        private System.Windows.Forms.Button SavePreferences;
        private System.Windows.Forms.Button BackgroundColorButton;
        private System.Windows.Forms.Button SubButtoncolorbutton;
        private System.Windows.Forms.Button MainButtonColorbutton;
        private System.Windows.Forms.Button FormBorderColorButton;
        private System.Windows.Forms.TextBox BackgroundColorTextbox;
        private System.Windows.Forms.TextBox SubButtonColorTextBox;
        private System.Windows.Forms.TextBox MainButtonColorTextbox;
        private System.Windows.Forms.TextBox FormBorderTextBox;
        private System.Windows.Forms.GroupBox ButtonOrder;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox Orientation;
        private System.Windows.Forms.RadioButton Horizontal;
        private System.Windows.Forms.RadioButton SqareMini;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Border;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel splitter;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button PreviewBackground;
        private System.Windows.Forms.Button PreviewSubButtons;
        private System.Windows.Forms.Button PreviewMainButtons;
        private System.Windows.Forms.Button PreviewFormBorder;
    }
}