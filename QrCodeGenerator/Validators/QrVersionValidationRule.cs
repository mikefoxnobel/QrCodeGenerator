using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace QrCodeGenerator.Validators
{
    public class QrVersionValidationRule : ValidationRule
    {
        private int _autoVersion = -1;
        private int _minimumVersion = 0;
        private int _maximumVersion = 40;
        private string _errorMessage;

        public int AutoVersion
        {
            get { return this._autoVersion; }
            set { this._autoVersion = value; }
        }
        public int MinimumVersion
        {
            get { return this._minimumVersion; }
            set { this._minimumVersion = value; }
        }

        public int MaximumVersion
        {
            get { return this._maximumVersion; }
            set { this._maximumVersion = value; }
        }

        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { this._errorMessage = value; }
        }

        public override ValidationResult Validate(object value,
            CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = (value ?? string.Empty).ToString();
            int version = -1;
            if (Int32.TryParse(inputString, out version))
            {
                if (version == this.AutoVersion)
                {

                }
                else if (version >= this.MinimumVersion && version <= this.MaximumVersion)
                {

                }
                else
                {
                    this.ErrorMessage = $"{this.MinimumVersion} to {this.MaximumVersion}, or {this.AutoVersion}";
                    result = new ValidationResult(false, this.ErrorMessage);
                }
            }
            else
            {
                this.ErrorMessage = $"{this.MinimumVersion} to {this.MaximumVersion}, or {this.AutoVersion}";
                result = new ValidationResult(false, this.ErrorMessage);
            }
            return result;
        }
    }

}
