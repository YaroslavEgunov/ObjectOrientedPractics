using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contacts.Model;
using Newtonsoft.Json;

namespace View.Model.Services
{
    /// <summary>
    /// Предоставляет методы для сериализации данных о контакте.
    /// </summary>
    public static class ContactSerializer
    {

        /// <summary>
        /// Путь к файлу сохранения.
        /// </summary>
        private static string _fileName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + 
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
        /// Сохраняет все данные о контакте в файл.
        /// </summary>
        /// <param name="contact"></param>
        public static void SaveToFile(Contact contact)
        {
            try
            {
                СheckFile();
                StreamWriter streamWriter = new StreamWriter(_fileName);
                var jsonContact = JsonConvert.SerializeObject(contact);
                streamWriter.Write(jsonContact);
                streamWriter.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // <summary>
        // Загружает данные из файла.
        // </summary>
        // <returns>Возвращает текущий контакт.</returns>
        public static Contact LoadFromFile()
        {
            СheckFile();
            StreamReader streamReader = new StreamReader(_fileName);
            var data = streamReader.ReadToEnd();
            var jsonContact = JsonConvert.DeserializeObject<Contact>(data);
            streamReader.Close();
            if (jsonContact == null)
            {
                return new Contact();
            }
            return jsonContact;
        }
    }
}