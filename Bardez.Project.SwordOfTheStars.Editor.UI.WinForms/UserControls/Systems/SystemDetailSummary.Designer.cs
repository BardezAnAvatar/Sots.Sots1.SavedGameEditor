namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.User_Controls
{
    partial class SystemDetailSummary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSystemId = new System.Windows.Forms.Label();
            this.textBoxSystemId = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelColor = new System.Windows.Forms.Label();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialogColor = new System.Windows.Forms.ColorDialog();
            this.labelSize = new System.Windows.Forms.Label();
            this.textBoxSize = new System.Windows.Forms.TextBox();
            this.groupBoxCoords = new System.Windows.Forms.GroupBox();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.labelZ = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelX = new System.Windows.Forms.Label();
            this.groupBoxCoords.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSystemId
            // 
            this.labelSystemId.AutoSize = true;
            this.labelSystemId.Location = new System.Drawing.Point(4, 25);
            this.labelSystemId.Name = "labelSystemId";
            this.labelSystemId.Size = new System.Drawing.Size(55, 13);
            this.labelSystemId.TabIndex = 0;
            this.labelSystemId.Text = "System ID";
            // 
            // textBoxSystemId
            // 
            this.textBoxSystemId.Location = new System.Drawing.Point(62, 22);
            this.textBoxSystemId.Name = "textBoxSystemId";
            this.textBoxSystemId.Size = new System.Drawing.Size(43, 20);
            this.textBoxSystemId.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(115, 25);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(156, 22);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(100, 20);
            this.textBoxName.TabIndex = 3;
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.Location = new System.Drawing.Point(272, 25);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(31, 13);
            this.labelColor.TabIndex = 4;
            this.labelColor.Text = "Color";
            // 
            // buttonColor
            // 
            this.buttonColor.Location = new System.Drawing.Point(309, 21);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(20, 20);
            this.buttonColor.TabIndex = 5;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // colorDialogColor
            // 
            this.colorDialogColor.AnyColor = true;
            this.colorDialogColor.FullOpen = true;
            // 
            // labelSize
            // 
            this.labelSize.AutoSize = true;
            this.labelSize.Location = new System.Drawing.Point(340, 25);
            this.labelSize.Name = "labelSize";
            this.labelSize.Size = new System.Drawing.Size(27, 13);
            this.labelSize.TabIndex = 6;
            this.labelSize.Text = "Size";
            // 
            // textBoxSize
            // 
            this.textBoxSize.Location = new System.Drawing.Point(373, 22);
            this.textBoxSize.Name = "textBoxSize";
            this.textBoxSize.Size = new System.Drawing.Size(31, 20);
            this.textBoxSize.TabIndex = 7;
            // 
            // groupBoxCoords
            // 
            this.groupBoxCoords.Controls.Add(this.textBoxZ);
            this.groupBoxCoords.Controls.Add(this.labelZ);
            this.groupBoxCoords.Controls.Add(this.textBoxY);
            this.groupBoxCoords.Controls.Add(this.labelY);
            this.groupBoxCoords.Controls.Add(this.textBoxX);
            this.groupBoxCoords.Controls.Add(this.labelX);
            this.groupBoxCoords.Location = new System.Drawing.Point(422, 3);
            this.groupBoxCoords.Name = "groupBoxCoords";
            this.groupBoxCoords.Size = new System.Drawing.Size(331, 52);
            this.groupBoxCoords.TabIndex = 8;
            this.groupBoxCoords.TabStop = false;
            this.groupBoxCoords.Text = "Coordinates";
            // 
            // textBoxZ
            // 
            this.textBoxZ.Location = new System.Drawing.Point(244, 19);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(80, 20);
            this.textBoxZ.TabIndex = 5;
            // 
            // labelZ
            // 
            this.labelZ.AutoSize = true;
            this.labelZ.Location = new System.Drawing.Point(224, 22);
            this.labelZ.Name = "labelZ";
            this.labelZ.Size = new System.Drawing.Size(14, 13);
            this.labelZ.TabIndex = 4;
            this.labelZ.Text = "Z";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(131, 19);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(80, 20);
            this.textBoxY.TabIndex = 3;
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(111, 22);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 2;
            this.labelY.Text = "Y";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(23, 19);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(80, 20);
            this.textBoxX.TabIndex = 1;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(3, 22);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 0;
            this.labelX.Text = "X";
            // 
            // SystemDetailSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxCoords);
            this.Controls.Add(this.textBoxSize);
            this.Controls.Add(this.labelSize);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.textBoxSystemId);
            this.Controls.Add(this.labelSystemId);
            this.Name = "SystemDetailSummary";
            this.Size = new System.Drawing.Size(762, 64);
            this.groupBoxCoords.ResumeLayout(false);
            this.groupBoxCoords.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSystemId;
        private System.Windows.Forms.TextBox textBoxSystemId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Button buttonColor;
        private System.Windows.Forms.ColorDialog colorDialogColor;
        private System.Windows.Forms.Label labelSize;
        private System.Windows.Forms.TextBox textBoxSize;
        private System.Windows.Forms.GroupBox groupBoxCoords;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label labelZ;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelX;
    }
}
