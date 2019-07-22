using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class GeolocationPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _latitude;
        private string _longitude;
        private PayloadGenerator.Geolocation.GeolocationEncoding _encoding = PayloadGenerator.Geolocation.GeolocationEncoding.GEO;

        public string Latitude
        {
            get { return this._latitude; }
            set { this._latitude = value; }
        }

        public string Longitude
        {
            get { return this._longitude; }
            set { this._longitude = value; }
        }

        public PayloadGenerator.Geolocation.GeolocationEncoding Encoding
        {
            get { return this._encoding; }
            set { this._encoding = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
