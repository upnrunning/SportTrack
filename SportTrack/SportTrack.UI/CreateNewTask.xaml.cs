using SportTrack.Logic.Model;
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
using System.Windows.Shapes;

namespace SportTrack.UI
{
    /// <summary>
    /// Логика взаимодействия для CreateNewTask.xaml
    /// </summary>
    public partial class CreateNewTask : Window
    {
        Context context = new Context();
        ModelRepository add = new ModelRepository();
        public CreateNewTask()
        {
            
            InitializeComponent();
            DateTime a = new DateTime(1, 1, 1);
            CalendarDateRange u = new CalendarDateRange(a, Convert.ToDateTime(DateTime.Today.AddDays(-1))); //блакаут для первого календаря 
            First_Date.BlackoutDates.Clear();
            First_Date.BlackoutDates.Add(u);
            Second_Date.BlackoutDates.Clear();
            Second_Date.BlackoutDates.Add(u);
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        private void AAAAA_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //блэкаут для второго календаря
        {
            DateTime a = new DateTime(1, 1, 1);
            DateTime? b = First_Date.SelectedDate;
            if (First_Date.SelectedDate != null)
            {
                b = First_Date.SelectedDate;
            }


            CalendarDateRange r = new CalendarDateRange(a, Convert.ToDateTime(b));
            Second_Date.BlackoutDates.Clear();
            Second_Date.BlackoutDates.Add(r);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            if (Qualitative.IsChecked == false)
            {
                s = "Качественная";
            }
            else s = "Количественная";
            add.AddGoal(NameForTask.Text, DescriptionOfTask.Text, First_Date.DisplayDate, Second_Date.DisplayDate, s);
            MainWindow a = new MainWindow();
            a.Close();
            a.Show();
            
        }

        private void f1_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextQualitative.Visibility = Visibility.Collapsed;
            TaskForQualitative.Visibility = Visibility.Collapsed;
            
        }

        private void Qualitative_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TaskForQualitative.Visibility = Visibility.Visible;
            TextQualitative.Visibility = Visibility.Visible;
        }
    }
 }
