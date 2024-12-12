using Doanqlchdt.BUS;
using Doanqlchdt.DAO;
using Doanqlchdt.RJ;
using System;
using System.Collections;
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
    public partial class RegisterAccount : Form
    {
        static taikhoandao tkdao = new taikhoandao();
        int soLuongTaiKhoan = tkdao.GetSoLuong() + 1;
         
        public RegisterAccount()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Boolean checkUser = new taikhoandao().checkUserID(txtUser.Texts);
            Boolean checkName = String.IsNullOrEmpty(txtName.Texts);
            Boolean checkRePass = txtPass.Texts.Equals(txtRePass.Texts);
            if (checkName)
            {
                txtName.BorderColor = Color.Red;
                label5.Text = "Không được để trống danh xưng";
                label5.Visible = true;

            }
            else
            {
                label5.Visible = false;
                txtName.BorderColor = Color.Green;
            }
            if (string.IsNullOrEmpty(txtUser.Texts))
            {
                txtUser.BorderColor = Color.Red;
                label11.Text = "Không được bỏ trống tên đăng nhập";
                label11.Visible = true;
            }
            else if (checkUser)
            {
                txtUser.BorderColor = Color.Red;
                label11.Text = "Tên đăng nhập đã bị trùng";
                label11.Visible = true;
            }
            else
            {
                label11.Visible = false;
                txtUser.BorderColor = Color.Green;
            }
            if (string.IsNullOrEmpty(txtPass.Texts))
            {
                txtPass.BorderColor = Color.Red;
                label10.Text = "Không được để trống mật khẩu";
                label10.Visible = true;
            }
            else {
                label5.Visible = false;
                txtPass.BorderColor = Color.Green;
                if (!checkRePass)
                {
                    txtRePass.BorderColor = Color.Red;
                    label13.Text = "Không trùng khớp";
                    label13.Visible = true;
                }
                else
                {
                    label13.Visible = false;
                    txtRePass.BorderColor = Color.Green;
                }
            }



            //Ở đây
            if (checkName && checkRePass && checkUser && !string.IsNullOrEmpty(txtPass.Texts))
            {

                tkdao.AddAccount(soLuongTaiKhoan.ToString(),txtUser.Texts, txtRePass.Texts);
                DateTime dt = dateTimePicker1.Value;
                string ngaySinh = dt.ToString();

                tkdao.AddCustomer(soLuongTaiKhoan, txtName.Texts, txtPhone.Texts, txtEmail.Texts, ngaySinh, comboBox1.SelectedItem.ToString());
                MessageBox.Show("Thêm Thành công");   
                Login frm = new Login();
                frm.Visible = true;
            }
        }

        //Viết thêm vô database
        public void InsertDataBase()
        {
            
        }

        private void txtUser_TextboxChanged(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ được nhập vào
            }
            // Thêm các xử lý khác nếu cần
            txtUser.BorderColor = Color.Green;
        }


        private void txtName_TextboxChanged(object sender, EventArgs e)
        {
            txtName.BorderColor = Color.Green;
            label5.Visible = false;
        }

        private void txtUser_TextboxChanged(object sender, EventArgs e)
        {
            txtUser.BorderColor = Color.Green;
            label11.Visible = false;
        }

        private void txtPass_TextboxChanged(object sender, EventArgs e)
        {
            txtPass.BorderColor = Color.Green;
            label10.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login frm = new Login();    
            frm.Visible = true;
            Close();
        }
    }
}