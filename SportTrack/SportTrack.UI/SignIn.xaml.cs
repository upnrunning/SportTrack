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
    /// Логика взаимодействия для SingIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        localsql users = new localsql();
        ModelRepository model = new ModelRepository();
        
        public SignIn()
        {
            InitializeComponent();
            
        }

      

        private void Sing_Up(object sender, RoutedEventArgs e)
        {
            ModelRepository model2 = new ModelRepository();
            
            if (model2.CheckingLogin(Login.Text) == false)
            {
                MainWindow openMW = new MainWindow();
                openMW.Show();
                this.Close();
            }
            else MessageBox.Show("This login is reserved.");
        }

        private void CreateAcc(object sender, RoutedEventArgs e)
        {
        
            CreatingAccount create = new CreatingAccount();
            create.Show();
            this.Close();

        }
    }
}
