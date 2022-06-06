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
    public partial class FormsCarOperations : Form
    {
        static string conString = "Data Source=LAPTOP-D24UAQ9F;Initial Catalog=Rent_Car;Integrated Security=True";
        SqlConnection connect = new SqlConnection(conString);
        SqlDataAdapter da;

        public FormsCarOperations()
        {
            InitializeComponent();
        }
        private void FormsCarOperations_Load(object sender, EventArgs e)
        {
            View_Cars();
        }
        private void combomarka_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                comboseri.Items.Clear();

                if (combomarka.SelectedItem.ToString() == "OPEL")
                {
                    comboseri.Items.Add("Corsa");
                    comboseri.Items.Add("Insıgna");
                    comboseri.Items.Add("Mokka");
                }
                else if (combomarka.SelectedItem.ToString() == "MERCEDES")
                {
                    comboseri.Items.Add("S400");
                    comboseri.Items.Add("AMG");
                    comboseri.Items.Add("A180");
                }
                else if (combomarka.SelectedItem.ToString() == "VOLVO")
                {
                    comboseri.Items.Add("XC40");
                    comboseri.Items.Add("S60");
                    comboseri.Items.Add("S90");
                }
                else if (combomarka.SelectedItem.ToString() == "NISSAN")
                {
                    comboseri.Items.Add("QASHGAİ");
                    comboseri.Items.Add("JUKE");
                    comboseri.Items.Add("X-TRAİL");
                }
                else if (combomarka.SelectedItem.ToString() == "RENULT")
                {
                    comboseri.Items.Add("CLİO");
                    comboseri.Items.Add("SYMBOL");
                    comboseri.Items.Add("MEGANE");
                }
                else if (combomarka.SelectedItem.ToString() == "SKODA")
                {
                    comboseri.Items.Add("OCTOVİA");
                    comboseri.Items.Add("FABİA");
                    comboseri.Items.Add("KAMİQ");
                }
                else if (combomarka.SelectedItem.ToString() == "FORD")
                {
                    comboseri.Items.Add("TOURNEO");
                    comboseri.Items.Add("FİESTA");
                    comboseri.Items.Add("MONDEO");
                }
                else if (combomarka.SelectedItem.ToString() == "FIAT")
                {
                    comboseri.Items.Add("DOBLO");
                    comboseri.Items.Add("LOUNGE");
                    comboseri.Items.Add("PALIO");
                }
                else if (combomarka.SelectedItem.ToString() == "VOLKSWAGEN")
                {
                    comboseri.Items.Add("PASSAT");
                    comboseri.Items.Add("TIGUAN");
                    comboseri.Items.Add("GOLF");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnrefuse_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void View_Cars()
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {

                    connect.Open();
                    da = new SqlDataAdapter("SELECT *FROM cars", connect);
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

        private void Clear()
        {
            pictureBox1.ImageLocation = "";
            comboseri.Text = "";
            combomarka.Text = "";
            comboyakıt.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void btnuploadphto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }

        private void btnrefuse_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnupdatecars_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }

                String query = "UPDATE cars SET licenseplate=@licenseplatecik,brand=@brandcik,serial=@serialcik,model=@modelcik,color=@colorcik,km=@kmcik,fuel=@fuelcik,rentalfee=@rentalfeecik,photo=@photocik,date=@datecik,situation=@situationcik WHERE cno=@cnocik";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@cnocik", Convert.ToInt32(textBox1.Text));
                command.Parameters.AddWithValue("@licenseplatecik", textBox2.Text);
                command.Parameters.AddWithValue("@brandcik", combomarka.Text);
                command.Parameters.AddWithValue("@serialcik", comboseri.Text);
                command.Parameters.AddWithValue("@modelcik", textBox3.Text);
                command.Parameters.AddWithValue("@colorcik", textBox4.Text);
                command.Parameters.AddWithValue("@kmcik", textBox5.Text);
                command.Parameters.AddWithValue("@fuelcik", comboyakıt.Text);
                command.Parameters.AddWithValue("@rentalfeecik", textBox6.Text);
                command.Parameters.AddWithValue("@photocik", pictureBox1.ImageLocation);
                command.Parameters.AddWithValue("@datecik", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@situationcik", "BOŞ");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Record uptaded!");//ing yap
                Clear();
                View_Cars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddcars_Click(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                String query = "insert into cars(licenseplate,brand,serial,model,color,km,fuel,rentalfee,photo,date,situation) values(@licenseplatecik,@brandcik,@serialcik,@modelcik,@colorcik,@kmcik,@fuelcik,@rentalfeecik,@photocik,@datecik,@situationcik)";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@licenseplatecik", textBox2.Text);
                command.Parameters.AddWithValue("@brandcik", combomarka.Text);
                command.Parameters.AddWithValue("@serialcik", comboseri.Text);
                command.Parameters.AddWithValue("@modelcik", textBox3.Text);
                command.Parameters.AddWithValue("@colorcik", textBox4.Text);
                command.Parameters.AddWithValue("@kmcik", textBox5.Text);
                command.Parameters.AddWithValue("@fuelcik", comboyakıt.Text);
                command.Parameters.AddWithValue("@rentalfeecik", textBox6.Text);
                command.Parameters.AddWithValue("@photocik", pictureBox1.ImageLocation);
                command.Parameters.AddWithValue("@datecik", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@situationcik", "FREE");
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Record added!");//ing yap
                Clear();
                View_Cars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndeletecars_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                string query = "DELETE FROM cars WHERE cno= @cnocuk";
                SqlCommand command = new SqlCommand(query, connect);
                command.Parameters.AddWithValue("@cnocuk", Convert.ToInt32(textBox1.Text));
                command.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Record deleted!");//ing yap
                Clear();
                View_Cars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow line = dataGridView1.CurrentRow;
            textBox1.Text = line.Cells["cno"].Value.ToString();
            textBox2.Text = line.Cells["licenseplate"].Value.ToString();
            combomarka.Text = line.Cells["brand"].Value.ToString();
            comboseri.Text = line.Cells["serial"].Value.ToString();
            textBox3.Text = line.Cells["model"].Value.ToString();
            textBox4.Text = line.Cells["color"].Value.ToString();
            textBox5.Text = line.Cells["km"].Value.ToString();
            comboyakıt.Text = line.Cells["fuel"].Value.ToString();
            textBox6.Text = line.Cells["rentalfee"].Value.ToString();
            pictureBox1.ImageLocation = line.Cells["photo"].Value.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    View_Cars();
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    da = new SqlDataAdapter("SELECT *FROM cars WHERE situation='FREE'", connect);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
                else if (comboBox1.SelectedIndex == 2)
                {
                    da = new SqlDataAdapter("SELECT *FROM cars WHERE situation='RENTED'", connect);
                    DataTable table = new DataTable();
                    da.Fill(table);
                    dataGridView1.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            Clear();
        }

    }
}

