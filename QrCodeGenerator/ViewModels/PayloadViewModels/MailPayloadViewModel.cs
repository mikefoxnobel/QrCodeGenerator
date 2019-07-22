using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class MailPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _mailReceiver;
        private string _encoding;
        private string _subject;
        private string _message;

        public string MailReceiver
        {
            get => this._mailReceiver;
            set => this._mailReceiver = value;
        }

        public string Encoding
        {
            get => this._encoding;
            set => this._encoding = value;
        }

        public string Subject
        {
            get => this._subject;
            set => this._subject = value;
        }

        public string Message
        {
            get => this._message;
            set => this._message = value;
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
