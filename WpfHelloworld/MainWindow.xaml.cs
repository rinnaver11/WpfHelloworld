using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfHelloworld
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Dictionary<string, string> users = new Dictionary<string, string>()
        {
            { "login", "12345" }
        };

        string LoginAttempt(string login, string passwd)
        {
            return users.TryGetValue(login, out passwd) ? "Login successful!" : "User not found!";
        }

        private void LoginClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(LoginAttempt(loginTextBox.Text, passwdTextBox.Text));
        }
    }
}