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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MidProject
{
    public partial class Manage_Students : Form
    {
        public Manage_Students()
        {
            InitializeComponent();
            AddItems();
        }

        string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=ProjectB;Integrated Security=True";


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();

                SqlCommand cmd = new SqlCommand("insert into Student values(@FirstName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)", conn);
                SqlCommand c = new SqlCommand("select LookupId from Lookup where Name=@Name", conn);
                c.Parameters.AddWithValue("@Name", comboBox1.Text);
                c.ExecuteScalar();
                SqlDataReader reader = c.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", i);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student Added!");
            }
            catch
            {
                MessageBox.Show("Cannot be Added!!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("update Student set FirstName=@FirstName, LastName=@LastName, Contact=@Contact, Email=@Email, RegistrationNumber=@RegistrationNumber" +
                                                "where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@FirstName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Updated!");
            }
            catch
            {
                MessageBox.Show("Cannot be Updated!!!");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connection);
                conn.Open();
                SqlCommand cmd = new SqlCommand("Delete Student where Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", textBox7.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Student Deleted!");
            }
            catch
            {
                MessageBox.Show("Cannot Be Deleted!!!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void AddItems()
        {
            string query = "SELECT Name FROM Lookup where LookupId > 4";

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
