using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace WpfUserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext _context;

        public MainWindow()
        {
            InitializeComponent();

            _context = new ApplicationDbContext();

            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 0;
            animation.To = 450;
            animation.Duration = TimeSpan.FromSeconds(3);
            RegistrationButton.BeginAnimation(Button.WidthProperty, animation);
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string password = passwordBox.Password.Trim();
            string password2 = passwordBox_2.Password.Trim();
            string email = textBoxEmail.Text.ToLower().Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Minimum login length 5 characters.";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(password.Length < 5)
            {
                passwordBox.ToolTip = "Minimum password length 5 characters.";
                passwordBox.Background = Brushes.DarkRed;
            }
            else if(password != password2)
            {
                passwordBox_2.ToolTip = "Passwords are not equal";
                passwordBox_2.Background = Brushes.DarkRed;
            }
            else if(email.Length < 5 || !email.Contains("@") || !email.Contains(".")) 
            {
                textBoxEmail.ToolTip = "Minimum email length 5 characters or incorect email.";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passwordBox.ToolTip = "";
                passwordBox.Background = Brushes.Transparent;
                passwordBox_2.ToolTip = "";
                passwordBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Registration completed successfully");

                var user = new User(login, email, password);

                _context.Users.Add(user);
                _context.SaveChanges();

                var userPageWindow = new UserPageWindow();
                userPageWindow.Show();
                Hide();
            }
        }

        private void ButtonWindowAuth_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new AuthWindow();
            authWindow.Show();
            Hide();
        }
    }
}
