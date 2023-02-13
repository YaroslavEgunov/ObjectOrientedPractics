
namespace Programming.View.Controls
{
    partial class RectanglesCollisionControl
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
            this.DeletePictureBox = new System.Windows.Forms.PictureBox();
            this.AddPictureBox = new System.Windows.Forms.PictureBox();
            this.HeightPanelTextBox = new System.Windows.Forms.TextBox();
            this.RectanglesPanelListBox = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.IdPanelTextBox = new System.Windows.Forms.TextBox();
            this.WidthPanelTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.YPanelTextBox = new System.Windows.Forms.TextBox();
            this.XPanelTextBox = new System.Windows.Forms.TextBox();
            this.RectanglePanel = new System.Windows.Forms.Panel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DeletePictureBox
            // 
            this.DeletePictureBox.Image = global::Programming.Properties.Resources.rectangle_remove_uncolor;
            this.DeletePictureBox.Location = new System.Drawing.Point(149, 199);
            this.DeletePictureBox.Name = "DeletePictureBox";
            this.DeletePictureBox.Size = new System.Drawing.Size(62, 49);
            this.DeletePictureBox.TabIndex = 39;
            this.DeletePictureBox.TabStop = false;
            this.DeletePictureBox.Click += new System.EventHandler(this.DeletePictureBox_Click);
            this.DeletePictureBox.MouseEnter += new System.EventHandler(this.DeletePictureBox_MouseEnter);
            this.DeletePictureBox.MouseLeave += new System.EventHandler(this.DeletePictureBox_MouseLeave);
            // 
            // AddPictureBox
            // 
            this.AddPictureBox.Image = global::Programming.Properties.Resources.rectangle_add__uncolor;
            this.AddPictureBox.Location = new System.Drawing.Point(34, 199);
            this.AddPictureBox.Name = "AddPictureBox";
            this.AddPictureBox.Size = new System.Drawing.Size(62, 49);
            this.AddPictureBox.TabIndex = 38;
            this.AddPictureBox.TabStop = false;
            this.AddPictureBox.Click += new System.EventHandler(this.AddPictureBox_Click);
            this.AddPictureBox.MouseEnter += new System.EventHandler(this.AddPictureBox_MouseEnter);
            this.AddPictureBox.MouseLeave += new System.EventHandler(this.AddPictureBox_MouseLeave);
            // 
            // HeightPanelTextBox
            // 
            this.HeightPanelTextBox.Location = new System.Drawing.Point(57, 332);
            this.HeightPanelTextBox.Name = "HeightPanelTextBox";
            this.HeightPanelTextBox.Size = new System.Drawing.Size(120, 20);
            this.HeightPanelTextBox.TabIndex = 28;
            this.HeightPanelTextBox.TextChanged += new System.EventHandler(this.HeightPanelTextBox_TextChanged);
            // 
            // RectanglesPanelListBox
            // 
            this.RectanglesPanelListBox.FormattingEnabled = true;
            this.RectanglesPanelListBox.Location = new System.Drawing.Point(12, 7);
            this.RectanglesPanelListBox.Name = "RectanglesPanelListBox";
            this.RectanglesPanelListBox.Size = new System.Drawing.Size(221, 186);
            this.RectanglesPanelListBox.TabIndex = 37;
            this.RectanglesPanelListBox.SelectedIndexChanged += new System.EventHandler(this.RectanglesPanelListBox_SelectedIndexChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 335);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 13);
            this.label19.TabIndex = 29;
            this.label19.Text = "Heigth: ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 257);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 13);
            this.label15.TabIndex = 36;
            this.label15.Text = "lD: ";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 361);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 13);
            this.label18.TabIndex = 30;
            this.label18.Text = "Width: ";
            // 
            // IdPanelTextBox
            // 
            this.IdPanelTextBox.Location = new System.Drawing.Point(57, 254);
            this.IdPanelTextBox.Name = "IdPanelTextBox";
            this.IdPanelTextBox.ReadOnly = true;
            this.IdPanelTextBox.Size = new System.Drawing.Size(120, 20);
            this.IdPanelTextBox.TabIndex = 35;
            // 
            // WidthPanelTextBox
            // 
            this.WidthPanelTextBox.Location = new System.Drawing.Point(57, 358);
            this.WidthPanelTextBox.Name = "WidthPanelTextBox";
            this.WidthPanelTextBox.Size = new System.Drawing.Size(120, 20);
            this.WidthPanelTextBox.TabIndex = 27;
            this.WidthPanelTextBox.TextChanged += new System.EventHandler(this.WidthPanelTextBox_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(31, 309);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 13);
            this.label16.TabIndex = 34;
            this.label16.Text = "Y: ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(31, 283);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(20, 13);
            this.label17.TabIndex = 33;
            this.label17.Text = "X: ";
            // 
            // YPanelTextBox
            // 
            this.YPanelTextBox.Location = new System.Drawing.Point(57, 306);
            this.YPanelTextBox.Name = "YPanelTextBox";
            this.YPanelTextBox.Size = new System.Drawing.Size(120, 20);
            this.YPanelTextBox.TabIndex = 32;
            this.YPanelTextBox.TextChanged += new System.EventHandler(this.YPanelTextBox_TextChanged);
            // 
            // XPanelTextBox
            // 
            this.XPanelTextBox.Location = new System.Drawing.Point(57, 280);
            this.XPanelTextBox.Name = "XPanelTextBox";
            this.XPanelTextBox.Size = new System.Drawing.Size(120, 20);
            this.XPanelTextBox.TabIndex = 31;
            this.XPanelTextBox.TextChanged += new System.EventHandler(this.XPanelTextBox_TextChanged);
            // 
            // RectanglePanel
            // 
            this.RectanglePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RectanglePanel.Location = new System.Drawing.Point(239, 7);
            this.RectanglePanel.Name = "RectanglePanel";
            this.RectanglePanel.Size = new System.Drawing.Size(487, 419);
            this.RectanglePanel.TabIndex = 26;
            // 
            // RectanglesCollisionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DeletePictureBox);
            this.Controls.Add(this.AddPictureBox);
            this.Controls.Add(this.HeightPanelTextBox);
            this.Controls.Add(this.RectanglesPanelListBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.IdPanelTextBox);
            this.Controls.Add(this.WidthPanelTextBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.YPanelTextBox);
            this.Controls.Add(this.XPanelTextBox);
            this.Controls.Add(this.RectanglePanel);
            this.Name = "RectanglesCollisionControl";
            this.Size = new System.Drawing.Size(734, 433);
            ((System.ComponentModel.ISupportInitialize)(this.DeletePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox DeletePictureBox;
        private System.Windows.Forms.PictureBox AddPictureBox;
        private System.Windows.Forms.TextBox HeightPanelTextBox;
        private System.Windows.Forms.ListBox RectanglesPanelListBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox IdPanelTextBox;
        private System.Windows.Forms.TextBox WidthPanelTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox YPanelTextBox;
        private System.Windows.Forms.TextBox XPanelTextBox;
        private System.Windows.Forms.Panel RectanglePanel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
