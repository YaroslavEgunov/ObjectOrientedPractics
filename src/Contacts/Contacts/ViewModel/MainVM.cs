using Contacts.Model;
using Contacts.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Контакт.
        /// </summary>
        private Contact _contact = new Contact();

        /// <summary>
        /// Возвращает и задает имя контакта.
        /// </summary>
        public string Name
        {
            get
            {
                return _contact.Name;
            }
            set
            {
                if (value != _contact.Name)
                {
                    _contact.Name = value;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает номер телефона контакта.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return _contact.PhoneNumber;
            }
            set
            {
                if (value != _contact.PhoneNumber)
                {
                    _contact.PhoneNumber = value;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает почту контакта.
        /// </summary>
        public string Email
        {
            get
            {
                return _contact.Email;
            }
            set
            {
                if (value != _contact.Email)
                {
                    _contact.Email = value;
                }
            }
        }

        /// <summary>
        /// Возвращает и задает контакт.
        /// </summary>
        public Contact Contact
        {
            get
            {
                return _contact;
            }
            set
            {
                if (value != _contact)
                {
                    _contact = value;
                }
            }
        }
    }
}