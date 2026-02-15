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

namespace Airlines_Toshmatov.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string fromCity = (FindName("from") as TextBox)?.Text;
            string toCity = (FindName("to") as TextBox)?.Text;
            string departureDate = (FindName("DepartureDate") as DatePicker)?.SelectedDate?.ToString("yyyy-MM-dd");
            string returnDate = (FindName("ReturnDate") as DatePicker)?.SelectedDate?.ToString("yyyy-MM-dd");

            if (!string.IsNullOrWhiteSpace(fromCity) && !string.IsNullOrWhiteSpace(toCity) &&
                !string.IsNullOrWhiteSpace(departureDate) && !string.IsNullOrWhiteSpace(returnDate))
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                mainWindow.LoadTickets();
                mainWindow.frame.Navigate(new Ticket(fromCity, toCity, departureDate, returnDate));
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}