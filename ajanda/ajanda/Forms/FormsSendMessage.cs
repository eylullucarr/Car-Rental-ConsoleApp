using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ajanda.Models;

namespace ajanda.Forms
{
    public partial class FormsSendMessage : Form
    {
        public FormsSendMessage()
        {
            InitializeComponent();
        }
        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;

        private void btnsendmessage_Click(object sender, EventArgs e)
        {
            SmsAppService smsApp = new SmsAppService();
            smsApp.SmsSender(txtphoneno.Text, txtsearchtc.Text);
            MessageBox.Show("Mesage sent.", "Case", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtphoneno.Text = "";
            txtxt.Text = "";
            txtsearchtc.Text = "";
        }
        private void Search_tc(TextBox searchtc, TextBox phone, string query)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    phone.Text = read["phone"].ToString();

                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtmessage_TextChanged(object sender, EventArgs e)
        {
            string query2 = "SELECT *FROM customer WHERE tc like '%" + txtsearchtc.Text + "%'";
            Search_tc(txtsearchtc, txtphoneno, query2);
        }

        private void btnbelate_Click(object sender, EventArgs e)
        {
            txtxt.Text = "You have exceeded your car rental period.You will be charged extra according to the rental method you choose.Like daily,monthly,weekly.Have a good day.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtxt.Text = "Your car delivery day is approaching. Have a good day!";


        }
    }
}
