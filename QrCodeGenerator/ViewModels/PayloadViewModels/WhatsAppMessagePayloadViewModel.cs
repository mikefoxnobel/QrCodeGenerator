using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class WhatsAppMessagePayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _message;

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
