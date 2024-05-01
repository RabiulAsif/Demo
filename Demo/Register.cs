using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Demo
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();

        }


      

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Username and  Password fields are empty", "Registration failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            else if(txtPassword.Text == txtComPassword.Text)
            {
                SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;");

                connection.Open();

                string register = "INSERT INTO tbl_users VALUES('"+txtUsername.Text+"', '"+txtPassword.Text+"')";
                SqlCommand cmd = new SqlCommand(register, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Your account has been succcessfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            {
                MessageBox.Show("Passwords does not mathced, Please re-enter", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtComPassword.Text = "";
                txtPassword.Focus();
            }
        }

     
        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked) 
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtComPassword.PasswordChar = '•';
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
