using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class SwissQrCodePayloadViewModel : BindableBase, IPayloadViewModel
    {
        private PayloadGenerator.SwissQrCode.Iban _iban;
        private PayloadGenerator.SwissQrCode.Currency _currency;
        private PayloadGenerator.SwissQrCode.Contact _creditor;
        private PayloadGenerator.SwissQrCode.Reference _reference;
        private PayloadGenerator.SwissQrCode.Contact _debitor = null;
        private decimal? _amount = null;
        private DateTime? _requestedDateOfPayment = null;
        private PayloadGenerator.SwissQrCode.Contact _ultimateCreditor = null;
        private string _alternativeProcedure1 = null;
        private string _alternativeProcedure2 = null;

        public PayloadGenerator.SwissQrCode.Iban Iban
        {
            get { return this._iban; }
            set { this._iban = value; }
        }

        public PayloadGenerator.SwissQrCode.Currency Currency1
        {
            get { return this._currency; }
            set { this._currency = value; }
        }

        public PayloadGenerator.SwissQrCode.Contact Creditor
        {
            get { return this._creditor; }
            set { this._creditor = value; }
        }

        public PayloadGenerator.SwissQrCode.Reference Reference
        {
            get { return this._reference; }
            set { this._reference = value; }
        }

        public PayloadGenerator.SwissQrCode.Contact Debitor
        {
            get { return this._debitor; }
            set { this._debitor = value; }
        }

        public decimal? Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public DateTime? RequestedDateOfPayment
        {
            get { return this._requestedDateOfPayment; }
            set { this._requestedDateOfPayment = value; }
        }

        public PayloadGenerator.SwissQrCode.Contact UltimateCreditor
        {
            get { return this._ultimateCreditor; }
            set { this._ultimateCreditor = value; }
        }

        public string AlternativeProcedure1
        {
            get { return this._alternativeProcedure1; }
            set { this._alternativeProcedure1 = value; }
        }

        public string AlternativeProcedure2
        {
            get { return this._alternativeProcedure2; }
            set { this._alternativeProcedure2 = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
