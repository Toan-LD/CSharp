using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Edit
{
    public partial class Editkh : Form
    {
        static khachhangbus khachhbus = new khachhangbus();
        private int borderWidth = 5;
        private khachhangbus khachhangbus=new khachhangbus();
        private DTO.khachhangdto Selectedkh;
        public Editkh(khachhangdto selectedkh)
        {
            Selectedkh = selectedkh;
            InitializeComponent();
            txtMaKh.Text = selectedkh.Mkh;
            txtMaTK.Text = selectedkh.MaTK.ToString();
            textBox1.Text = selectedkh.Hoten.Trim();
            txtEmail.Text = selectedkh.Email.Trim();
            txtSDT.Text = selectedkh.Sdt.Trim();
            dtpNgaySinh.Value = selectedkh.Ngaysinh;
            if (selectedkh.Gioitinh.Trim() == "Nam")
            {
                radioButtonnam.Checked = true;
            }
            else if (selectedkh.Gioitinh.Trim() == "Nữ")
            {
                radioButtonnu.Checked = true;
            }
            mousehover();
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
        private void Editkh_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void Editkh_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            khachhangdto khdto = new khachhangdto();
            khdto.Hoten = textBox1.Text.Trim();
            khdto.Email = txtEmail.Text.Trim();
            khdto.Sdt = txtSDT.Text.Trim();
            khdto.Ngaysinh = dtpNgaySinh.Value;
            if (radioButtonnam.Checked)
            {
                khdto.Gioitinh = "Nam";
            }
            else
            {
                khdto.Gioitinh = "Nữ";
            }
            khdto.Mkh = txtMaKh.Text.Trim();
            khdto.MaTK = int.Parse(txtMaTK.Text.Trim());
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                khachhbus.UPDATE(khdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                this.Close();
            }


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonnu_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonnam_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtMaTK_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKh_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
