using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class MoneroTransactionPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _address;
        private float? _txAmount = null;
        private string _txPaymentId = null;
        private string _recipientName = null;
        private string _txDescription = null;

        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public float? TxAmount
        {
            get { return this._txAmount; }
            set { this._txAmount = value; }
        }

        public string TxPaymentId
        {
            get { return this._txPaymentId; }
            set { this._txPaymentId = value; }
        }

        public string RecipientName
        {
            get { return this._recipientName; }
            set { this._recipientName = value; }
        }

        public string TxDescription
        {
            get { return this._txDescription; }
            set { this._txDescription = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
