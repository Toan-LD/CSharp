using Doanqlchdt.DTO;
using Doanqlchdt.BUS;
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
using Doanqlchdt.GUI.Messageboxshow;
using System.Text.RegularExpressions;

namespace Doanqlchdt.GUI
{
    public partial class KhuyenMai : Form
    {
        static khuyenmaibus khuyenMaibus = new khuyenmaibus();
        khuyenmaidto kmdto = new khuyenmaidto();
        khuyenmaibus kmbus = new khuyenmaibus();
        ArrayList arrayKM = new ArrayList();
        public KhuyenMai()
        {
            InitializeComponent();
            ColumnListView();
            LoadDataToGUI();
        }

        private void ColumnListView()
        {
            listView1.FullRowSelect = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Mã KM", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Tỉ Lệ", 100, HorizontalAlignment.Left);
        }

        private void LoadDataToGUI()
        {
            listView1.Items.Clear();
            arrayKM = khuyenMaibus.GetKM();
            foreach (khuyenmaidto km in arrayKM)
            {
                string tileAsString = km.Tile.ToString(); // Chuyển đổi km.Tile thành chuỗi
                string[] row = { km.MaKM, tileAsString };
                listView1.Items.Add(new ListViewItem(row));
            }
        }

        private void KhuyenMai_Load(object sender, EventArgs e)
        {
            arrayKM.Add(khuyenMaibus.GetKM());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtMaKhuyenMai.Text == "" || txtTiLe.Text == "")
            {
                Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Nhập Đầy Đủ");
                comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                comfrimupdate.ShowDialog();
            }
            else { 
                if(txtMaKhuyenMai.Text == "")
                {
                    Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Nhập Mã Khuyến Mãi");
                    comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                    comfrimupdate.ShowDialog();
                    txtMaKhuyenMai.Focus();
                }
                else if(txtTiLe.Text == "")
                {
                    Comfrimupdate comfrimupdate = new Comfrimupdate("Vui Lòng Nhập Đầy Đủ");
                    comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                    comfrimupdate.ShowDialog();
                    txtTiLe.Focus();    
                }
                else
                {
                    string maKM = txtMaKhuyenMai.Text.Trim();
                    if(kmbus.GetMaKM(maKM))
                    {
                        Comfrimupdate comfrimupdate = new Comfrimupdate("Mã Khuyến Mãi Đã Tồn Tại");
                        comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                        comfrimupdate.ShowDialog();
                        txtMaKhuyenMai.Focus();
                    }
                    else
                    {
                        if(Convert.ToDouble(txtTiLe.Text) > 1 || Convert.ToDouble(txtTiLe.Text) <0)
                        {
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Tỉ Lệ Sai");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                            txtTiLe.Focus();

                        }
                        else 
                        {
                            kmbus.AddMaKM(txtMaKhuyenMai.Text, Convert.ToDouble(txtTiLe.Text));
                            Comfrimupdate comfrimupdate = new Comfrimupdate("Thêm Thành Công");
                            comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                            comfrimupdate.ShowDialog();
                            txtMaKhuyenMai.Focus();
                            LoadDataToGUI();
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];

                txtMaKM.Text = selectedItem.SubItems[0].Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtMaKM.Text == "")
            {
                Comfrimupdate comfrimupdate = new Comfrimupdate("Hãy Chọn Mã Khuyến Mãi Để Xóa");
                comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                comfrimupdate.ShowDialog();
            }
            else
            {
                YesOrNo yesOrNo = new YesOrNo("Bạn có muốn xóa không ?");
                yesOrNo.StartPosition = FormStartPosition.CenterScreen;
                yesOrNo.ShowDialog();

                if(yesOrNo.Comfirm == true)
                {
                    kmbus.DeleteMaKM(txtMaKM.Text);
                    Comfrimupdate comfrimupdate = new Comfrimupdate("Xóa Thành Công");
                    comfrimupdate.StartPosition = FormStartPosition.CenterScreen;
                    comfrimupdate.ShowDialog();
                    LoadDataToGUI();
                }
            }
        }
    }
}
