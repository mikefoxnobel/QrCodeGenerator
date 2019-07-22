using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class SmsPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _number;
        private string _subject;
        private PayloadGenerator.SMS.SMSEncoding _encoding = PayloadGenerator.SMS.SMSEncoding.SMS;

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

        public PayloadGenerator.SMS.SMSEncoding Encoding
        {
            get { return this._encoding; }
            set { this._encoding = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
