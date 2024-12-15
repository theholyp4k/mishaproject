using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TourismRoute
{
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void UserBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            User user = new User();
            user.ShowDialog();
            this.ShowDialog();
        }
        private void RoutesBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Routes routes = new Routes();
            routes.ShowDialog();
            this.ShowDialog();
        }

        private void BackBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}
