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
using Airlines;
using MySql.Data.MySqlClient;

namespace Airlines_Toshmatov
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>



    public partial class MainWindow : Window
    {
        public List<TicketClass> ticketsClasses = new List<TicketClass>();
        public MainWindow()
        {
            InitializeComponent();
            frame.Navigate(new Pages.Main()); 

        }
        public void LoadTickets()
        {
            ticketsClasses.Clear();
            string connection = "server=localhost;port=3306;database=airlines;uid=root;pwd=";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tickets;", mySqlConnection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // Получаем время и обрезаем секунды
                    string timeWay = reader["time_way"]?.ToString() ?? "";
                    if (timeWay.Length >= 5)
                    {
                        timeWay = timeWay.Substring(0, 5); 
                    }

                    ticketsClasses.Add(new TicketClass(
                        reader["from"]?.ToString() ?? "",        
                        reader["to"]?.ToString() ?? "",          
                        reader["price"]?.ToString() ?? "0",      
                        timeWay,                             
                        "",                                       
                        reader["time_start"]?.ToString() ?? ""   
                    ));
                }
                reader.Close();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
