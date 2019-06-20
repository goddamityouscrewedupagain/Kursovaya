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
    public partial class FilterForm : Form
    {
        private int i;

        public FilterForm()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            List<string> states = new List<string>
            {
                "Названию","Имени"
            };
            domainUpDown1.Items.AddRange(states);
            domainUpDown1.TextChanged += domainUpDown1_TextChanged;
        }
        void domainUpDown1_TextChanged(object sender, EventArgs e)
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

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
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

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Medicaments", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Medicaments");
            dataGridView1.DataSource = dataSet.Tables[0];
            radioButton4.Text = "По названию";
            radioButton5.Text = "По ID";
            textBox2.Hide();
            textBox3.Hide();
            button2.Hide();
            groupBox7.Hide();


        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from bolezni", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "bolezni");
            dataGridView1.DataSource = dataSet.Tables[0];
            radioButton4.Text = "По имени";
            radioButton5.Text = "По ID";
            textBox2.Hide();
            textBox3.Hide();
            button2.Hide();
            groupBox7.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Pacients", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Pacients");
            dataGridView1.DataSource = dataSet.Tables[0];
            radioButton4.Text = "По фамилии";
            radioButton5.Text = "По возрасту";
            textBox2.Show();
            textBox3.Show();
            button2.Show();
            groupBox7.Show();
        }

        //private void radioButton1_Click(object sender, EventArgs e)

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows[i].Selected = false;
            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                if (dataGridView1.Rows[i].Cells[j].Value != null)
                    if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox2.Text))
                    {
                        dataGridView1.Rows[i].Selected = true;
                        break;
                    }
        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            dataGridView1.Rows[i].Selected = true;
                            break;
                        }
            }
        }
    }
}
