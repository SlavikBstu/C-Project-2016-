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
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data.SqlTypes;


namespace Signing
{
    /// <summary>
    /// Логика взаимодействия для BookingWindow.xaml
    /// </summary>
    public partial class BookingWindow : Window
    {
        
        public BookingWindow()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {              
                if (CategoryOfRoom.Text != string.Empty && NumberOfPeople.Text != string.Empty && DateOfRace.Text != string.Empty && StayPeriod.Text != string.Empty)
                {
                    if (Convert.ToInt32(NumberOfPeople.Text) == 0)
                    {
                        MessageBox.Show("Введите количество человек", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        NumberOfPeople.Text = "";
                        return;
                    }
                    if ((CategoryOfRoom.Text == "Одноместная" || CategoryOfRoom.Text == "Одноместная (vip)") && Convert.ToInt32(NumberOfPeople.Text) > 1)
                    {
                        MessageBox.Show("Здесь не может поселиться больше 1 человека", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        NumberOfPeople.Text = "";
                        return;
                    }
                    if ((CategoryOfRoom.Text == "Двухместная" || CategoryOfRoom.Text == "Двухместная (vip)") && Convert.ToInt32(NumberOfPeople.Text) > 2)
                    {
                        MessageBox.Show("Здесь не может поселиться больше 2 человека", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        NumberOfPeople.Text = "";
                        return;
                    }
                    if ((CategoryOfRoom.Text == "Трехместная" || CategoryOfRoom.Text == "Трехместная (vip)") && Convert.ToInt32(NumberOfPeople.Text) > 3)
                    {
                        MessageBox.Show("Здесь не может поселиться больше 3 человека", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        NumberOfPeople.Text = "";
                        return;
                    }

                    if (Convert.ToDateTime(DateOfRace.Text) < DateTime.Now)
                    {
                        MessageBox.Show("Некорретно выбрана дата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        
                        return;
                    }

                    if (LoginWindow.db.FondOfNumbers.Where(x => CategoryOfRoom.Text == x.CategoryOfRoom && x.Status == "Свободна").Count() > 0)
                    {
                        FondOfNumbers room = LoginWindow.db.FondOfNumbers.ToList().Find(x => CategoryOfRoom.Text == x.CategoryOfRoom && x.Status == "Свободна");
                        LoginWindow.db.FondOfNumbers.Find(room.NumberOfRoom).Status = "Забронирована с " + DateOfRace.Text;
                        LoginWindow.db.SaveChanges();

                        SqlCommand Command = new SqlCommand("INSERT INTO Booking (DateOfBooking, CategoryOfRoom, NumberOfPeople, DateOfRice, StayPeriod, Login, NumberOfRoom) VALUES (@VALUE1, @VALUE2, @VALUE3, @VALUE4, @VALUE5, @VALUE6, @VALUE7)", cnn);
                        Command.Parameters.AddWithValue("@VALUE1", DateTimeOffset.Now);
                        Command.Parameters.AddWithValue("@VALUE2", CategoryOfRoom.Text);
                        Command.Parameters.AddWithValue("@VALUE3", NumberOfPeople.Text);
                        Command.Parameters.AddWithValue("@VALUE4", DateOfRace.Text);
                        Command.Parameters.AddWithValue("@VALUE5", StayPeriod.Text);
                        Command.Parameters.AddWithValue("@VALUE6", LoginWindow.Log.login);
                        Command.Parameters.AddWithValue("@VALUE7", room.NumberOfRoom);
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Command.Connection.Close();
                        MessageBox.Show("Ваша заявка отправлена", "", MessageBoxButton.OK);
                        this.Close();
                        return;
                    }

                    DateTime DRice = Convert.ToDateTime(DateOfRace.Text);
                    DateTime DLeave = Convert.ToDateTime(DateOfRace.Text);
                    DLeave.AddDays(Convert.ToInt32(StayPeriod.Text));

                    foreach(FondOfNumbers room in LoginWindow.db.FondOfNumbers.Where(x => x.Status != "Свободна"))
                    {
                        bool flag = true;

                        foreach (Living l in LoginWindow.db.Living.Where(x => x.NumberOfRoom == room.NumberOfRoom))
                        {
                            if ((l.DateOfRice >= DRice && l.DateOfRice <= DLeave) || (l.DateOfLeave >= DRice && l.DateOfLeave <= DLeave))
                            {
                                flag = false;
                            }
                        }

                        foreach (Booking l in LoginWindow.db.Booking.Where(x => x.NumberOfRoom == room.NumberOfRoom))
                        {
                            DateTime BDLeave = l.DateOfRice;
                            BDLeave.AddDays(Convert.ToInt32(StayPeriod.Text));
                            if ((l.DateOfRice >= DRice && l.DateOfRice <= DLeave) || (BDLeave >= DRice && BDLeave <= DLeave))
                            {
                                flag = false;
                            }
                        }

                        if (flag == true)
                        {
                            LoginWindow.db.FondOfNumbers.Find(room.NumberOfRoom).Status = "Забронирована с " + DateOfRace.Text;
                            LoginWindow.db.SaveChanges();
                            SqlCommand Command = new SqlCommand("INSERT INTO Booking (DateOfBooking, CategoryOfRoom, NumberOfPeople, DateOfRice, StayPeriod, Login, NumberOfRoom) VALUES (@VALUE1, @VALUE2, @VALUE3, @VALUE4, @VALUE5, @VALUE6, @VALUE7)", cnn);
                            Command.Parameters.AddWithValue("@VALUE1", DateTimeOffset.Now);
                            Command.Parameters.AddWithValue("@VALUE2", CategoryOfRoom.Text);
                            Command.Parameters.AddWithValue("@VALUE3", NumberOfPeople.Text);
                            Command.Parameters.AddWithValue("@VALUE4", DateOfRace.Text);
                            Command.Parameters.AddWithValue("@VALUE5", StayPeriod.Text);
                            Command.Parameters.AddWithValue("@VALUE6", LoginWindow.Log.login);
                            Command.Parameters.AddWithValue("@VALUE7", room.NumberOfRoom);
                            Command.Connection.Open();
                            Command.ExecuteNonQuery();
                            Command.Connection.Close();
                            MessageBox.Show("Ваша заявка отправлена", "", MessageBoxButton.OK);
                            this.Close();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("Мест нет");
                            return;
                        }
                    }
                    MessageBox.Show("Нет свободной комнаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    MessageBox.Show("Заполнены не все поля!", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (SqlException sqlexcept)
            { MessageBox.Show(sqlexcept.Message); }
            catch (Exception except)
            { MessageBox.Show(except.Message); }         
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }
        private void NumberOfPeople_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
        }
        private void StayPeriod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (FondOfNumbers fond in LoginWindow.db.FondOfNumbers.Where(x => x.Status == "Свободна"))
                {
                    if (!CategoryOfRoom.Items.Contains(fond.CategoryOfRoom))
                        CategoryOfRoom.Items.Add(fond.CategoryOfRoom);
                }
                if (LoginWindow.db.FondOfNumbers.Where(x => x.Status == "Свободна").Count() == 0)
                {
                    MessageBox.Show("Нет свободных номеров", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Close();
                }
            }
            catch { };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        } 
    }
}
