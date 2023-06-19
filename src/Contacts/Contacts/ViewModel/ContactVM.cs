using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Model;

namespace View.ViewModel
{
    public class ContactVM : INotifyPropertyChanged, IDataErrorInfo
    {
        /// <summary>
        /// Контакт.
        /// </summary>
        private Contact _contact;











        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();

        /// <summary>
        /// Хранит событие на изменение.
        /// Зажигается при изменении данных контакта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
