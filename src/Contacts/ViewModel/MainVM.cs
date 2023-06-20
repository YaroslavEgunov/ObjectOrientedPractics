using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using ViewModel.Services;
using System.Xml.Linq;

namespace ViewModel
{
    /// <summary>
    /// ViewModel главного окна.
    /// </summary>
    public partial class MainVM : ObservableObject
    {
        /// <summary>
        /// Коллекция контактов.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Contact> _contacts =
            new ObservableCollection<Contact>();

        /// <summary>
        /// Текущий контакт.
        /// </summary>
        private Contact _currentContact;

        /// <summary>
        /// Отвечает за доступность функций Edit и Remove.
        /// </summary>
        [ObservableProperty]
        private bool _isUnavailable = true;

        /// <summary>
        /// Отвечает за доступность функции Add.
        /// </summary>
        [ObservableProperty]
        private bool _addIsUnavailable = true;

        /// <summary>
        /// Блокировка элементов управления во время редактирования.
        /// </summary>
        private bool _editInProcess = false;

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public Contact CurrentContact
        {
            get => _currentContact;
            set
            {
                if (SetProperty(ref _currentContact, value))
                {
                    RemoveCommand.NotifyCanExecuteChanged();
                    EditCommand.NotifyCanExecuteChanged();
                    ApplyCommand.NotifyCanExecuteChanged();
                }

                if (_editInProcess == true)
                {
                    AddIsUnavailable = true;
                    _editInProcess = false;
                }
            }
        }

        /// <summary>
        /// Команда на добавление контакта.
        /// </summary>
        [RelayCommand]
        private void Add()
        {
            CurrentContact = new Contact();
            IsUnavailable = false;
            AddIsUnavailable = false;
            _editInProcess = true;
        }

        /// <summary>
        /// Команда на применение изменений в контакт.
        /// </summary>
        [RelayCommand]
        private void Apply()
        {
            if (CurrentContact != null && !Contacts.Contains(CurrentContact))
            {
                Contacts.Add(CurrentContact);
            }
            IsUnavailable = true;
            AddIsUnavailable = true;
            _editInProcess = false;
        }

        /// <summary>
        /// Команда на удаление контакта.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CheckingCurrentContactForNull))]
        private void Remove()
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
        }

        /// <summary>
        /// Команда на изменение контакта.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CheckingCurrentContactForNull))]
        private void Edit()
        {
            if (CurrentContact != null && Contacts.Count > 0)
            {
                IsUnavailable = false;
                AddIsUnavailable = false;
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
        /// Проверяет выбранных контакт на null.
        /// </summary>
        /// <returns>Возвращает false,
        /// если контакт равен null, иначе true.</returns>
        private bool CheckingCurrentContactForNull()
        {
            if (CurrentContact != null)
            {
                return true;
            }

            return false;
        }
    }
}
