//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;

//namespace View.ViewModel
//{
//    public class BoolToIsEnableConverter : IValueConverter
//    {
//        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            Button.IsEnabledProperty visibility = Visibility.Collapsed;
//            if ((bool)value)
//            {
//                visibility = Visibility.Visible;
//            }
//            else
//            {
//                visibility = Visibility.Collapsed;
//            }
//            return visibility;
//        }

//        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
//        {
//            return 0;
//        }
//    }
//}
