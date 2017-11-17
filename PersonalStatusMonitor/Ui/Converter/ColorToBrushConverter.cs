using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.Converter {
    public class ColorToBrushConverter:IValueConverter{
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is Color) {
                return new SolidColorBrush((Color)value);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}