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
    public partial class ChangePassword : Form
    {
        khachhangdto acc;
        bool isPasswordHidden = true;
        public ChangePassword(khachhangdto acc)
        {
            InitializeComponent();
            this.acc = acc;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPass=textBox1.Text;
            if (new taikhoandao().checkOldPass(acc.MaTK, oldPass))
            {
                string newPass = textBox2.Text;
                if (!string.IsNullOrWhiteSpace(newPass))
                {
                    if (new taikhoandao().changePW(acc.MaTK, newPass)) MessageBox.Show("Đổi mật khẩu thành công");
                }
                else MessageBox.Show("Vui lòng nhập mật khẩu mới");
            }
            else MessageBox.Show("Mật khẩu cũ đã sai");
        }

        private void button3_Click(object sender, EventArgs e)
        {
        isPasswordHidden = !isPasswordHidden;

            // Thiết lập PasswordChar tùy thuộc vào trạng thái
            textBox2.PasswordChar = isPasswordHidden ? '*' : '\0';
            textBox1.PasswordChar = isPasswordHidden ? '*' : '\0';
        }
    }
}
