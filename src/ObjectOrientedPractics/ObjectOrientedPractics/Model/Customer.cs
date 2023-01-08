using System.Collections.Generic;
using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Discounts;
using ObjectOrientedPractics.Model.Orders;
using ObjectOrientedPractics.Services;

public class Customer
{
    /// <summary>
    /// Уникальный индетификатор.
    /// </summary>
    private readonly int _customersId;

    /// <summary>
    /// Полное имя покупателя. Должно быть меньше 200 символов.
    /// </summary>
    private string _fullName;

    /// <summary>
    /// Адрес доставки. Должен быть меньше 500 символов.
    /// </summary>
    private Address _address;

    /// <summary>
    /// Корзина покупателя.
    /// </summary>
    private Cart _cart;

    /// <summary>
    /// Приоритетный покупатель.
    /// </summary>
    private bool _isPriority;

    /// <summary>
    /// Коллекция заказов.
    /// </summary>
    private List<Order> _orders;

    /// <summary>
    /// Возвращает уникальный идентификатор.
    /// </summary>
    public int Id
    {
        get
        {
            return _customersId;
        }
    }

    /// <summary>
    /// Возвращает и задаёт полное имя покупателя товара. Должно быть не больше 200 символов.
    /// </summary>
    public string FullName
    {
        get
        {
            return _fullName;
        }
        set
        {
            Validator.AssertStringOnLength(value, 200, nameof(FullName));
            _fullName = value;
        }
    }

    /// <summary>
    /// Возвращает и задаёт адрес доставки товара. Должен быть не больше 500 символов.
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
        }
    }

    /// <summary>
    /// Возвращает и задаёт корзину покупателя.
    /// </summary>
    public Cart Cart
    {
        get
        {
            return _cart;
        }
        set
        {
            _cart = value;
        }
    }

    /// <summary>
    /// Возвращает и задает коллекцию заказов.
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
    /// Возвращает и задает булевое значение, является ли покупатель приоритетным или нет.
    /// </summary>
    public bool IsPriority
    {
        get
        {
            return _isPriority;
        }
        set
        {
            _isPriority = value;
        }
    }

    public List<IDiscount> Discounts { get; set; }

    /// <summary>
    /// Создаёт экземпляр класса <see cref="Customer"/>.
    /// </summary>
    /// <param name="Fullname">Полное имя. Должно быть не более 200 символов.</param>
    /// <param name="Address">Адрес.</param>
    /// <param name="Cart">Корзина покупателя.</param>
    /// <param name="Orders">Коллекция заказов.</param>
    /// <param name="IsPriority">Приоритетный покупатель.</param>
    public Customer(string FullName, Address Address, Cart Cart, List<Order> Orders, bool IsPriority)
    {
        _customersId = IdGenerator.GetNextCustomersId();
        FullName = _fullName;
        Cart = new Cart();
        Address = _address;
        Cart = _cart;
        Orders = _orders;
        IsPriority = _isPriority;
        Discounts = new List<IDiscount>();
        Discounts.Add(new PointsDiscount());
    }

    /// <summary>
    /// Создает экземпляр класса <see cref="Customer"/>.
    /// </summary>
    public Customer()
    {
        _customersId = IdGenerator.GetNextCustomersId();
        FullName = "Empty";
        Cart = new Cart();
        Orders = new List<Order>();
        IsPriority = false;
        Address = new Address();
        Discounts = new List<IDiscount>();
    }

}