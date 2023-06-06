using View.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.Model.Services;
using System.Windows.Controls;

namespace View.ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Коллекция контактов.
        /// </summary>
        private ObservableCollection<Contact> _contacts =
            new ObservableCollection<Contact>();

        /// <summary>
        /// Текущий контакт.
        /// </summary>
        private Contact _currentContact = new Contact();

        /// <summary>
        /// Команда добавления контакта.
        /// </summary>
        private RelayCommand _addCommand;

        /// <summary>
        /// Команда применения контакта.
        /// </summary>
        private RelayCommand _applyCommand;

        /// <summary>
        /// Команда удаления контакта.
        /// </summary>
        private RelayCommand _removeCommand;

        /// <summary>
        /// Команда изменения контакта.
        /// </summary>
        private RelayCommand _editCommand;

        /// <summary>
        /// Отвечает за доступность функций Edit и Remove.
        /// </summary>
        private bool _buttonIsUnavailable = false;

        /// <summary>
        /// Отвечает за доступность функции Add.
        /// </summary>
        private bool _addIsUnavailable = true;

        /// <summary>
        /// Отвечает за доступность текстовых полей.
        /// </summary>
        private bool _textBoxesIsUnavailable = false;

        private bool _editInProcess = false;

        /// <summary>
        /// Хранит событие на изменение.
        /// Зажигается при изменении данных контакта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ButtonIsUnavailable
        {
            get
            {
                return _buttonIsUnavailable;
            }
            set
            {
                _buttonIsUnavailable = value;
                OnPropertyChanged(nameof(ButtonIsUnavailable));
            }
        }

        public bool AddIsUnavailable
        {
            get
            {
                return _addIsUnavailable;
            }
            set
            {
                _addIsUnavailable = value;
                OnPropertyChanged(nameof(AddIsUnavailable));
            }
        }

        public bool TextBoxesIsUnavailable
        {
            get
            {
                return _textBoxesIsUnavailable;
            }
            set
            {
                _textBoxesIsUnavailable = value;
                OnPropertyChanged(nameof(TextBoxesIsUnavailable));
            }
        }

        /// <summary>
        /// Команда на выполнение добавления контакта.
        /// </summary>
        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ??
                    (_addCommand = new RelayCommand(obj =>
                    {
                        TextBoxesIsUnavailable = true;
                        CurrentContact = new Contact("", "", "");
                        ButtonIsUnavailable = false;
                        AddIsUnavailable = false;
                        _editInProcess = true;
                    }));
            }
        }

        /// <summary>
        /// Команда на выполнение применения контакта.
        /// </summary>
        public RelayCommand ApplyCommand
        {
            get
            {
                return _applyCommand ??
                    (_applyCommand = new RelayCommand(obj =>
                    {
                        if (CurrentContact != null && !Contacts.Contains(CurrentContact))
                        {
                            Contacts.Add(CurrentContact);
                        }
                        TextBoxesIsUnavailable = false;
                        ButtonIsUnavailable = true;
                        AddIsUnavailable = true;
                        _editInProcess = false;
                    }));
            }
        }

        /// <summary>
        /// Команда на выполнение редактирования контакта.
        /// </summary>
        public RelayCommand EditCommand
        {
            get
            {
                return _editCommand ??
                    (_editCommand = new RelayCommand(obj =>
                    {
                        TextBoxesIsUnavailable = true;
                        ButtonIsUnavailable = false;
                        AddIsUnavailable = false;
                    }));
            }
        }

        /// <summary>
        /// Команда на выполнение удаления контакта.
        /// </summary>
        public RelayCommand RemoveCommand
        {
            get
            {
                return _removeCommand ??
                    (_removeCommand = new RelayCommand(obj =>
                    {
                        if (Contacts.Count > 1)
                        {
                            int index = Contacts.IndexOf(CurrentContact);

                            if (index == 0)
                            {
                                CurrentContact = Contacts[index + 1];
                            }
                            else
                            {
                                CurrentContact = Contacts[index - 1];
                            }

                            Contacts.RemoveAt(index);
                        }
                        else
                        {
                            Contacts.Remove(CurrentContact);
                            ButtonIsUnavailable = true;
                        }
                    },
                    (obj) => CurrentContact != null));
            }
        }

        /// <summary>
        /// Возвращает и задает коллекцию контактов.
        /// </summary>
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set
            {
                if (value != _contacts)
                {
                    _contacts = value;
                    OnPropertyChanged(nameof(Contacts));
                }
            }
        }

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public Contact CurrentContact
        {
            get
            {
                return _currentContact;
            }
            set
            {
                if (_currentContact != value)
                {
                    _currentContact = value;
                    if (CurrentContact == null)
                    {
                        ButtonIsUnavailable = false;
                    }
                    else
                    {
                        ButtonIsUnavailable = true;
                    }
                    OnPropertyChanged(nameof(CurrentContact));
                    if (_editInProcess == true)
                    {
                        TextBoxesIsUnavailable = false;
                        AddIsUnavailable = true;
                        _editInProcess = false;
                    }
                }
            }
        }

        /// <summary>
        /// Сохраняет данные.
        /// </summary>
        public void Save()
        {
            ContactSerializer.SaveToFile(Contacts);
        }

        /// <summary>
        /// Загружает данные.
        /// </summary>
        public void Load()
        {
            Contacts = ContactSerializer.LoadFromFile();
        }

        /// <summary>
        /// Зажигает событие.
        /// </summary>
        /// <param name="prop">Название свойства,
        /// для которого зажигается событие.</param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public MainVM()
        {
            ButtonIsUnavailable = true;
        }
    }
}
