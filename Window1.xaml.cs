using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace LoginWPF
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        SqlConnection cnct = new SqlConnection(@"Data Source=CAPATINA\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True");
        public Window1()
        {
            InitializeComponent();
        }

        private void Buton1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cnct = new SqlConnection(@"Data Source=CAPATINA\SQLEXPRESS;Initial Catalog=AdventureWorks2017;Integrated Security=True")) ;
                cnct.Open();
                SqlCommand cmd = new SqlCommand("Adaugare", cnct);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Username", textBox1.Text.Trim());
                if (textBox2.Password.ToString() == textBox3.Password.ToString())
                {
                    cmd.Parameters.AddWithValue("@Password", Hash.Hash1(textBox2.Password.ToString()));
                }
                else
                {
                    MessageBox.Show("Cele doua parole nu se potrivesc, mai incercati o data!");
                }
                cmd.Parameters.AddWithValue("@Tara", textBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@Judet", textBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@Oras", textBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@Strada", textBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@Numar", textBox8.Text.Trim());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Succes!");

            }
            catch
            {
                MessageBox.Show("A aparut o eroare la creearea contului, incercati din nou!");
            }
            finally
            {
                cnct.Close();
            }
        }
    }
}
