using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CsharpwithDatabase
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public void LoadEmployeeRecords()
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Database=CsharpTut; Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * from Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dgvEmployee.DataSource = bs;
            sda.Update(dt);
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadEmployeeRecords();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost; Database=CsharpTut; Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee ([ID],[First Name],[Last Name],[Email],[Gender],[Hire Date],[Salary],[Mobile No]) VALUES ('" + txbID.Text + "', '" + txbFirstName.Text + "', '" + txbLastName.Text + "', '" + txbEmail.Text + "', '" + cmbGender.Text + "', '" + dtpHireDate.Value + "', '" + txbSalary.Text + "', '" + txbMobileNo.Text + "')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record Saved Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.None);
            con.Close();
            LoadEmployeeRecords();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= localhost; Database= CsharpTut; Integrated Security= True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE [Employee] SET [First Name]= '"+txbFirstName.Text+ "',[Last Name]= '"+txbLastName.Text+ "',[Email]= '"+txbEmail.Text+ "',[Gender]= '" + cmbGender.Text + "',[Hire Date]= '" + dtpHireDate.Value+"',[Salary]= '"+txbSalary.Text+"',[Mobile No] = '"+txbMobileNo.Text+"' Where [ID]= '"+txbID.Text+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadEmployeeRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source= localhost; Database= CsharpTut; Integrated Security= True");
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM [Employee] WHERE [ID]= '" + txbID.Text + "'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Deleted Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
            LoadEmployeeRecords();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txbID.Text = string.Empty;
            txbFirstName.Text = string.Empty;
            txbLastName.Text = string.Empty;
            txbEmail.Text = string.Empty;
            cmbGender.Text = string.Empty;
            txbSalary.Text = string.Empty;
            txbMobileNo.Text = string.Empty;
        }
    }
}
