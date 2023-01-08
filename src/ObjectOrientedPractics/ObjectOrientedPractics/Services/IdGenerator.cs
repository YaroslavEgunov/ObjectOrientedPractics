using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    /// <summary>
    /// Хранит метод, отвечающий за создание уникальных идентификаторов.
    /// </summary>
    public static class IdGenerator
    {
        /// <summary>
        /// Уникальный индетификатор. 
        /// </summary>
        private static int _customersId = 1;

        /// <summary>
        /// Уникальный индетификатор. 
        /// </summary>
        private static int _itemsId = 1;

        /// <summary>
        /// Уникальный индетификатор. 
        /// </summary>
        private static int _ordersId = 1;

        /// <summary>
        /// Создаёт уникальный идентификатор.
        /// </summary>
        /// <returns>Возвращает уникальный идентификатор.</returns>
        public static int GetNextItemsId()
        {
            return _itemsId++;
        }

        /// <summary>
        /// Создаёт уникальный идентификатор.
        /// </summary>
        /// <returns>Возвращает уникальный идентификатор.</returns>
        public static int GetNextCustomersId()
        {
            return _customersId++;
        }

        /// <summary>
        /// Создаёт уникальный идентификатор.
        /// </summary>
        /// <returns>Возвращает уникальный идентификатор.</returns>
        public static int GetNextOrderId()
        {
            return _ordersId++;
        }
    }
}