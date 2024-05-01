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
using Microsoft.Win32;

namespace Demo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string login = "SELECT * FROM tbl_users WHERE username=@username and password=@password";

                using (SqlCommand cmd = new SqlCommand(login, connection))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Authentication successful
                            new Form1().Show();
                            this.Hide();
                        }
                        else
                        {
                            // Authentication failed
                            MessageBox.Show("Invalid Username or Password, Please try again", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Text = "";
                            txtPassword.Text = "";
                            txtUsername.Focus();
                        }
                    }
                }
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
              
            }
            else
            {
                txtPassword.PasswordChar = '•';
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }
    }
}
