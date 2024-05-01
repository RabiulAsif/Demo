using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[tbASIF]\r\n           ([Name]\r\n     ,[Roll])\r\n     VALUES\r\n   ('"+textBox1.Text+"','"+textBox2.Text+"')",connection);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Information Saved!");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;");
            connection.Open();
            string Query = "SELECT * FROM tbASIF;";
            SqlCommand cmd = new SqlCommand(Query,connection);
            var reader= cmd.ExecuteReader();

            while(reader.Read())
            {
         dataGridView1.Rows.Add(reader["Name"].ToString().ToUpper(), reader["Roll"]);
            }
            


            /*Method1
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table; */



            connection.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;");
           
            connection.Open();
            string Name = textBox1.Text;
            string Roll = textBox2.Text;

            string Query = "UPDATE tbASIF SET Name = '" + Name + "' WHERE Roll = '"+Roll+"'";
            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.ExecuteNonQuery();
            connection.Close();

            MessageBox.Show("Information UPDATED!");

            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7LKR989;Initial Catalog=ASIF;Integrated Security=True;");
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            string Roll = textBox2.Text;

            string Query = "DELETE FROM tbASIF WHERE Roll = @Roll";

            SqlCommand cmd = new SqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@Roll", Roll);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                MessageBox.Show("Record deleted successfully!");
            }
            else
            {
                MessageBox.Show("No record found with the provided Roll number.");
            }

            connection.Close();

            // Clear the textBox after deletion
            textBox2.Text = "";

        }
    }
}
