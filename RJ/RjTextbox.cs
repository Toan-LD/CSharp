using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.RJ
{
    [DefaultEvent("TextboxChanged")]
    public partial class RjTextbox : UserControl
    {
        public event EventHandler TextboxChanged;

        private Color borderColor = Color.MediumAquamarine;
        private int bordersize = 2;
        private bool underlinedstyle = false;
        public RjTextbox()
        {
            InitializeComponent();
        }

        public Color BorderColor {
            get
            {
                return borderColor;
            }
            set {
                borderColor = value;
                this.Invalidate();
            } 
        }
        public int Bordersize { 
            get => bordersize; 
            set { 
                bordersize = value; 
                this.Invalidate();
            }
        }
        public bool Underlinedstyle { get => underlinedstyle; set { underlinedstyle = value;this.Invalidate();} }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            using (Pen penBorder = new Pen(BorderColor,Bordersize))
            {
                penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                if (underlinedstyle)
                {
                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                }
                else graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(this.DesignMode)
            UpdateControlHeight();
        }

        public bool PasswordChar
        {
            get
            {
                return textBox1.UseSystemPasswordChar;
            }
            set => textBox1.UseSystemPasswordChar = value;
        }

        public string Texts { get => textBox1.Text; set => textBox1.Text = value; }

       
        private void UpdateControlHeight()
        {
            if(textBox1.Multiline == false)
            {
                int txtHeight=TextRenderer.MeasureText("Text",this.Font).Height+1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextboxChanged != null)
            {
                TextboxChanged.Invoke(sender,e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
        }
    }
}
