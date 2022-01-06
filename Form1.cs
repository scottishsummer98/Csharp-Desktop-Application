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

namespace CsharpwithDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=Localhost; Database=CsharpTut; Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Account Where Username='" + txbUsername.Text + "' and Password='" + txbPassword.Text + "'", con);
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Dashboard ds = new Dashboard();
                ds.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Incorrect Username and Password", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
    }
}
