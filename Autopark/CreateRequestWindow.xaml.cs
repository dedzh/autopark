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
using System.Windows.Shapes;

namespace Autopark
{
    /// <summary>
    /// Логика взаимодействия для CreateRequestWindow.xaml
    /// </summary>
    public partial class CreateRequestWindow : Window
    {
 
            public string Description { get; private set; }
            private Car _car;

            public CreateRequestWindow(Car car)
            {
                InitializeComponent();
                _car = car;
                txtCarInfo.Text = $"{car.brand} {car.model}, госномер: {car.license_plate}";
            }

            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Введите описание работ");
                    return;
                }
                Description = txtDescription.Text.Trim();
                DialogResult = true;
                Close();
            }

            private void BtnCancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
                Close();
            }
    }
}

