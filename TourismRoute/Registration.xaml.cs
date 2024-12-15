using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MySqlConnector;

namespace TourismRoute
{
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private TextBox GetPasswordTextBox()
        {
            return PasswordTextBox;
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e, TextBox passwordTextBox)
        {
            if (LoginTextBox.Text == "" ||
                PasswordTextBox.Text == "" ||
                PasswordRepeat.Text == "")
            {
                MessageBox.Show("Вы не ввели логин или пароль");
            }
            else if (PasswordTextBox.Text != PasswordRepeat.Text)
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(DataBase.strConnection);
                connection.Open();

                string
                    login = LoginTextBox.Text,
                    password = passwordTextBox.Text;

                MySqlCommand command = new MySqlCommand(DataBase.CheckLog(login), connection);

                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Такой логин уже существует");
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    command = new MySqlCommand
                        (DataBase.Registration(login, password),
                        connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
                connection.Close();
            }
        }

        private void RegBTN_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == "" ||
                PasswordTextBox.Text == "" ||
                PasswordRepeat.Text == "")
            {
                MessageBox.Show("Вы не ввели логин или пароль");
            }
            else if (PasswordTextBox.Text != PasswordRepeat.Text)
            {
                MessageBox.Show("Ваши пароли не совпадают");
            }
            else
            {
                MySqlConnection connection = new MySqlConnection(DataBase.strConnection);
                connection.Open();

                string
                    login = LoginTextBox.Text,
                    password = PasswordTextBox.Text;

                MySqlCommand command = new MySqlCommand(DataBase.CheckLog(login), connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Такой логин уже существует");
                    reader.Close();
                }
                else
                {
                    reader.Close();
                    command = new MySqlCommand(DataBase.Registration(login, password), connection);
                    command.ExecuteNonQuery();
                    connection.Close();
                    this.Close();
                }
                connection.Close();
            }
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
