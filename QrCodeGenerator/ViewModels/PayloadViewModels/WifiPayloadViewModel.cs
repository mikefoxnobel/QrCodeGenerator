using Prism.Mvvm;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class WifiPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _ssid;
        private string _password;
        private PayloadGenerator.WiFi.Authentication _authenticationMode;
        private bool _isHiddenSSID;

        public string Ssid
        {
            get { return this._ssid; }
            set { this._ssid = value; }
        }

        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public PayloadGenerator.WiFi.Authentication AuthenticationMode
        {
            get { return this._authenticationMode; }
            set { this._authenticationMode = value; }
        }

        public bool IsHiddenSsid
        {
            get { return this._isHiddenSSID; }
            set { this._isHiddenSSID = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
