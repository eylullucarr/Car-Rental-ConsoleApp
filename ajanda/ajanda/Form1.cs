using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ajanda
{
    public partial class Form1 : Form
    {
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;

        
        public Form1()
        {
            InitializeComponent();
            random = new Random();

        }
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                    panelHome.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(21, 28, 84);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();

            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
            labelHome.Text = currentButton.Text;

        }

        private void btncustomer_op_Click(object sender, EventArgs e)
        {
        OpenChildForm(new Forms.FormsAddCustomer(), sender);
        }

        private void btncar_op_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormsCarOperations(), sender);
        }

        private void btnrent_car_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormsAgreement(), sender);
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormsSales(), sender);
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormsSendMessage(), sender);
        }

        private void btndamgerecords_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.FormsDamageRecord(), sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }
    }
}
