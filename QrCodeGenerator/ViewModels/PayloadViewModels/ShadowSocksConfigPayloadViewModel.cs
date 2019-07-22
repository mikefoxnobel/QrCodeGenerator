using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class ShadowSocksConfigPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string hostname;
        private int port;
        private string password;
        private PayloadGenerator.ShadowSocksConfig.Method method;
        private string tag = null;

        public string Hostname
        {
            get { return this.hostname; }
            set { this.hostname = value; }
        }

        public int Port
        {
            get { return this.port; }
            set { this.port = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public PayloadGenerator.ShadowSocksConfig.Method Method
        {
            get { return this.method; }
            set { this.method = value; }
        }

        public string Tag
        {
            get { return this.tag; }
            set { this.tag = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
