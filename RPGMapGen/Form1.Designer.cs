namespace RPGMapGen
{
    partial class Form1
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
            this.numRoomsDropDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.motifComboBx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.generalRoomSizeDropDown = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numFloorsDropDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numStairsDropDown = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lockedDoorsChkBx = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapGenBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRoomsDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorsDropDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStairsDropDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numRoomsDropDown
            // 
            this.numRoomsDropDown.Location = new System.Drawing.Point(99, 3);
            this.numRoomsDropDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRoomsDropDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRoomsDropDown.Name = "numRoomsDropDown";
            this.numRoomsDropDown.Size = new System.Drawing.Size(64, 20);
            this.numRoomsDropDown.TabIndex = 0;
            this.numRoomsDropDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of rooms:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Motif:";
            // 
            // motifComboBx
            // 
            this.motifComboBx.FormattingEnabled = true;
            this.motifComboBx.Location = new System.Drawing.Point(42, 108);
            this.motifComboBx.Name = "motifComboBx";
            this.motifComboBx.Size = new System.Drawing.Size(121, 21);
            this.motifComboBx.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "General room size:";
            // 
            // generalRoomSizeDropDown
            // 
            this.generalRoomSizeDropDown.FormattingEnabled = true;
            this.generalRoomSizeDropDown.Location = new System.Drawing.Point(99, 29);
            this.generalRoomSizeDropDown.Name = "generalRoomSizeDropDown";
            this.generalRoomSizeDropDown.Size = new System.Drawing.Size(64, 21);
            this.generalRoomSizeDropDown.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of floors:";
            // 
            // numFloorsDropDown
            // 
            this.numFloorsDropDown.Location = new System.Drawing.Point(99, 56);
            this.numFloorsDropDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numFloorsDropDown.Name = "numFloorsDropDown";
            this.numFloorsDropDown.Size = new System.Drawing.Size(64, 20);
            this.numFloorsDropDown.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Number of stairs:";
            // 
            // numStairsDropDown
            // 
            this.numStairsDropDown.Location = new System.Drawing.Point(99, 82);
            this.numStairsDropDown.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numStairsDropDown.Name = "numStairsDropDown";
            this.numStairsDropDown.Size = new System.Drawing.Size(64, 20);
            this.numStairsDropDown.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mapGenBtn);
            this.panel1.Controls.Add(this.lockedDoorsChkBx);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.motifComboBx);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.numStairsDropDown);
            this.panel1.Controls.Add(this.numRoomsDropDown);
            this.panel1.Controls.Add(this.generalRoomSizeDropDown);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.numFloorsDropDown);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 210);
            this.panel1.TabIndex = 10;
            // 
            // lockedDoorsChkBx
            // 
            this.lockedDoorsChkBx.AutoSize = true;
            this.lockedDoorsChkBx.Location = new System.Drawing.Point(6, 135);
            this.lockedDoorsChkBx.Name = "lockedDoorsChkBx";
            this.lockedDoorsChkBx.Size = new System.Drawing.Size(123, 17);
            this.lockedDoorsChkBx.TabIndex = 10;
            this.lockedDoorsChkBx.Text = "Enable locked doors";
            this.lockedDoorsChkBx.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(200, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMapToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openMapToolStripMenuItem
            // 
            this.openMapToolStripMenuItem.Name = "openMapToolStripMenuItem";
            this.openMapToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openMapToolStripMenuItem.Text = "Open map";
            // 
            // mapGenBtn
            // 
            this.mapGenBtn.Location = new System.Drawing.Point(6, 158);
            this.mapGenBtn.Name = "mapGenBtn";
            this.mapGenBtn.Size = new System.Drawing.Size(157, 46);
            this.mapGenBtn.TabIndex = 11;
            this.mapGenBtn.Text = "Generate map";
            this.mapGenBtn.UseVisualStyleBackColor = true;
            this.mapGenBtn.Click += new System.EventHandler(this.mapGenBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 243);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Dungeon Input";
            ((System.ComponentModel.ISupportInitialize)(this.numRoomsDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFloorsDropDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStairsDropDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numRoomsDropDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox motifComboBx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox generalRoomSizeDropDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numFloorsDropDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numStairsDropDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button mapGenBtn;
        private System.Windows.Forms.CheckBox lockedDoorsChkBx;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMapToolStripMenuItem;
    }
}

