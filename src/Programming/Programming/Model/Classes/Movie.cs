using System;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о фильме.
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Длительность фильма в минутах.
        /// </summary>
        private int _durationInMinutes;

        /// <summary>
        /// Год премьеры фильма.
        /// </summary>
        private int _year;

        /// <summary>
        /// Рейтинг фильма.
        /// </summary>
        private double _rating;

        /// <summary>
        /// Возвращает и задаёт жанр фильма.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Возвращает и задаёт название фильма.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Movie"/>.
        /// </summary>
        public Movie()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Movie"/>.
        /// </summary>
        /// <param name="title">Название фильма. </param>
        /// <param name="year">Год премьеры фильма, должен быть 
        /// значением от 1900 до текущего года включительно. </param>
        /// <param name="rating">Рейтинг фильма, должен быть 
        /// значением от 0 до 10 включительно. </param>
        /// <param name="durationInMinutes">Длительность фильма в минутах, должно быть 
        /// положительным значением. </param>
        /// <param name="genre">Жанр фильма. </param>
        public Movie(string title, int year, double rating, int durationInMinutes, string genre)
        {
            Title = title;
            _durationInMinutes = durationInMinutes;
            _year = year;
            _rating = rating;
            Genre = genre;
        }

        /// <summary>
        /// Возвращает и задаёт рейтинг фильма. Должен быть значением от 0 до 10 включительно.
        /// </summary>
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                Validator.AssertValueInRange(value, 0, 10, nameof(Rating));
                _rating = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт длительность фильма в минутах. Должна быть положительным значением.
        /// </summary>
        public int DurationInMinutes
        {
            get
            {
                return _durationInMinutes;
            }
            set
            {
                Validator.AssertOnPositiveValue(value, nameof(DurationInMinutes));
                _durationInMinutes = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт год премьеры фильма. Должен быть 
        /// значением от 1900 до текущего года включительно.
        /// </summary>
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                Validator.AssertValueInRange(value, 1900, DateTime.Now.Year, nameof(Year));
                _year = value;
            }
        }
    }
}
