using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.Model.Classes
{
    /// <summary>
    /// Хранит данные о человеке и его контактных данных.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Номер телефона человека.
        /// </summary>
        private string _phoneNumber;

        /// <summary>
        /// Фамилия человека. 
        /// </summary>
        private string _surname;

        /// <summary>
        /// Имя человека. 
        /// </summary>
        private string _name;

        /// <summary>
        /// Электронная почта человека. 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возвращает и задаёт фамилию человека. Должна состоять только из букв.
        /// </summary>
        public string Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                Validator.AssertStringContainsOnlyLetters(value, nameof(Surname));
                _surname = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт имя человека. Должно состоять только из букв.
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Validator.AssertStringContainsOnlyLetters(value, nameof(Name));
                _name = value;
            }
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="name">Имя человека, должно состоять только из букв. </param>
        /// <param name="number">Номер телефона человека, должно состоять только из цифр 
        /// и не более 11 символов. </param>
        /// <param name="email">Электронная почта человека. </param>
        /// <param name="surname">>Фамилия человека, должно состоять только из букв. </param>
        public Contact(string name, string number , string email, string surname)
        {
            _name = name;
            _phoneNumber = number;
            Email = email;
            _surname = surname;
        }

        /// <summary>
        /// Возвращает и задаёт номер телефона человека. Должно состоять только из цифр 
        /// и не более 11 символов. 
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value.Length != 11)
                {
                    throw new ArgumentException("Номер телефона должен состоять из 11 цифр");
                }
                if (!long.TryParse(value, out var x))
                {
                    throw new ArgumentException("Номер должен состоять только из цифр");
                }
                _phoneNumber = value;
            }
        }
    }
}   
