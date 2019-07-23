using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using QrCodeGenerator.ViewModels.PayloadViewModels;

namespace QrCodeGenerator.Views.PayloadViews
{
    public abstract class PayloadViewBase : UserControl
    {
        public IPayloadViewModel PayloadViewModel
        {
            get => (IPayloadViewModel)this.DataContext;
            set => this.DataContext = value;
        }
    }
}
