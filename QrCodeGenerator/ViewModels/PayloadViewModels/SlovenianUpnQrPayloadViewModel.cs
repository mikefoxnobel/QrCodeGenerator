using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class SlovenianUpnQrPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _payerName;
        private string _payerAddress;
        private string _payerPlace;
        private string _recipientName;
        private string _recipientAddress;
        private string _recipientPlace;
        private string _recipientIban;
        private string _description;
        private double _amount;
        private DateTime? _deadline;
        private string _recipientSiModel = "SI99";
        private string _recipientSiReference = "";
        private string _code = "OTHR";

        public string PayerName
        {
            get { return this._payerName; }
            set { this._payerName = value; }
        }

        public string PayerAddress
        {
            get { return this._payerAddress; }
            set { this._payerAddress = value; }
        }

        public string PayerPlace
        {
            get { return this._payerPlace; }
            set { this._payerPlace = value; }
        }

        public string RecipientName
        {
            get { return this._recipientName; }
            set { this._recipientName = value; }
        }

        public string RecipientAddress
        {
            get { return this._recipientAddress; }
            set { this._recipientAddress = value; }
        }

        public string RecipientPlace
        {
            get { return this._recipientPlace; }
            set { this._recipientPlace = value; }
        }

        public string RecipientIban
        {
            get { return this._recipientIban; }
            set { this._recipientIban = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public double Amount
        {
            get { return this._amount; }
            set { this._amount = value; }
        }

        public DateTime? Deadline
        {
            get { return this._deadline; }
            set { this._deadline = value; }
        }

        public string RecipientSiModel
        {
            get { return this._recipientSiModel; }
            set { this._recipientSiModel = value; }
        }

        public string RecipientSiReference
        {
            get { return this._recipientSiReference; }
            set { this._recipientSiReference = value; }
        }

        public string Code
        {
            get { return this._code; }
            set { this._code = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
