using Doanqlchdt.BUS;
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

namespace Doanqlchdt.GUI
{
    public partial class DoiMatKhau : Form
    {
        QuenMatKhauBUS quenMatKhauBUS = new QuenMatKhauBUS();
        string userName;
        public DoiMatKhau(string username)
        {
            InitializeComponent();
            userName = username; 
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string matKhau = txtMatKhauMoi.Text;
            string xacNhan = txtXacNhanMatKhau.Text;

            if(matKhau == "" || xacNhan == "")
            {
                Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Nhập Đầy Đủ");
                comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                comfrimupdate.ShowDialog();
            }
            else
            {
                if (matKhau == "")
                {
                    Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Nhập Mật Khẩu Mới");
                    comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                    comfrimupdate.ShowDialog();
                }
                else if (xacNhan == "")
                {
                    Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Xác Nhận Lại Mật Khẩu");
                    comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                    comfrimupdate.ShowDialog();
                }
                else
                {
                    if (matKhau != xacNhan)
                    {
                        Comfrimupdate comfrimupdate = new Comfrimupdate("Xác Nhận Mật Khẩu Không Khớp");
                        comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                        comfrimupdate.ShowDialog();
                    }
                    else
                    {
                        quenMatKhauBUS.ChangePassWord(userName, xacNhan); 
                        Comfrimupdate comfrimupdate = new Comfrimupdate("Đổi Mật Khẩu Thành Công");
                        comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                        comfrimupdate.ShowDialog();
                        this.Visible = false;
                        Login frm = new Login();
                        frm.Visible = true;
                    }
                }
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            QuenMatKhau frm = new QuenMatKhau();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Visible = true;
            this.Close();
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtXacNhanMatKhau.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtMatKhauMoi.UseSystemPasswordChar = false;
                txtXacNhanMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhauMoi.UseSystemPasswordChar = true;
                txtXacNhanMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
