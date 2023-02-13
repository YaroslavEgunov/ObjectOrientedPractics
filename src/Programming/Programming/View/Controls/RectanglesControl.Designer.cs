
namespace Programming.View.Controls
{
    partial class RectanglesControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RectanglesGroupBox = new System.Windows.Forms.GroupBox();
            this.CollisionLabel = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.CoordinateYTextBox = new System.Windows.Forms.TextBox();
            this.CoordinateXTextBox = new System.Windows.Forms.TextBox();
            this.FindRectangleButton = new System.Windows.Forms.Button();
            this.ColorTextBox = new System.Windows.Forms.TextBox();
            this.LengthTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.RectanglesListBoxInClasses = new System.Windows.Forms.ListBox();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.LenghtLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.RectanglesGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // RectanglesGroupBox
            // 
            this.RectanglesGroupBox.Controls.Add(this.CollisionLabel);
            this.RectanglesGroupBox.Controls.Add(this.Label13);
            this.RectanglesGroupBox.Controls.Add(this.IDTextBox);
            this.RectanglesGroupBox.Controls.Add(this.label12);
            this.RectanglesGroupBox.Controls.Add(this.label11);
            this.RectanglesGroupBox.Controls.Add(this.CoordinateYTextBox);
            this.RectanglesGroupBox.Controls.Add(this.CoordinateXTextBox);
            this.RectanglesGroupBox.Controls.Add(this.FindRectangleButton);
            this.RectanglesGroupBox.Controls.Add(this.ColorTextBox);
            this.RectanglesGroupBox.Controls.Add(this.LengthTextBox);
            this.RectanglesGroupBox.Controls.Add(this.label8);
            this.RectanglesGroupBox.Controls.Add(this.WidthTextBox);
            this.RectanglesGroupBox.Controls.Add(this.RectanglesListBoxInClasses);
            this.RectanglesGroupBox.Controls.Add(this.WidthLabel);
            this.RectanglesGroupBox.Controls.Add(this.LenghtLabel);
            this.RectanglesGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RectanglesGroupBox.Name = "RectanglesGroupBox";
            this.RectanglesGroupBox.Size = new System.Drawing.Size(348, 422);
            this.RectanglesGroupBox.TabIndex = 2;
            this.RectanglesGroupBox.TabStop = false;
            this.RectanglesGroupBox.Text = "Rectangles";
            // 
            // CollisionLabel
            // 
            this.CollisionLabel.AutoSize = true;
            this.CollisionLabel.Location = new System.Drawing.Point(6, 313);
            this.CollisionLabel.Name = "CollisionLabel";
            this.CollisionLabel.Size = new System.Drawing.Size(41, 13);
            this.CollisionLabel.TabIndex = 13;
            this.CollisionLabel.Text = "label14";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(158, 21);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(23, 13);
            this.Label13.TabIndex = 12;
            this.Label13.Text = "lD: ";
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(161, 36);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.ReadOnly = true;
            this.IDTextBox.Size = new System.Drawing.Size(120, 20);
            this.IDTextBox.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(158, 264);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Center (Y coordinate): ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(158, 215);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(113, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Center (X coordinate): ";
            // 
            // CoordinateYTextBox
            // 
            this.CoordinateYTextBox.Location = new System.Drawing.Point(161, 280);
            this.CoordinateYTextBox.Name = "CoordinateYTextBox";
            this.CoordinateYTextBox.ReadOnly = true;
            this.CoordinateYTextBox.Size = new System.Drawing.Size(120, 20);
            this.CoordinateYTextBox.TabIndex = 8;
            // 
            // CoordinateXTextBox
            // 
            this.CoordinateXTextBox.Location = new System.Drawing.Point(161, 231);
            this.CoordinateXTextBox.Name = "CoordinateXTextBox";
            this.CoordinateXTextBox.ReadOnly = true;
            this.CoordinateXTextBox.Size = new System.Drawing.Size(120, 20);
            this.CoordinateXTextBox.TabIndex = 7;
            // 
            // FindRectangleButton
            // 
            this.FindRectangleButton.Location = new System.Drawing.Point(6, 278);
            this.FindRectangleButton.Name = "FindRectangleButton";
            this.FindRectangleButton.Size = new System.Drawing.Size(123, 23);
            this.FindRectangleButton.TabIndex = 6;
            this.FindRectangleButton.Text = "Find";
            this.FindRectangleButton.UseVisualStyleBackColor = true;
            this.FindRectangleButton.TextChanged += new System.EventHandler(this.FindRectangleButton_Click);
            this.FindRectangleButton.Click += new System.EventHandler(this.FindRectangleButton_Click);
            // 
            // ColorTextBox
            // 
            this.ColorTextBox.Location = new System.Drawing.Point(161, 178);
            this.ColorTextBox.Name = "ColorTextBox";
            this.ColorTextBox.Size = new System.Drawing.Size(120, 20);
            this.ColorTextBox.TabIndex = 2;
            this.ColorTextBox.TextChanged += new System.EventHandler(this.ColorTextBox_TextChanged);
            // 
            // LengthTextBox
            // 
            this.LengthTextBox.Location = new System.Drawing.Point(161, 81);
            this.LengthTextBox.Name = "LengthTextBox";
            this.LengthTextBox.Size = new System.Drawing.Size(120, 20);
            this.LengthTextBox.TabIndex = 1;
            this.LengthTextBox.TextChanged += new System.EventHandler(this.LengthTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Color: ";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(161, 126);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(120, 20);
            this.WidthTextBox.TabIndex = 0;
            this.WidthTextBox.TextChanged += new System.EventHandler(this.WidthTextBox_TextChanged);
            // 
            // RectanglesListBoxInClasses
            // 
            this.RectanglesListBoxInClasses.FormattingEnabled = true;
            this.RectanglesListBoxInClasses.IntegralHeight = false;
            this.RectanglesListBoxInClasses.Location = new System.Drawing.Point(6, 20);
            this.RectanglesListBoxInClasses.Name = "RectanglesListBoxInClasses";
            this.RectanglesListBoxInClasses.Size = new System.Drawing.Size(123, 231);
            this.RectanglesListBoxInClasses.TabIndex = 0;
            this.RectanglesListBoxInClasses.SelectedIndexChanged += new System.EventHandler(this.RectanglesListBox_SelectedIndexChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(158, 110);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(41, 13);
            this.WidthLabel.TabIndex = 4;
            this.WidthLabel.Text = "Width: ";
            // 
            // LenghtLabel
            // 
            this.LenghtLabel.AutoSize = true;
            this.LenghtLabel.Location = new System.Drawing.Point(158, 65);
            this.LenghtLabel.Name = "LenghtLabel";
            this.LenghtLabel.Size = new System.Drawing.Size(46, 13);
            this.LenghtLabel.TabIndex = 3;
            this.LenghtLabel.Text = "Length: ";
            // 
            // RectanglesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RectanglesGroupBox);
            this.Name = "RectanglesControl";
            this.Size = new System.Drawing.Size(355, 445);
            this.RectanglesGroupBox.ResumeLayout(false);
            this.RectanglesGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox RectanglesGroupBox;
        private System.Windows.Forms.Label CollisionLabel;
        private System.Windows.Forms.Label Label13;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox CoordinateYTextBox;
        private System.Windows.Forms.TextBox CoordinateXTextBox;
        private System.Windows.Forms.Button FindRectangleButton;
        private System.Windows.Forms.TextBox ColorTextBox;
        private System.Windows.Forms.TextBox LengthTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.ListBox RectanglesListBoxInClasses;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label LenghtLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
