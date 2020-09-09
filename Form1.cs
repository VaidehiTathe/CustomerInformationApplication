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

namespace CustomerInformationForSalesTeam
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\CustomerInformation\CustomerInformationForSalesTeam\SalesTeamServer.mdf;Integrated Security=True;Connect Timeout=30");

        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText= "insert into [MyTable](Name,Address,email,DateOfBirth) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            cmd.ExecuteNonQuery();
            connection.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            MessageBox.Show("Added successfully");
            display_data();
        }
        public void display_data()
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from MyTable";
            cmd.ExecuteNonQuery();
            DataTable dta = new DataTable();
            SqlDataAdapter dataadp = new SqlDataAdapter(cmd);
            dataadp.Fill(dta);
            dg.DataSource = dta;
            connection.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            display_data();
 
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dg.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dg.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dg.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dg.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update MyTable set Address = '" + textBox2.Text + "',email = '" + textBox3.Text + "', DateOfBirth = '" + textBox4.Text+"' where Name = '" + textBox1.Text+"'"; 
            cmd.ExecuteNonQuery();
            connection.Close();
            display_data();
            MessageBox.Show("Data updated successfully");
        }
    }
}
