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
using SportTrack.Logic;

namespace SportTrack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //SportsFeedRepository sp = new SportsFeedRepository();
            BingRepository b = new BingRepository();
            InitializeComponent();
            //sp.GetDataAsync("nba", 2017, "playoff", new DateTime(2017, 04, 22), null);

            b.GetBingDataAsync("nba news");
           
        }

        private void Goals_Click(object sender, RoutedEventArgs e)
        {
            CreateNewTask a = new CreateNewTask();
            a.Show();
           
        }
    }
}
