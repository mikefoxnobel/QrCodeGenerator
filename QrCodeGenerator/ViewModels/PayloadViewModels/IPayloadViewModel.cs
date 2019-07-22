using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public interface IPayloadViewModel
    {
        PayloadGenerator.Payload Payload { get; }
    }
}
