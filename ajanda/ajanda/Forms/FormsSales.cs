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
    public partial class FormsSales : Form
    {
        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;

        public FormsSales()
        {
            InitializeComponent();
        }
        public void View_Customer()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {

                    connect.Open();
                    da = new SqlDataAdapter("SELECT *FROM sales", connect);
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
        private void FormsSales_Load(object sender, EventArgs e)
        {
            View_Customer();
            CalculatetoSales(label1);
        }
        public void CalculatetoSales( Label lbl)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {

                    connect.Open();
                    string query2 = "select sum(amount) from sales";
                    SqlCommand command2 = new SqlCommand(query2, connect);
                    label1.Text = "TOTAL AMOUNT=" + command2.ExecuteScalar() + "TL";
                    connect.Close();
                    View_Customer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
