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
using Airlines_Toshmatov.Elements;

namespace Airlines_Toshmatov.Pages
{
    public partial class Ticket : Page
    {
        public Ticket(string from, string to, string departureDate, string returnDate)
        {
            InitializeComponent();
            LoadFlights(from, to, departureDate, returnDate);
        }

        private void LoadFlights(string from, string to, string departureDate, string returnDate)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;

            // Все рейсы
            var allFlights = mainWindow.ticketsClasses;

            // Рейсы ТУДА (из А в Б на дату туда)
            var flightsThere = allFlights.Where(t =>
                t.from.Equals(from, StringComparison.OrdinalIgnoreCase) &&
                t.to.Equals(to, StringComparison.OrdinalIgnoreCase) &&
                t.date == departureDate).ToList();

            // Рейсы ОБРАТНО (из Б в А на дату обратно)
            var flightsBack = allFlights.Where(t =>
                t.from.Equals(to, StringComparison.OrdinalIgnoreCase) &&
                t.to.Equals(from, StringComparison.OrdinalIgnoreCase) &&
                t.date == returnDate).ToList();

            FlightsContainer.Children.Clear();

            // Заголовок "Туда"
            TextBlock thereHeader = new TextBlock
            {
                Text = $"Туда: {departureDate}",
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                Margin = new Thickness(0, 10, 0, 10)
            };
            FlightsContainer.Children.Add(thereHeader);

            // Рейсы туда
            if (flightsThere.Any())
            {
                foreach (var flight in flightsThere)
                {
                    Item item = new Item();
                    item.DataContext = flight;
                    FlightsContainer.Children.Add(item);
                }
            }
            else
            {
                TextBlock noFlights = new TextBlock
                {
                    Text = "Нет рейсов",
                    FontSize = 14,
                    Foreground = new SolidColorBrush(Colors.Gray),
                    Margin = new Thickness(0, 0, 0, 20)
                };
                FlightsContainer.Children.Add(noFlights);
            }

            // Заголовок "Обратно"
            TextBlock backHeader = new TextBlock
            {
                Text = $"Обратно: {returnDate}",
                FontSize = 18,
                FontWeight = FontWeights.Bold,
                Foreground = new SolidColorBrush(Colors.Black),
                Margin = new Thickness(0, 20, 0, 10)
            };
            FlightsContainer.Children.Add(backHeader);

            // Рейсы обратно
            if (flightsBack.Any())
            {
                foreach (var flight in flightsBack)
                {
                    Item item = new Item();
                    item.DataContext = flight;
                    FlightsContainer.Children.Add(item);
                }
            }
            else
            {
                TextBlock noFlights = new TextBlock
                {
                    Text = "Нет рейсов",
                    FontSize = 14,
                    Foreground = new SolidColorBrush(Colors.Gray),
                    Margin = new Thickness(0, 0, 0, 0)
                };
                FlightsContainer.Children.Add(noFlights);
            }
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.frame.Navigate(new Main());
        }
    }
}