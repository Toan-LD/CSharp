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
    public partial class ChiTiet : Form
    {
        private string maHD;
        public ChiTiet(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
            UpdateDataGridView();
        }

        public void UpdateDataGridView()
        {
            double Tong = 0;
            double tienThu = 0;
            foreach (var item in new chitietdonbandao().findByCondition(maHD))
            {
                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["tensp"].Value = item.Tensp;
                string a = item.Dongia.ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["gia"].Value = a;
                dataGridView1.Rows[rowIndex].Cells["soluong"].Value = item.Soluong;
                dataGridView1.Rows[rowIndex].Cells["tong"].Value = item.Tongtien.ToString("#,##0");
                Tong += item.Tongtien;
                lbDate.Text = item.Ngay.ToString("dd/MM/yyyy HH:mm:ss");
                label5.Text = item.MaKM1;
                tienThu = item.Tong1;
            }
            label7.Text = Tong.ToString("#,##0")+"vnđ";
            label8.Text =(tienThu-Tong).ToString("#,##0") + "vnđ";
            label3.Text = tienThu.ToString("#,##0") + "vnđ";
        }

    }
}
