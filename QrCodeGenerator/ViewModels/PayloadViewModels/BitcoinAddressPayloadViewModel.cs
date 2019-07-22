using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class BitcoinAddressPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _address;
        private double? _amount;
        private string _label = null;
        private string _message = null;

        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public double? Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
