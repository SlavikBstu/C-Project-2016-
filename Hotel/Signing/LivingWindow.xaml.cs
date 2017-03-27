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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Surname.Focus();
        }
        private bool IsNumber(string Text)
        {
            int output;
            return int.TryParse(Text, out output);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                if (Surname.Text != string.Empty && Name.Text != string.Empty && Rice.Text != string.Empty && Room.Text != string.Empty && Place.Text != string.Empty && Passport.Text != string.Empty)
                {
                    FondOfNumbers obj;
                   
                    int num = Convert.ToInt32(Room.Text);
                    if (LoginWindow.db.FondOfNumbers.Where(x => num == x.NumberOfRoom).Count() > 0)
                    {
                        if (LoginWindow.db.Living.Where(x => num == x.NumberOfRoom).Count() > 0)
                        {
                            obj = LoginWindow.db.FondOfNumbers.Where(x => num == x.NumberOfRoom).ToList()[0];
                            foreach (Living obj1 in LoginWindow.db.Living.Where(x => num == x.NumberOfRoom).ToList())
                            {
                               
                                if ((obj1.DateOfRice >= Convert.ToDateTime(Rice.Text) && obj1.DateOfRice <= Convert.ToDateTime(Leave.Text))
                                    || (obj1.DateOfLeave >= Convert.ToDateTime(Rice.Text) && obj1.DateOfLeave <= Convert.ToDateTime(Leave.Text)))
                                {
                                    MessageBox.Show("Этот номер уже занят на данный период", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return;
                                }

                                
                            }
                            LoginWindow.db.FondOfNumbers.Find(obj.NumberOfRoom).Status = "Заселен с " + Rice.Text + " по " + Leave.Text;
                            LoginWindow.db.SaveChanges();
                        }
                        else
                        {
                            obj = LoginWindow.db.FondOfNumbers.Where(x => num == x.NumberOfRoom).ToList()[0];
                            LoginWindow.db.FondOfNumbers.Find(obj.NumberOfRoom).Status = "Заселен с " + Rice.Text + " по " + Leave.Text;
                            LoginWindow.db.SaveChanges();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет свободной комнаты", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    if (Convert.ToDateTime(Rice.Text) < DateTime.Now && Convert.ToDateTime(Rice.Text) > Convert.ToDateTime(Leave.Text))
                    {
                        MessageBox.Show("Некорретно выбрана дата", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);

                        return;
                    }                   
                    SqlCommand Command = new SqlCommand("INSERT INTO Living (DateOfRice, DateOfLeave, NumberOfRoom, Place, Surname, Name, Passport) VALUES (@VALUE1, @VALUE2, @VALUE3, @VALUE4, @VALUE5, @VALUE6, @VALUE7)", cnn);
                    Command.Parameters.AddWithValue("@VALUE1", Rice.Text);
                    Command.Parameters.AddWithValue("@VALUE2", Leave.Text);
                    Command.Parameters.AddWithValue("@VALUE3", Room.Text);
                    Command.Parameters.AddWithValue("@VALUE4", Place.Text);
                    Command.Parameters.AddWithValue("@VALUE5", Surname.Text);
                    Command.Parameters.AddWithValue("@VALUE6", Name.Text);
                    Command.Parameters.AddWithValue("@VALUE7", Passport.Text);
                    Command.Connection.Open();
                    Command.ExecuteNonQuery();
                    Command.Connection.Close();

                    MessageBox.Show(Surname.Text+ " " + Name.Text + " заселен", "", MessageBoxButton.OK);
                    this.Close();
                    
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

        private void Surname_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.Text, 0);
        }

        private void Name_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.Text, 0);
        }

        private void Room_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (IsNumber(e.Text) == false)
            {
                e.Handled = true;
            }
        }

        private void Place_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.Text, 0);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
