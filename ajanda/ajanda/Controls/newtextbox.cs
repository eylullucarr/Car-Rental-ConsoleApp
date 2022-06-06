using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ajanda.Controls
{
    public partial class newtextbox : UserControl
    {
        public newtextbox()
        {
            InitializeComponent();
        }
        private Color borderColor = Color.White;
        private int borderSize = 3;
        private bool UnderLinedStyle = true;
        
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                borderSize = value;
                this.Invalidate();
            }
        }
        public bool UnderLinedStyle1
        {
            get
            {
                return UnderLinedStyle;
            }
            set
            {
                UnderLinedStyle = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            using (Pen penborder = new Pen(borderColor, borderSize))
            {
                if (UnderLinedStyle)
                    graph.DrawLine(penborder, 0, this.Height - 1, this.Width, this.Height - 1);
                else
                    graph.DrawRectangle(penborder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);

            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }
        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {

                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;

                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

    }
}

