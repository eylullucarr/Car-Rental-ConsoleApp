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
    public partial class FormsAgreement : Form
    {
        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;

        public FormsAgreement()
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
                    da = new SqlDataAdapter("SELECT *FROM allagree", connect);
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
        private void FormsAgreement_Load(object sender, EventArgs e)
        {
            View_Customer();
            Freecars1();
        }
        private void Freecars1()
        {
            try
            {
                string query2 = "SELECT *FROM cars WHERE situation='FREE'";
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
            BringfromCombo(combocars, txtbrand, txtserial, txtmodel, txtcolor, query2);
        }

        private void Search_tc(TextBox serachtc, TextBox tc, TextBox name, TextBox surname, TextBox phone, string query)
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
                    tc.Text = read["tc"].ToString();
                    name.Text = read["name"].ToString();
                    surname.Text = read["surname"].ToString();
                    phone.Text = read["phone"].ToString();

                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CalculatetoAmount(ComboBox formofamount, TextBox amount, string query)
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
                    if (formofamount.SelectedIndex == 0) amount.Text = (int.Parse(read["rentalfee"].ToString()) * 1).ToString();
                    if (formofamount.SelectedIndex == 1) amount.Text = (int.Parse(read["rentalfee"].ToString()) * 0.80).ToString();
                    if (formofamount.SelectedIndex == 1) amount.Text = (int.Parse(read["rentalfee"].ToString()) * 0.70).ToString();
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void combof_rental_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query2 = "SELECT *FROM cars WHERE licenseplate like '" + combocars.SelectedItem + "'";
            CalculatetoAmount(combof_rental, txtrentalfee, query2);
        }

        private void btncalculate(object sender, EventArgs e)
        {
            TimeSpan day = DateTime.Parse(datetime_return.Text) - DateTime.Parse(datetime_leased.Text);
            double day2 = day.Days;
            txtday.Text = day2.ToString();
            txtamount.Text = (day2 * double.Parse(txtrentalfee.Text)).ToString();
        }
        private void Clearforcustomers()
        {

            txttc.Text = "";
            txtname.Text = "";
            txtsurname.Text = "";
            txtphone.Text = "";
            txtdl_serial.Text = "";
            txtdl_date.Text = "";
            txtdl_place.Text = "";
        }
        private void Clearforcar()
        {

            combocars.Text = "";
            txtbrand.Text = "";
            txtserial.Text = "";
            txtmodel.Text = "";
            txtcolor.Text = "";
            combof_rental.Text = "";
            txtrentalfee.Text = "";
            txtamount.Text = "";
            txtday.Text = "";
            datetime_leased.Text = DateTime.Now.ToShortDateString();
            datetime_return.Text = DateTime.Now.ToShortDateString();

        }

       
        private void btnAdd_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "insert into allagree(tc,name,surname,phone,dl_no,dl_date,dl_place,licenseplate,brand,serial,model,color,formof_rental,rentalfee," +
                    "day,amount,leased_date,return_date) values(@tccik,@namecik,@surnamecik,@phonecik,@dl_nocik,@dl_datecik,@dl_placecik,@licenseplatecik,@brandcik,@serialcik," +
                    "@modelcik,@colorcik,@formof_rentalcik,@rentalfeecik,@daycik,@amountcik,@leased_datecik,@return_datecik)";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@tccik", txttc.Text);
                command.Parameters.AddWithValue("@namecik", txtname.Text);
                command.Parameters.AddWithValue("@surnamecik", txtsurname.Text);
                command.Parameters.AddWithValue("@phonecik", txtphone.Text);
                command.Parameters.AddWithValue("@dl_nocik", txtdl_serial.Text);
                command.Parameters.AddWithValue("@dl_datecik", txtdl_date.Text);
                command.Parameters.AddWithValue("@dl_placecik", txtdl_place.Text);
                command.Parameters.AddWithValue("@licenseplatecik", combocars.Text);
                command.Parameters.AddWithValue("@brandcik", txtbrand.Text);
                command.Parameters.AddWithValue("@serialcik", txtserial.Text);
                command.Parameters.AddWithValue("@modelcik", txtmodel.Text);
                command.Parameters.AddWithValue("@colorcik", txtcolor.Text);
                command.Parameters.AddWithValue("@formof_rentalcik", combof_rental.Text);
                command.Parameters.AddWithValue("@rentalfeecik", int.Parse(txtrentalfee.Text));
                command.Parameters.AddWithValue("@daycik", int.Parse(txtday.Text));
                command.Parameters.AddWithValue("@amountcik", int.Parse(txtamount.Text));
                command.Parameters.AddWithValue("@leased_datecik", datetime_leased.Text);
                command.Parameters.AddWithValue("@return_datecik", datetime_return.Text);
                command.ExecuteNonQuery();
                string query2 = "UPDATE cars SET situation='RENTED' WHERE licenseplate='" + combocars.Text + "'";
                SqlCommand command2 = new SqlCommand(query2, connect);
                command2.ExecuteNonQuery();
                Freecars1();
                connect.Close();
                MessageBox.Show("Record added!");//ing yap
                View_Customer();
                Clearforcar();
                Clearforcustomers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtsearch_tc_TextChanged(object sender, EventArgs e)
        {
            string query2 = "SELECT *FROM customer WHERE tc like '%" + txtsearch_tc.Text + "%'";
            Search_tc(txtsearch_tc, txttc, txtname, txtsurname, txtphone, query2);
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "UPDATE allagree SET tc=@tccik,name=@namecik,surname=@surnamecik,phone=@phonecik,dl_no=@dl_nocik,dl_date=@dl_datecik," +
                    "dl_place=@dl_placecik,licenseplate=@licenseplatecik,brand=@brandcik,serial=@serialcik,model=@modelcik,color=@colorcik," +
                    "formof_rental=@formof_rentalcik,rentalfee=@rentalfeecik," +
                    "day=@daycik,amount=@amountcik,leased_date=@leased_datecik,return_date= @return_datecik WHERE licenseplate=@licenseplatecik";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@tccik", txttc.Text);
                command.Parameters.AddWithValue("@namecik", txtname.Text);
                command.Parameters.AddWithValue("@surnamecik", txtsurname.Text);
                command.Parameters.AddWithValue("@phonecik", txtphone.Text);
                command.Parameters.AddWithValue("@dl_nocik", txtdl_serial.Text);
                command.Parameters.AddWithValue("@dl_datecik", txtdl_date.Text);
                command.Parameters.AddWithValue("@dl_placecik", txtdl_place.Text);
                command.Parameters.AddWithValue("@licenseplatecik", combocars.Text);
                command.Parameters.AddWithValue("@brandcik", txtbrand.Text);
                command.Parameters.AddWithValue("@serialcik", txtserial.Text);
                command.Parameters.AddWithValue("@modelcik", txtmodel.Text);
                command.Parameters.AddWithValue("@colorcik", txtcolor.Text);
                command.Parameters.AddWithValue("@formof_rentalcik", combof_rental.Text);
                command.Parameters.AddWithValue("@rentalfeecik", int.Parse(txtrentalfee.Text));
                command.Parameters.AddWithValue("@daycik", int.Parse(txtday.Text));
                command.Parameters.AddWithValue("@amountcik", int.Parse(txtamount.Text));
                command.Parameters.AddWithValue("@leased_datecik", datetime_leased.Text);
                command.Parameters.AddWithValue("@return_datecik", datetime_return.Text);
                command.ExecuteNonQuery();
                combocars.Items.Clear();
                connect.Close();
                MessageBox.Show("Record updated!");//ing yap
                View_Customer();
                Clearforcar();
                Clearforcustomers();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow line = dataGridView1.CurrentRow;
            txttc.Text = line.Cells[0].Value.ToString();
            txtname.Text = line.Cells[1].Value.ToString();
            txtsurname.Text = line.Cells[2].Value.ToString();
            txtphone.Text = line.Cells[3].Value.ToString();
            txtdl_serial.Text = line.Cells[4].Value.ToString();
            txtdl_date.Text = line.Cells[5].Value.ToString();
            txtdl_place.Text = line.Cells[6].Value.ToString();
            combocars.Text = line.Cells[7].Value.ToString();
            txtbrand.Text = line.Cells[8].Value.ToString();
            txtserial.Text = line.Cells[9].Value.ToString();
            txtmodel.Text = line.Cells[10].Value.ToString();
            txtcolor.Text = line.Cells[11].Value.ToString();
            combof_rental.Text = line.Cells[12].Value.ToString();
            txtrentalfee.Text = line.Cells[13].Value.ToString();
            txtday.Text = line.Cells[14].Value.ToString();
            txtamount.Text = line.Cells[15].Value.ToString();
            datetime_leased.Text = line.Cells[16].Value.ToString();
            datetime_return.Text = line.Cells[17].Value.ToString();

            try
            {

                DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
                DateTime returnday = DateTime.Parse(line.Cells["return_date"].Value.ToString());
                int rentalfee = int.Parse(line.Cells["rentalfee"].Value.ToString());
                TimeSpan disparity = today - returnday;
                int _disparity = disparity.Days;
                int disparity_amount;
                disparity_amount = _disparity * rentalfee;
                txtextra.Text = disparity_amount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void interimdelivery_Click_1(object sender, EventArgs e)
        {

            DataGridViewRow line = dataGridView1.CurrentRow;

            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                if (int.Parse(txtextra.Text) >= 0 || int.Parse(txtextra.Text) < 0)
                {
                    DateTime today = DateTime.Parse(DateTime.Now.ToShortDateString());
                    int rental_fee = int.Parse(line.Cells["rentalfee"].Value.ToString());
                    int amount = int.Parse(line.Cells["amount"].Value.ToString());
                    DateTime leaseddate = DateTime.Parse(line.Cells["leased_date"].Value.ToString());
                    TimeSpan day = today - leaseddate;
                    int _day = day.Days;
                    int totalamount = _day * rental_fee;
                    
                    string query = "DELETE FROM allagree WHERE licenseplate='" + line.Cells["licenseplate"].Value.ToString() + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    
                    string query2 = "UPDATE cars SET situation='FREE' WHERE licenseplate='" + line.Cells["licenseplate"].Value.ToString() + "'";
                    SqlCommand command2 = new SqlCommand(query2, connect);
                    command2.ExecuteNonQuery();

                    String query3 = "insert into sales(tc,name,surname,licenseplate,brand,serial,model,color,day,price,amount,leased_date,real_returned_date) values(@tccik,@namecik,@surnamecik,@licenseplatecik,@brandcik,@serialcik," +
                        "@modelcik,@colorcik,@daycik,@pricecik,@amountcik,@leased_datecik,@real_returned_datecik)";
                    SqlCommand command3 = new SqlCommand(query3, connect);
                    command3.Parameters.AddWithValue("@tccik", line.Cells["tc"].Value.ToString());
                    command3.Parameters.AddWithValue("@namecik", line.Cells["name"].Value.ToString());
                    command3.Parameters.AddWithValue("@surnamecik", line.Cells["surname"].Value.ToString());
                    command3.Parameters.AddWithValue("@licenseplatecik", line.Cells["licenseplate"].Value.ToString());
                    command3.Parameters.AddWithValue("@brandcik", line.Cells["brand"].Value.ToString());
                    command3.Parameters.AddWithValue("@serialcik", line.Cells["serial"].Value.ToString());
                    command3.Parameters.AddWithValue("@modelcik", line.Cells["model"].Value.ToString());
                    command3.Parameters.AddWithValue("@colorcik", line.Cells["color"].Value.ToString()); ;
                    command3.Parameters.AddWithValue("@daycik", _day);
                    command3.Parameters.AddWithValue("@pricecik", int.Parse(line.Cells["rentalfee"].Value.ToString()));
                    command3.Parameters.AddWithValue("@amountcik", totalamount);
                    command3.Parameters.AddWithValue("@leased_datecik", line.Cells["leased_date"].Value.ToString());
                    command3.Parameters.AddWithValue("@real_returned_datecik", DateTime.Now.ToShortDateString());
                    command3.ExecuteNonQuery(); 
                    connect.Close();
                    MessageBox.Show("Vehicle delivered!");
                    View_Customer();
                }
                else
                {
                    MessageBox.Show("Please make a choice!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}





