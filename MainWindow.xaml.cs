using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
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
using System.Security.Cryptography;

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection cnct = new SqlConnection(@"Data Source=CAPATINA\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True");

        public MainWindow()
        {
            InitializeComponent();

        }

        public void Buton1_Click(object sender, RoutedEventArgs e)
        {
            String user_name, password_user;
            user_name = textBox1.Text;
            password_user = textBox2.Password.ToString();

            try
            {
                string hashed = Hash.Hash1(password_user = textBox2.Password.ToString());
                String querry = "SELECT * FROM Users2 WHERE Username = '" + textBox1.Text + "' AND Password = '" + hashed + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(querry, cnct);
                DataTable dtab = new DataTable();
                adapter.Fill(dtab);

                if (dtab.Rows.Count >= 0)
                {

                    MessageBox.Show("Username and password are correct!");
                }
                else
                {
                    MessageBox.Show("Eroare");
                    textBox1.Clear();
                    textBox2.Clear();

                }

            }
            catch
            {
                MessageBox.Show(" A aparut o eroare, reincercati!");
            }
            finally
            {
                cnct.Close();
            }
            
        }

        private void Buton2_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Window1 window1 = new Window1();
            window1.Show();
        }
    }

}
