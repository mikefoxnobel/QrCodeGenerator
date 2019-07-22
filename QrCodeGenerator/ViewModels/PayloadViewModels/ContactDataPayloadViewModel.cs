using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class ContactDataPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private PayloadGenerator.ContactData.ContactOutputType _outputType;
        private string _firstname;
        private string _lastname;
        private string _nickname = null;
        private string _phone = null;
        private string _mobilePhone = null;
        private string _workPhone = null;
        private string _email = null;
        private DateTime? _birthday = null;
        private string _website = null;
        private string _street = null;
        private string _houseNumber = null;
        private string _city = null;
        private string _zipCode = null;
        private string _country = null;
        private string _note = null;
        private string _stateRegion = null;
        private PayloadGenerator.ContactData.AddressOrder _addressOrder = PayloadGenerator.ContactData.AddressOrder.Default;

        public PayloadGenerator.ContactData.ContactOutputType OutputType
        {
            get { return this._outputType; }
            set { this._outputType = value; }
        }

        public string Firstname
        {
            get { return this._firstname; }
            set { this._firstname = value; }
        }

        public string Lastname
        {
            get { return this._lastname; }
            set { this._lastname = value; }
        }

        public string Nickname
        {
            get { return this._nickname; }
            set { this._nickname = value; }
        }

        public string Phone
        {
            get { return this._phone; }
            set { this._phone = value; }
        }

        public string MobilePhone
        {
            get { return this._mobilePhone; }
            set { this._mobilePhone = value; }
        }

        public string WorkPhone
        {
            get { return this._workPhone; }
            set { this._workPhone = value; }
        }

        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        public DateTime? Birthday
        {
            get { return this._birthday; }
            set { this._birthday = value; }
        }

        public string Website
        {
            get { return this._website; }
            set { this._website = value; }
        }

        public string Street
        {
            get { return this._street; }
            set { this._street = value; }
        }

        public string HouseNumber
        {
            get { return this._houseNumber; }
            set { this._houseNumber = value; }
        }

        public string City
        {
            get { return this._city; }
            set { this._city = value; }
        }

        public string ZipCode
        {
            get { return this._zipCode; }
            set { this._zipCode = value; }
        }

        public string Country
        {
            get { return this._country; }
            set { this._country = value; }
        }

        public string Note
        {
            get { return this._note; }
            set { this._note = value; }
        }

        public string StateRegion
        {
            get { return this._stateRegion; }
            set { this._stateRegion = value; }
        }

        public PayloadGenerator.ContactData.AddressOrder AddressOrder
        {
            get { return this._addressOrder; }
            set { this._addressOrder = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
