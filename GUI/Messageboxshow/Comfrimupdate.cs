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
    public partial class Comfrimupdate : Form
    {
        public Comfrimupdate(String thongbao)
        {
            InitializeComponent();
            labelluu.Text = thongbao;
            mousehover();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void mousehover()
        {
            btnOK.MouseEnter += (sender, e) =>
            {
                btnOK.BackColor = Color.DodgerBlue;
                btnOK.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnOK.MouseLeave += (sender, e) =>
            {
                btnOK.BackColor = System.Drawing.SystemColors.Window;
                btnOK.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
        }
    }
}
