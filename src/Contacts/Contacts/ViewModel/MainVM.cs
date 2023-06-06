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
        /// Отвечает за доступность кнопок Edit и Remove.
        /// </summary>
        private bool _buttonIsBlocked = false;

        /// <summary>
        /// Отвечает за доступность кнопки Add.
        /// </summary>
        private bool _addIsEnabled = true;

        /// <summary>
        /// Отвечает за доступность textbox.
        /// </summary>
        private bool _textBoxesIsBlocked = false;

        private bool _applyInProcess = false;

        /// <summary>
        /// Хранит событие на изменение.
        /// Зажигается при изменении данных контакта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ButtonIsBlocked
        {
            get
            {
                return _buttonIsBlocked;
            }
            set
            {
                _buttonIsBlocked = value;
                OnPropertyChanged(nameof(ButtonIsBlocked));
            }
        }

        public bool AddIsEnabled
        {
            get
            {
                return _addIsEnabled;
            }
            set
            {
                _addIsEnabled = value;
                OnPropertyChanged(nameof(AddIsEnabled));
            }
        }

        public bool TextBoxesIsBlocked
        {
            get
            {
                return _textBoxesIsBlocked;
            }
            set
            {
                _textBoxesIsBlocked = value;
                OnPropertyChanged(nameof(TextBoxesIsBlocked));
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
                        TextBoxesIsBlocked = true;
                        CurrentContact = new Contact("", "", "");
                        ButtonIsBlocked = false;
                        AddIsEnabled = false;
                        _applyInProcess = true;
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
                        TextBoxesIsBlocked = false;
                        ButtonIsBlocked = true;
                        AddIsEnabled = true;
                        _applyInProcess = false;
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
                        TextBoxesIsBlocked = true;
                        ButtonIsBlocked = false;
                        AddIsEnabled = false;
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
                            ButtonIsBlocked = true;
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
                        ButtonIsBlocked = false;
                    }
                    else
                    {
                        ButtonIsBlocked = true;
                    }
                    OnPropertyChanged(nameof(CurrentContact));
                    if (_applyInProcess == true)
                    {
                        TextBoxesIsBlocked = false;
                        AddIsEnabled = true;
                        _applyInProcess = false;
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
            ButtonIsBlocked = true;
        }
    }
}
