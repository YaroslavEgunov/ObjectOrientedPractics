using Programming.Model.Classes;
using Programming.Model.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = Programming.Model.Geometry.Rectangle;

namespace Programming.View.Controls
{
    /// <summary>
    /// Показывает на холсте прямоугольники и проверяет на пересечение.
    /// </summary>
    public partial class RectanglesCollisionControl : UserControl
    {
        /// <summary>
        /// Список прямоугольников.
        /// </summary>
        private List<Rectangle> _rectangles = new List<Rectangle>();

        /// <summary>
        /// Хранит данные о выбранном прямоугольнике.
        /// </summary>
        private Rectangle _currentRectangle = new Rectangle();

        /// <summary>
        /// Список прямоугольников для холста.
        /// </summary>
        private List<Panel> _rectanglesPanel = new List<Panel>();

        public RectanglesCollisionControl()
        {
            Rectangle._allRectanglesCount = 1; 
            InitializeComponent();
            FindCollisions();
        }

        /// <summary>
        /// Очищает все значения TextBoх и меняет цвет на стандартный. 
        /// </summary>
        private void ClearRectangleInfo()
        {
            _currentRectangle = null;
            IdPanelTextBox.Text = "";
            XPanelTextBox.Text = "";
            YPanelTextBox.Text = "";
            WidthPanelTextBox.Text = "";
            HeightPanelTextBox.Text = "";
            HeightPanelTextBox.BackColor = AppColors.CorrectColor;
            XPanelTextBox.BackColor = AppColors.CorrectColor;
            YPanelTextBox.BackColor = AppColors.CorrectColor;
            WidthPanelTextBox.BackColor = AppColors.CorrectColor;
        }

        /// <summary>
        /// Обновляет информацию о прямоугольнике во всех TextBox.
        /// </summary>
        /// <param name="rectangle"></param>
        private void UpdateRectangleInfo(Rectangle rectangle)
        {
            _currentRectangle = rectangle;
            IdPanelTextBox.Text = _currentRectangle.Id.ToString();
            XPanelTextBox.Text = _currentRectangle.Center.X.ToString();
            YPanelTextBox.Text = _currentRectangle.Center.Y.ToString();
            WidthPanelTextBox.Text = _currentRectangle.Width.ToString();
            HeightPanelTextBox.Text = _currentRectangle.Length.ToString();
        }

        private void AddPictureBox_MouseEnter(object sender, EventArgs e)
        {
            AddPictureBox.Image = Properties.Resources.rectangle_add;
        }

        private void AddPictureBox_MouseLeave(object sender, EventArgs e)
        {
            AddPictureBox.Image = Properties.Resources.rectangle_add__uncolor;
        }

        private void DeletePictureBox_MouseEnter(object sender, EventArgs e)
        {
            DeletePictureBox.Image = Properties.Resources.rectangle_remove;
        }

        private void DeletePictureBox_MouseLeave(object sender, EventArgs e)
        {
            DeletePictureBox.Image = Properties.Resources.rectangle_remove_uncolor;
        }

        /// <summary>
        /// Проверяет прямоугольники на пересечение.
        /// </summary>
        private void FindCollisions()
        {
            for (int i = 0; i < _rectanglesPanel.Count; i++)
            {
                _rectanglesPanel[i].BackColor = AppColors.CorrectColorPanel;
            }
            for (int i = 0; i < _rectanglesPanel.Count; i++)
            {
                for (int j = i + 1; j < _rectanglesPanel.Count; j++)
                {
                    if (CollisionManager.IsCollision(_rectangles[i], _rectangles[j]))
                    {
                        _rectanglesPanel[i].BackColor = AppColors.WrongColorPanel;
                        _rectanglesPanel[j].BackColor = AppColors.WrongColorPanel;
                    }
                }
            }
        }

        /// <summary>
        /// Создаёт объект типа Panel, добавляет на холст.
        /// </summary>
        /// <param name="rectangle">Прямоугольник, 
        /// на основе которого создаётся прямоугольник для холста.</param>
        private void NewPanel(Rectangle rectangle)
        {
            Panel panel = new Panel();
            panel.BackColor = AppColors.CorrectColorPanel;
            panel.Location = new Point(
                (int)rectangle.Center.X,
                (int)rectangle.Center.Y);
            panel.Width = (int)rectangle.Width;
            panel.Height = (int)rectangle.Length;
            _rectanglesPanel.Add(panel);
            RectanglePanel.Controls.Add(panel);
        }

        /// <summary>
        /// Предоставляет информацию о прямоугольнике.
        /// </summary>
        /// <returns>Возвращает сроку с обновлёнными данными.</returns>
        private string GetRectangleInfo()
        {
            return $"{_currentRectangle.Id}:" +
                $"(X = {_currentRectangle.Center.X};" +
                $"Y = {_currentRectangle.Center.Y};" +
                $"W = {_currentRectangle.Width};" +
                $"H = {_currentRectangle.Length})";
        }

        /// <summary>
        /// Обновляет информацию о прямоугольнике на холсте.
        /// </summary>
        /// <param name="panel"></param>
        private void UpdatePanel(Panel panel)
        {
            panel.BackColor = AppColors.CorrectColorPanel;
            panel.Location = new Point(
                (int)_currentRectangle.Center.X,
                (int)_currentRectangle.Center.Y);
            panel.Width = (int)_currentRectangle.Width;
            panel.Height = (int)_currentRectangle.Length;
        }

        /// <summary>
        /// Инициализирует список 5 прямоугольников.
        /// </summary>
        private void AddPictureBox_Click(object sender, EventArgs e)
        {
            RectangleFactory.RandomizeList(_rectangles);
            _currentRectangle = _rectangles[_rectangles.Count - 1];
            RectanglesPanelListBox.Items.Add(GetRectangleInfo());
            NewPanel(_currentRectangle);
            FindCollisions();
        }

        private void DeletePictureBox_Click(object sender, EventArgs e)
        {
            if (_currentRectangle == null || RectanglesPanelListBox.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                _rectangles.RemoveAt(RectanglesPanelListBox.SelectedIndex);
                _rectanglesPanel.RemoveAt(RectanglesPanelListBox.SelectedIndex);
                RectanglePanel.Controls.RemoveAt(RectanglesPanelListBox.SelectedIndex);
                RectanglesPanelListBox.Items.RemoveAt(RectanglesPanelListBox.SelectedIndex);
                if (RectanglesPanelListBox.Items.Count > 0)
                {
                    RectanglesPanelListBox.SelectedIndex = 0;
                }
            }
            FindCollisions();
        }

        private void RectanglesPanelListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RectanglesPanelListBox.SelectedIndex == -1)
            {
                ClearRectangleInfo();
            }
            else
            {
                _currentRectangle = _rectangles[RectanglesPanelListBox.SelectedIndex];
                UpdateRectangleInfo(_currentRectangle);
            }
        }

        private void UpdatePanelListBox()
        {
            RectanglesPanelListBox.Items[RectanglesPanelListBox.SelectedIndex] =
                    GetRectangleInfo();
        }

        private void HeightPanelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentRectangle == null)
            {
                return;
            }
            try
            {
                _currentRectangle.Length = Convert.ToInt32(HeightPanelTextBox.Text);
                HeightPanelTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(HeightPanelTextBox, "");
                UpdateRectangleInfo(_currentRectangle);
                UpdatePanelListBox();
                UpdatePanel(_rectanglesPanel[RectanglesPanelListBox.SelectedIndex]);
                FindCollisions();
            }
            catch (Exception exception)
            {
                Validator.AssertOnPositiveValue(_currentRectangle.Length,
                                                nameof(HeightPanelTextBox));
                HeightPanelTextBox.BackColor = AppColors.WrongColor;
                toolTip.SetToolTip(HeightPanelTextBox, exception.Message);
                return;
            }
        }

        private void XPanelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentRectangle == null)
            {
                return;
            }
            try
            {
                _currentRectangle.Center.X = Int32.Parse(XPanelTextBox.Text);
                XPanelTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(XPanelTextBox, "");
                UpdateRectangleInfo(_currentRectangle);
                UpdatePanelListBox();
                UpdatePanel(_rectanglesPanel[RectanglesPanelListBox.SelectedIndex]);
                FindCollisions();
            }
            catch (Exception exception)
            {
                XPanelTextBox.BackColor = AppColors.WrongColor;
                toolTip.SetToolTip(XPanelTextBox, exception.Message);
                return;
            }
        }

        private void YPanelTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_currentRectangle == null)
            {
                return;
            }
            try
            {
                YPanelTextBox.BackColor = AppColors.CorrectColor;
                _currentRectangle.Center.Y = Int32.Parse(YPanelTextBox.Text);
                toolTip.SetToolTip(YPanelTextBox, "");
                UpdateRectangleInfo(_currentRectangle);
                UpdatePanelListBox();
                UpdatePanel(_rectanglesPanel[RectanglesPanelListBox.SelectedIndex]);
                FindCollisions();
            }
            catch (Exception exception)
            {
                YPanelTextBox.BackColor = AppColors.WrongColor;
                toolTip.SetToolTip(YPanelTextBox, exception.Message);
                return;
            }
        }

        private void WidthPanelTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentRectangle.Width = Convert.ToInt32(WidthPanelTextBox.Text);
                WidthPanelTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(WidthPanelTextBox, "");
                UpdateRectangleInfo(_currentRectangle);
                UpdatePanelListBox();
                UpdatePanel(_rectanglesPanel[RectanglesPanelListBox.SelectedIndex]);
                FindCollisions();
            }
            catch (Exception exception)
            {
                toolTip.SetToolTip(WidthPanelTextBox, exception.Message);
                WidthPanelTextBox.BackColor = AppColors.WrongColor;
                return;
            }
        }
    }
}
