using Doanqlchdt.BUS;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class TaiKhoanNhanVien : Form
    {

        TaiKhoanNhanVienBUS taiKhoanNhanVienBUS = new TaiKhoanNhanVienBUS();
        taikhoandto account = new taikhoandto();

        public TaiKhoanNhanVien()
        {
            InitializeComponent();
            ColumnListView();
            LoadListView();
        }

        private void cbPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPsw.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
                txtNhapLai.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
                txtNhapLai.UseSystemPasswordChar = true;
            }
        }

        private void TaiKhoanNhanVien_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            txtNhapLai.UseSystemPasswordChar = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "" || txtNhapLai.Text == "")
            {
                MessageBox.Show("Vui lòng không được để trống");
                if (txtTaiKhoan.Text == "")
                {
                    txtTaiKhoan.Focus();
                }
                else if (txtMatKhau.Text == "")
                {
                    txtMatKhau.Focus();
                } 
                else if (txtNhapLai.Text == "")
                {
                    txtNhapLai.Focus();
                }

            }
            else
            {
                string taiKhoan = txtTaiKhoan.Text;
                string matKhau = txtMatKhau.Text;
                string nhapLai = txtNhapLai.Text;

                ArrayList userNameCheck = new ArrayList();
                userNameCheck.AddRange(taiKhoanNhanVienBUS.GetDSUsername());

                //flag = false ở đây kiểm tra xem là tài khoản đã tồn tại hay là chưa nếu là false thì là chưa
                bool flag = false;

                foreach (string user in userNameCheck)
                {
                    if (taiKhoan == user)
                    {
                        flag = true;
                    }

                }
                if (flag == false)
                {
                    if (matKhau != nhapLai)
                    {
                        MessageBox.Show("Mật khẩu không khớp!");
                        txtNhapLai.Focus();
                    }
                    else
                    {
                        int UserID = taiKhoanNhanVienBUS.GetDSUserID().Count + 1;

                        account.Username = taiKhoan;
                        account.Password = matKhau;
                        account.Quyen = 2;
                        account.Trangthai = 0;


                        try
                        {
                            taiKhoanNhanVienBUS.AddAccount(account, UserID);
                            MessageBox.Show("Thêm tài khoản nhân viên thành công!");
                            LoadListView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                else if (flag == true)
                {
                    MessageBox.Show("Tài Khoản Đã Tồn Tại. Xin Vui Lòng Nhập Tên Tài Khoản Mới");
                }
            }
        }

        public void ColumnListView()
        {
            listView1.View = View.Details;
            listView1.Columns.Add("UserName", 100);
            listView1.Columns.Add("Password", 100);
            listView1.Columns.Add("Quyen", 100);
            listView1.Columns.Add("TrangThai", 100);
        }

        public void LoadListView()
        {
            listView1.Items.Clear();
            foreach (taikhoandto account in taiKhoanNhanVienBUS.GetDSTaiKhoan())
            {
                string[] row = { account.Username, account.Password, account.Quyen.ToString(), account.Trangthai.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }
        }
    }
}
