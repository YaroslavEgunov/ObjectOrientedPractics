using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ViewModel;
using Model;


namespace ViewModel.Services
{
    /// <summary>
    /// Предоставляет методы для сериализации данных о контакте.
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Путь к файлу сохранения.
        /// </summary>
        private static string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
            @"\Contacts\contacts.json";

        /// <summary>
        /// Метод, который проверяет существует ли файл. Если не существует, то создаёт.
        /// </summary>
        private static void СheckFile()
        {
            if (!Directory.Exists(_fileName))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_fileName));
            }
        }

        /// <summary>
        /// Сохраняет данные о товарах в файл.
        /// </summary>
        /// <param name="contacts">Данные о контактах, которые нужно сохранить.</param>
        /// <exception cref="Exception">Возникает, 
        /// если произошла ошибка при сохранении.</exception>
        public static void SaveToFile(ObservableCollection<Contact> contacts)
        {
            try
            {
                СheckFile();
                StreamWriter streamWriter = new StreamWriter(_fileName);
                var jsonContact = JsonConvert.SerializeObject(contacts);
                streamWriter.Write(jsonContact);
                streamWriter.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /// <summary>
        /// Загружает данные из файла и передает их в список.
        /// </summary>
        /// <returns>Возвращает текущий контакт.</returns>
        public static ObservableCollection<Contact> LoadFromFile()
        {
            СheckFile();
            StreamReader streamReader = new StreamReader(_fileName);
            var data = streamReader.ReadToEnd();
            streamReader.Close();
            if (data == null)
            {
                return new ObservableCollection<Contact>();
            }
            else
            {
                var jsonData = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(data);
                return jsonData;
            }
        }
    }
}
