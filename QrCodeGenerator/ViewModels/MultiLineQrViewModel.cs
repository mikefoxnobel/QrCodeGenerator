using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using QrCodeGenerator.Helpers;
using QrCodeGenerator.Models;
using Clipboard = System.Windows.Clipboard;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace QrCodeGenerator.ViewModels
{
    public class MultiLineQrViewModel : BindableBase
    {
        private static string[] __splitter = { "\r\n", "\r", "\n" };
        private QrCodeHelper _helper => Core.Instance.QrHelper;
        private FolderBrowserDialog _folderDialog;
        #region Field
        private string _text = string.Empty;
        private string[] _textLines = { "" };
        private ImageSource _image = null;
        private int _lineIndex = 0;
        private int _lineCount = 0;
        private int _imageSavedCount = 0;
        private bool _enableView = false;
        private SnackbarMessageQueue _messageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.5));
        #endregion

        #region Property
        public string Text
        {
            get { return this._text; }
            set
            {
                if (this.SetProperty(ref this._text, value))
                {
                    this._textLines = this._text.Split(__splitter, StringSplitOptions.None);
                    this.LineCount = 0;
                    this.LineIndex = 0;
                    this.EnableView = false;
                }
            }
        }

        public SnackbarMessageQueue MessageQueue
        {
            get { return this._messageQueue; }
            set { this.SetProperty(ref this._messageQueue, value); }
        }

        public ImageSource Image
        {
            get { return this._image; }
            set { this.SetProperty(ref this._image, value); }
        }

        public int LineIndex
        {
            get { return this._lineIndex; }
            set
            {
                if (value <= 0)
                {
                    value = this._lineCount > 0 ? 1 : 0;
                }
                else if (value > this._lineCount)
                {
                    value = this._lineCount;
                }
                this.SetProperty(ref this._lineIndex, value);
            }
        }

        public int LineCount
        {
            get { return this._lineCount; }
            set
            {
                this.SetProperty(ref this._lineCount, value);
            }
        }

        public bool EnableView
        {
            get { return this._enableView; }
            set { this.SetProperty(ref this._enableView, value); }
        }

        public int ImageSavedCount
        {
            get { return this._imageSavedCount; }
            set { this.SetProperty(ref this._imageSavedCount, value); }
        }
        #endregion

        #region Command
        public ICommand GenerateCommand => new DelegateCommand(this.OnGenerate);
        public ICommand SaveCommand => new DelegateCommand(this.OnSave);
        public ICommand CopyCommand => new DelegateCommand(this.OnCopy);
        public ICommand PreviousLineCommand => new DelegateCommand(this.OnPreviousLine);
        public ICommand NextLineCommand => new DelegateCommand(this.OnNextLine);
        #endregion

        public MultiLineQrViewModel()
        {
            this.PropertyChanged += this.MultiLineQrViewModel_PropertyChanged;
        }

        private void MultiLineQrViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(this.LineIndex):
                    if (this.LineIndex > 0 && this.LineIndex <= this.LineCount)
                    {
                        this.SetImage(this._textLines[this.LineIndex - 1]);
                    }
                    break;
            }
        }

        private void SetImage(string text)
        {
            Bitmap bitmap = this._helper.GenerateQrBitmap(text);
            this.Image = bitmap.ToWpfBitmap();
        }

        private void OnGenerate()
        {
            this.LineCount = this._textLines.Length;
            this.LineIndex = 1;
            this.EnableView = true;

            if (this.LineIndex > 0 && this.LineIndex <= this.LineCount)
            {
                this.SetImage(this._textLines[this.LineIndex - 1]);
            }
        }
        private void OnCopy()
        {
            if (this.Image != null)
            {
                Clipboard.SetImage(this.Image as BitmapSource);
                this.MessageQueue.Enqueue("QR Code copied to clipboard.");
            }
            else
            {
                this.MessageQueue.Enqueue("No QR Code to copy.");
            }
        }


        private async void OnSave()
        {
            this.OnGenerate();
            if (this._folderDialog == null)
            {
                this._folderDialog = new FolderBrowserDialog()
                {
                    RootFolder = Environment.SpecialFolder.MyComputer,
                    SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
                    Description = "Select Target Folder",
                    ShowNewFolderButton = true,
                };
            }

            DialogResult result = this._folderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                await Task.Run(() =>
                {

                    string formatString = "{0:D" + this.LineCount.ToString().Length + "}";
                    for (int i = 0; i < this.LineCount; i++)
                    {
                        string filename = Path.Combine(this._folderDialog.SelectedPath, string.Format(formatString, i + 1) + this._helper.Config.Codec.FilenameExtension.Split(';')[0].Replace("*", ""));
                        Bitmap bitmap = this._helper.GenerateAndSaveQrBitmap(this._textLines[i], filename);
                        this.ImageSavedCount = i + 1;
                    }
                    this.MessageQueue.Enqueue($"{this.LineCount} QR Codes saved.");
                });
            }

        }

        private void OnPreviousLine()
        {
            this.LineIndex--;
        }

        private void OnNextLine()
        {
            this.LineIndex++;
        }
    }
}
