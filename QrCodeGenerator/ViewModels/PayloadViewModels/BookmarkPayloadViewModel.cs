using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class BookmarkPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _url;
        private string _title;

        public string Url
        {
            get { return this._url; }
            set { this._url = value; }
        }

        public string Title
        {
            get { return this._title; }
            set { this._title = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
