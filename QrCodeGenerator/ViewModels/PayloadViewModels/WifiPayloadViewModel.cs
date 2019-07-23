using Prism.Mvvm;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QrCodeGenerator.Helpers;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class WifiPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _ssid = string.Empty;
        private string _password = string.Empty;
        private PayloadGenerator.WiFi.Authentication _authenticationMode = PayloadGenerator.WiFi.Authentication.WPA;
        private bool _isHiddenSSID = false;

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

        public IEnumerable<KeyValuePair<PayloadGenerator.WiFi.Authentication, string>> AllAuthenticationModes => EnumExtension.GetAllValuesAndDescriptions<PayloadGenerator.WiFi.Authentication>();

        PayloadGenerator.Payload IPayloadViewModel.Payload => new PayloadGenerator.WiFi(this.Ssid, this.Password, this.AuthenticationMode, this.IsHiddenSsid);
    }
}
