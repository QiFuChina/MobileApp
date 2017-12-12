using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Data;

namespace TravelRecord.ViewModel
{
    public class EventViewModel : NotificationBase<Event>
    {
        public EventViewModel(Event event = null) : base(Event) { }
        public int ID {
        get { return This.ID; }
        set { SetProperty(This.ID, value, () => This.ID = value); }
        }
        public String Title {
        get { return This.Title; }
        set { SetProperty(This.Title, value, () => This.Title = value); }
        }
        public String Date {
        get { return This.Date; }
        set { SetProperty(This.Date, value, () => This.Date = value); }
        }
        public String Introduction {
        get { return This.Introduction; }
        set { SetProperty(This.Introduction, value, () => This.Introduction = value); }
        }
}
}
