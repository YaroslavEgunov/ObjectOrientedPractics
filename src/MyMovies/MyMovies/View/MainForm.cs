using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Movies.Model;
using Movies.Properties;

namespace Movies.View
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Всплывающее описание TextBox. 
        /// </summary>
        private ToolTip _toolTip = new ToolTip();

        /// <summary>
        /// Список фильмов.
        /// </summary>
        private List<Movie> _movies = new List<Movie>();

        /// <summary>
        /// Текущий фильм.
        /// </summary>
        private Movie _currentMovie;

        /// <summary>
        /// Обновляет информацию во всех TextBox.
        /// </summary>
        private void UpdateMovieInfo(Movie movie)
        {
            if (MoviesListBox.SelectedIndex == -1)
            {
                return;
            }
            MoviesListBox.Items[MoviesListBox.SelectedIndex] = GetMovieInfo(movie);
        }

        /// <summary>
        /// Очищает информацию из всех TextBox.
        /// </summary>
        private void ClearMovieInfo()
        {
            GenreComboBox.BackColor = AppColors.CorrectColor;
            TitleTextBox.Text = "";
            TitleTextBox.BackColor = AppColors.CorrectColor;
            YearTextBox.Text = "";
            YearTextBox.BackColor = AppColors.CorrectColor;
            RatingTextBox.Text = "";
            RatingTextBox.BackColor = AppColors.CorrectColor;
            DurationTextBox.Text = "";
            DurationTextBox.BackColor = AppColors.CorrectColor;
        }

        /// <summary>
        /// Предоставляет информацию о фильме в заданном виде.
        /// </summary>
        /// <param name="movie">Фильм.</param>
        /// <returns>Возвращает строку, состоящую из названия фильма, года выпуска и жанра.</returns>
        private string GetMovieInfo(Movie movie)
        {
            return $"{movie.Title} | {movie.Year} | {movie.Genre}";
        }

        /// <summary>
        /// Сортировка по названию фильма.
        /// </summary>
        private void TitleSorting(List<Movie> movies)
        {
            var sortedMovies = movies.OrderBy(movie => movie.Title).ToList();
            for (int i = 0; i < MoviesListBox.Items.Count; i++)
            {
                MoviesListBox.Items[i] = GetMovieInfo(movies[i]);
                movies[i] = sortedMovies[i];
            }
            MoviesListBox.SelectedIndex = _movies.IndexOf(_currentMovie);
        }

        public MainForm()
        {
            InitializeComponent();
            GenreComboBox.DataSource = Enum.GetValues(typeof(Genres));
        }

        private void AddPictureBox_Click(object sender, EventArgs e)
        {
            _movies.Add(new Movie());
            _currentMovie = _movies[_movies.Count - 1];
            MoviesListBox.Items.Add(GetMovieInfo(_currentMovie));
            MoviesListBox.SelectedIndex = MoviesListBox.Items.Count - 1;
        }

        private void RemovePictureBox_Click(object sender, EventArgs e)
        {
            if (_currentMovie == null || MoviesListBox.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                _movies.RemoveAt(MoviesListBox.SelectedIndex);
                MoviesListBox.Items.RemoveAt(MoviesListBox.SelectedIndex);
                if (MoviesListBox.Items.Count > 0)
                {
                    MoviesListBox.SelectedIndex = 0;
                }
            }
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TitleTextBox.SelectionStart = TitleTextBox.Text.Length;
                _currentMovie.Title = TitleTextBox.Text;
                _toolTip.SetToolTip(TitleTextBox, "");
                TitleTextBox.BackColor = AppColors.CorrectColor;
                UpdateMovieInfo(_currentMovie);
                TitleSorting(_movies);
            }
            catch (Exception exception)
            {
                TitleTextBox.BackColor = AppColors.WrongColor;
                _toolTip.SetToolTip(TitleTextBox, exception.Message);
            }
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                YearTextBox.SelectionStart = YearTextBox.Text.Length;
                _currentMovie.Year = Convert.ToInt32(YearTextBox.Text);
                _toolTip.SetToolTip(YearTextBox, "");
                YearTextBox.BackColor = AppColors.CorrectColor;
                UpdateMovieInfo(_currentMovie);
            }
            catch (Exception exception)
            {
               YearTextBox.BackColor = AppColors.WrongColor;
               _toolTip.SetToolTip(YearTextBox, exception.Message);
            }
        }

        private void RatingTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                RatingTextBox.SelectionStart = RatingTextBox.Text.Length;
                _currentMovie.Rating = Convert.ToDouble(RatingTextBox.Text);
                _toolTip.SetToolTip(RatingTextBox,"");
                RatingTextBox.BackColor = AppColors.CorrectColor;
            }
            catch (Exception exception)
            {
                RatingTextBox.BackColor = AppColors.WrongColor;
                _toolTip.SetToolTip(RatingTextBox, exception.Message);
            }
        }

        private void GenreComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_currentMovie == null || MoviesListBox.SelectedIndex == -1)
                {
                    return;
                }
                else
                {
                    GenreComboBox.SelectionStart = GenreComboBox.Text.Length;
                    _currentMovie.Genre = (Genres)GenreComboBox.SelectedItem;
                    _toolTip.SetToolTip(GenreComboBox, "");
                    GenreComboBox.BackColor = AppColors.CorrectColor;
                    UpdateMovieInfo(_currentMovie);
                }
            }
            catch (Exception exception)
            {
                GenreComboBox.BackColor = AppColors.WrongColor;
                _toolTip.SetToolTip(GenreComboBox, exception.Message);
            }
        }

        private void DurationTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DurationTextBox.SelectionStart = DurationTextBox.Text.Length;
                _currentMovie.Duration = Convert.ToInt32(DurationTextBox.Text);
                _toolTip.SetToolTip(DurationTextBox, "");
                DurationTextBox.BackColor = AppColors.CorrectColor;
                UpdateMovieInfo(_currentMovie);
            }
            catch (Exception exception)
            {
                DurationTextBox.BackColor = AppColors.WrongColor;
                _toolTip.SetToolTip(DurationTextBox, exception.Message);
            }
        }

        private void MoviesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MoviesListBox.SelectedIndex == -1)
            {
                ClearMovieInfo();
            }
            else
            {
                _currentMovie = _movies[MoviesListBox.SelectedIndex];
                TitleTextBox.Text = _currentMovie.Title.ToString();
                YearTextBox.Text = _currentMovie.Year.ToString();
                GenreComboBox.Text = _currentMovie.Genre.ToString();
                RatingTextBox.Text = _currentMovie.Rating.ToString();
                DurationTextBox.Text = _currentMovie.Duration.ToString();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _movies.AddRange(ProjectSerializer.LoadMoviesToFile());
            for (int i = 0; i < _movies.Count; i++)
            {
                MoviesListBox.Items.Add(GetMovieInfo(_movies[i]));
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           ProjectSerializer.SaveMoviesToFile(_movies);
        }

        private void AddPictureBox_MouseEnter(object sender, EventArgs e)
        {
            AddPictureBox.Image = Resources.Video_add_color;
        }

        private void AddPictureBox_MouseLeave(object sender, EventArgs e)
        {
            AddPictureBox.Image = Resources.Video_add;
        }

        private void RemovePictureBox_MouseLeave(object sender, EventArgs e)
        {
            RemovePictureBox.Image = Resources.Video_remove;
        }

        private void RemovePictureBox_MouseEnter(object sender, EventArgs e)
        {
            RemovePictureBox.Image = Resources.Video_remove_color;
        }
    }
}
