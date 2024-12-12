using Doanqlchdt.BUS;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Doanqlchdt.GUI.Edit
{
    public partial class editdbh : Form
    {
        static donbaohanhbus bus = new donbaohanhbus();
        private int borderWidth = 5;
        private DTO.donbaohanhdto selecteddto;
        public editdbh(donbaohanhdto dbhdto)
        {
            selecteddto = dbhdto;
            InitializeComponent();
            mousehover();
            txtMadbh.Text = selecteddto.Madonbaohanh;
            DataTable dtnv = bus.getnv();
            DataTable dtkh = bus.getkh();
            DataTable dtsp = bus.getsp();
            cbbtenmanv.DataSource = dtnv;
            cbbtenmanv.DisplayMember = "HoTen";
            cbbtenmanv.ValueMember = "MaNV";
            cbbtenmanv.SelectedValue = selecteddto.Manv;
            comboBoxmkh.DataSource = dtkh;
            comboBoxmkh.DisplayMember = "HoTen";
            comboBoxmkh.ValueMember = "MaKH";
            comboBoxmkh.SelectedValue = selecteddto.Makh;
            comboBoxmsp.DataSource = dtsp;
            comboBoxmsp.DisplayMember = "TenSP";
            comboBoxmsp.ValueMember = "MaSP";
            comboBoxmsp.SelectedValue = selecteddto.Masp;
            dtpNgaytra.Value = selecteddto.Ngaytao;
            dateTimePickerngaytao.Value = selecteddto.Ngaytra;
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
            donbaohanhdto dbhdto = new donbaohanhdto();
            dbhdto.Madonbaohanh = txtMadbh.Text.Trim();
            dbhdto.Manv = cbbtenmanv.SelectedValue.ToString();
            dbhdto.Masp = comboBoxmsp.SelectedValue.ToString();
            dbhdto.Makh = comboBoxmkh.SelectedValue.ToString();
            dbhdto.Ngaytao = dateTimePickerngaytao.Value;
            dbhdto.Ngaytra = dtpNgaytra.Value;
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                bus.UPDATE(dbhdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                this.Close();
            }


        }

        private void buttonminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxmsp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxmkh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbbtenmanv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerngaytao_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgaytra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMadbh_TextChanged(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
