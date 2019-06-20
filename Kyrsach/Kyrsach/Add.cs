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
    public partial class Add : Form
    {
        DateTime dateNow = DateTime.Now;
         
       // int year = dateNow.Year - dateTimePicker1.Value;


        private string connString;
        //ateTimePicker1.MaxDate- dateTimePicker1.DataBindings

        public Add()
        {
            InitializeComponent();
            //dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //dataGridView1.AllowUserToAddRows = false;
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
       public  void insertData()
        {
            string host; int port; string database; string username; string password;
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "Insert into  Pacients (FIO, POL, Data_Rozhdeniya, Data_Postypleniya, Vozrast) VALUES (?FIO, ?POL, ?Data_Rozhdeniya, ?Data_Postypleniya, ?Vozrast)";
                command.Parameters.Add("?FIO", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("?POL", MySqlDbType.VarChar).Value = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
               // command.Parameters.Add("?POL", MySqlDbType.VarChar).Value = radioButton2.Text;
                command.Parameters.Add("?Data_Rozhdeniya", MySqlDbType.Date).Value = dateTimePicker1.Value;
                command.Parameters.Add("?Data_Postypleniya", MySqlDbType.Date).Value = dateTimePicker2.Value;
                command.Parameters.Add("?Vozrast", MySqlDbType.UInt32).Value = textBox2.Text;
             //   int SetYear = dateTimePicker2.Value - dateTimePicker1.Value;

                command.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                MessageBox.Show("Добавка строки пациента прошла успешно");
                connection.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //String s = "";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
            Close();
            
           // String add = "INSERT INTO MEDICAMENTS"
        }

     //   private void insertData()
       // {
         //   throw new NotImplementedException();
        //}

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
