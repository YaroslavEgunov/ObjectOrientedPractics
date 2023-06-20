using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View.Controls
{
    /// <summary>
    /// Логика взаимодействия для ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        /// <summary>
        /// Константа для проверки номера телефона.
        /// </summary>
        const string pattern = @"[\+\-\(\)\d]";

        /// <summary>
        /// Хранит свойство зависимости возможности редактирования.
        /// </summary>
        public static readonly DependencyProperty IsEditProperty = 
            DependencyProperty.Register(nameof(IsEdit), typeof(bool),
                typeof(ContactControl));

        /// <summary>
        /// Возвращает и задает возможность редактирования.
        /// </summary>
        public bool IsEdit
        {
            get => (bool)GetValue(IsEditProperty);
            set => SetValue(IsEditProperty, value);
        }

        public ContactControl()
        {
            InitializeComponent();
        }

        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, pattern))
            {
                e.Handled = true;
            }
        }

        private void PhoneNumberTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                string input = (string)e.DataObject.GetData(typeof(string));
                if (!Regex.IsMatch(input, pattern))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}
