using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class MmsPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _number;
        private string _subject;
        private PayloadGenerator.MMS.MMSEncoding _encoding = PayloadGenerator.MMS.MMSEncoding.MMS;

        public string Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        public string Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }

        public PayloadGenerator.MMS.MMSEncoding Encoding
        {
            get { return this._encoding; }
            set { this._encoding = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
