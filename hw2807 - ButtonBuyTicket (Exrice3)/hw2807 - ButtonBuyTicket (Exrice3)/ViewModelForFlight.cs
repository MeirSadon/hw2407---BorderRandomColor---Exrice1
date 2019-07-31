using Prism.Commands;
using FlightManagementProject;
using FlightManagementProject.Facade;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace hw2807___ButtonBuyTicket__Exrice3_
{
    public class ViewModelForFlight : INotifyPropertyChanged
    {
        
        private Flight myFlight;
        public Flight MyFlight
        {
            get
            { return this.myFlight; }
            set
            {
                this.myFlight = value;
                OnPropertyChanged("MyFlight");
                
            }
        }

        public ICommand MyActionCommandForSearch { get; set; }
        public ICommand MyActionCommandForBuy { get; set; }
        public DelegateCommand MyDelegate { get; set; }


        public ViewModelForFlight()
        {
            myFlight = new Flight();

            MyActionCommandForSearch = new ActionCommand<string>((s) => { return true; },
                (s) => MyFlight = new AnonymousUserFacade().GetFlightById(Convert.ToInt32(s)));

            MyDelegate = new DelegateCommand(() => {MessageBox.Show($"Congratulations!!\n You Buy Ticket For Flight Number: {MyFlight.Id}.");
            }, () => { return MyFlight.Departure_Time > DateTime.Now && MyFlight.Remaining_Tickets > 0; });

            Task.Run(() =>
            {
                while (true)
                {
                    MyDelegate.RaiseCanExecuteChanged();
                    Thread.Sleep(500);
                }
            });

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
