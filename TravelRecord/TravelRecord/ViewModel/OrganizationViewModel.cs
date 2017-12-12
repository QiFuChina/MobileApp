using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;

namespace TravelRecord.ViewModel
{
    public class OrganizationViewModel : NotificationBase
    {
        Organization organization;
        public OrganizationViewModel(String name)
        {
            organization = new Organization(name);

            // Load the database
            foreach (var event in organization.Event)
            {
                var np = new EventViewModel(event);
                np.PropertyChanged += Event_OnNotifyPropertyChanged;
                _Event.Add(np);
            }
        }

        ObservableCollection<EventViewModel> _Event
           = new ObservableCollection<EventViewModel>();

        public ObservableCollection<EventViewModel> Event
        {
            get { return Event; }
            set => SetProperty(ref Event, value);
        }

        String _Name;
        public String Name
        {
            get { return organization.Name; }
        }

        //int _SelectedIndex;
        //public int SelectedIndex
        //{
        //    get { return _SelectedIndex; }
        //    set
        //    {
        //        if (SetProperty(ref _SelectedIndex, value))
        //        { RaisePropertyChanged(nameof(SelectedEvent)); }
        //    }
        //}

        //public EventViewModel SelectedPerson
        //{
        //    get { return (_SelectedIndex >= 0) ? _Event[_SelectedIndex] : null; }
        //}

        public void Add()
        {
            var event = new EventViewModel();
            event.PropertyChanged += Event_OnNotifyPropertyChanged;
            Event.Add(event);
            organization.Add(event);
            、、SelectedIndex = Event.IndexOf(event);
        }

        //public void Delete()
        //{
        //    if (SelectedIndex != -1)
        //    {
        //        var event = Event [SelectedIndex];
        //        Event.RemoveAt(SelectedIndex);
        //        organization.Delete(event);
        //    }
        //}

        void Event_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            organization.Update((EventViewModel)sender);
        }   
}
}
