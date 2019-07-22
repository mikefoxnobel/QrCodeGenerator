using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class PhoneNumberPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _number;

        public string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
