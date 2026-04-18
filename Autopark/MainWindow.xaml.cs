using Autopark.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autopark
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
            private User _currentUser;

            public MainWindow(User user)
            {
                InitializeComponent();
                _currentUser = user;
            txtUserInfo.Text = $"{user.full_name} ({user.role})";
            if (user.role != "manager")
            {
                btnCreateRequest.Visibility = Visibility.Visible;   
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                LoadCars();
            }

            private void LoadCars()
            {
                dgCars.ItemsSource = Database.GetCars();
            }

            private void BtnCreateRequest_Click(object sender, RoutedEventArgs e)
            {
                var selectedCar = dgCars.SelectedItem as Car;
                if (selectedCar == null)
                {
                    MessageBox.Show("Выберите автомобиль из списка");
                    return;
                }

                var requestWindow = new CreateRequestWindow(selectedCar);
                if (requestWindow.ShowDialog() == true)
                {
                    Database.CreateMaintenanceRequest(selectedCar.id, requestWindow.Description);
                    MessageBox.Show("Заявка оформлена");
                }
            }

            private void BtnLogout_Click(object sender, RoutedEventArgs e)
            {
                new LoginWindow().Show();
                Close();
            }
        }
    }

