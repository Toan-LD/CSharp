using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Thêm
{
    public partial class themloaisp : Form
    {
        private loaisanphambus bus = new loaisanphambus();
        int so = 0;
        public themloaisp()
        {
            InitializeComponent();
            so = bus.getcount();
            txtMaloai.Text = kiemtrathemma(so);
            mousehover();
        }
        public String kiemtrathemma(int kiemtra)
        {
            String trave = "";
            if (kiemtra > 0)
            {
                if (kiemtra < 10)
                {
                    kiemtra++;
                    trave = "LSP00" + kiemtra;
                }
                else if (kiemtra >= 10 && kiemtra < 100)
                {
                    kiemtra++;
                    trave = "LSP0" + kiemtra;
                }
                else if (kiemtra >= 100 && kiemtra < 1000)
                {
                    kiemtra++;
                    trave = "LSP" + kiemtra;
                }
            }
            return trave;
        }
        public void mousehover()
        {
            btnthem.MouseEnter += (sender, e) =>
            {
                btnthem.BackColor = Color.DodgerBlue;
                btnthem.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnthem.MouseLeave += (sender, e) =>
            {
                btnthem.BackColor = System.Drawing.SystemColors.Window;
                btnthem.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
            btnHuy.MouseEnter += (sender, e) =>
            {
                btnHuy.BackColor = System.Drawing.Color.OrangeRed;
                btnHuy.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnHuy.MouseLeave += (sender, e) =>
            {
                btnHuy.BackColor = System.Drawing.SystemColors.Window;
                btnHuy.ForeColor = System.Drawing.Color.OrangeRed;
            };
        }
        private void buttonminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            loaisanphamdto lspdto = new loaisanphamdto();
            lspdto.Maloai = txtMaloai.Text;
            lspdto.Tenloai = txtMaloai.Text;
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                bus.them(lspdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                so = bus.getcount();
                txtMaloai.Text = kiemtrathemma(so);
                textBoxtenloai.Text = "";
            }


        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn hủy không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                Comfrimupdate cfm = new Comfrimupdate("Bạn hủy thành công");
                cfm.ShowDialog();
                this.Close();
            }
        }

    }
}

