using MySqlConnector;
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

namespace TourismRoute
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string password;



        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if (LogTXT.Text == "" || PassTXT.Text == "")
            {
                MessageBox.Show("Вы не заполнили логин или пароль");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(DataBase.strConnection);
                connection.Open();

                string
                    login = LogTXT.Text;
                password = PassTXT.Text;

                MySqlCommand command = new MySqlCommand(DataBase.Logining(login, password), connection);

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    int id = reader.GetInt32(0);

                    LogTXT.Text = "";
                    PassTXT.Text = "";
                    connection.Close();
                    this.Hide();
                    Admin admin = new Admin();
                    admin.ShowDialog();
                    this.ShowDialog();
                }
                else MessageBox.Show("Вы неверно ввели логин или пароль");

                connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
            this.ShowDialog();
        }
    }
}