using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Model
{
    /// <summary>
    /// Предоставляет методы, которые загружают и сохраняют данные.
    /// </summary>
    public static class ProjectSerializer
    {
        /// <summary>
        /// Путь к файлу сохранения.
        /// </summary>
        private static string _fileName =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Movies";

        /// <summary>
        /// Проверяет наличие файла, если он отсутствует, то создает его. 
        /// </summary>
        private static void СheckFile()
        {
            if (!File.Exists(_fileName))
            {
                FileStream fileStream = new FileStream(_fileName, FileMode.Create);
                fileStream.Close();
            }
        }

        /// <summary>
        /// Сохраняет все данные о фильмах в файл.
        /// </summary>
        /// <param name="movies">Список фильмов, которые нужно сохранить.</param>
        /// <exception cref="NotImplementedException">Возникает, если произошла ошибка при сохранении.</exception>
        public static void SaveMoviesToFile(List<Movie> movies)
        {
            try
            {
                СheckFile();
                StreamWriter streamWriter = new StreamWriter(_fileName);
                var jsonBooks = JsonConvert.SerializeObject(movies);
                streamWriter.Write(jsonBooks);
                streamWriter.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Загружает данные из файла и передаёт их в список.
        /// </summary>
        /// <returns>Возвращает список фильмов.</returns>
        public static List<Movie> LoadMoviesToFile()
        {
            СheckFile();
            StreamReader streamReader = new StreamReader(_fileName);
            var data = streamReader.ReadToEnd();
            var jsonMovies = JsonConvert.DeserializeObject<List<Movie>>(data);
            streamReader.Close();
            if (jsonMovies == null)
            {
                return new List<Movie>();
            }
            return jsonMovies;
        }
    }
}
