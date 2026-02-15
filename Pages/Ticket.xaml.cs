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
            var flights = mainWindow.ticketsClasses.FindAll(t =>
                t.from.Equals(from, StringComparison.OrdinalIgnoreCase) &&
                t.to.Equals(to, StringComparison.OrdinalIgnoreCase));

            // Здесь можно разделить на рейсы туда и обратно по датам

            FlightsContainer.Children.Clear();

            // Заголовок "Туда"
            TextBlock thereHeader = new TextBlock
            {
                Text = $"Туда: {departureDate}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 10, 0, 10)
            };
            FlightsContainer.Children.Add(thereHeader);

            // Рейсы туда (фильтр по дате)
            foreach (var flight in flights)
            {
                Item item = new Item();
                item.DataContext = flight;
                FlightsContainer.Children.Add(item);
            }

            // Заголовок "Обратно"
            TextBlock backHeader = new TextBlock
            {
                Text = $"Обратно: {returnDate}",
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Margin = new Thickness(0, 20, 0, 10)
            };
            FlightsContainer.Children.Add(backHeader);

            // Рейсы обратно (фильтр по дате)
            // Аналогично
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.frame.Navigate(new Main());
        }
    }
}