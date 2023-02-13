using System;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о перелёте.
    /// </summary>
    public class Flight
    {
        /// <summary>
        /// Время перелёта.
        /// </summary>
        private int _flightTimeInMinutes;

        /// <summary>
        /// Возвращает и задаёт место назначения.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Возвращает и задаёт место отправления.
        /// </summary>
        public string Departure { get; set; }

        public Flight()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Flight"/>.
        /// </summary>
        /// <param name="flightTimeInMinutes">Время перелёта, должно быть значением от 1 до 1440. </param>
        /// <param name="departure">Место отправления. </param>
        /// <param name="destination">Место назначения. </param>
        public Flight(int flightTimeInMinutes, string departure, string destination)
        {
            _flightTimeInMinutes = flightTimeInMinutes;
            Departure = departure;
            Destination = destination;
        }

        /// <summary>
        /// Возвращает и задаёт время перелёта. Должно быть значением от 1 до 1440. 
        /// </summary>
        public int FlightTimeInMinutes
        {
            get
            {
                return _flightTimeInMinutes;
            }
            set
            {
                Validator.AssertValueInRange(value,1,1440, nameof(FlightTimeInMinutes));
                _flightTimeInMinutes = value;
            }
        }
    }
}
