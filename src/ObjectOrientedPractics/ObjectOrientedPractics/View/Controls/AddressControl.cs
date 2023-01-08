using System;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.View.Controls
{
    public partial class AddressControl : UserControl
    {
        /// <summary>
        /// Создаёт всплывающую подсказку.
        /// </summary>
        private ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Адрес.
        /// </summary>
        private Address _address;

        /// <summary>
        /// Только для чтения.
        /// </summary>
        private bool _readOnly;

        /// <summary>
        /// Создает экземпляр класса <see cref="AddressControl"/>.
        /// </summary>
        public AddressControl()
        {
            _address = new Address();
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает и задает адрес.
        /// </summary>
        public Address Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                SetValuesTextBoxes();
            }
        }

        /// <summary>
        /// Устанавливает 
        /// </summary>
        private void SetValuesTextBoxes()
        {
            PostIndexTextBox.Text = _address.Index.ToString();
            CountryTextBox.Text = _address.Country;
            CityTextBox.Text = _address.City;
            StreetTextBox.Text = _address.Street;
            BuildingTextBox.Text = _address.Building;
            ApartamentTextBox.Text = _address.Apartament;
        }

        private void PostIndexTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Index = Int32.Parse(PostIndexTextBox.Text);
                PostIndexTextBox.BackColor = AppColor.CorrectColor;
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(PostIndexTextBox, exception.Message);
                PostIndexTextBox.BackColor = AppColor.WrongColor;
            }
        }

        private void CountryTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Country = CountryTextBox.Text;
                CountryTextBox.BackColor = AppColor.CorrectColor;
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(CountryTextBox, exception.Message);
                CountryTextBox.BackColor = AppColor.WrongColor;
            }
        }

        private void CityTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.City = CityTextBox.Text;
                CityTextBox.BackColor = AppColor.CorrectColor;

            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(CityTextBox, exception.Message);
                CityTextBox.BackColor = AppColor.WrongColor;
            }
        }

        private void StreetTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Street = StreetTextBox.Text;
                StreetTextBox.BackColor = AppColor.CorrectColor;

            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(StreetTextBox, exception.Message);
                StreetTextBox.BackColor = AppColor.WrongColor;
            }
        }

        private void BuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Building = BuildingTextBox.Text;
                BuildingTextBox.BackColor = AppColor.CorrectColor;

            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(BuildingTextBox, exception.Message);
                BuildingTextBox.BackColor = AppColor.WrongColor;
            }
        }

        private void ApartamentTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Address.Apartament = ApartamentTextBox.Text;
                ApartamentTextBox.BackColor = AppColor.CorrectColor;

            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(ApartamentTextBox, exception.Message);
                ApartamentTextBox.BackColor = AppColor.WrongColor;
            }
        }

        public void Clear()
        {
            PostIndexTextBox.Clear();
            CountryTextBox.Clear();
            CityTextBox.Clear();
            StreetTextBox.Clear();
            BuildingTextBox.Clear();
            ApartamentTextBox.Clear();
            PostIndexTextBox.BackColor = AppColor.CorrectColor;
        }
    }
}
