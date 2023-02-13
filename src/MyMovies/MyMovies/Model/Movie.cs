using System;

namespace Movies.Model
{
    /// <summary>
    /// Хранит данные о фильме. 
    /// </summary>
    public class Movie
    {
        /// <summary>
        /// Название фильма. 
        /// </summary>
        private string _title;

        /// <summary>
        /// Год выпуска фильма. 
        /// </summary>
        private int _year;

        /// <summary>
        /// Рейтинг фильма. 
        /// </summary>
        private double _rating;

        /// <summary>
        /// Продолжительность фильма. 
        /// </summary>
        private int _duration;

        /// <summary>
        /// Жанр фильма. 
        /// </summary>
        public Genres Genre { get; set; }

        /// <summary>
        /// Название фильма. Должно быть не  более 100 символов. 
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                Validator.AssertLessThan100Characters(value, nameof(Title));
                _title = value;
            }
        }

        /// <summary>
        /// Год выпуска фильма. Должен быть больше 0 и меньше нынешнего года. 
        /// </summary>
        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                Validator.AssertValueInRangeInt
                    (value, 1895, DateTime.Now.Year, nameof(Year));
                _year = value;
            }
        }

        /// <summary>
        /// Рейтинг фильма. Должен быть больше 0 и меньше 10. 
        /// </summary>
        public double Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                Validator.AssertValueInRangeDouble(value, 0, 10, nameof(Rating));
                _rating = value;
            }
        }

        /// <summary>
        /// Продолжительность фильма.  Должна быть больше 0 и меньше 300. 
        /// </summary>
        public int Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                Validator.AssertValueInRangeInt(value, 1, 300, nameof(Duration));
                _duration = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Movie">. 
        /// </summary>
        /// <param name="title">Название фильма, должно быть не более 100 символов.</param>
        /// <param name="year">Год выпуска фильма, 
        /// должно быть значением от 1 до текущего года.</param>
        /// <param name="rating">Рейтинг фильма. Должен быть больше 0 и меньше 10.</param>
        /// <param name="genre">Жанр фильма.</param>
        /// <param name="duration">Продолжительность фильма.  Должена быть больше 0 и меньше 300.</param>
        public Movie(string title, int year, double rating, int genre, int duration)
        {
            Title = title;
            Year = year;
            Rating = rating;
            Genre = (Genres)genre;
            Duration = duration;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Movie">. 
        /// </summary>
        public Movie()
        {
            Title = "Новый фильм";
            Year = DateTime.Now.Year;
            Rating = 5;
            Genre = Genres.Horror;
            Duration = 150;
        }
    }
}
