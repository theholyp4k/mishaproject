using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySqlConnector;

namespace TourismRoute
{
    public partial class Route : Window
    {
        private string v1;
        private string v2;

        public Route(int v)
        {
            InitializeComponent();
        }

        public Route(int v, string v1, string v2) : this(v)
        {
            this.v1 = v1;
            this.v2 = v2;
        }

        public Route()
        {

        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "" || LenghtTextBox.Text == "")
            {
                MessageBox.Show("Не заполнены имя или длину");
            }

            else
            {
                MySqlConnection connection = new MySqlConnection(DataBase.strConnection);
                connection.Open();

                MySqlCommand command = new MySqlCommand(DataBase.Route(NameTextBox.Text, LenghtTextBox.Text), connection);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    reader.Close();
                    command = new MySqlCommand(DataBase.Route(NameTextBox.Text, LenghtTextBox.Text),connection);
                    NameTextBox.Text = "";
                    LenghtTextBox.Text = "";
                    command.ExecuteNonQuery();
                    List<Routes> routes = new List<Routes>();
                    reader = command.ExecuteReader();
                    while (reader.Read()) {
                        routes.Add(new Routes(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.GetString(2)
                            ));
                    }
                    reader.Close();
                    this.DataGridOrder.ItemsSource = routes;
                }
                connection.Close();
            }
        }
    }
}
