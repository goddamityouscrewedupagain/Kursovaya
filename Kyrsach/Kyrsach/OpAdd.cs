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
    public partial class OpAdd : Form
    {
        public OpAdd()
        {
            InitializeComponent();
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

           // foreach (string[] s in data)
               // dataGridView1.Rows.Add(s);
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

        private void OpAdd_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            MySqlConnection connection2 = DBUtils.GetDBConnection();
            MySqlConnection connection3 = DBUtils.GetDBConnection();
            connection.Open();
            connection2.Open();
            connection3.Open();

            try
            {
                MySqlCommand command = connection.CreateCommand();
                MySqlCommand command2 = connection2.CreateCommand();
                MySqlCommand command3 = connection3.CreateCommand();
                command.CommandText = "Select * from Pacients";
                command2.CommandText = "Select * from Operats";
                command3.CommandText = "Select * from Doctors";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                MySqlDataReader mySqlDataReader2 = command2.ExecuteReader();
                MySqlDataReader mySqlDataReader3 = command3.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    string nums = mySqlDataReader["FIO"].ToString();
                    //  string inums = Convert.ToString(nums);
                    comboBox1.Items.Add(nums);


                }
                while (mySqlDataReader2.Read())
                {
                    string op = mySqlDataReader2["Name"].ToString();
                    //  string inums = Convert.ToString(nums);
                    comboBox2.Items.Add(op);


                }
                while (mySqlDataReader3.Read())
                {
                    string doc = mySqlDataReader3["Name"].ToString();
                    //  string inums = Convert.ToString(nums);
                    comboBox3.Items.Add(doc);


                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {   
                connection.Close();
                connection2.Close();
                connection3.Close();
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
                command.CommandText = "Insert into  Operations (FIO_Pacienta, Date, Opisanie,Operation, FIO_Vracha) VALUES (?FIO_Pacienta, ?Date, ?Opisanie, ?Operation, ?FIO_Vracha)";
                command.Parameters.Add("?FIO_Pacienta", MySqlDbType.VarChar).Value = comboBox1.Text;
                command.Parameters.Add("?Date", MySqlDbType.VarChar).Value = dateTimePicker1.Value;
                command.Parameters.Add("?Opisanie", MySqlDbType.VarChar).Value = textBox1.Text;
                command.Parameters.Add("?Operation", MySqlDbType.Date).Value = comboBox2.Text;
                command.Parameters.Add("?FIO_Vracha", MySqlDbType.Date).Value = comboBox3.Text;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertData();
        }

        private void domainUpDown2_SelectedItemChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
