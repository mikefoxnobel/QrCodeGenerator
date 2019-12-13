using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace QrCodeGenerator.Views.PreviewViews
{
    public class PreviewViewBase : UserControl
    {
        #region QR Image
        public static readonly DependencyProperty QrImageProperty = DependencyProperty.Register(nameof(QrImage), typeof(ImageSource), typeof(PreviewViewBase), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, QrImagePropertyChanged));
        private static void QrImagePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PreviewViewBase)d).QrImagePropertyChanged((ImageSource)e.NewValue);
        }
        public ImageSource QrImage
        {
            get => (ImageSource)this.GetValue(QrImageProperty);
            set => this.SetValue(QrImageProperty, value);
        }
        private void QrImagePropertyChanged(ImageSource newValue)
        {
        }
        #endregion
    }
}
