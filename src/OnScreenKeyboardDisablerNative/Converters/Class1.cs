using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace zieschang.net.Projects.OnScreenKeyboardDisabler.Native.Converters
{
    [ValueConversion(typeof(System.ServiceProcess.ServiceControllerStatus), typeof(Brush))]
    public class ServiceStateColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
      object parameter, CultureInfo culture)
        {
            System.ServiceProcess.ServiceControllerStatus state = (System.ServiceProcess.ServiceControllerStatus)value;

            switch (state)
            {
                case System.ServiceProcess.ServiceControllerStatus.Running:
                    return new SolidColorBrush(Colors.Green);
                    break;
                case System.ServiceProcess.ServiceControllerStatus.Stopped:
                    return new SolidColorBrush(Colors.Red);
                    break;
                default:
                    return new SolidColorBrush(Colors.Yellow);
            }

            return new SolidColorBrush(Colors.LightGray);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }

    }
}
