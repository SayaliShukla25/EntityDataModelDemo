using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDataModelDemo
{
    public partial class Form3 : Form
    {
        StudentEntities dbcontext = new StudentEntities();
        public Form3()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = new Student();
                stud.Name = txtName.Text;
                stud.Branch = txtBranch.Text;
                stud.Percentage = Convert.ToDouble(txtPercentage.Text);
                dbcontext.Students.Add(stud);
                dbcontext.SaveChanges();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud= dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    txtName.Text = stud.Name;
                    txtBranch.Text = stud.Branch;
                    txtPercentage.Text = stud.Percentage.ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    stud.Name = txtName.Text;
                    stud.Branch = txtBranch.Text;
                    stud.Percentage = Convert.ToDouble(txtPercentage.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Student stud = dbcontext.Students.Find(Convert.ToInt32(txtRollNo.Text));
                if (stud != null)
                {
                    dbcontext.Students.Remove(stud);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnShowAllStudentDetails_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbcontext.Students.ToList();
        }
    }
}
