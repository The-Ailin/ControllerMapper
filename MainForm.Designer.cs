namespace ControllerMapper
{
    partial class MainForm
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
            this.cbController = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMnK = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSet = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMouseSpeed = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownMouseAcceleration = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDeadZone = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownScrollSpeed = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMouseSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMouseAcceleration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadZone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScrollSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // cbController
            // 
            this.cbController.FormattingEnabled = true;
            this.cbController.Location = new System.Drawing.Point(63, 110);
            this.cbController.Name = "cbController";
            this.cbController.Size = new System.Drawing.Size(221, 28);
            this.cbController.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(59, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 20);
            this.label1.TabIndex = 100;
            this.label1.Text = "Controller Button";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbMnK
            // 
            this.cbMnK.FormattingEnabled = true;
            this.cbMnK.Location = new System.Drawing.Point(401, 109);
            this.cbMnK.Name = "cbMnK";
            this.cbMnK.Size = new System.Drawing.Size(337, 28);
            this.cbMnK.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(397, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 100;
            this.label2.Text = "Mouse/Key Button";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonSet
            // 
            this.buttonSet.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSet.CausesValidation = false;
            this.buttonSet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSet.FlatAppearance.BorderSize = 3;
            this.buttonSet.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.buttonSet.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonSet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSet.Location = new System.Drawing.Point(805, 87);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(114, 69);
            this.buttonSet.TabIndex = 2;
            this.buttonSet.Text = "SET";
            this.buttonSet.UseVisualStyleBackColor = false;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(120, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Mouse Speed";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(303, 175);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 20);
            this.label4.TabIndex = 104;
            this.label4.Text = "Mouse Acceleration";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownMouseSpeed
            // 
            this.numericUpDownMouseSpeed.DecimalPlaces = 1;
            this.numericUpDownMouseSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownMouseSpeed.Location = new System.Drawing.Point(124, 198);
            this.numericUpDownMouseSpeed.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDownMouseSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMouseSpeed.Name = "numericUpDownMouseSpeed";
            this.numericUpDownMouseSpeed.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownMouseSpeed.TabIndex = 3;
            this.numericUpDownMouseSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDownMouseAcceleration
            // 
            this.numericUpDownMouseAcceleration.DecimalPlaces = 2;
            this.numericUpDownMouseAcceleration.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownMouseAcceleration.Location = new System.Drawing.Point(307, 198);
            this.numericUpDownMouseAcceleration.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownMouseAcceleration.Name = "numericUpDownMouseAcceleration";
            this.numericUpDownMouseAcceleration.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownMouseAcceleration.TabIndex = 4;
            // 
            // numericUpDownDeadZone
            // 
            this.numericUpDownDeadZone.DecimalPlaces = 2;
            this.numericUpDownDeadZone.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownDeadZone.Location = new System.Drawing.Point(499, 198);
            this.numericUpDownDeadZone.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            131072});
            this.numericUpDownDeadZone.Name = "numericUpDownDeadZone";
            this.numericUpDownDeadZone.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownDeadZone.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(495, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 106;
            this.label5.Text = "Deadzone";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDownScrollSpeed
            // 
            this.numericUpDownScrollSpeed.DecimalPlaces = 2;
            this.numericUpDownScrollSpeed.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownScrollSpeed.Location = new System.Drawing.Point(678, 198);
            this.numericUpDownScrollSpeed.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownScrollSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownScrollSpeed.Name = "numericUpDownScrollSpeed";
            this.numericUpDownScrollSpeed.Size = new System.Drawing.Size(120, 26);
            this.numericUpDownScrollSpeed.TabIndex = 7;
            this.numericUpDownScrollSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(674, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 108;
            this.label6.Text = "Scroll Speed";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(960, 336);
            this.Controls.Add(this.numericUpDownScrollSpeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownDeadZone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownMouseAcceleration);
            this.Controls.Add(this.numericUpDownMouseSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMnK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbController);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map Controller to Key/Mouse";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMouseSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMouseAcceleration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDeadZone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScrollSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbController;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMnK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMouseSpeed;
        private System.Windows.Forms.NumericUpDown numericUpDownMouseAcceleration;
        private System.Windows.Forms.NumericUpDown numericUpDownDeadZone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownScrollSpeed;
        private System.Windows.Forms.Label label6;
    }
}

