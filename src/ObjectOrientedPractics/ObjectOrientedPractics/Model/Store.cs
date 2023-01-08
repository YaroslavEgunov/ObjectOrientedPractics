using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Model.Orders;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о товарах и покупателях.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Данные о товарах.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Данные о покупателях.
        /// </summary>
        private List<Customer> _customers;

        /// <summary>
        /// Данные о заказах.
        /// </summary>
        private List<Order> _orders;

        /// <summary>
        /// Возвращает и задаёт данные о покупателях.
        /// </summary>
        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт данные о покупателях.
        /// </summary>
        public List<Customer> Customers
        {
            get
            {
                return _customers;
            }
            set
            {
                _customers = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт данные о заказах.
        /// </summary>
        public List<Order> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Store"/>.
        /// </summary>
        public Store()
        {
            _items = new List<Item>();
            _customers = new List<Customer>();
            _orders = new List<Order>();
        }
    }
}
