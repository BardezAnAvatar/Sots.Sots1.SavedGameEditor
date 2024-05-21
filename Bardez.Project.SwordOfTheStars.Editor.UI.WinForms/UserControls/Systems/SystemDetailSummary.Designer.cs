namespace Bardez.Project.SwordOfTheStars.Editor.UI.WinForms.UserControls
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
            labelSystemId = new System.Windows.Forms.Label();
            textBoxSystemId = new System.Windows.Forms.TextBox();
            labelName = new System.Windows.Forms.Label();
            textBoxName = new System.Windows.Forms.TextBox();
            labelColor = new System.Windows.Forms.Label();
            buttonColor = new System.Windows.Forms.Button();
            colorDialogColor = new System.Windows.Forms.ColorDialog();
            labelSize = new System.Windows.Forms.Label();
            textBoxSize = new System.Windows.Forms.TextBox();
            groupBoxCoords = new System.Windows.Forms.GroupBox();
            textBoxZ = new System.Windows.Forms.TextBox();
            labelZ = new System.Windows.Forms.Label();
            textBoxY = new System.Windows.Forms.TextBox();
            labelY = new System.Windows.Forms.Label();
            textBoxX = new System.Windows.Forms.TextBox();
            labelX = new System.Windows.Forms.Label();
            groupBoxCoords.SuspendLayout();
            SuspendLayout();
            // 
            // labelSystemId
            // 
            labelSystemId.AutoSize = true;
            labelSystemId.Location = new System.Drawing.Point(5, 25);
            labelSystemId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSystemId.Name = "labelSystemId";
            labelSystemId.Size = new System.Drawing.Size(59, 15);
            labelSystemId.TabIndex = 0;
            labelSystemId.Text = "System ID";
            // 
            // textBoxSystemId
            // 
            textBoxSystemId.Location = new System.Drawing.Point(72, 21);
            textBoxSystemId.Margin = new System.Windows.Forms.Padding(4);
            textBoxSystemId.Name = "textBoxSystemId";
            textBoxSystemId.Size = new System.Drawing.Size(41, 23);
            textBoxSystemId.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new System.Drawing.Point(121, 25);
            labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelName.Name = "labelName";
            labelName.Size = new System.Drawing.Size(39, 15);
            labelName.TabIndex = 2;
            labelName.Text = "Name";
            // 
            // textBoxName
            // 
            textBoxName.Location = new System.Drawing.Point(168, 21);
            textBoxName.Margin = new System.Windows.Forms.Padding(4);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new System.Drawing.Size(297, 23);
            textBoxName.TabIndex = 3;
            // 
            // labelColor
            // 
            labelColor.AutoSize = true;
            labelColor.Location = new System.Drawing.Point(473, 25);
            labelColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelColor.Name = "labelColor";
            labelColor.Size = new System.Drawing.Size(36, 15);
            labelColor.TabIndex = 4;
            labelColor.Text = "Color";
            // 
            // buttonColor
            // 
            buttonColor.Location = new System.Drawing.Point(511, 21);
            buttonColor.Margin = new System.Windows.Forms.Padding(4);
            buttonColor.Name = "buttonColor";
            buttonColor.Size = new System.Drawing.Size(23, 23);
            buttonColor.TabIndex = 5;
            buttonColor.UseVisualStyleBackColor = false;
            buttonColor.Click += buttonColor_Click;
            // 
            // colorDialogColor
            // 
            colorDialogColor.AnyColor = true;
            colorDialogColor.FullOpen = true;
            // 
            // labelSize
            // 
            labelSize.AutoSize = true;
            labelSize.Location = new System.Drawing.Point(548, 25);
            labelSize.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelSize.Name = "labelSize";
            labelSize.Size = new System.Drawing.Size(27, 15);
            labelSize.TabIndex = 6;
            labelSize.Text = "Size";
            // 
            // textBoxSize
            // 
            textBoxSize.Location = new System.Drawing.Point(579, 21);
            textBoxSize.Margin = new System.Windows.Forms.Padding(4);
            textBoxSize.Name = "textBoxSize";
            textBoxSize.Size = new System.Drawing.Size(24, 23);
            textBoxSize.TabIndex = 7;
            // 
            // groupBoxCoords
            // 
            groupBoxCoords.Controls.Add(textBoxZ);
            groupBoxCoords.Controls.Add(labelZ);
            groupBoxCoords.Controls.Add(textBoxY);
            groupBoxCoords.Controls.Add(labelY);
            groupBoxCoords.Controls.Add(textBoxX);
            groupBoxCoords.Controls.Add(labelX);
            groupBoxCoords.Location = new System.Drawing.Point(613, 3);
            groupBoxCoords.Margin = new System.Windows.Forms.Padding(4);
            groupBoxCoords.Name = "groupBoxCoords";
            groupBoxCoords.Padding = new System.Windows.Forms.Padding(4);
            groupBoxCoords.Size = new System.Drawing.Size(313, 48);
            groupBoxCoords.TabIndex = 8;
            groupBoxCoords.TabStop = false;
            groupBoxCoords.Text = "Coordinates";
            // 
            // textBoxZ
            // 
            textBoxZ.Location = new System.Drawing.Point(229, 18);
            textBoxZ.Margin = new System.Windows.Forms.Padding(4);
            textBoxZ.Name = "textBoxZ";
            textBoxZ.Size = new System.Drawing.Size(80, 23);
            textBoxZ.TabIndex = 5;
            // 
            // labelZ
            // 
            labelZ.AutoSize = true;
            labelZ.Location = new System.Drawing.Point(211, 22);
            labelZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelZ.Name = "labelZ";
            labelZ.Size = new System.Drawing.Size(14, 15);
            labelZ.TabIndex = 4;
            labelZ.Text = "Z";
            // 
            // textBoxY
            // 
            textBoxY.Location = new System.Drawing.Point(125, 18);
            textBoxY.Margin = new System.Windows.Forms.Padding(4);
            textBoxY.Name = "textBoxY";
            textBoxY.Size = new System.Drawing.Size(80, 23);
            textBoxY.TabIndex = 3;
            // 
            // labelY
            // 
            labelY.AutoSize = true;
            labelY.Location = new System.Drawing.Point(107, 22);
            labelY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelY.Name = "labelY";
            labelY.Size = new System.Drawing.Size(14, 15);
            labelY.TabIndex = 2;
            labelY.Text = "Y";
            // 
            // textBoxX
            // 
            textBoxX.Location = new System.Drawing.Point(22, 18);
            textBoxX.Margin = new System.Windows.Forms.Padding(4);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new System.Drawing.Size(80, 23);
            textBoxX.TabIndex = 1;
            // 
            // labelX
            // 
            labelX.AutoSize = true;
            labelX.Location = new System.Drawing.Point(4, 22);
            labelX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelX.Name = "labelX";
            labelX.Size = new System.Drawing.Size(14, 15);
            labelX.TabIndex = 0;
            labelX.Text = "X";
            // 
            // SystemDetailSummary
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(groupBoxCoords);
            Controls.Add(textBoxSize);
            Controls.Add(labelSize);
            Controls.Add(buttonColor);
            Controls.Add(labelColor);
            Controls.Add(textBoxName);
            Controls.Add(labelName);
            Controls.Add(textBoxSystemId);
            Controls.Add(labelSystemId);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "SystemDetailSummary";
            Size = new System.Drawing.Size(926, 56);
            groupBoxCoords.ResumeLayout(false);
            groupBoxCoords.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
