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
            ViewModelLocationProvider.Register<MainWindow, MainViewModel>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }
    }
}
