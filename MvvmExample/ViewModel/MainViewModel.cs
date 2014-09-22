using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MvvmExample.Annotations;
using MvvmExample.Model;

namespace MvvmExample.ViewModel
{
    // Yes you just have to do it? inotify-what?
    class MainViewModel : INotifyPropertyChanged
    {
        private RestaurantModel _restaurant;
        private ObservableCollection<RestaurantModel> _restaurants;

        // constructor - executed when you create an instance of this viewmodel
        public MainViewModel()
        {
            // this code is only for testing - things should come from a database someday...
            //add 'fake' restaurants
            _restaurants = new ObservableCollection<RestaurantModel>()
            {
                new RestaurantModel() {Name = "Cafe Vivaldi", Address = "Stændertorvet 8", PhoneNumber = "+45 12345678"},
                new RestaurantModel() {Name = "La fiesta", Address = "Hestetorvet", PhoneNumber = "+45 12345678"}
            };
        }

        // a list of resaturnt made for the view
        public ObservableCollection<RestaurantModel> Restaurants
        {
            get
            {
                return _restaurants;
            }
            set
            {
                // set my restaurans variable to what ever the user wants
                _restaurants = value;
                //tell the view that it changed!!!!
                OnPropertyChanged("Restaurants");
            }
        }

        public RestaurantModel Restaurant
        {
            get
            {
                return _restaurant;
            }
            set
            {
                _restaurant = value;
                OnPropertyChanged("Restaurant");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
