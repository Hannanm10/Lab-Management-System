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

namespace MidProject
{
    public partial class Manage_Evaluations : Form
    {
        public Manage_Evaluations()
        {
            InitializeComponent();
            AddItems1();
            AddItems2();
            AddItems3();
        }

        string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=ProjectB;Integrated Security=True";

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from StudentResult", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into StudentResult values (@StudentId,@AssCompId,@RubLvlId,@Date)", sqlConnection);

                SqlCommand c1 = new SqlCommand("select Id from Student where RegistrationNumber=@Regno", sqlConnection);
                c1.Parameters.AddWithValue("@Regno", comboBox1.Text);
                SqlDataReader reader = c1.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                c1.ExecuteScalar();

                SqlCommand c2 = new SqlCommand("select Id from AssessmentComponent where Name=@Name", sqlConnection);
                c2.Parameters.AddWithValue("@Name", comboBox2.Text);
                SqlDataReader reader2 = c2.ExecuteReader();
                reader2.Read();
                int j = reader2.GetInt32(0);
                reader2.Close();
                c2.ExecuteScalar();

                SqlCommand c3 = new SqlCommand("select Id from RubricLevel where Details=@Details", sqlConnection);
                c3.Parameters.AddWithValue("@Details", comboBox3.Text);
                SqlDataReader r3 = c3.ExecuteReader();
                r3.Read();
                int x = r3.GetInt32(0);
                r3.Close();
                c3.ExecuteScalar();

                sqlCommand.Parameters.AddWithValue("@StudentId", i);
                sqlCommand.Parameters.AddWithValue("@AssCompId", j);
                sqlCommand.Parameters.AddWithValue("@RubLvlId", x);
                sqlCommand.Parameters.AddWithValue("@Date", DateTime.Now);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Evaluation Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }

        }

        private void AddItems1()
        {
            string query = "SELECT RegistrationNumber FROM Student";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox1.Items.Clear();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }

        private void AddItems2()
        {
            string query = "SELECT Name FROM AssessmentComponent";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox2.Items.Clear();

            while (reader.Read())
            {
                comboBox2.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }

        private void AddItems3()
        {
            string query = "SELECT Details FROM RubricLevel";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);

            SqlDataReader reader = command.ExecuteReader();

            comboBox3.Items.Clear();

            while (reader.Read())
            {
                comboBox3.Items.Add(reader.GetString(0));
            }

            reader.Close();
            con.Close();
        }
    }
}
