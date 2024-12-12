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
    public partial class XemLichSu : Form
    {
        khachhangdto kh = new khachhangdto();
        public XemLichSu(khachhangdto kh)
        {
            InitializeComponent();
            this.kh = kh;
            UpdateDataGridView();
            dataGridView1.CellClick += dataGridView1_CellClickCheck;
            dataGridView1.CellClick += dataGridView1_CellClickDelete;
        }


        public void UpdateDataGridView()
        {
            dataGridView1.Rows.Clear();
            foreach (var item in new hoadonbandao().findByCondition(kh.Mkh))
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["maHD"].Value = item.Mhdb;
                string a = item.Tongtien.ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["Sum"].Value = a;
                dataGridView1.Rows[rowIndex].Cells["date"].Value = item.Ngaytao.ToString("dd/MM/yyyy hh:mm:ss");
                if (item.Trangthai == 0)
                {
                    dataGridView1.Rows[rowIndex].Cells["trangthai"].Value = "Chưa thanh toán";
                    dataGridView1.Rows[rowIndex].Cells["huy"].Value = "Hủy";
                }
                else
                {
                    dataGridView1.Rows[rowIndex].Cells["trangthai"].Value = "Đã thanh toán";
                    dataGridView1.Rows[rowIndex].Cells["huy"].Value = "x";
                }
                dataGridView1.Rows[rowIndex].Cells["check"].Value = "Xem";
            }
        }

        private void dataGridView1_CellClickDelete(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["huy"].Index)
            {
                string trangThai = dataGridView1.Rows[e.RowIndex].Cells["trangthai"].Value.ToString();

                // Kiểm tra trạng thái
                if (trangThai == "Chưa thanh toán")
                {
                    string mahd = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                    DateTime ngaytao = new hoadonbanbus().getNgayTao(mahd);
                    if (CheckNgay(ngaytao))
                    {
                        List<sanphamdto> list = new hoadonbandao().huyDonHang(mahd);
                        foreach (var item in list)
                        {
                            new sanphamdao().updateQuantity(item.Masp, item.Soluong);
                        }
                        if (new hoadonbanbus().delete(mahd))
                        {
                            MessageBox.Show("Hủy đơn đặt hàng thành công");
                            UpdateDataGridView();
                        }
                    }
                    else MessageBox.Show("Đơn hàng của bàng không thể hủy vì đã quá ngày cho phép hủy đơn");
                }
                else
                {
                    MessageBox.Show("Không thể thực hiện hủy đơn hàng đã thanh toán.");
                }
            }
        }

        private void dataGridView1_CellClickCheck(object sender, DataGridViewCellEventArgs e)
        {

            int choise = dataGridView1.Columns["check"].Index;

            // Kiểm tra nếu người dùng nhấn vào cột "Tăng"
            if (e.ColumnIndex == choise && e.RowIndex >= 0)
            {
                string mahd = dataGridView1.Rows[e.RowIndex].Cells["maHD"].Value.ToString();
                ChiTiet form = new ChiTiet(mahd);
                form.Show();
            }
        }

        public bool CheckNgay(DateTime ngaytao)
        {

            DateTime currentDateTime = DateTime.Now;

            TimeSpan difference = currentDateTime - ngaytao;


            if (difference.TotalDays < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


