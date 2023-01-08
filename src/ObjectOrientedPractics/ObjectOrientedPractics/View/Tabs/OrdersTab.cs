using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Model.Orders;

namespace ObjectOrientedPractics.View.Tabs
{
    public partial class OrdersTab : UserControl
    {
        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Коллекция покупателей.
        /// </summary>
        private List<Customer> _customers;

        private List<Order> _orders;

        private Order _currentOrder;

        private PriorityOrder _currentPriorityOrder;

        private string[] _deliveryTime =
        {
            "9:00 - 11:00",
            "11:00 - 13:00",
            "13:00 - 15:00",
            "15:00 - 17:00",
            "17:00 - 19:00",
            "19:00 - 21:00"
        };

        public OrdersTab()
        {
            InitializeComponent();
            _orders = new List<Order>();
            var orderStatusValues = Enum.GetValues(typeof(OrderStatus));

            foreach (var value in orderStatusValues)
            {
                StatusComboBox.Items.Add(value);
            }

            foreach (var time in _deliveryTime)
            {
                DeliveryTimeComboBox.Items.Add(time);
            }

            StatusComboBox.Enabled = false;
            PriorityOptionsPanel.Visible = false;
        }

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

                if (_customers != null) UpdateOrders();
            }
        }

        public void RefreshData()
        {
            OrdersDataGridView.Rows.Clear();
            _orders = new List<Order>();
            UpdateOrders();
        }

        private void UpdateOrders()
        {
            foreach (var customer in _customers)
            {
                Address address = customer.Address;
                string fullAddress = $"{address.Index}, {address.Country}, " +
                                     $"{address.City}," + $" {address.Street}, " +
                                     $"{address.Building}, {address.Apartament}";

                foreach (var order in customer.Orders)
                {
                    _orders.Add(order);
                    OrdersDataGridView.Rows.Add
                        (order.OrdersId.ToString(), order.Total.ToString(), 
                            order.DateOfCreate, order.Status, customer.FullName, 
                            fullAddress, order.Amount.ToString());
                }
            }
        }

        private void SetValueInTextBoxes()
        {
            StatusComboBox.Enabled = true;
            IDTextBox.Text = _currentOrder.OrdersId.ToString();
            CreatedTextBox.Text = _currentOrder.DateOfCreate;
            StatusComboBox.SelectedIndex = (int) _currentOrder.Status;
            AddressControl.Address = _currentOrder.DeliveryAddress;
            AmountDigitLabel.Text = _currentOrder.Amount.ToString();
            TotalAmountDigitLabel.Text = _currentOrder.Total.ToString();
            OrderItemsListBox.Items.Clear();

            foreach (var item in _currentOrder.Items)
            {
                OrderItemsListBox.Items.Add(item.Name);
            }

            if (_currentOrder is PriorityOrder priority)
            {
                DeliveryTimeComboBox.SelectedIndex = 
                    Array.IndexOf(_deliveryTime, _currentPriorityOrder.DeliveryTime);
            }
        }

        private void OrdersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int index = OrdersDataGridView.CurrentCell.RowIndex;

            if (index == -1)
            {
                return;
            }

            _currentOrder = _orders[index];

            if (_currentOrder is PriorityOrder priority)
            {
                _currentPriorityOrder = (PriorityOrder) _orders[index];
                PriorityOptionsPanel.Visible = true;
            }
            else
            {
                PriorityOptionsPanel.Visible = false;
                _currentPriorityOrder = null;
            }

            SetValueInTextBoxes();
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = OrdersDataGridView.CurrentCell.RowIndex;
            _currentOrder.Status = (OrderStatus) StatusComboBox.SelectedIndex;
            OrdersDataGridView.Rows[index].Cells[3].Value = 
                (OrderStatus) StatusComboBox.SelectedIndex;
        }

        private void DeliveryTimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPriorityOrder.DeliveryTime = (string) DeliveryTimeComboBox.SelectedItem;
        }

        private void PriorityOptionsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
