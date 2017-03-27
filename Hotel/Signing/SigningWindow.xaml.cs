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
using System.Security.Cryptography;

namespace Signing
{
    /// <summary>
    /// Логика взаимодействия для SigningWindow.xaml
    /// </summary>
    public partial class SigningWindow : Window
    {
        public SigningWindow()
        {
            InitializeComponent();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=SLAVIK;Initial Catalog=hotel;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {

                string password = txtBox4.Password;
                string repeatpassword = txtBox5.Password;
                if (txtBox1.Text != string.Empty && txtBox2.Text != string.Empty && txtBox3.Text != string.Empty && txtBox4.Password != string.Empty && txtBox5.Password != string.Empty && txtBox1.Text != string.Empty)
                {
                    if (repeatpassword != password)
                    {
                        MessageBox.Show("Пароли не совпадают", "Неверно", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        SqlCommand Command = new SqlCommand("INSERT INTO Registration (Login, Surname, Name, Password) VALUES (@VALUE1, @VALUE2, @VALUE3, @VALUE4)", cnn);

                        Command.Parameters.AddWithValue("@VALUE1", txtBox1.Text);
                        Command.Parameters.AddWithValue("@VALUE2", txtBox2.Text);
                        Command.Parameters.AddWithValue("@VALUE3", txtBox3.Text);
                        Command.Parameters.AddWithValue("@VALUE4", GetHashString(txtBox4.Password));
                        Command.Connection.Open();
                        Command.ExecuteNonQuery();
                        Command.Connection.Close();
                        txtBox4.Password = GetHashString(txtBox5.Password);
                        MessageBox.Show("Регистрация прошла успешно", "", MessageBoxButton.OK);
                        txtBox1.Text = "";
                        txtBox2.Text = "";
                        txtBox3.Text = "";
                        txtBox4.Password = "";
                        txtBox5.Password = "";
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Заполнены не все поля", "", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                //cnn.Close();
            }
            catch (SqlException sqlexcept)
            {
                string ClassError = sqlexcept.Class.ToString();

                if (ClassError == "14")
                {
                    MessageBox.Show("Такой логин уже существует. Введите другой", "", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(sqlexcept.Message);
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }  
        private void txtBox3_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.Text, 0);
        }

        private void txtBox2_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Char.IsLetter(e.Text, 0);
        }



     
    }
}
