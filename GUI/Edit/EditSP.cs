using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Messageboxshow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Doanqlchdt.GUI.Edit
{
    public partial class EditSP : Form
    {
        static sanphambus bus = new sanphambus();
        private int borderWidth = 5;
        private DTO.sanphamdto Selectedsp;
        public EditSP(sanphamdto spdto)
        {
            this.Selectedsp = spdto;
            InitializeComponent();
            txtMasp.Text=Selectedsp.Masp;
            textBox1tensp.Text = Selectedsp.Tensp;
            textBoxmota.Text = Selectedsp.Mota;
            textgianhap.Text = Selectedsp.Gianhap.ToString();
            txtgiaban.Text = Selectedsp.Giaban.ToString();
            pictureBox1.Image = ByteArraytoimage(Selectedsp.Hinhanh);
            DataTable dt = bus.gettenloaisp();
            cbbtenmaloai.DataSource = dt;
            cbbtenmaloai.DisplayMember = "TenLoai";
            cbbtenmaloai.ValueMember = "MaLoai";
            cbbtenmaloai.SelectedValue=Selectedsp.Maloai;
            int soluong=Selectedsp.Soluong;
            decimal soluongnumberirc = Convert.ToDecimal(soluong);
            numericUpDownsoluong.Value = soluongnumberirc;
            mousehover();
        }
        public Image ByteArraytoimage(byte[] b)
        {
            MemoryStream m = new MemoryStream(b);
            return Image.FromStream(m);

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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonminimize_Click(object sender, EventArgs e)
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
        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            sanphamdto spdto = new sanphamdto();

            spdto.Masp = txtMasp.Text.Trim();
            spdto.Tensp = textBox1tensp.Text.Trim();
            spdto.Gianhap = int.Parse(textgianhap.Text.Trim());
            spdto.Giaban = int.Parse(txtgiaban.Text.Trim());
            spdto.Mota = textBoxmota.Text.Trim();
            spdto.Hinhanh = ImageToByteArray(pictureBox1.Image);
            spdto.Maloai = cbbtenmaloai.SelectedValue.ToString();
            decimal numberic = numericUpDownsoluong.Value;
            spdto.Soluong = Convert.ToInt32(numberic);
            YesOrNo yon = new YesOrNo("Bạn có chắc chắn muốn lưu không");
            yon.ShowDialog();
            if (yon.Comfirm == true)
            {
                bus.UPDATE(spdto);
                Comfrimupdate cfm = new Comfrimupdate("Bạn đã lưu thông tin thành công");
                cfm.ShowDialog();
                this.Close();
            }
        }
    }
}
