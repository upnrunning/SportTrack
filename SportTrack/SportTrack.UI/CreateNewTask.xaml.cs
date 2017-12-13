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
        public CreateNewTask()
        {
            InitializeComponent();
            DateTime a = new DateTime(1, 1, 1);
            CalendarDateRange u = new CalendarDateRange(a, Convert.ToDateTime(DateTime.Today.AddDays(-1))); //блакаут для первого календаря 
            AAAAA.BlackoutDates.Clear();
            AAAAA.BlackoutDates.Add(u);
            basd.BlackoutDates.Clear();
            basd.BlackoutDates.Add(u);
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        private void AAAAA_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //блэкаут для второго календаря
        {
            DateTime a = new DateTime(1, 1, 1);
            DateTime? b = AAAAA.SelectedDate;
            if (AAAAA.SelectedDate != null)
            {
                b = AAAAA.SelectedDate;
            }


            CalendarDateRange r = new CalendarDateRange(a, Convert.ToDateTime(b));
            basd.BlackoutDates.Clear();
            basd.BlackoutDates.Add(r);

        }
    }
 }
