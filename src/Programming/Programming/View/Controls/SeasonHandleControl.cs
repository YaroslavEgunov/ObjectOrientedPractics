using Programming.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programming.Model.Classes;

namespace Programming.View.Controls
{
    /// <summary>
    /// При нажатии на кнопку происходит действие в зависимости от выбранного времени года.
    /// </summary>
    public partial class SeasonHandleControl : UserControl
    {
        public SeasonHandleControl()
        {
            InitializeComponent();
            var values = Enum.GetValues(typeof(Seasons));
            foreach (var value in values)
            {
                ChooseSeasonComboBox.Items.Add(value);
            }
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            var item = ChooseSeasonComboBox.SelectedItem;
            if (ChooseSeasonComboBox.SelectedItem == null)
            {
                return;
            }
            switch (item)
            {
                case Seasons.Winter:
                    BackColor = AppColors.NoneColor;
                    MessageBox.Show(@"Бррр! Холодно!");
                    break;
                case Seasons.Summer:
                    BackColor = AppColors.NoneColor;
                    MessageBox.Show(@"Ура! Солнце!");
                    break;
                case Seasons.Autumn:
                    BackColor = AppColors.AutumnColor;
                    break;
                case Seasons.Spring:
                    BackColor = AppColors.SpringColor;
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
