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
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Doanqlchdt.GUI
{
    public partial class NhanVien : Form
    {
        static nhanvienbus employeeBUS = new nhanvienbus();
        nhanviendto employeeDTO = new nhanviendto();
        List<nhanviendto> employees = employeeBUS.GetNhanVien();

        public NhanVien()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            ColumnListView();
            LoadDataToGUI();
        }
        private void LoadDataToGUI()
        {
            listView1.Items.Clear();
            foreach (nhanviendto employee in employees)
            {
                string[] row = { employee.MaNV, employee.HoTen, employee.SDT, employee.Email, employee.GioiTinh ,employee.TrangThai.ToString(), employee.NgaySinh.ToString(), employee.MaTK.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void ColumnListView()
        {
            listView1.FullRowSelect = true;
            listView1.View = View.Details; // Đảm bảo rằng ListView sẽ hiển thị dưới dạng Details
            listView1.Columns.Add("Mã NV", 100, HorizontalAlignment.Left); // Thêm các cột vào ListView
            listView1.Columns.Add("Họ Tên", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Số Điện Thoại", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Email", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Giới Tính", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Trạng Thái", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày Sinh", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã Tài Khoản", 100, HorizontalAlignment.Left);
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    string selectedMaNV = listView1.SelectedItems[0].SubItems[0].Text;
                    // Tìm kiếm thông tin nhân viên theo mã
                    nhanviendto selectedEmployee = employees.FirstOrDefault(employee => employee.MaNV == selectedMaNV);
                    if (selectedEmployee != null)
                    {
                        // Truyền thông tin nhân viên được chọn qua form sửa nhân viên
                        SuaNhanVien suaNhanVienForm = new SuaNhanVien(selectedEmployee);
                        suaNhanVienForm.StartPosition = FormStartPosition.CenterParent;
                        suaNhanVienForm.ShowDialog();
                        // Tự động làm mới dữ liệu sau khi cập nhật                              
                        employees = employeeBUS.GetNhanVien();
                        LoadDataToGUI();
                    }
                }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(cbbLuaChon.SelectedItem == null)
            {
                MessageBox.Show("Chọn giá trị để tìm kiếm!");
            } 
            else if(cbbLuaChon.SelectedItem.ToString() == "Mã NV")
            {
                employeeDTO.MaNV = txtTimKiem.Text;
                string keyWord = employeeDTO.MaNV.ToString();  
                try
                {
                    ArrayList result = employeeBUS.SearchEmployeeByID(keyWord);
                    LoadDataToGUI(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
                }
            }
            else if (cbbLuaChon.SelectedItem.ToString() == "Họ Tên")
            {
                employeeDTO.MaNV = txtTimKiem.Text;
                string keyWord = employeeDTO.MaNV.ToString();
                try
                {
                    ArrayList result = employeeBUS.SearchEmployeeByName(keyWord);
                    LoadDataToGUI(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
                }
            }
            else if (cbbLuaChon.SelectedItem.ToString() == "SĐT")
            {
                employeeDTO.MaNV = txtTimKiem.Text;
                string keyWord = employeeDTO.MaNV.ToString();
                try
                {
                    ArrayList result = employeeBUS.SearchEmployeeByPhoneNumber(keyWord);
                    LoadDataToGUI(result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra trong quá trình tìm kiếm: " + ex.Message);
                }
            }
        }

        private void LoadDataToGUI(ArrayList result)
        {
            
            listView1.Items.Clear();
            foreach (nhanviendto employee in result)
            {
                string[] row = { employee.MaNV, employee.HoTen, employee.SDT, employee.Email, employee.GioiTinh, employee.TrangThai.ToString(), employee.NgaySinh.ToString(), employee.MaTK.ToString() };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemNhanVien themNhanVien = new ThemNhanVien(); 
            themNhanVien.StartPosition = FormStartPosition.CenterParent;
            themNhanVien.ShowDialog();

            employees = employeeBUS.GetNhanVien();
            LoadDataToGUI();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
