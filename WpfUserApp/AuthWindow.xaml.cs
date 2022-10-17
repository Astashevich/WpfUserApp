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

namespace WpfUserApp
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void ButtonAuth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Minimum login length 5 characters.";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                passwordBox.ToolTip = "Minimum password length 5 characters.";
                passwordBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;

                User authUser = null;
                using(var db = new ApplicationDbContext())
                {
                    authUser = db.Users.Where(u => u.Login.Equals(login) && u.Password.Equals(password)).FirstOrDefault();
                }

                if (authUser != null) MessageBox.Show($"Welcome, {authUser.Login}");
                else MessageBox.Show("Oooppsss.... Something went wrong!");
            }
        }
    }
}
