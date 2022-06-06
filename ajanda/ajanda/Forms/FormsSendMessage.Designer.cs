
namespace ajanda.Forms
{
    partial class FormsSendMessage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtphoneno = new System.Windows.Forms.TextBox();
            this.btnsendmessage = new System.Windows.Forms.Button();
            this.txtsearchtc = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnbelate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtphoneno
            // 
            this.txtphoneno.Location = new System.Drawing.Point(168, 105);
            this.txtphoneno.Name = "txtphoneno";
            this.txtphoneno.Size = new System.Drawing.Size(208, 28);
            this.txtphoneno.TabIndex = 1;
            // 
            // btnsendmessage
            // 
            this.btnsendmessage.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsendmessage.ForeColor = System.Drawing.Color.Black;
            this.btnsendmessage.Location = new System.Drawing.Point(436, 64);
            this.btnsendmessage.Name = "btnsendmessage";
            this.btnsendmessage.Size = new System.Drawing.Size(103, 52);
            this.btnsendmessage.TabIndex = 2;
            this.btnsendmessage.Text = "Send";
            this.btnsendmessage.UseVisualStyleBackColor = true;
            this.btnsendmessage.Click += new System.EventHandler(this.btnsendmessage_Click);
            // 
            // txtsearchtc
            // 
            this.txtsearchtc.Location = new System.Drawing.Point(168, 60);
            this.txtsearchtc.Name = "txtsearchtc";
            this.txtsearchtc.Size = new System.Drawing.Size(208, 28);
            this.txtsearchtc.TabIndex = 3;
            this.txtsearchtc.TextChanged += new System.EventHandler(this.txtmessage_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtxt);
            this.groupBox1.Controls.Add(this.btnsendmessage);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtphoneno);
            this.groupBox1.Controls.Add(this.txtsearchtc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(17, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 329);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Message!";
            // 
            // txtxt
            // 
            this.txtxt.Location = new System.Drawing.Point(168, 172);
            this.txtxt.Multiline = true;
            this.txtxt.Name = "txtxt";
            this.txtxt.Size = new System.Drawing.Size(383, 131);
            this.txtxt.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Text:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Phone no:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Search to TC:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(28)))), ((int)(((byte)(84)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.panel1.Location = new System.Drawing.Point(43, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(651, 361);
            this.panel1.TabIndex = 5;
            // 
            // btnbelate
            // 
            this.btnbelate.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnbelate.Location = new System.Drawing.Point(772, 126);
            this.btnbelate.Name = "btnbelate";
            this.btnbelate.Size = new System.Drawing.Size(162, 75);
            this.btnbelate.TabIndex = 6;
            this.btnbelate.Text = "Message about delaying delivery";
            this.btnbelate.UseVisualStyleBackColor = true;
            this.btnbelate.Click += new System.EventHandler(this.btnbelate_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(772, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 75);
            this.button1.TabIndex = 7;
            this.button1.Text = "Date to delivery warning";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormsSendMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1335, 651);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnbelate);
            this.Controls.Add(this.panel1);
            this.Name = "FormsSendMessage";
            this.Text = "FormsSendMessage";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtphoneno;
        private System.Windows.Forms.Button btnsendmessage;
        private System.Windows.Forms.TextBox txtsearchtc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnbelate;
        private System.Windows.Forms.Button button1;
    }
}