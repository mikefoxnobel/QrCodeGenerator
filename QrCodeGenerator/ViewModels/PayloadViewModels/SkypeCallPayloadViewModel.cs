using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class SkypeCallPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _skypeUsername;

        public string SkypeUsername
        {
            get { return this._skypeUsername; }
            set { this._skypeUsername = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
