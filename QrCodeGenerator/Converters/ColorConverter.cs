using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using QRCoder;

namespace QrCodeGenerator.Converters
{
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color)
            {
                System.Windows.Media.Color color = (System.Windows.Media.Color)value;
                if (targetType == typeof(System.Drawing.Color))
                {
                    return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (value is System.Drawing.Color)
            {
                System.Drawing.Color color = (System.Drawing.Color)value;
                if (targetType == typeof(System.Windows.Media.Color))
                {
                    return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is System.Windows.Media.Color)
            {
                System.Windows.Media.Color color = (System.Windows.Media.Color)value;
                if (targetType == typeof(System.Drawing.Color))
                {
                    return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else if (value is System.Drawing.Color)
            {
                System.Drawing.Color color = (System.Drawing.Color)value;
                if (targetType == typeof(System.Windows.Media.Color))
                {
                    return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
