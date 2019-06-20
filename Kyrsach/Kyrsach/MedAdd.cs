using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Kyrsach
{
    public partial class MedAdd : Form
    {
        public MedAdd()
        {

            InitializeComponent();
            List<string> states = new List<string>
            {
                "Гомеопатическое","Противоопухольное","Снотворное","Капли"
            };
            domainUpDown1.Items.AddRange(states);
            domainUpDown1.TextChanged += domainUpDown1_TextChanged;

         //   List<string> Leth = new List<string>
           // {
             //   "Гомеопатическое","Противоопухольное","Снотворное","Капли"
            //};
            //domainUpDown2.Items.AddRange(Leth);
            //domainUpDown2.TextChanged += domainUpDown1_TextChanged;
        }

        void domainUpDown1_TextChanged(object sender, EventArgs e)
        {
            //      MessageBox.Show(domainUpDown1.Text);
        }
        void domainUpDown2_TextChanged(object sender, EventArgs e)
        {
            //      MessageBox.Show(domainUpDown1.Text);
        }

        private void LoadData()
        {
            string connectString = "Data Source=.\\SQLEXPRESS;Initial Catalog=test;" +
                "Integrated Security=true;";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * users";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[2]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                //data[data.Count - 1][2] = reader[2].ToString();
            }

            reader.Close();

            myConnection.Close();

            //foreach (string[] s in data)
            //  dataGridView1.Rows.Add(s);
        }//*/

        internal class DBUtils
        {
            public static MySqlConnection GetDBConnection()
            {
                string host = "localhost";
                int port = 3306;
                string database = "test";
                string username = "root";
                string password = "1106";
                return DB_MySQL_Utils.GetMySQLConnection(host, port, database, username, password);
            }
        }
        internal class DB_MySQL_Utils
        {
            public static MySqlConnection GetMySQLConnection(string host, int port, string database, string username, string password)
            {
                string connectionString = "Server=" + host + ";Database=" + database + ";port=" + port + ";User Id=" + username + ";password=" + password;
                MySqlConnection connection = new MySqlConnection(connectionString);
                return connection;
            }
        }
        public void insertData()
        {
            string host; int port; string database; string username; string password;
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "Insert into  Medicaments (ID, Name, Formakologia, Srok_Godnosti, Data_izgotovleniya, Istechenie_Sroka) VALUES (?ID, ?Name, ?Formakologia, ?Srok_Godnosti, ?Data_izgotovleniya, ?Istechenie_Sroka)";
                command.Parameters.Add("?Name", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("?Formakologia", MySqlDbType.VarChar).Value = domainUpDown1.Text;
               // command.Parameters.Add("?Srok_Godnosti", MySqlDbType.VarChar).Value = radioButton2.Text;
                command.Parameters.Add("?Data_izgotovleniya", MySqlDbType.Date).Value = dateTimePicker2.Value;
                command.Parameters.Add("?Istechenie_Sroka", MySqlDbType.Date).Value = dateTimePicker1.Value;
                //command.Parameters.Add("?Vozrast", MySqlDbType.UInt32).Value = textBox2.Text;
                //   int SetYear = dateTimePicker2.Value - dateTimePicker1.Value;

                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally










            {
              //  MessageBox.Show("Добавка строки пациента прошла успешно");
                //connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void MedAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
