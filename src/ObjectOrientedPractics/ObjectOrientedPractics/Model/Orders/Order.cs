﻿using System;
using System.Collections.Generic;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model.Orders
{
    /// <summary>
    /// Представляет реализацию по оформлению заказа.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Уникальный идентификатор для всех объектов данного класса.
        /// </summary>
        private readonly int _ordersId;

        /// <summary>
        /// Дата создания заказа.
        /// </summary>
        private readonly string _dateOfCreate;

        /// <summary>
        /// Адрес доставки.
        /// </summary>
        private Address _deliveryAddress;

        /// <summary>
        /// Коллекция товаров.
        /// </summary>
        private List<Item> _items;

        /// <summary>
        /// Общая стоимость.
        /// </summary>
        private double _amount;

        /// <summary>
        /// Возвращает и задает скидку на товары.
        /// </summary>
        public double DiscountAmount { get; set; }

        /// <summary>
        /// Возвращает итоговую стоимость заказа.
        /// </summary>
        public double Total
        {
            get
            {
                return Amount - DiscountAmount;
            }
        }

        /// <summary>
        /// Возвращает уникальный идентификатор заказа.
        /// </summary>
        public int OrdersId
        {
            get
            {
                return _ordersId;
            }
        }

        /// <summary>
        /// Возвращает дату создания заказа.
        /// </summary>
        public string DateOfCreate
        {
            get
            {
                return _dateOfCreate;
            }
        }

        /// <summary>
        /// Возвращает и задает статус заказа.
        /// </summary>
        public OrderStatus Status { get; set; }

        /// <summary>
        /// Возвращает и задает адрес доставки заказа.
        /// </summary>
        public Address DeliveryAddress
        {
            get
            {
                return _deliveryAddress;
            }
            set
            {
                _deliveryAddress = value;
            }
        }

        /// <summary>
        /// Возвращает и задает коллекцию товаров заказа.
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
        /// Возвращает общую стоимость товаров.
        /// </summary>
        public double Amount
        {
            get
            {
                _amount = 0;

                if (_items == null)
                {
                    return _amount;
                }

                foreach (var item in _items)
                {
                    _amount += item.Cost;
                }

                return _amount;
            }
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>. 
        /// </summary>
        public Order()
        {
            _dateOfCreate = DateTime.Now.ToString();
            _ordersId = IdGenerator.GetNextOrderId();
        }

        /// <summary>
        /// Создает экземпляр класса <see cref="Order"/>. 
        /// </summary>
        /// <param name="status">Статус заказа.</param>
        /// <param name="deliveryAddres">Адрес.</param>
        /// <param name="items">Товары.</param>
        public Order(OrderStatus status, Address deliveryAddres, List<Item> items)
        {
            Status = status;
            DeliveryAddress = deliveryAddres;
            Items = items;
            _dateOfCreate = DateTime.Now.ToString();
            _ordersId = IdGenerator.GetNextOrderId();
        }
    }
}
