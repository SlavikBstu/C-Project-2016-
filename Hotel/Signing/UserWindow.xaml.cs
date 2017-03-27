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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Signing
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();
            SearchCategory.Visibility = Visibility.Hidden;
            SearchPlace.Visibility = Visibility.Hidden;
            SearchStatus.Visibility = Visibility.Hidden;
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            LoginWindow win = new LoginWindow();
            win.ShowDialog();
        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            BookingWindow win = new BookingWindow();
            win.Show();
            
        }

        private void Category_Click(object sender, RoutedEventArgs e)
        {
            SearchPlace.Visibility = Visibility.Hidden;
            SearchStatus.Visibility = Visibility.Hidden;
            SearchCategory.Visibility = Visibility.Visible;
            SearchCategory.Focus();
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select Distinct CategoryOfRoom as [Категория комнаты], Price as [Цена за сутки] from FondOfNumbers";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "FondOfNumbers");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        private void Having_Click(object sender, RoutedEventArgs e)
        {
            SearchPlace.Visibility = Visibility.Hidden;
            SearchCategory.Visibility = Visibility.Hidden;
            SearchStatus.Visibility = Visibility.Visible;
            SearchStatus.Focus();
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select NumberOfRoom as [Номер комнаты], CategoryOfRoom as [Категория комнаты], Status as [Наличие] from FondOfNumbers";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "FondOfNumbers");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        private void Places_Click(object sender, RoutedEventArgs e)
        {
            SearchStatus.Visibility = Visibility.Hidden;
            SearchCategory.Visibility = Visibility.Hidden;
            SearchPlace.Visibility = Visibility.Visible;
            SearchPlace.Focus();
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select NumberOfRoom as [Номер комнаты], Place as [Место] from Places";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "Places");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        private void SearchPlace_KeyUp(object sender, KeyEventArgs e)
        {
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select NumberOfRoom as [Номер комнаты], Place as [Место] from Places where Place like('%" + SearchPlace.Text + "%')";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "Places");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        private void SearchStatus_KeyUp(object sender, KeyEventArgs e)
        {
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select NumberOfRoom as [Номер комнаты], CategoryOfRoom as [Категория комнаты], Status as [Наличие] from FondOfNumbers where Status like('%" + SearchStatus.Text + "%')";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "FondOfNumbers");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        private void SearchCategory_KeyUp(object sender, KeyEventArgs e)
        {
            
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select Distinct CategoryOfRoom as [Категория комнаты], Price as [Цена за сутки] from FondOfNumbers where CategoryOfRoom like('%" + SearchCategory.Text + "%')";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "FondOfNumbers");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
    }
}
