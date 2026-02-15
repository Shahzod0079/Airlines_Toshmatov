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
            string connection = "server=localhost;port=3306;database=airlines;uid=root;pwd=shSH..,,";

            using (MySqlConnection mySqlConnection = new MySqlConnection(connection))
            {
                mySqlConnection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM tickets;", mySqlConnection);
                MySqlDataReader ticket_query = cmd.ExecuteReader();

                while (ticket_query.Read())
                {
                    ticketsClasses.Add(new TicketClass(
                        ticket_query.GetValue(1).ToString(), 
                        ticket_query.GetValue(2).ToString(), 
                        ticket_query.GetValue(3).ToString(), 
                        ticket_query.GetValue(4).ToString(), 
                        ticket_query.GetValue(5).ToString(), 
                        ticket_query.GetValue(6).ToString()  
                    ));
                }
                ticket_query.Close();
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
