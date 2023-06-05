using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace View.ViewModel
{
    public class BoolToStringConverter : IValueConverter
    {
        /// <summary>
        /// Конвертирует <see cref="bool"> в <see cref="string">.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns>Возвращает объект <see cref="string">.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "True";
            }
            else
            {
                return "False";
            }
        }

        /// <summary>
        /// Конвертирует  <see cref="string"> в <see cref="bool">.
        /// </summary>
        /// <param name="value">Значение, которое надо преобразовать.</param>
        /// <param name="targetType">Тип, к которому надо преобразовать значение value.</param>
        /// <param name="parameter">Вспомогательный параметр.</param>
        /// <param name="culture">Текущая культура приложения.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}