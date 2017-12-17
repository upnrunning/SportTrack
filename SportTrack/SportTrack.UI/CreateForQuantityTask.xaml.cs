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
    /// Interaction logic for CreateForQuantityTask.xaml
    /// </summary>
    public partial class CreateForQuantityTask : Window
    {
        public CreateForQuantityTask()
        {
            InitializeComponent();
        }

       
        private void Quantitative_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            localsql a = new localsql();
            Objective item = new Objective();
            CreateNewTask open = new CreateNewTask(item);
            open.Show();
            this.Close();
        }

        private void Qualitative_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
          
            

        }
    }
}
