using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class UrlPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _url;

        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
