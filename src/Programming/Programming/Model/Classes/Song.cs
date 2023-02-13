using System;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о песне и её композиторе.
    /// </summary>
    public class Song 
    {
        /// <summary>
        /// Возвращает и задаёт название песни.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Возвращает и задаёт жанр песни.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Возвращает и задаёт исполнителя песни.
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        public Song()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Song"/>.
        /// </summary>
        /// <param name="artist">Исполнитель песни. </param>
        /// <param name="genre">Жанр песни. </param>
        /// <param name="name">Название песни. </param>
        public Song(string artist, string genre, string name)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
        }
    }
}
