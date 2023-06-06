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
        /// Отвечает за видимость кнопки Apply.
        /// </summary>
        private bool _applyIsVisible = false;

        /// <summary>
        /// Отвечает за доступность кнопок Edit и Remove.
        /// </summary>
        private bool _buttonIsEnabled = false;

        /// <summary>
        /// Отвечает за доступность кнопки Add.
        /// </summary>
        private bool _addIsEnabled = true;

        /// <summary>
        /// Отвечает за доступность textbox.
        /// </summary>
        private bool _textBoxesIsEnabled = false;

        /// <summary>
        /// Хранит событие на изменение.
        /// Зажигается при изменении данных контакта.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ApplyIsVisible
        {
            get
            {
                return _applyIsVisible;
            }
            private set
            {
                _applyIsVisible = value;
                OnPropertyChanged(nameof(ApplyIsVisible));
            }
        }

        public bool ButtonIsEnabled
        {
            get
            {
                return _buttonIsEnabled;
            }
            set
            {
                _buttonIsEnabled = value;
                OnPropertyChanged(nameof(ButtonIsEnabled));
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

        public bool TextBoxesIsEnabled
        {
            get
            {
                return _textBoxesIsEnabled;
            }
            set
            {
                _textBoxesIsEnabled = value;
                OnPropertyChanged(nameof(TextBoxesIsEnabled));
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
                        ApplyIsVisible = true;
                        TextBoxesIsEnabled = true;
                        CurrentContact = new Contact("", "", "");
                        ButtonIsEnabled = false;
                        AddIsEnabled = false;
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
                        if (CurrentContact != null || !Contacts.Contains(CurrentContact) )
                        {
                            Contacts.Add(CurrentContact);
                        }
                        ApplyIsVisible = false;
                        TextBoxesIsEnabled = false;
                        ButtonIsEnabled = true;
                        AddIsEnabled = true;
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
                        ApplyIsVisible = true;
                        TextBoxesIsEnabled = true;
                        ButtonIsEnabled = false;
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
                        ButtonIsEnabled = false;
                    }
                    else
                    {
                        ButtonIsEnabled = true;
                    }
                    OnPropertyChanged(nameof(CurrentContact));
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
    }
}
