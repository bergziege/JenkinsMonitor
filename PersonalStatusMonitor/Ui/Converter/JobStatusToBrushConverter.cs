using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

using De.BerndNet2000.Hudson.Service.Domain;
using De.BerndNet2000.PersonalStatusMonitor.Domain;

namespace De.BerndNet2000.PersonalStatusMonitor.Ui.Converter {
    public class JobStatusToBrushConverter:IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is JobStatus) {
                JobStatus status = (JobStatus)value;
                switch (status) {
                    case JobStatus.Blue:
                        return new SolidColorBrush(Color.FromArgb(255, 0, 255, 14));
                    case JobStatus.Red:
                        return new SolidColorBrush(Colors.Red);
                    case JobStatus.Grey:
                        return new SolidColorBrush(Color.FromArgb(255, 154, 154, 154));
                    case JobStatus.Disabled:
                        return new SolidColorBrush(Colors.White);
                    case JobStatus.Yellow:
                        return new SolidColorBrush(Color.FromArgb(255, 245, 255, 0));
                    default:
                        return new SolidColorBrush(Colors.Black);
                }

            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}