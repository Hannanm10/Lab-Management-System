using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class Manage_StudentAssessments : Form
    {
        public Manage_StudentAssessments()
        {
            InitializeComponent();
            AddItems1();
            AddItems2();
            AddItems3();
            AddItems4();
        }

        string connection = "Data Source=DESKTOP-NLQHPI9;Initial Catalog=ProjectB;Integrated Security=True";

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu main_Menu = new Main_Menu();
            main_Menu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(connection);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select * from StudentAssessments", sqlConnection);
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
                SqlCommand cmd = new SqlCommand("delete StudentAssessments where Id=@Id", sqlConnection);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Assessment Deleted!");
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
                SqlCommand cmd = new SqlCommand("update StudentAssessments set StudentRubricLevel=@lvl", sqlConnection);
                cmd.Parameters.AddWithValue("@lvl", textBox2.Text);
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Assessment Updated!");
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
                SqlCommand cmd = new SqlCommand("insert into StudentAssessments values(@stu,@comp,@rub,@compMarks,@rublvl,@stulvl,@obtained)", sqlConnection);

                SqlCommand c1 = new SqlCommand("select Id from Student where RegistrationNumber=@Regno", sqlConnection);
                c1.Parameters.AddWithValue("@Regno", comboBox1.Text);
                SqlDataReader reader = c1.ExecuteReader();
                reader.Read();
                int i = reader.GetInt32(0);
                reader.Close();
                c1.ExecuteScalar();

                SqlCommand c2 = new SqlCommand("select Name from AssessmentComponent where Name=@name", sqlConnection);
                c2.Parameters.AddWithValue("@name", comboBox2.Text);
                SqlDataReader sqlDataReader = c2.ExecuteReader();
                sqlDataReader.Read();
                string n = sqlDataReader.GetString(0);
                sqlDataReader.Close();
                c2.ExecuteScalar();

                SqlCommand c3 = new SqlCommand("select TotalMarks from AssessmentComponent where Name=@name", sqlConnection);
                c3.Parameters.AddWithValue("@name", comboBox2.Text);
                SqlDataReader sqlDataReader1 = c3.ExecuteReader();
                sqlDataReader1.Read();
                int m = sqlDataReader1.GetInt32(0);
                sqlDataReader1.Close();
                c3.ExecuteScalar();

                SqlCommand c4 = new SqlCommand("select Details from Rubric where Details=@det", sqlConnection);
                c4.Parameters.AddWithValue("@det", comboBox3.Text);
                SqlDataReader sqlDataReader2 = c4.ExecuteReader();
                sqlDataReader2.Read();
                string d = sqlDataReader2.GetString(0);
                sqlDataReader2.Close();
                c4.ExecuteScalar();

                SqlCommand c5 = new SqlCommand("select MeasurementLevel from RubricLevel where MeasurementLevel=@det", sqlConnection);
                c5.Parameters.AddWithValue("@det", comboBox4.Text);
                SqlDataReader sqlDataReader3 = c5.ExecuteReader();
                sqlDataReader3.Read();
                int l = sqlDataReader3.GetInt32(0);
                sqlDataReader3.Close();
                c5.ExecuteScalar();


                cmd.Parameters.AddWithValue("@stu", i);
                cmd.Parameters.AddWithValue("@comp", n);
                cmd.Parameters.AddWithValue("@stulvl", textBox2.Text);
                cmd.Parameters.AddWithValue("@compMarks", m);
                cmd.Parameters.AddWithValue("@rub", d);
                cmd.Parameters.AddWithValue("@rublvl", l);
                cmd.Parameters.AddWithValue("@obtained", Obtained(float.Parse(textBox2.Text), l, m));
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Student Assessment Added!");
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
            string query = "SELECT Details FROM Rubric";

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

        private void AddItems4()
        {
            string query = "SELECT MeasurementLevel FROM RubricLevel";

            SqlConnection con = new SqlConnection(connection);
            con.Open();

            SqlCommand command = new SqlCommand(query, con);


            SqlDataReader reader1 = command.ExecuteReader();

            comboBox4.Items.Clear();

            while (reader1.Read())
            {
                comboBox4.Items.Add(reader1.GetInt32(0));
            }

            reader1.Close();
            con.Close();
        }

        private float Obtained(float studentLevel,int RubricLevel,int ComponentMarks)
        {
            float o = (studentLevel / RubricLevel) * ComponentMarks;
            return o;
        }
    }
}
