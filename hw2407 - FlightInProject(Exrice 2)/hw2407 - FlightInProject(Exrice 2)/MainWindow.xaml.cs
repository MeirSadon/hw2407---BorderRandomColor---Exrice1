using FlightManagementProject;
using FlightManagementProject.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace hw2407___FlightInProject_Exrice_2_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModelForFlight mvvm = new ViewModelForFlight(); 

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mvvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mvvm.MyFlight = new AnonymousUserFacade().GetFlightById(Convert.ToInt32(numberFlightTxtBx.Text));
        }
    }
}
