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
using Autopark.Models;

namespace Autopark
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public User CurrentUser { get; private set; }

            public LoginWindow()
            {
                InitializeComponent();
            }

            private void BtnLogin_Click(object sender, RoutedEventArgs e)
            {
                string login = txtLogin.Text.Trim();
                string pass = txtPassword.Password;

                if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(pass))
                {
                    MessageBox.Show("Введите логин и пароль");
                    return;
                }

                var user = Database.GetUser(login, pass);
                if (user != null)
                {
                    CurrentUser = user;
                    
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }

            private void BtnCancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
                Close();
            }
        }
    }