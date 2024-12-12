using Doanqlchdt.BUS;
using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
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
    public partial class Login : Form
    {
        taikhoanbus taikhoanbus;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            taikhoanbus = new taikhoanbus();
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng điền đẩy đủ!!");
                return;
            }
            String tk = textBox1.Text;
            String mk = textBox2.Text;
            if (taikhoanbus.checkt(tk, mk))
            {
                int checkQuyen = taikhoanbus.GetQuyen(tk, mk);
                if (checkQuyen == 1)
                {
                    this.Visible = false;
                    MessageBox.Show("Bạn đang đăng nhập dưới dạng ADMIN");
                    Manager.Manager frm = new GUI.Manager.Manager(checkQuyen);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
                else if (checkQuyen == 2)
                {
                    MessageBox.Show("Bạn đang đăng nhập dưới dạng Nhân Viên Quản Lý Nhân Sự");
                    Manager.Manager frm = new GUI.Manager.Manager(checkQuyen);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
                else if (checkQuyen == 3)
                {
                    MessageBox.Show("Cảm ơn vì đã sử dụng dịch vụ của chúng tôi!");
                    this.Hide();
                    string matk= textBox1.Text;
                    khachhangdto kh = new taikhoandao().getKhachHang(matk);
                    UserGui userGui = new UserGui(kh);
                    userGui.Show();
                    userGui.FormClosed += (s, args) => this.ShowLogin();
                }
                else if(checkQuyen == 4)
                {
                    MessageBox.Show("Bạn đang đăng nhập dưới dạng Nhân Viên Quản Lý Kho");
                    Manager.Manager frm = new GUI.Manager.Manager(checkQuyen);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Username hoặc Password của bạn bị sai!!");
            }
        }

        private void ShowLogin()
        {
            // Hiển thị lại Form1
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegisterAccount frmRegis = new RegisterAccount();
            this.Hide();
            frmRegis.StartPosition = FormStartPosition.CenterScreen;
            frmRegis.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau frm = new QuenMatKhau();
            this.Hide();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }
    }
}
