using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QrCodeGenerator.Converters
{
    public class ColorToStringConverter : IValueConverter
    {
        private static System.Windows.Media.ColorConverter _mediaColorConverter = new System.Windows.Media.ColorConverter();
        private static System.Drawing.ColorConverter _drawingColorConverter = new System.Drawing.ColorConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color)
            {
                System.Windows.Media.Color color = (System.Windows.Media.Color)value;
                return $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            }
            else if (value is System.Drawing.Color)
            {
                System.Drawing.Color color = (System.Drawing.Color) value;
                return color.IsNamedColor ? color.Name : $"#{color.A:X2}{color.R:X2}{color.G:X2}{color.B:X2}";
            }
            else
            {
                throw new Exception("Source object is not a valid color type.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == typeof(System.Windows.Media.Color))
            {
                return _mediaColorConverter.ConvertFrom(value);
            }
            else if (targetType == typeof(System.Drawing.Color))
            {
                return _drawingColorConverter.ConvertFrom(value);
            }
            else
            {
                throw new Exception("Unknown target type.");
            }
        }
    }
}
