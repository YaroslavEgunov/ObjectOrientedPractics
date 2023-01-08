using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectOrientedPractics.Model
{
    /// <summary>
    /// Хранит данные о корзине.
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Список товаров.
        /// </summary>
        private List<Item> _cartItems;

        /// <summary>
        /// Общая стоимость.
        /// </summary>
        private double _amount;

        /// <summary>
        /// Возвращает и задаёт список товаров.
        /// </summary>
        public List<Item> CartItems
        {
            get
            {
                return _cartItems;
            }
            set
            {
                _cartItems = value;
            }
        }

        /// <summary>
        /// Возвращает итоговую сумму всех товаров.
        /// </summary>
        public double Amount
        {
            get
            {
                double amount = 0;
                if (_cartItems == null)
                {
                    return amount;
                }
                for (int i = 0; i < _cartItems.Count; i++)
                {
                    amount += _cartItems[i].Cost;
                }
                return amount;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Cart">.
        /// </summary>
        public Cart()
        {
            CartItems = new List<Item>();
        }
    }
}