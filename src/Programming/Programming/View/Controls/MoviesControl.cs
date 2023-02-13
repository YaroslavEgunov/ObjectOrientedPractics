using Programming.Model.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming.View.Controls
{
    /// <summary>
    /// Выводит список фильмов и их информацию. Нажатие кнопки находит фильм с наивысшим рейтингом.
    /// </summary>
    public partial class MoviesControl : UserControl
    {
        /// <summary>
        /// Массив из фильмов.
        /// </summary>
        private Movie[] _movies;

        /// <summary>
        /// Хранит данные о выбранном фильме.
        /// </summary>
        private Movie _currentMovie = new Movie();

        public MoviesControl()
        {
            InitializeComponent();
            InitMovies();
        }

        /// <summary>
        /// Находит фильм с наивысшим рейтингом.
        /// </summary>
        /// <param name="movies">Массив фильмов. </param>
        /// <returns>Возвращает индекс фильма с наивысшим рейтингом. </returns>
        private int FindMovieWithMaxRating(Movie[] movies)
        {
            int index = 0;
            double maxValues = 0;
            for (var i = 0; i < movies.Length; i++)
            {
                if (movies[i].Rating > maxValues)
                {
                    maxValues = movies[i].Rating;
                    index = i;
                }
            }
            return index;
        }

        /// <summary>
        /// Метод инициализации массива фильмов со случайными значениями.
        /// </summary>
        private void InitMovies()
        {
            _movies = new Movie[5];
            Random random = new Random();
            string[] MoviesTitle = {"Holk","Iren Man","Captain Latvia","White window", "Gold Man",
                                   "Pink Panther", "Thor son of the Pluto", "Recruit Marvel",
                                    "Peter-man", "Vatman", "Flash energy",
                                    "Wonder NotHuman", "Super-Monkey" };
            string[] MoviesGenre = { "Horror", "Action", "Comedy", "Fantasy",
                                    "Mystery", "Romance", "Thriller", "Drama" };
            for (var i = 0; i < 5; i++)
            {
                var Title = random.Next(MoviesTitle.Length);
                var Genre = random.Next(MoviesGenre.Length);
                _movies[i] = new Movie(MoviesTitle[Title],
                                      random.Next(1900, DateTime.Now.Year),
                                      Math.Round(random.NextDouble() * 10, 1),
                                      random.Next(60, 180),
                                      MoviesGenre[Genre]);
                MoviesListBox.Items.Add($"Movie {i + 1}");
            }
            MoviesListBox.SelectedIndex = 0;
        }

        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentMovie = _movies[MoviesListBox.SelectedIndex];
            DurationInMinutesTextBox.Text = _currentMovie.DurationInMinutes.ToString();
            YearTextBox.Text = _currentMovie.Year.ToString();
            RatingTextBox.Text = _currentMovie.Rating.ToString();
            TitleTextBox.Text = _currentMovie.Title;
            GenreTextBox.Text = _currentMovie.Genre;
        }

        private void DurationInMinutesTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentMovie.DurationInMinutes = Convert.ToInt32(DurationInMinutesTextBox.Text);
                DurationInMinutesTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(DurationInMinutesTextBox, "");
            }
            catch (Exception exception)
            {
                toolTip.SetToolTip(DurationInMinutesTextBox, exception.Message);
                DurationInMinutesTextBox.BackColor = AppColors.WrongColor;
            }
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentMovie.Year = Convert.ToInt32(YearTextBox.Text);
                YearTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(YearTextBox, "");
            }
            catch (Exception exception)
            {
                toolTip.SetToolTip(YearTextBox, exception.Message);
                YearTextBox.BackColor = AppColors.WrongColor;
            }
        }

        private void RatingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _currentMovie.Rating = Convert.ToDouble(RatingTextBox.Text);
                RatingTextBox.BackColor = AppColors.CorrectColor;
                toolTip.SetToolTip(RatingTextBox, "");
            }
            catch (Exception exception)
            {
                toolTip.SetToolTip(RatingTextBox, exception.Message);
                RatingTextBox.BackColor = AppColors.WrongColor;
            }
        }

        private void GenreTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentMovie.Genre = Convert.ToString(GenreTextBox.Text);
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            _currentMovie.Title = Convert.ToString(TitleTextBox.Text);
        }

        private void FindMovieButton_Click(object sender, EventArgs e)
        {
            MoviesListBox.SelectedIndex = FindMovieWithMaxRating(_movies);
        }
    }
}
