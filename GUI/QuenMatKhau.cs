using Doanqlchdt.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doanqlchdt.RJ;
using Doanqlchdt.GUI.Messageboxshow;
using Doanqlchdt.DAO;
namespace Doanqlchdt.GUI
{
    public partial class QuenMatKhau : Form
    {

        QuenMatKhauBUS quenMatKhauBUS = new QuenMatKhauBUS();

        public QuenMatKhau()
        {
            InitializeComponent();
            dtNgaySinh.Value = DateTime.Today.Date;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                Comfrimupdate comfrimupdate = new Comfrimupdate("Hãy điền đầy đủ thông tin");
                comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                comfrimupdate.ShowDialog();
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtUsername.Focus();
                }
                else if (txtSoDienThoai.Text == "") 
                {
                    txtSoDienThoai.Focus();
                }
            }
            else
            {
                string username = txtUsername.Text;
                string phoneNumber = txtSoDienThoai.Text;
                DateTime dateTime1 = dtNgaySinh.Value;
                string dateTime = dateTime1.ToString();
                List<UserInfo> userInfoList = quenMatKhauBUS.GetUserName(username);

                if (userInfoList != null && userInfoList.Count > 0)
                {
                    foreach (UserInfo userInfo in userInfoList)
                    {
                        if (phoneNumber == userInfo.PhoneNumber && dateTime == userInfo.Birthday)
                        {
                            DoiMatKhau frm = new DoiMatKhau(txtUsername.Text);
                            frm.StartPosition = FormStartPosition.CenterScreen;
                            this.Visible = false;
                            frm.ShowDialog();
                        } 
                        else if(phoneNumber == userInfo.PhoneNumber && dateTime != userInfo.Birthday)
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Ngày Sinh Không Đúng!");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }
                        else if(phoneNumber != userInfo.PhoneNumber && dateTime == userInfo.Birthday)
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Số Điện Thoại Không Đúng!");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }
                        else
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Số Điện Thoại Và Ngày Sinh Không Đúng!");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                        }

                    }
                }
                else
                {
                    // Không tìm thấy dữ liệu
                    Comfrimupdate confirmUpdate = new Comfrimupdate("Không tìm thấy Username");
                    confirmUpdate.StartPosition = FormStartPosition.CenterScreen;
                    confirmUpdate.ShowDialog();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();
            frm.Visible = true;
            Close();
        }

        private void dtNgaySinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSoDienThoai_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
