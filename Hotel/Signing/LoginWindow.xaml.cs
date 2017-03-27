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
using System.Security.Cryptography;
using System.Data.Entity;

namespace Signing
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        static public hotelEntities2 db;
        static public class Log
        {
            static public string login { get; set; }
        }
        public LoginWindow()
        {
            InitializeComponent();
            UserNameTextBox.Focus();
            db = new hotelEntities2();
            List<Remember> r = LoginWindow.db.Remember.Select(x => x).ToList();
            UserNameTextBox.Text = r[0].Login;
            PasswordPasswordBox.Password = r[0].Password;
        }
   
        string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }  
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
           
            Login();
        }
        void Login()
        {
            LoginWindow.Log.login = UserNameTextBox.Text;
            MainWindow fr1 = new MainWindow();
            UserWindow fr2 = new UserWindow();
            try
            {
                string connetionString = null;
                SqlConnection cnn;
                connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
                cnn = new SqlConnection(connetionString);
                if (UserNameTextBox.Text != string.Empty && PasswordPasswordBox.Password != string.Empty)
                {
                    if (Remember.IsChecked == true)
                    {
                        
                        Remember remember = new Remember();
                        List<Remember> rem = App.db.Remember.Select(x => x).ToList();
                        App.db.Remember.RemoveRange(rem);
                        App.db.SaveChanges();                       
                        remember.Login = UserNameTextBox.Text;
                        remember.Password = PasswordPasswordBox.Password;
                        LoginWindow.db.Remember.Add(remember);
                        LoginWindow.db.SaveChanges();

                    }
                    PasswordPasswordBox.Password = GetHashString(PasswordPasswordBox.Password);
                    string cmd = "SELECT COUNT(*) FROM Registration WHERE Login = @VALUE1 AND Password = @VALUE4";
                    SqlCommand Command = new SqlCommand(cmd, cnn);
                    Command.Parameters.AddWithValue("@VALUE1", UserNameTextBox.Text);
                    Command.Parameters.AddWithValue("@VALUE4", PasswordPasswordBox.Password);
                    
                    Command.Connection.Open();
                    Command.ExecuteNonQuery();

                    int size = System.Convert.ToInt32(Command.ExecuteScalar());
                    if (size > 0)
                    {
                        if (UserNameTextBox.Text == "Slavik")
                        {
                            this.Hide();
                            fr1.ShowDialog();
                           
                        }
                        else
                        {
                            this.Hide();
                            fr2.ShowDialog();
                        }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Логин или пароль введены неверно!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        UserNameTextBox.Clear();
                        PasswordPasswordBox.Clear();
                        UserNameTextBox.Background = Brushes.LightCoral;
                        PasswordPasswordBox.Background = Brushes.LightCoral;
                    }
                    Command.Connection.Close();
                }
                else
                {
                    MessageBox.Show("Введите логин и пароль!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    UserNameTextBox.Background = Brushes.LightCoral;
                    PasswordPasswordBox.Background = Brushes.LightCoral;
                }
            }
            catch (SqlException sqlexcept)
            { MessageBox.Show(sqlexcept.Message); }
            catch (Exception except)
            { MessageBox.Show(except.Message); }

        }
        
        private void SigningButton_Click(object sender, RoutedEventArgs e)
        {
            SigningWindow win = new SigningWindow();
            win.ShowDialog();
        }
            
    }
}
