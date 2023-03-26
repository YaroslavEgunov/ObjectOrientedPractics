﻿using System;
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
        /// Возвращает и задает путь к файлу.
        /// </summary>
        public static string Filename { get; set; }

        /// <summary>
        /// Создает экземпляр класса <see cref="ContactSerializer"/>.
        /// </summary>
        static ContactSerializer()
        {
            var myDocumentsFolder =
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                @"\Contacts\contacts.json";
            Filename = myDocumentsFolder;
        }

        /// <summary>
        /// Проверяет, существует ли папка, указанная в свойстве Filename, иначе создает её.
        /// </summary>
        public static void CreateDirectory()
        {
            if (!Directory.Exists(Filename))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(Filename));
            }
        }

        /// <summary>
        /// Сохраняет данные о контактах в файл.
        /// </summary>
        /// <param name="contact">Данные о контакте, которые нужно сохранить.</param>
        /// <exception cref="Exception">Возникает, 
        /// если произошла ошибка при сохранении.</exception>
        public static void SaveToFile(Contact contact)
        {
            try
            {
                CreateDirectory();
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                JsonSerializer serializer = new JsonSerializer();
                serializer = JsonSerializer.Create(settings);
                using (StreamWriter sw = new StreamWriter(Filename))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, contact);
                }
            }
            catch
            {
                throw new Exception($"An error occurred while saving data");
            }
        }

        /// <summary>
        /// Загружает данные из файла и передает их в список.
        /// </summary>
        /// <returns>Возвращает текущий контакт.</returns>
        public static Contact LoadFromFile()
        {
            Contact contact = null;

            try
            {
                CreateDirectory();
                var settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                JsonSerializer serializer = new JsonSerializer();
                serializer = JsonSerializer.Create(settings);
                using (StreamReader sr = new StreamReader(Filename))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    contact = serializer.Deserialize<Contact>(reader);
                }
            }
            catch
            {
                return new Contact();
            }

            return contact;
        }
    }
}