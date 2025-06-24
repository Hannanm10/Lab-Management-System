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
    public partial class Manage_Assessments : Form
    {
        public Manage_Assessments()
        {
            InitializeComponent();
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
            SqlCommand cmd = new SqlCommand("select * from Assessment",sqlConnection);
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
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("delete Assessment where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Deleted!");
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
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("update Assessment set Title=@Title,TotalMarks=@TotalMarks,TotalWeightage=@TotalWeightage where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", textBox4.Text);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Updated!");
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
                SqlCommand cmd = new SqlCommand("insert into Assessment values(@Title,@DateCreated,@TotalMarks,@TotalWeightage)", sqlConnection);
                cmd.Parameters.AddWithValue("@Title", textBox2.Text);
                cmd.Parameters.AddWithValue("@TotalMarks", textBox3.Text);
                cmd.Parameters.AddWithValue("@TotalWeightage", textBox4.Text);
                cmd.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Assessment Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }
        }
    }
}
