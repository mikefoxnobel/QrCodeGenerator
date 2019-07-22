using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class GirocodePayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _iban;
        private string _bic;
        private string _name;
        private decimal _amount;
        private string _remittanceInformation = "";
        private PayloadGenerator.Girocode.TypeOfRemittance _typeOfRemittance = PayloadGenerator.Girocode.TypeOfRemittance.Unstructured;
        private string _purposeOfCreditTransfer = "";
        private string _messageToGirocodeUser = "";
        private PayloadGenerator.Girocode.GirocodeVersion _version = PayloadGenerator.Girocode.GirocodeVersion.Version1;
        private PayloadGenerator.Girocode.GirocodeEncoding _encoding = PayloadGenerator.Girocode.GirocodeEncoding.ISO_8859_1;

        public string Iban
        {
            get { return this._iban; }
            set { this._iban = value; }
        }

        public string Bic
        {
            get { return this._bic; }
            set { this._bic = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public decimal Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public string RemittanceInformation
        {
            get { return this._remittanceInformation; }
            set { this._remittanceInformation = value; }
        }

        public PayloadGenerator.Girocode.TypeOfRemittance TypeOfRemittance
        {
            get { return this._typeOfRemittance; }
            set { this._typeOfRemittance = value; }
        }

        public string PurposeOfCreditTransfer
        {
            get { return this._purposeOfCreditTransfer; }
            set { this._purposeOfCreditTransfer = value; }
        }

        public string MessageToGirocodeUser
        {
            get { return this._messageToGirocodeUser; }
            set { this._messageToGirocodeUser = value; }
        }

        public PayloadGenerator.Girocode.GirocodeVersion Version
        {
            get { return this._version; }
            set { this._version = value; }
        }

        public PayloadGenerator.Girocode.GirocodeEncoding Encoding
        {
            get { return this._encoding; }
            set { this._encoding = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
