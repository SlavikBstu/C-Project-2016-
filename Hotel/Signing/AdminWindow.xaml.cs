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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Signing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DeleteBook.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Hidden;
            DeleteReg.Visibility = Visibility.Hidden;
        }

        private void ReturnButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            LoginWindow win = new LoginWindow();
            win.ShowDialog();
        } 
        public List<Registration> registration = new List<Registration>();
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook.Visibility = Visibility.Hidden;
            DeleteReg.Visibility = Visibility.Visible;
            Change.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Hidden;
            registration.Clear();
            foreach (var temp in LoginWindow.db.Registration)
            {
                registration.Add(temp);
            }
            DataGrid1.ItemsSource = registration.ToList();
        }       
        private void Living_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Visible;
            DeleteReg.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Hidden;
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select Surname as [Фамилия], Name as [Имя], Passport as [Паспортные данные], NumberOfRoom as [Номер комнаты], Place as [Место], DateOfRice as [Дата заезда], DateOfLeave as [Дата выезда] from Living";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "Living");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }
        public List<Booking> booking = new List<Booking>();
        private void Booking_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook.Visibility = Visibility.Visible;
            DeleteReg.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Hidden;
            booking.Clear();
            foreach (var temp in LoginWindow.db.Booking)
            {
                booking.Add(temp);
            }
            DataGrid1.ItemsSource = booking.ToList();
        }
        public List<FondOfNumbers> numb = new List<FondOfNumbers>();
        private void Category_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Visible;
            DeleteReg.Visibility = Visibility.Hidden;
            numb.Clear();
            foreach (var temp in LoginWindow.db.FondOfNumbers)
            {
                numb.Add(temp);
            }
            DataGrid1.ItemsSource = numb.ToList();           
        }

        private void Places_Click(object sender, RoutedEventArgs e)
        {
            DeleteBook.Visibility = Visibility.Hidden;
            AddLiving.Visibility = Visibility.Hidden;
            Change.Visibility = Visibility.Hidden;
            DeleteReg.Visibility = Visibility.Hidden;
            string connetionString = null;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            SqlConnection cnn = new SqlConnection(connetionString);
            string command = "Select NumberOfRoom as [Номер комнаты], Place as [Место] from Places";
            SqlDataAdapter da = new SqlDataAdapter(command, cnn);
            DataSet dt = new DataSet();
            da.Fill(dt, "Places");
            DataGrid1.ItemsSource = dt.Tables[0].DefaultView;
        }

        private void AddLiving_Click(object sender, RoutedEventArgs e)
        {
           Window1 win = new Window1();
           win.Show();
           
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow.db.SaveChanges();
        }
        
        private void DataGrid1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (MessageBox.Show("Действительно удалить?", "", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    DataGrid1.CanUserDeleteRows = true;
                }
                else
                {
                    DataGrid1.CanUserDeleteRows = false;
                }
            }
            LoginWindow.db.SaveChanges();
        }

        private void DeleteReg_Click(object sender, RoutedEventArgs e)
        {
            if(DataGrid1.SelectedItem !=null)
            {
                var reg = DataGrid1.SelectedItem as Registration;

                LoginWindow.db.Registration.Remove(reg);
                LoginWindow.db.SaveChanges();
            }
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var book = DataGrid1.SelectedItem as Booking;

                LoginWindow.db.Booking.Remove(book);
                LoginWindow.db.SaveChanges();
            }
        }




    }
}
