using SportTrack.Logic.Model;
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
using System.Windows.Shapes;

namespace SportTrack.UI
{
    /// <summary>
    /// Логика взаимодействия для CreateNewTask.xaml
    /// </summary>
    public partial class CreateNewTask : Window
    {
        localsql context = new localsql();
        ModelRepository add = new ModelRepository();
        public CreateNewTask(Objective item)
        {
            if (item.Name != null)
            {
                InitializeComponent();
                NameForTask.Text = item.Name.ToString();
                DescriptionOfTask.Text = item.Description.ToString();
                First_Date.SelectedDate = item.StartingDay;
                Second_Date.SelectedDate = item.LastDay;
                if (item.Type.ToString() == "Qualitative")
                {
                    Quantitative.IsChecked = true;
                    QuantitativeT.Text = item.Type.ToString();
                }
                else
                {
                    Qualitative.IsChecked = true;
                    QualitativeT.Text = item.Type.ToString();
                }
            }
            else
            {
                InitializeComponent();
                DateTime dt = new DateTime(1, 1, 1);
                CalendarDateRange calendardr = new CalendarDateRange(dt, Convert.ToDateTime(DateTime.Today.AddDays(-1))); //блакаут для первого календаря 
                First_Date.BlackoutDates.Clear();
                First_Date.BlackoutDates.Add(calendardr);
                Second_Date.BlackoutDates.Clear();
                Second_Date.BlackoutDates.Add(calendardr);
            }
            
        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }


        private void Fd_SelectedDateChanged(object sender, SelectionChangedEventArgs e) //блэкаут для второго календаря
        {
            DateTime a = new DateTime(1, 1, 1);
            DateTime? firstdate = First_Date.SelectedDate;
            if (First_Date.SelectedDate != null)
            {
                firstdate = First_Date.SelectedDate;
            }


            CalendarDateRange calendardr = new CalendarDateRange(a, Convert.ToDateTime(firstdate));
            Second_Date.BlackoutDates.Clear();
            Second_Date.BlackoutDates.Add(calendardr);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            if (Qualitative.IsChecked == false)
            {
                s = "Qualitative";
            }
            else s = "Quantitative";
            add.AddGoal(NameForTask.Text, DescriptionOfTask.Text, First_Date.SelectedDate.Value, Second_Date.SelectedDate.Value, s);
            MessageBox.Show(Second_Date.SelectedDate.ToString());
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
           
            
            
            
        }

        private void Qualitative_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            TextQualitative.Visibility = Visibility.Collapsed;
            TaskForQualitative.Visibility = Visibility.Collapsed;
            
        }

        private void Quantitative_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //TaskForQualitative.Visibility = Visibility.Visible;
            //TextQualitative.Visibility = Visibility.Visible;
            CreateForQuantityTask open = new CreateForQuantityTask();
            for (int i = 0; i < 1; i++)
            {
                
                open.Show();
                this.Close();
            }
            
           
            
            
        }
    }
 }
