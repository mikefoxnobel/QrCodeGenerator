using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using QRCoder;

namespace QrCodeGenerator.ViewModels.PayloadViewModels
{
    public class CalendarEventPayloadViewModel : BindableBase, IPayloadViewModel
    {
        private string _subject;
        private string _description;
        private string _location;
        private DateTime _start;
        private DateTime _end;
        private bool _allDayEvent;
        private PayloadGenerator.CalendarEvent.EventEncoding _encoding = PayloadGenerator.CalendarEvent.EventEncoding.Universal;

        public string Subject
        {
            get { return this._subject; }
            set { this._subject = value; }
        }

        public string Description
        {
            get { return this._description; }
            set { this._description = value; }
        }

        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        public DateTime Start
        {
            get { return this._start; }
            set { this._start = value; }
        }

        public DateTime End
        {
            get { return this._end; }
            set { this._end = value; }
        }

        public bool AllDayEvent
        {
            get { return this._allDayEvent; }
            set { this._allDayEvent = value; }
        }

        public PayloadGenerator.CalendarEvent.EventEncoding Encoding1
        {
            get { return this._encoding; }
            set { this._encoding = value; }
        }

        PayloadGenerator.Payload IPayloadViewModel.Payload => throw new NotImplementedException();
    }
}
