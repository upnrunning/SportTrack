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
    /// Interaction logic for CreatingAccount.xaml
    /// </summary>
    public partial class CreatingAccount : Window
    {
        
        ModelRepository model = new ModelRepository();
        public CreatingAccount()
        {
            InitializeComponent();
        }

        private void End_Registration(object sender, RoutedEventArgs e)
        {
            if (model.CheckingLogin(TextLogin.Text) == true)
            {
                if ((PasswordPass.Password != "") && (TextName.Text != "") && (TextLogin.Text != "") && (TextAge.ToString() != ""))
                {
                    string a = TextLogin.Text;
                    string b = TextName.Text;
                    int c = Int32.Parse(TextAge.Text);
                    string d = PasswordPass.ToString();
                    model.AddUser(a, b, c, d);
                    MessageBox.Show("You are registred");
                    SignIn open = new SignIn();
                    open.Show();
                    this.Close();
                }
                else { MessageBox.Show("All fields must be filled"); }

            }
            else MessageBox.Show("This login is reserved.");
        }
    }
}
