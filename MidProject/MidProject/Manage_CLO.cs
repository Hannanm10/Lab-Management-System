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
    public partial class Manage_CLO : Form
    {
        public Manage_CLO()
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into Clo values(@Name,@DateCreated,@DateUpdated)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", textBox2.Text);
                sqlCommand.Parameters.AddWithValue("@DateCreated", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("CLO Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnectionm = new SqlConnection(connection);
                sqlConnectionm.Open();
                SqlCommand cmd = new SqlCommand("update Clo set Name=@Name,DateUpdated=@DateUpdated where Id=@Id", sqlConnectionm);
                cmd.Parameters.AddWithValue("@Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@DateUpdated", DateTime.Now);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConnectionm.Close();
                MessageBox.Show("CLO Updated!");
            }
            catch
            {
                MessageBox.Show("Cannot be Updated!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection(connection);
            sql.Open();
            SqlCommand cmd = new SqlCommand("select * from Clo", sql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(connection);
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("delete Clo where Id=@Id", sqlConn);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConn.Close();
                MessageBox.Show("CLO Deleted!");
            }
            catch
            {
                MessageBox.Show("Cannot Be Deleted!!!");
            }
        }
    }
}
