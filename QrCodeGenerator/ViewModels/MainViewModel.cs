using Prism.Mvvm;
using QrCodeGenerator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QrCodeGenerator.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Fields
        private Dictionary<string, UserControl> _qrCodeModeList = new Dictionary<string, UserControl>();
        private UserControl _selectedView;
        #endregion

        #region Properties
        public Dictionary<string, UserControl> QrCodeModeList { get => this._qrCodeModeList; }
        public UserControl SelectedView { get => this._selectedView; set => this.SetProperty(ref this._selectedView, value); }

        #endregion


        public MainViewModel()
        {
            this.InitQrCodeModeList();
        }


        public void InitQrCodeModeList()
        {
            this.QrCodeModeList.Clear();

            this.QrCodeModeList.Add("Text Mode", new TextQrView());
            this.QrCodeModeList.Add("Multiple Lines Mode", new MultiLineQrView());
            this.QrCodeModeList.Add("Json Mode", new JsonQrView());
            this.RaisePropertyChanged(nameof(this.QrCodeModeList));

            this.SelectedView = this.QrCodeModeList["Text Mode"];
        }
    }
}
