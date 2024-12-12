using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Thêm
{
    public partial class Themsanpham : Form
    {
        private sanphambus spb=new sanphambus();
        int so = 0;
        public Themsanpham()
        {
            InitializeComponent();
            so = spb.getcount();
            txtMasp.Text = kiemtrathemma(so);
            Hienthiloaisanpham();
            mousehover();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            sanphamdto spdto = new sanphamdto();

            spdto.Masp = txtMasp.Text.Trim();
            spdto.Tensp=textBox1tensp.Text.Trim();
            spdto.Gianhap=int.Parse(textgianhap.Text.Trim());
            spdto.Giaban=int.Parse(txtgiaban.Text.Trim());
            spdto.Mota=textBoxmota.Text.Trim();
            spdto.Hinhanh = ImageToByteArray(pictureBox1.Image);
            spdto.Maloai = cbbtenmaloai.SelectedValue.ToString();
            decimal numberic = numericUpDownsoluong.Value;
            spdto.Soluong = Convert.ToInt32(numberic);
            spb.themsp(spdto);
            Messageboxshow.Comfrimupdate cfm=new Messageboxshow.Comfrimupdate("Lưu thông tin thành công");
            cfm.ShowDialog();
            textBox1tensp.Text = "";
            textBoxmota.Text = "";
            textgianhap.Text = "";
            txtgiaban.Text = "";
            pictureBox1.Image = null;
            cbbtenmaloai.SelectedIndex = 0;
            numericUpDownsoluong.Value = 0;
            so = spb.getcount();
            txtMasp.Text = kiemtrathemma(so);


        }
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m=new MemoryStream();
            img.Save(m,System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open=new OpenFileDialog();
            if(open.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image=Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void txtMasp_TextChanged(object sender, EventArgs e)
        {

        }
        public String kiemtrathemma(int kiemtra)
        {
            String trave = "";
            if(kiemtra>0)
            {
                if(kiemtra<10)
                {
                    kiemtra++;
                    trave = "SP00" + kiemtra;
                }
                else if(kiemtra>=10 && kiemtra<100)
                {
                    kiemtra++;
                    trave = "SP0" + kiemtra;
                }
                else if (kiemtra >= 100 && kiemtra < 1000)
                {
                    kiemtra++;
                    trave = "SP" + kiemtra;
                }
            }
            return trave;
        }
        public void Hienthiloaisanpham()
        {
            DataTable dt = spb.gettenloaisp();
            cbbtenmaloai.DataSource = dt;
            cbbtenmaloai.DisplayMember = "TenLoai";
            cbbtenmaloai.ValueMember = "MaLoai";
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
