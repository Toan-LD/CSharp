using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Messageboxshow
{
    public partial class YesOrNo : Form
    {
       private Boolean comfirm = false;
        public YesOrNo(String thongbao)
        {
            InitializeComponent();
            labelluu.Text = thongbao;
            mousehover();
        }

        public bool Comfirm { get => comfirm; set => comfirm = value; }

        public void mousehover()
        {
            btnco.MouseEnter += (sender, e) =>
            {
                btnco.BackColor = Color.DodgerBlue;
                btnco.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnco.MouseLeave += (sender, e) =>
            {
                btnco.BackColor = System.Drawing.SystemColors.Window;
                btnco.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
            btnkhong.MouseEnter += (sender, e) =>
            {
                btnkhong.BackColor = System.Drawing.Color.OrangeRed;
                btnkhong.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnkhong.MouseLeave += (sender, e) =>
            {
                btnkhong.BackColor = System.Drawing.SystemColors.Window;
                btnkhong.ForeColor = System.Drawing.Color.OrangeRed;
            };
        }

        private void btnco_Click(object sender, EventArgs e)
        {
            Comfirm = true;
            this.Close();
        }

        private void btnkhong_Click(object sender, EventArgs e)
        {
            Comfirm = false;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
