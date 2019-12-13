using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Ninject;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Ninject;
using Prism.Ninject.Ioc;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.ViewModels;
using QrCodeGenerator.ViewModels.PayloadViewModels;
using QrCodeGenerator.Views;
using QrCodeGenerator.Views.PayloadViews;
using QRCoder;

namespace QrCodeGenerator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IQrCodeHelper, QrCodeHelper>();
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();

            #region Main
            ViewModelLocationProvider.Register<MainWindow, MainViewModel>();
            #endregion

            #region Views
            ViewModelLocationProvider.Register<ConfigurationView, ConfigurationViewModel>();
            ViewModelLocationProvider.Register<JsonQrView, JsonQrViewModel>();
            ViewModelLocationProvider.Register<MultiLineQrView, MultiLineQrViewModel>();
            ViewModelLocationProvider.Register<PayloadQrView, PayloadQrViewModel>();
            ViewModelLocationProvider.Register<TextQrView, TextQrViewModel>();
            #endregion

            #region Payload Views
            ViewModelLocationProvider.Register<BezahlCodePayloadView, BezahlCodePayloadViewModel>();
            ViewModelLocationProvider.Register<BitcoinAddressPayloadView, BitcoinAddressPayloadViewModel>();
            ViewModelLocationProvider.Register<BookmarkPayloadView, BookmarkPayloadViewModel>();
            ViewModelLocationProvider.Register<CalendarEventPayloadView, CalendarEventPayloadViewModel>();
            ViewModelLocationProvider.Register<ContactDataPayloadView, ContactDataPayloadViewModel>();
            ViewModelLocationProvider.Register<GeolocationPayloadView, GeolocationPayloadViewModel>();
            ViewModelLocationProvider.Register<GirocodePayloadView, GirocodePayloadViewModel>();
            ViewModelLocationProvider.Register<MailPayloadView, MailPayloadViewModel>();
            ViewModelLocationProvider.Register<MmsPayloadView, MmsPayloadViewModel>();
            ViewModelLocationProvider.Register<MoneroTransactionPayloadView, MoneroTransactionPayloadViewModel>();
            ViewModelLocationProvider.Register<OneTimePasswordPayloadView, OneTimePasswordPayloadViewModel>();
            ViewModelLocationProvider.Register<PhoneNumberPayloadView, PhoneNumberPayloadViewModel>();
            ViewModelLocationProvider.Register<ShadowSocksConfigPayloadView, ShadowSocksConfigPayloadViewModel>();
            ViewModelLocationProvider.Register<SkypeCallPayloadView, SkypeCallPayloadViewModel>();
            ViewModelLocationProvider.Register<SlovenianUpnQrPayloadView, SlovenianUpnQrPayloadViewModel>();
            ViewModelLocationProvider.Register<SmsPayloadView, SmsPayloadViewModel>();
            ViewModelLocationProvider.Register<SwissQrCodePayloadView, SwissQrCodePayloadViewModel>();
            ViewModelLocationProvider.Register<UrlPayloadView, UrlPayloadViewModel>();
            ViewModelLocationProvider.Register<WhatsAppMessagePayloadView, WhatsAppMessagePayloadViewModel>();
            ViewModelLocationProvider.Register<WifiPayloadView, WifiPayloadViewModel>();
            #endregion

        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
