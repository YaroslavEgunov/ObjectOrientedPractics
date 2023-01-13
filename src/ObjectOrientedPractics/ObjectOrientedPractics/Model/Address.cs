using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectOrientedPractics.Services;

namespace ObjectOrientedPractics.Model
{
    public class Address
    {
        public EventHandler<EventArgs> AddressChanged;

        /// <summary>
        /// Почтовый индекс.
        /// </summary>
        private int _index;

        /// <summary>
        /// Страна/регион.
        /// </summary>
        private string _country;

        /// <summary>
        /// Город/населённый пункт.
        /// </summary>
        private string _city;

        /// <summary>
        /// Улица.
        /// </summary>
        private string _street;

        /// <summary>
        /// Номер дома.
        /// </summary>
        private string _building;

        /// <summary>
        /// Номер квартиры/помещения.
        /// </summary>
        private string _apartament;

        /// <summary>
        /// Возвращает и задаёт индекс. Должен быть шестизначным числом.
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }
            set
            {
                Validator.AssertValueInRange(value, 100000, 999999, nameof(Index));
                if (_index != value)
                {
                    _index = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт страну/регион. Должна быть меньше 50 символов.
        /// </summary>
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, nameof(Country));
                if (_country != value)
                {
                    _country = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт город/населённый пункт. Должен быть меньше 50 символов.
        /// </summary>
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, nameof(City));
                if (_city != value)
                {
                    _city = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт улицу. Должна быть меньше 50 символов.
        /// </summary>
        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                Validator.AssertStringOnLength(value, 50, nameof(Street));
                if (_street != value)
                {
                    _street = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер дома. Должен быть меньше 10 символов.
        /// </summary>
        public string Building
        {
            get
            {
                return _building;
            }
            set
            {
                Validator.AssertStringOnLength(value, 10, nameof(Building));
                if (_building != value)
                {
                    _building = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт номер квартиры/помещения.
        /// Должны быть меньше 10 символов.
        /// </summary>
        public string Apartament
        {
            get
            {
                return _apartament;
            }
            set
            {
                Validator.AssertStringOnLength(value, 10, nameof(Apartament));
                if (_apartament != value)
                {
                    _apartament = value;
                    AddressChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Address"/>.
        /// </summary>
        /// <param name="Index">Почтовый индекс. Должен быть шестизначным числом.</param>
        /// <param name="Country">Возвращает и задаёт страну/регион.
        /// Должна быть меньше 50 символов.</param>
        /// <param name="City"Возвращает и задаёт город/населённый пункт.
        /// Должен быть меньше 50 символов.></param>
        /// <param name="Street">Возвращает и задаёт улицу.
        /// Должна быть меньше 50 символов.</param>
        /// <param name="Building">Возвращает и задаёт номер дома.
        /// Должен быть меньше 10 символов.</param>
        /// <param name="Apartament">Возвращает и задаёт номер квартиры/помещения.
        /// Должен быть меньше 10 символов</param>
        public Address(int Index, string Country, string City,
                    string Street, string Building, string Apartament)
        {
            Index = _index;
            Country = _country;
            City = _city;
            Street = _street;
            Building = _building;
            Apartament = _apartament;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Address"/>.
        /// </summary>
        public Address()
        {
            Index = 100000;
            Country = "Empty";
            City = "Empty";
            Street = "Empty";
            Building = "Empty";
            Apartament = "Empty";
        }

    }
}