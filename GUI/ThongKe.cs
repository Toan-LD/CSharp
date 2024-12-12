using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Doanqlchdt.DTO;
using Doanqlchdt.BUS;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Doanqlchdt.DAO;
using System.Data.SqlClient;

namespace Doanqlchdt.GUI
{
    public partial class ThongKe : Form
    {
        ThongKeBUS thongKeBUS = new ThongKeBUS();

        private string namLoc;

        public ThongKe()
        {
            InitializeComponent();
            ShowQuantity();
            loadCombobox();
            chartPie.Titles.Add("Pie Chart");
        }

        /*public void loadChartPie(string year)
        {

            chartPie.Series["s1"].Points.Clear();

            int tongTienNhap = thongKeBUS.LayTongTienNhapTheoNam(namLoc);
            int tongTienBan = thongKeBUS.LayTongTienBanTheoNam(namLoc);
            double tiLeTienNhap = (tongTienNhap * 100) / (tongTienNhap + tongTienBan);
            double tiLeTienBan = 100 - tiLeTienNhap;
            chartPie.Series["s1"].Points.AddXY(tiLeTienBan + "%", tiLeTienBan);
            chartPie.Series["s1"].Points.AddXY(tiLeTienNhap + "%", tiLeTienNhap);
        }*/

        public void loadChartPie(string year)
        {
            chartPie.Series["s1"].Points.Clear();

            int tongTienNhap = thongKeBUS.LayTongTienNhapTheoNam(year);
            int tongTienBan = thongKeBUS.LayTongTienBanTheoNam(year);
            double total = tongTienNhap + tongTienBan;

            if (total > 0)
            {
                double tiLeTienNhap = (tongTienNhap * 100) / total;
                double tiLeTienBan = (tongTienBan * 100) / total;

                chartPie.Series["s1"].Points.AddXY("Tiền Nhập" + tiLeTienNhap, tiLeTienNhap);
                chartPie.Series["s1"].Points.AddXY("Tiền Bán" + tiLeTienBan, tiLeTienBan);
            }
            else
            {
                // Không có dữ liệu để hiển thị trên biểu đồ tròn
                MessageBox.Show("Không có dữ liệu để hiển thị.");
            }
        }

        public void loadCombobox()
        {
            ArrayList arrayList = thongKeBUS.GetDSNam();

            cbbYear.Items.Clear();
            cbbYear.Items.AddRange(arrayList.ToArray());
            cbbYear.SelectedIndex = 0;

            namLoc = cbbYear.SelectedItem.ToString();
            fillChart(namLoc);
            loadChartPie(namLoc);
        }

        public void ShowQuantity()
        {
            ArrayList hoaDonBan = new ArrayList();
            hoaDonBan = thongKeBUS.GetSoLuongHoaDonBan();
            int soLuongDonHang = hoaDonBan.Count;

            ArrayList khachHang = new ArrayList();
            khachHang = thongKeBUS.GetSoLuongKhachHang();
            int soLuongKhachHang = khachHang.Count;

            int soLuongBan = thongKeBUS.SoLuongSanPhamBan();

            int tongTienBan = thongKeBUS.TongTienBan();

            lbDonHang.Text = soLuongDonHang.ToString();
            lbKhachHang.Text = soLuongKhachHang.ToString();
            lbSoLuongBan.Text = soLuongBan.ToString();  
            lbTong.Text = tongTienBan.ToString("N0") + " VND";
        }

        public void fillChart(string year)
        {
            try
            {
                var dataTable = thongKeBUS.LayTongTienTheoNam(year);
                var dataTable1 = thongKeBUS.LayTongTienTheoThangNam1(year);

                // Combine data from both DataTables into a single DataTable
                DataTable combinedTable = new DataTable();
                combinedTable.Columns.Add("ThangNam", typeof(string));
                combinedTable.Columns.Add("TongTienNhap", typeof(int));
                combinedTable.Columns.Add("TongTienBan", typeof(int));

                foreach (DataRow row in dataTable.Rows)
                {
                    combinedTable.Rows.Add($"{row["Thang"]}/{row["Nam"]}", row["TongTienThang"], 0);
                }

                foreach (DataRow row in dataTable1.Rows)
                {
                    string thangNam = $"{row["Thang"]}/{row["Nam"]}";
                    DataRow existingRow = combinedTable.Select($"ThangNam = '{thangNam}'").FirstOrDefault();
                    if (existingRow != null)
                    {
                        existingRow["TongTienBan"] = row["TongTienThang"];
                    }
                    else
                    {
                        combinedTable.Rows.Add(thangNam, 0, row["TongTienThang"]);
                    }
                }

                chartBan.DataSource = combinedTable;

                chartBan.Series["Tổng tiền nhập"].XValueMember = "ThangNam";
                chartBan.Series["Tổng tiền nhập"].YValueMembers = "TongTienNhap";
                chartBan.Series["Tổng tiền bán"].XValueMember = "ThangNam";
                chartBan.Series["Tổng tiền bán"].YValueMembers = "TongTienBan";

                chartBan.DataBind();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi điền dữ liệu vào biểu đồ: " + ex.Message);
            }
        }

        /* public void fillChart1(string year)
         {

             try
             {
                 var dataTable = thongKeBUS.LayTongTienTheoNam(year);

                 chartBan.DataSource = dataTable;



                 chartBan.Series["Tổng tiền nhập"].XValueMember = "ThangNam";
                 chartBan.Series["Tổng tiền nhập"].YValueMembers = "TongTienThang";
                 chartBan.Series["Tổng tiền bán"].XValueMember = "ThangNam";
                 chartBan.Series["Tổng tiền bán"].YValueMembers = "TongTienThang";

                 chartBan.DataBind();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Lỗi khi điền dữ liệu vào biểu đồ: " + ex.Message);
             }
         }*/

        private void btnLocNam_Click(object sender, EventArgs e)
        {
            if(cbbYear.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn năm để lọc dữ liệu!!!");
            } 
            else
            {
                namLoc = cbbYear.SelectedItem.ToString();
                fillChart(namLoc);
                loadChartPie(namLoc);

            }
        }

        private void chartPie_Click(object sender, EventArgs e)
        {

        }

        private void ThongKe_Load(object sender, EventArgs e)
        {

        }

        private void chartBan_Click(object sender, EventArgs e)
        {

        }
    }
}
