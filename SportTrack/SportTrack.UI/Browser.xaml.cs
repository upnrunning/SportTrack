using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SportTrack.UI
{
    /// <summary>
    /// Логика взаимодействия для Brouser.xaml
    /// </summary>
    public partial class Browser : Window
    {
     
        public Browser()
        {
            
            InitializeComponent();
        }

        public Browser(Uri uri)
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            WebBrowser.Navigate(uri);
            dynamic activeX = WebBrowser.GetType().InvokeMember("ActiveXInstance",
                     BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                     null, WebBrowser, new object[] { }); 

            activeX.Silent = true; // silent the script error message
        }
    }
}
