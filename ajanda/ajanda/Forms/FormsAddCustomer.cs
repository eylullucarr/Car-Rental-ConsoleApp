using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ajanda.Forms
{
    public partial class FormsAddCustomer : Form
    {
        public FormsAddCustomer()
        {
            InitializeComponent();
        }

        private void FormsAddCustomer_Load(object sender, EventArgs e)
        {
            View_Customer();
        }
        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;


        private void btnrefuse_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Clear()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }
        public void View_Customer()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {

                    connect.Open();
                    da = new SqlDataAdapter("SELECT *FROM customer", connect);
                    DataTable table = new DataTable();
                    da.Fill(table);

                    dataGridView1.DataSource = table;
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      
        
        private void btnupdatecustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "UPDATE customer SET tc=@tccik,name=@namecik,surname=@surnamecik,mail=@mailcik,phone=@phonecik WHERE mno=@mnocik";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@mnocik", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("@tccik", textBox2.Text);
                command.Parameters.AddWithValue("@namecik", textBox3.Text);
                command.Parameters.AddWithValue("@surnamecik", textBox4.Text);
                command.Parameters.AddWithValue("@mailcik", textBox5.Text);
                command.Parameters.AddWithValue("@phonecik", textBox6.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Clear();
                MessageBox.Show("Record uptaded!");//ing yap
                View_Customer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndeletecustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "DELETE FROM customer WHERE mno= @mnocuk";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@mnocuk", Convert.ToInt32(textBox1.Text));
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Record deleted!");//ing yap
                Clear();
                View_Customer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "insert into customer(tc,name,surname,mail,phone) values(@tccik,@namecik,@surnamecik,@mailcik,@phonecik)";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@tccik", textBox2.Text);
                command.Parameters.AddWithValue("@namecik", textBox3.Text);
                command.Parameters.AddWithValue("@surnamecik", textBox4.Text);
                command.Parameters.AddWithValue("@mailcik", textBox5.Text);
                command.Parameters.AddWithValue("@phonecik", textBox6.Text);
                command.ExecuteNonQuery();
                Clear();
                connect.Close();
                MessageBox.Show("Record added!");//ing yap
                View_Customer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow line = dataGridView1.CurrentRow;
            textBox1.Text = line.Cells["mno"].Value.ToString();
            textBox2.Text = line.Cells["tc"].Value.ToString();
            textBox3.Text = line.Cells["name"].Value.ToString();
            textBox4.Text = line.Cells["surname"].Value.ToString();
            textBox5.Text = line.Cells["mail"].Value.ToString();
            textBox6.Text = line.Cells["phone"].Value.ToString();
        }

        
    }
    }


