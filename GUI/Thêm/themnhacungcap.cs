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
    public partial class themnhacungcap : Form
    {
        private nhacungcapbus bus = new nhacungcapbus();
        int so = 0;
        public themnhacungcap()
        {
            InitializeComponent();
            so = bus.getcount();
            txtMa.Text = kiemtrathemma(so);
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
                    trave = "NCCP00" + kiemtra;
                }
                else if (kiemtra >= 10 && kiemtra < 100)
                {
                    kiemtra++;
                    trave = "NCC0" + kiemtra;
                }
                else if (kiemtra >= 100 && kiemtra < 1000)
                {
                    kiemtra++;
                    trave = "NCC" + kiemtra;
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
            nhacungcapdto nccdto = new nhacungcapdto();
            nccdto.Mancc = txtMa.Text;
            nccdto.Tenncc = textBoxten.Text;
            nccdto.Diachi = textBoxdiachi.Text;
            nccdto.Sdt = textBoxsdt.Text;
            nccdto.Email = textBoxemail.Text;
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                bus.them(nccdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                so = bus.getcount();
                txtMa.Text = kiemtrathemma(so);
                txtMa.Text = "";
                textBoxten.Text = "";
                textBoxdiachi.Text = "";
                textBoxsdt.Text = "";
                textBoxemail.Text = "";
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxdiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxsdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxten_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
