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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            ToolStripMenuItem fileItem = new ToolStripMenuItem("Файл");

            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить") { Checked = true, CheckOnClick = true };
            saveItem.Click += saveItem_Click;
            saveItem.ShortcutKeys = Keys.Control | Keys.P;

            fileItem.DropDownItems.Add(saveItem);
            menuStrip1.Items.Add(fileItem);


            ToolStripMenuItem searchItem = new ToolStripMenuItem("Поиск и фильтрация");

            ToolStripMenuItem opSearchItem = new ToolStripMenuItem("Выполнить поиск")
            { Checked = true, CheckOnClick = true };
            opSearchItem.Click += aboutSave_Click;
            opSearchItem.ShortcutKeys = Keys.Control | Keys.R;


            searchItem.DropDownItems.Add(opSearchItem);
            menuStrip1.Items.Add(searchItem);
            ToolStripMenuItem diagItem = new ToolStripMenuItem("Диагностика заболевания");
            ToolStripMenuItem opDiagItem = new ToolStripMenuItem("Выполнить диагностику")
            { Checked = true, CheckOnClick = true };
            opDiagItem.Click += aboutDiag_Click;
            opDiagItem.ShortcutKeys = Keys.Control | Keys.F;

            diagItem.DropDownItems.Add(opDiagItem);
            menuStrip1.Items.Add(diagItem);

            ToolStripMenuItem instrItem = new ToolStripMenuItem("Инструкция");

            ToolStripMenuItem instrinItem = new ToolStripMenuItem("посмотреть инструкцию") { Checked = true, CheckOnClick = true };
            instrinItem.Click += instrinItem_Click;
            instrinItem.ShortcutKeys = Keys.Control | Keys.Z;

            instrItem.DropDownItems.Add(instrinItem);
            menuStrip1.Items.Add(instrItem);

            // LoadData();
        }

        private void instrinItem_Click(object sender, EventArgs e)
        {
            InstrForm instrForm = new InstrForm();
            instrForm.Show();
        }

        void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("О программе");
        }
        void aboutSave_Click(object sender, EventArgs e)
            {
            FilterForm filterForm = new FilterForm();
            filterForm.Show();
            }
       void aboutDiag_Click(object sender, EventArgs e)
        {
            //FilterForm filterForm = new FilterForm();
            DiagnostikForm diagnostikForm = new DiagnostikForm();
            diagnostikForm.Show();
            //filterForm.Show();
        }
        void menuItem_CheckedChanged(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            if (menuItem.CheckState == CheckState.Checked)
                MessageBox.Show("Отмечен");
            else if (menuItem.CheckState == CheckState.Unchecked)
                MessageBox.Show("Отметка снята");
        }
        void saveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Сохранение");
        }
        private void LoadData()
        {
            string connectString = "Data Source=.\\SQLEXPRESS;Initial Catalog=test;" +
                "Integrated Security=true;";

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT * bolezni";

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
        private void PaintRows()
        {
            foreach (DataGridViewRow row in dataGridView5.Rows)
            {
                try
                {
                    if (int.Parse(row.Cells[3].Value.ToString()) == 200)
                        row.DefaultCellStyle.BackColor = Color.Red;
                    else
                        row.DefaultCellStyle.BackColor = Color.White;
                }
                catch
                {
                    // здесь можно отреагировать на неправильные данные, а можно ничего не делать
                }
            }
        }
       


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from bolezni", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "bolezni");
            dataGridView1.DataSource = dataSet.Tables[0];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BolAdd bolAdd = new BolAdd();
            bolAdd.Show();
        }               

        private void button3_Click_1(object sender, EventArgs e)
        {


        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpAdd opAdd = new OpAdd();
            opAdd.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "Select * from Medicaments";
            MySqlDataReader mySqlDataReader = command.ExecuteReader();
           // DateTime dt1 = mySqlDataReader["Istechenie_Sroka"].ToString;
            foreach (DataGridViewRow Myrow in dataGridView5.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume
                if (Convert.ToInt32(Myrow.Cells[2].Value) < Convert.ToInt32(Myrow.Cells[1].Value))// Or your condition 
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Green;
                }
               
              
                    connection.Close();
                
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Medicaments", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Medicaments");
            dataGridView5.DataSource = dataSet.Tables[0];
        }

        private void button12_Click(object sender, EventArgs e)
        {
            PaintRows();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Pacients", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Pacients");
            dataGridView2.DataSource = dataSet.Tables[0];
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MedAdd medAdd = new MedAdd();
            medAdd.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Operations", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Operations");
            dataGridView3.DataSource = dataSet.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                dataGridView3.Rows.Remove(row);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                dataGridView5.Rows.Remove(row);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter("Select * from Doctors", connection);
            MySqlCommandBuilder mySqlCommandBuilder = new MySqlCommandBuilder(mySqlDataAdapter);
            DataSet dataSet = new DataSet();
            mySqlDataAdapter.Fill(dataSet, "Doctors");
            dataGridView4.DataSource = dataSet.Tables[0];
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DocAdd docAdd = new DocAdd();
            docAdd.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {

        }
    }
}
