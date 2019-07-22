using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class OneTimePasswordPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private PayloadGenerator.OneTimePassword.OneTimePasswordAuthType _type;
        private string _secret;
        private PayloadGenerator.OneTimePassword.OneTimePasswordAuthAlgorithm _authAlgorithm;
        private string _issuer;
        private string _label;
        private int _digits;
        private int? _counter;
        private int? _period;

        public PayloadGenerator.OneTimePassword.OneTimePasswordAuthType Type
        {
            get => this._type;
            set => this._type = value;
        }

        public string Secret
        {
            get => this._secret;
            set => this._secret = value;
        }

        public PayloadGenerator.OneTimePassword.OneTimePasswordAuthAlgorithm AuthAlgorithm
        {
            get => this._authAlgorithm;
            set => this._authAlgorithm = value;
        }

        public string Issuer
        {
            get => this._issuer;
            set => this._issuer = value;
        }

        public string Label
        {
            get => this._label;
            set => this._label = value;
        }

        public int Digits
        {
            get => this._digits;
            set => this._digits = value;
        }

        public int? Counter
        {
            get => this._counter;
            set => this._counter = value;
        }

        public int? Period
        {
            get => this._period;
            set => this._period = value;
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
