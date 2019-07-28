using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace hw2407___BorderRandomColor_Exrice1_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int numOfColor;
        public MainWindow()
        {
            InitializeComponent();
            Task.Run(() => { ChooseColor(); });
        }

    private void ChooseColor()
    {
        numOfColor = new Random().Next(7);
        switch (numOfColor)
        {
            case 0:
                { ChangeColor(Brushes.Blue); break; }
            case 1:
                { ChangeColor(Brushes.Red); break; }
            case 2:
                { ChangeColor(Brushes.Yellow); break; }
            case 3:
                { ChangeColor(Brushes.Green); break; }
            case 4:
                { ChangeColor(Brushes.Black); break; }
            case 5:
                { ChangeColor(Brushes.White); break; }
            case 6:
                { ChangeColor(Brushes.Pink); break; }
            case 7:
                { ChangeColor(Brushes.Orange); break; }
            default:
                { ChangeColor(Brushes.Gray); break; }
        }
        Thread.Sleep(1000);
        ChooseColor();
    }

    private void ChangeColor(Brush color)
    {
        Action a = () => {ColorBrd.Background = color;};
        SafeInvoke(a);
    }

    private void SafeInvoke(Action uiWork)
    {
        if (Dispatcher.CheckAccess())
        {
            uiWork.Invoke();
        }
        else
        {
            this.Dispatcher.Invoke(uiWork);
        }
    }
}
}
