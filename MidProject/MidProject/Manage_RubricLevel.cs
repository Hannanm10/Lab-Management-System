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
    public partial class Manage_RubricLevel : Form
    {
        public Manage_RubricLevel()
        {
            InitializeComponent();
            AddItems();
        }

        string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=ProjectB;Integrated Security=True";

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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("Select * from RubricLevel", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd = new SqlCommand("delete RubricLevel where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Rubric Level Deleted!");
            }
            catch
            {
                MessageBox.Show("Cannot Be Deleted!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("update RubricLevel set Details=@Details,MeasurementLevel=@MeasurementLevel where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", textBox3.Text);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Rubric Level Updated!");
            }
            catch
            {
                MessageBox.Show("Cannot be Updated!!!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("insert into RubricLevel values(@RubricId,@Details,@MeasurementLevel)", sqlConnection);
                SqlCommand c = new SqlCommand("select Id from Rubric where Details=@Details", sqlConnection);
                c.Parameters.AddWithValue("@Details", comboBox1.Text);
                SqlDataReader sqlDataReader = c.ExecuteReader();
                sqlDataReader.Read();
                int i = sqlDataReader.GetInt32(0);
                sqlDataReader.Close();
                c.ExecuteScalar();
                cmd.Parameters.AddWithValue("Details", textBox2.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", textBox3.Text);
                cmd.Parameters.AddWithValue("@RubricId", i);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Rubric Level Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }
        }

        private void AddItems()
        {
            string query = "SELECT Details FROM Rubric";

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
    }
}
