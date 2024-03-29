﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ObjectOrientedPractics.Model;

namespace ObjectOrientedPractics.View
{
    /// <summary>
    /// Предоставляет реализацию по представлению главного окна.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Покупатели и товары.
        /// </summary>
        private Store _store;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="MainForm"/>.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _store = new Store();
            ItemsTab.Items = _store.Items;
            CustomersTab.Customers = _store.Customers;
            CartsTab.Items = _store.Items;
            CartsTab.Customers = _store.Customers;
            OrdersTab.Customers = _store.Customers;
            ItemsTab.ItemsChanged += ItemsTab_ItemsChanged; 
        }

        private void ItemsTab_ItemsChanged(object sender, EventArgs e)
        {
            CartsTab.Items = ItemsTab.Items;
            CartsTab.Customers = CustomersTab.Customers;
            OrdersTab.Customers = CartsTab.Customers;
            OrdersTab.RefreshData();
            CartsTab.RefreshData();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void TabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (TabControl.SelectedIndex == 2)
            {
                CartsTab.Items = ItemsTab.Items;
                CartsTab.Customers = CustomersTab.Customers;
                CartsTab.RefreshData();
            }
            else if (TabControl.SelectedIndex == 3)
            {
                OrdersTab.Customers = CartsTab.Customers;
                OrdersTab.RefreshData();
            }
        }
    }
}
