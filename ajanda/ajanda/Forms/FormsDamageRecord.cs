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
    public partial class FormsDamageRecord : Form
    {
        public FormsDamageRecord()
        {
            InitializeComponent();
        }

        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;

        public void View_Damage()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {

                    connect.Open();
                    da = new SqlDataAdapter("SELECT *FROM damage", connect);
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
        private void Free_cars(ComboBox combo, string query)
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
                    combo.Items.Add(read["licenseplate"].ToString());

                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BringfromCombo(ComboBox the_cars, TextBox brand, TextBox serial, TextBox model, TextBox color, string query)
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
                    brand.Text = read["brand"].ToString();
                    serial.Text = read["serial"].ToString();
                    model.Text = read["model"].ToString();
                    color.Text = read["color"].ToString();

                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void BringDamage(ComboBox the_cars, TextBox damage, string query)
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
                    damage.Text = read["damage"].ToString();

                }

                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Freecars1()
        {
            try
            {
                string query2 = "SELECT *FROM cars";
                Free_cars(combocars, query2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combocars_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clear tarzı bisi
            string query2 = "SELECT *FROM cars WHERE licenseplate like '" + combocars.SelectedItem + "'";
            string query = "SELECT *FROM damage WHERE licenseplate like '" + combocars.SelectedItem + "'";
            BringDamage(combocars, txtdamage, query);
            BringfromCombo(combocars, txtbrand, txtserial, txtmodel, txtcolor, query2);
        }


        private void Clearforcar()
        {

            combocars.Text = "";
            txtbrand.Text = "";
            txtserial.Text = "";
            txtmodel.Text = "";
            txtcolor.Text = "";
            txtdamage.Text = "";


        }





        private void FormsDamageRecord_Load(object sender, EventArgs e)
        {
            Freecars1();
            View_Damage();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "insert into damage(licenseplate,brand,serial,model,color,damage) values (@licenseplatecik,@brandcik,@serialcik,@modelcik,@colorcik,@damagecik)";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@licenseplatecik", combocars.Text);
                command.Parameters.AddWithValue("@brandcik", txtbrand.Text);
                command.Parameters.AddWithValue("@serialcik", txtserial.Text);
                command.Parameters.AddWithValue("@modelcik", txtmodel.Text);
                command.Parameters.AddWithValue("@colorcik", txtcolor.Text);
                command.Parameters.AddWithValue("@damagecik", txtdamage.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Freecars1();
                View_Damage();
                MessageBox.Show("Record added!");//ing yap
                Clearforcar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "UPDATE damage SET licenseplate=@licenseplatecik,brand=@brandcik,serial=@serialcik,model=@modelcik,color=@colorcik," +
                    "damage=@damagecik WHERE licenseplate=@licenseplatecik";
                SqlCommand command = new SqlCommand(query, connect);

                command.Parameters.AddWithValue("@licenseplatecik", combocars.Text);
                command.Parameters.AddWithValue("@brandcik", txtbrand.Text);
                command.Parameters.AddWithValue("@serialcik", txtserial.Text);
                command.Parameters.AddWithValue("@modelcik", txtmodel.Text);
                command.Parameters.AddWithValue("@colorcik", txtcolor.Text);
                command.Parameters.AddWithValue("@damagecik", txtdamage.Text);
                command.ExecuteNonQuery();
                connect.Close();
                Freecars1();
                View_Damage();
                MessageBox.Show("Record updated!");//ing yap
                combocars.Items.Clear();

                Clearforcar();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "DELETE FROM damage WHERE licenseplate=@licenseplatecik";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@licenseplatecik", combocars.Text);
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Record deleted!");//ing yap
                Clearforcar();
                View_Damage();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow line = dataGridView1.CurrentRow;

            combocars.Text = line.Cells[0].Value.ToString();
            txtbrand.Text = line.Cells[1].Value.ToString();
            txtserial.Text = line.Cells[2].Value.ToString();
            txtmodel.Text = line.Cells[3].Value.ToString();
            txtcolor.Text = line.Cells[4].Value.ToString();
            txtdamage.Text = line.Cells[5].Value.ToString();

        }
    }

}
