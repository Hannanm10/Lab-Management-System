using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidProject
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Students manage_Students = new Manage_Students();
            manage_Students.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_CLO manage_CLO = new Manage_CLO();   
            manage_CLO.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Rubrics manage_Rubrics = new Manage_Rubrics();
            manage_Rubrics.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_RubricLevel rl = new Manage_RubricLevel();
            rl.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Assessments manage_Assessments = new Manage_Assessments();
            manage_Assessments.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_Evaluations manage_Evaluations = new Manage_Evaluations();
            manage_Evaluations.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_AssessmentComponent manage_AssessmentComponent = new Manage_AssessmentComponent();
            manage_AssessmentComponent.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_ClassAttendance manage = new Manage_ClassAttendance();   
            manage.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_StudentAttendance manage_StudentAttendance = new Manage_StudentAttendance();
            manage_StudentAttendance.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manage_StudentAssessments manage_StudentAssessments = new Manage_StudentAssessments();
            manage_StudentAssessments.Show();
        }
    }
}
