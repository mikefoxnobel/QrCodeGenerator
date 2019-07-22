using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class BezahlCodePayloadViewModel : BindableBase, IPayloadViewModel
    {
        private PayloadGenerator.BezahlCode.AuthorityType _authority;
        private string _name;
        private string _account;
        private string _bnc;
        private string _iban;
        private string _bic;
        private decimal _amount;
        private string _periodicTimeunit = "";
        private int _periodicTimeunitRotation = 0;
        private DateTime? _periodicFirstExecutionDate = null;
        private DateTime? _periodicLastExecutionDate = null;
        private string _creditorId = "";
        private string _mandateId = "";
        private DateTime? _dateOfSignature = null;
        private string _reason = "";
        private int _postingKey = 0;
        private string _sepaReference = "";
        private PayloadGenerator.BezahlCode.Currency _currency = PayloadGenerator.BezahlCode.Currency.EUR;
        private DateTime? _executionDate = null;
        private int _internalMode = 0;

        public PayloadGenerator.BezahlCode.AuthorityType Authority
        {
            get { return this._authority; }
            set { this._authority = value; }
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public string Account
        {
            get { return this._account; }
            set { this._account = value; }
        }

        public string Bnc
        {
            get { return this._bnc; }
            set { this._bnc = value; }
        }

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

        public decimal Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public string PeriodicTimeunit
        {
            get { return this._periodicTimeunit; }
            set { this._periodicTimeunit = value; }
        }

        public int PeriodicTimeunitRotation
        {
            get { return this._periodicTimeunitRotation; }
            set { this._periodicTimeunitRotation = value; }
        }

        public DateTime? PeriodicFirstExecutionDate
        {
            get { return this._periodicFirstExecutionDate; }
            set { this._periodicFirstExecutionDate = value; }
        }

        public DateTime? PeriodicLastExecutionDate
        {
            get { return this._periodicLastExecutionDate; }
            set { this._periodicLastExecutionDate = value; }
        }

        public string CreditorId
        {
            get { return this._creditorId; }
            set { this._creditorId = value; }
        }

        public string MandateId
        {
            get { return this._mandateId; }
            set { this._mandateId = value; }
        }

        public DateTime? DateOfSignature
        {
            get { return this._dateOfSignature; }
            set { this._dateOfSignature = value; }
        }

        public string Reason
        {
            get { return this._reason; }
            set { this._reason = value; }
        }

        public int PostingKey
        {
            get { return this._postingKey; }
            set { this._postingKey = value; }
        }

        public string SepaReference
        {
            get { return this._sepaReference; }
            set { this._sepaReference = value; }
        }

        public PayloadGenerator.BezahlCode.Currency Currency1
        {
            get { return this._currency; }
            set { this._currency = value; }
        }

        public DateTime? ExecutionDate
        {
            get { return this._executionDate; }
            set { this._executionDate = value; }
        }

        public int InternalMode
        {
            get { return this._internalMode; }
            set { this._internalMode = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
