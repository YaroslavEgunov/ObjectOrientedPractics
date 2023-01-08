using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using ObjectOrientedPractics.Model.Orders;
using ObjectOrientedPractics.Services;
using ObjectOrientedPractics.View.Forms;
using Color = ObjectOrientedPractics.Services.AppColor;

namespace ObjectOrientedPractics.View.Tabs
{
    /// <summary>
    /// Представляет реализацию по представлению покупателей.
    /// </summary>
    public partial class CustomersTab : UserControl
    {
        /// <summary>
        /// Создаёт всплывающую подсказку.
        /// </summary>
        private ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Коллекция покупателей.
        /// </summary>
        private List<Customer> _customers = new List<Customer>();

        /// <summary>
        /// Выбранный покупатель.
        /// </summary>
        private Customer _currentCustomer;

        /// <summary>
        /// Создает экземпляр класса <see cref="CustomersTab"/>
        /// </summary>
        public CustomersTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Возвращает и задает коллекцию покупателей.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;

                if (_customers != null)
                {
                    UpdateListBox(-1);
                }
            }
        }

        private void UpdateDiscountsListBox()
        {
            DiscountsListBox.Items.Clear();
            
            foreach (var discount in _currentCustomer.Discounts)
            {
                DiscountsListBox.Items.Add(discount.Info);
            }
        }

        /// <summary>
        /// Обновляет данные в ListBox.
        /// </summary>
        /// <param name="selectedIndex">Выбранный элемент.</param>
        private void UpdateListBox(int selectedIndex)
        {
            CustomersListBox.Items.Clear();
            var orderedListItems = from customer in _customers
                orderby customer.FullName  
                select customer;
            _customers = orderedListItems.ToList();

            foreach (Customer customer in _customers)
            {
                CustomersListBox.Items.Add(FormattedText(customer));
            }

            CustomersListBox.SelectedIndex = selectedIndex;
        }

        /// <summary>
        /// Ищет индекс элемента по уникальному идентификатору.
        /// </summary>
        /// <returns>Возвращает индекс найденного элемента.</returns>
        private int FindIndexItemById()
        {
            var orderedListItems = from customer in _customers
                orderby customer.FullName
                select customer;
            _customers = orderedListItems.ToList();
            int currentCustomerId = _currentCustomer.Id;
            int index = -1;

            for (int i = 0; i < _customers.Count; i++)
            {
                if (_customers[i].Id != currentCustomerId) continue;

                index = i;
                break;
            }

            return index;
        }

        /// <summary>
        /// Очищает поля вывода информации.
        /// </summary>
        private void ClearCustomersInfo()
        {
            IDTextBox.Clear();
            FullNameTextBox.Clear();
            AddressControl.Clear();
            DiscountsListBox.Items.Clear();
        }

        /// <summary>
        /// Генерирует форматированный текст для отображения.
        /// </summary>
        /// <param name="customer">Покупатель.</param>
        /// <returns>Возвращает форматированный текст.</returns>
        private string FormattedText(Customer customer)
        {
            return $"{customer.FullName}";
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
            Address address = new Address
                (000000, "country", "city", "street", "building", "apartament");
            _currentCustomer = new Customer();
            _customers.Add(_currentCustomer);
            UpdateListBox(0);
        }

        private void RemoveButton_Click(object sender, System.EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _customers.RemoveAt(index);
            UpdateListBox(-1);
            ClearCustomersInfo();
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            _currentCustomer = _customers[index];
            IsPriorityCheckBox.Checked = _currentCustomer.IsPriority;
            IDTextBox.Text = _currentCustomer.Id.ToString();
            FullNameTextBox.Text = _currentCustomer.FullName;
            AddressControl.Address = _currentCustomer.Address;
            UpdateDiscountsListBox();
        }

        private void FullNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int index = CustomersListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            try
            {
                FullNameTextBox.SelectionStart = FullNameTextBox.Text.Length;
                _currentCustomer.FullName = FullNameTextBox.Text;
                int indexCustomer = FindIndexItemById();
                FullNameTextBox.BackColor = Color.CorrectColor;
                UpdateListBox(indexCustomer);
            }
            catch (Exception exception)
            {
                _toolTip.SetToolTip(FullNameTextBox, exception.Message);
                if (CustomersListBox.Items.Count != 0)
                {
                    FullNameTextBox.BackColor = Color.WrongColor;
                }
            }

        }

        private void IsPriorityCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _currentCustomer.IsPriority = IsPriorityCheckBox.Checked;
        }

        private void AddDiscountButton_Click(object sender, EventArgs e)
        {
            AddDiscountForm addDiscountForm = new AddDiscountForm();

            if (addDiscountForm.ShowDialog() == DialogResult.OK)
            {
                foreach (var discount in _currentCustomer.Discounts)
                {
                    if (discount is PointsDiscount)
                    {
                        continue;
                    }

                    if (((PercentDiscount) discount).Category ==
                        addDiscountForm.PercentDiscount.Category)
                    {
                        return;
                    }
                }

                _currentCustomer.Discounts.Add(addDiscountForm.PercentDiscount);
                UpdateDiscountsListBox();
            }
        }

        private void RemoveDiscountButton_Click(object sender, EventArgs e)
        {
            int index = DiscountsListBox.SelectedIndex;

            if (index == -1)
            {
                return;
            }

            if (index == 0)
            {
                return;
            }

            _currentCustomer.Discounts.RemoveAt(index);
            UpdateDiscountsListBox();
        }

    }
}
