using Doanqlchdt.Cart;
using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections.Generic;

using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class UserGui : Form
    {
        private CartBean shop;
        private khachhangdto kh;
        private double TongTien = 0;
        private XemLichSu check;
        private DoiThongTinKH change;
        private ChangePassword changePW;
        public UserGui(khachhangdto kh)
        {
            InitializeComponent();
            InitializeImageList();
            listView2.SelectedIndexChanged += listView2_SelectedIndexChanged;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.RowsAdded += dataGridView1_RowsAdded;
            dataGridView1.RowsRemoved += dataGridView1_RowsRemoved;
            lbName.Text = "Xin chào, " + kh.Hoten;
            button3.Enabled = false;
            this.kh = kh;
            lbSum.Text = TongTien.ToString() + " vnđ";
        }

        public void updateMoney()
        {
            if (shop != null)
            {
                this.TongTien = 0;
                foreach (var item in shop.Values)
                {
                    this.TongTien += item.Quantity * item.Sanpham.Giaban;
                }
            }
            lbSum.Text = TongTien.ToString("#,##0") + " vnđ";
        }

        public void InitializeImageList()
        {
            List<sanphamdto> list = new sanphamdao().getds();
            update(list);
            cbChoise.SelectedIndex = 0;
        }

        public void update(List<sanphamdto> list)
        {
            listView2.Clear();
            foreach (sanphamdto sp in list)
            {
                String tenSP = sp.Tensp;
                String gia = sp.Giaban.ToString("#,##0");
                byte[] imageData = sp.Hinhanh;
                string maSP = sp.Masp;
                Image img = ByteArrayToImage(imageData);
                ListViewItem item = new ListViewItem();
                item.Name = maSP;
                item.Text = tenSP + "\n" + "Giá bán: " + gia + " vnđ";
                item.ImageIndex = ImagesList.Images.Count; // Sử dụng index của hình ảnh trong ImageList
                listView2.Items.Add(item);
                ImagesList.Images.Add(img);
            }
            listView2.LargeImageList = ImagesList;
        }




        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                // Lấy ListViewItem được chọn
                ListViewItem selectedItem = listView2.SelectedItems[0];

                // Lấy thông tin từ ListViewItem
                sanphamdto sp = new sanphamdao().findByID(selectedItem.Name);
                // Hiển thị thông tin trong TextBox
                lbMaSP.Text = sp.Masp;
                txtName.Text = sp.Tensp;
                txtPrice.Text = sp.Giaban.ToString("#,##0") + " vnđ";
                txtStyle.Text = sp.Maloai;
                txtInfor.Text = sp.Mota;
                txtQuan.Text = sp.Soluong.ToString();
                if (sp.Soluong > 0)
                {
                    txtStatus.Text = "Còn hàng";
                    btAddCart.Enabled = true;
                }
                else
                {
                    txtStatus.Text = "Mặt hàng đã hết";
                    btAddCart.Enabled = false;
                }
                if (shop != null && shop.checkCart(sp.Masp))
                {
                    if (sp.Soluong == shop[sp.Masp].Quantity) btAddCart.Enabled = false;
                    else btAddCart.Enabled = true;
                }
                // Hiển thị hình ảnh trong PictureBox
                if (selectedItem.ImageIndex >= 0 && selectedItem.ImageIndex < ImagesList.Images.Count)
                {
                    Image selectedImage = ImagesList.Images[selectedItem.ImageIndex];
                    picItem.Image = selectedImage;
                }
            }
        }




        private Image ByteArrayToImage(byte[] byteArrayIn)
        {
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArrayIn))
            {
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string condition = txtSearch.Text;
            string dk = cbChoise.SelectedItem.ToString();
            string dau = null;
            string price = null;
            if (string.Equals(dk, "--Tất cả--"))
            {
                price = "0";
                dau = ">";
            }
            else if (string.Equals(dk, "--dưới 5.000.000đ--"))
            {
                price = "5000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--dưới 10.000.000đ--"))
            {
                price = "10000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--dưới 20.000.000đ--"))
            {
                price = "20000000";
                dau = "<";
            }
            else if (string.Equals(dk, "--trên 20.000.000đ--"))
            {
                price = "20000000";
                dau = ">";
            }
            List<sanphamdto> list = new sanphamdao().findByCondition(condition, price, dau);
            update(list);
        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            reset();
        }

        public void reset()
        {
            txtName.Text = "";
            txtPrice.Text = "";
            txtQuan.Text = "";
            txtStatus.Text = "";
            txtInfor.Text = "";
            lbMaSP.Text = null;
            txtStyle.Text = "";
            picItem.Image = null;
        }

        private void btAddCart_Click(object sender, EventArgs e)
        {
            if (shop == null)
            {
                shop = new CartBean();
            }
            if (lbMaSP.Text != "")
            {
                sanphamdto sp = new sanphamdao().findByID(lbMaSP.Text);
                addToCart product = new addToCart(sp);
                shop.addSanPham(product);
                if (shop[lbMaSP.Text].Quantity == sp.Soluong) btAddCart.Enabled = false;
                UpdateDataGridView();
                updateMoney();
            }
            else MessageBox.Show("Vui lòng chọn sản phẩm");
            button3.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xác định cột "Tăng"
            int tangColumnIndex = dataGridView1.Columns["btTang"].Index;

            // Xác định cột "Giảm"
            int giamColumnIndex = dataGridView1.Columns["btGiam"].Index;

            // Kiểm tra nếu người dùng nhấn vào cột "Tăng"
            if (e.ColumnIndex == tangColumnIndex)
            {
                // Thực hiện chức năng tăng số lượng
                // Lấy giá trị hiện tại từ ô "Tên SP" trong hàng đã nhấn nút
                string maSP = dataGridView1.Rows[e.RowIndex].Cells["maSP"].Value.ToString();

                // Thực hiện tăng số lượng trong Cart 
                if (shop.ContainsKey(maSP))
                {
                    sanphamdto sp = new sanphamdao().findByID(maSP);
                    if (shop[maSP].Quantity < sp.Soluong) shop[maSP].Quantity++;
                    else MessageBox.Show("Quá số lượng mặt hàng có trong kho");
                }

                // Cập nhật lại DataGridView
                UpdateDataGridView();
                updateMoney();
            }

            // Kiểm tra nếu người dùng nhấn vào cột "Giảm"
            else if (e.ColumnIndex == giamColumnIndex)
            {
                // Thực hiện chức năng giảm số lượng
                // Lấy giá trị hiện tại từ ô "Tên SP" trong hàng đã nhấn nút
                string maSP = dataGridView1.Rows[e.RowIndex].Cells["maSP"].Value.ToString();

                // Thực hiện giảm số lượng trong Cart (giả sử shop là đối tượng Cart của bạn)
                if (shop.ContainsKey(maSP) && shop[maSP].Quantity > 0)
                {
                    shop[maSP].Quantity--;
                }
                sanphamdto sp = new sanphamdao().findByID(maSP);
                if (shop[maSP].Quantity < sp.Soluong)
                {
                    btAddCart.Enabled = true;
                    reset();
                }
                if (shop[maSP].Quantity == 0) shop.removeSanPham(maSP);

                // Cập nhật lại DataGridView
                UpdateDataGridView();
                updateMoney();
            }
        }

        public void UpdateDataGridView()
        {
            // Xóa dữ liệu hiện tại trong DataGridView
            dataGridView1.Rows.Clear();
            foreach (var item in shop.Values)
            {

                int rowIndex = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIndex].Cells["maSP"].Value = item.Sanpham.Masp;
                dataGridView1.Rows[rowIndex].Cells["txtNameCart"].Value = item.Sanpham.Tensp;
                string a = item.Sanpham.Giaban.ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["txtGia"].Value = a;
                dataGridView1.Rows[rowIndex].Cells["txtQuantity"].Value = item.Quantity;
                string Tong = (item.Quantity * item.Sanpham.Giaban).ToString("#,##0");
                dataGridView1.Rows[rowIndex].Cells["txtSum"].Value = Tong;
                dataGridView1.Rows[rowIndex].Cells["btTang"].Value = "+";
                dataGridView1.Rows[rowIndex].Cells["btGiam"].Value = "-";
            }
        }

        private void UpdateButtonState()
        {
            // Kiểm tra xem TextBox có giá trị null hoặc rỗng không
            bool isTextBoxNullOrEmpty = dataGridView1.RowCount > 0;

            // Cập nhật trạng thái của nút dựa trên điều kiện
            button3.Enabled = isTextBoxNullOrEmpty;
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateButtonState();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateButtonState();
        }


        private void label14_Click(object sender, EventArgs e)
        {
            if (change == null || change.IsDisposed)
            {
                change = new DoiThongTinKH(kh);
                change.Show();
            }
            else
            {
                change.BringToFront();
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            if (changePW == null || changePW.IsDisposed)
            {
                changePW = new ChangePassword(kh);
                changePW.Show();
            }
            else
            {
                changePW.BringToFront();
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            shop = new CartBean();
            UpdateDataGridView();
            button3.Enabled = true;
            txtSale.Text = null;
            UpdateButtonState();
            lbSum.Text = "0vnđ";
            txtSale.ReadOnly = false;
        }

        private void btAccept_Click_1(object sender, EventArgs e)
        {
            if (shop != null)
            {
                int stt = new hoadonbandao().getSTT();
                try
                {
                    if (new hoadonbandao().insert(shop, stt, kh.Mkh, txtSale.Text, TongTien))
                    {
                        if (new sanphamdao().updateQuantity(shop))
                        {

                            MessageBox.Show("Đặt đơn hàng thành công\nChú ý:Trong thời hạn 1 ngày có thể hủy đơn!!!");
                            if (!string.IsNullOrEmpty(txtSale.Text)) new khuyenmaidao().updateTrangthai(kh.Mkh, txtSale.Text);
                            lbSum.Text = "";
                            txtSale.Text = "";
                            txtSale.ReadOnly = false;
                        }
                    }
                    else MessageBox.Show("Giỏ hàng rỗng");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                shop = new CartBean();
                UpdateDataGridView();
                reset();
            }
            else MessageBox.Show("Chưa có sản phẩm trong giỏ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSale.Text))
            {
                if (new khuyenmaidao().checkKM(kh.Mkh, txtSale.Text))
                {
                    lbSum.Text = (TongTien *(1- new khuyenmaidao().getTiLe(txtSale.Text))).ToString("#,##0") + "vnđ";
                    TongTien *= 1-new khuyenmaidao().getTiLe(txtSale.Text);
                    MessageBox.Show("Áp dụng mã thành công");
                    button3.Enabled = false;
                    txtSale.ReadOnly = true;
                }
                else MessageBox.Show("Bạn đã sử dụng mã này hoặc mã không tồn tại !!! ");
            }
            else MessageBox.Show("Hãy điền mà khuyến mãi");
        }

        private void label15_Click(object sender, EventArgs e)
        {
            if (check == null || check.IsDisposed)
            {
                check = new XemLichSu(kh);
                check.Show();
            }
            else
            {
                check.BringToFront();
            }

        }

    }
}

