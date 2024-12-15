using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TourismRoute
{
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" || PasswordTextBox.Text == "")
            {
                MessageBox.Show("Не заполнены логин и пароль");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(DataBase.strConnection);
                connection.Open();


                MySqlCommand command = new MySqlCommand(DataBase.CheckLog(LoginTextBox.Text), connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new MySqlCommand(DataBase.Registration(LoginTextBox.Text, PasswordTextBox.Text), connection);
                    LoginTextBox.Text = "";
                    PasswordTextBox.Text = "";
                    command.ExecuteNonQuery();
                    List<Users> users = new List<Users>();
                    command = new MySqlCommand(DataBase.Users, connection);

                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        users.Add(new Users(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                            ));
                    }
                    reader.Close();
                    this.DataGridUsers.ItemsSource = users;
                }
                connection.Close();
            }
        }
    }
}
