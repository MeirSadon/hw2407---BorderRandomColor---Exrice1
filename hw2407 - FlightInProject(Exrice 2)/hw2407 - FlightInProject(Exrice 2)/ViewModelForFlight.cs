using FlightManagementProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2407___FlightInProject_Exrice_2_
{
    class ViewModelForFlight : INotifyPropertyChanged
    {
        private Flight myFlight;
        public Flight MyFlight
        {
            get
            {
                return this.myFlight;
            }
            set
            {
                myFlight = value;
                OnPropertyChanged("MyFlight");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ViewModelForFlight()
        {
            myFlight = new Flight();
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
