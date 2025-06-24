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
    public partial class Manage_ClassAttendance : Form
    {
        public Manage_ClassAttendance()
        {
            InitializeComponent();
        }

        string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=ProjectB;Integrated Security=True";

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into ClassAttendance values (@AttendanceDate)", con);
                sqlCommand.Parameters.AddWithValue("@AttendanceDate", DateTime.Now);
                sqlCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Class Attendance Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("delete ClassAttendance where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Class Attendance Deleted!");
            }
            catch
            {
                MessageBox.Show("Cannot Be Deleted!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from ClassAttendance", sqlConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }
    }
}
