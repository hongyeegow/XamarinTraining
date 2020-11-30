using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinTraining.Model;
using XamarinTraining.Services;

namespace XamarinTraining.ViewModel
{
    public class NearbyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        IFoursquare _rest = DependencyService.Get<IFoursquare>();

        private ObservableCollection<Venue> venue;

        public ObservableCollection<Venue> Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Venue"));
            }
        }

        public NearbyViewModel()
        {
            GetVenue();
        }

        public async void GetVenue()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    var result = await _rest.getvenue(location.Latitude, location.Longitude);

                    if (result != null)
                    {
                        Venue = result.response.venues;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
