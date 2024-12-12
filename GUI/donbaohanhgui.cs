using Doanqlchdt.DTO;
using Doanqlchdt.GUI.Edit;
using Doanqlchdt.GUI.Thêm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI
{
    public partial class donbaohanhgui : Form
    {
        static donbaohanhbus bus=new donbaohanhbus();
        private Boolean timkiem = false;
        private Boolean sx = false;
        private Boolean temppage = true;
        private Boolean side = false;
        private int totalpage = 0;
        private static int record = 1;
        private static int temp = 1;
        private static int ofset = (temp - 1) * record;
        private String tenlcsx = "";
        private String loaisx = "";
        private String tempsx = "";
        private String temploaisx = "";

        private String ketquatim = "";
        private String ten = "";
        private int totalpageorder = 0;
        private static int recordorder = 1;
        private static int temporder = 1;
        private static int ofsetorder = (temporder - 1) * recordorder;
        private ArrayList ds = bus.getdsfrompage(ofset, record);
        private System.Windows.Forms.Button[] btnarray;
        private System.Windows.Forms.Button[] btnarrayod;
        public donbaohanhgui()
        {
            InitializeComponent();
            double totalpagetemp = (double)bus.getcount() / record;
            totalpage = (int)Math.Ceiling(totalpagetemp);
            btnarray = new System.Windows.Forms.Button[(int)(totalpage + 2)];
            comboBoxsx.SelectedIndex = 0;
            comboBoxsxlc.SelectedIndex = 0;
            comboboxtimkiem.SelectedIndex = 0;
            loadlistview();
            mousehover();
            loadtable();
            page();
        }
        ///////// bắt đầu code viết tay ////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // THAY ĐỔI  sự kiện load listview lên ghi header v.v.v
        public void loadlistview()
        {
            //listView1.Columns.Add("", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã DBH", 100, HorizontalAlignment.Left); // Thêm các cột vào ListView
            listView1.Columns.Add("Mã NV", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã KH", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã SP", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày Tạo", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Ngày trả", 150, HorizontalAlignment.Left);

            Graphics g = listView1.CreateGraphics();

            // Điều chỉnh kích thước cho từng cột header
            foreach (ColumnHeader colHeader in listView1.Columns)
            {
                colHeader.Width = TextRenderer.MeasureText(colHeader.Text, listView1.Font).Width + 100; // 10 làm margin
            }

            // Giải phóng đối tượng Graphics
            g.Dispose();
        }
        // THAY ĐỔI  sự kiện load table tất cả 
        public void loadtable()
        {
            setvisiblebutonpage(totalpageorder, btnarrayod);
            ofset = (temp - 1) * record;
            ds.Clear();
            if (sx == false)
            {
                ds = bus.getdsfrompage(ofset, record);
            }
            else
            {
                ds = bus.getdspagesx(tenlcsx, loaisx, ofset, record);
            }
            listView1.Items.Clear();
            foreach (donbaohanhdto dbhdto in ds)
            {

                ListViewItem ls = new ListViewItem(dbhdto.Madonbaohanh);
                ls.SubItems.Add(dbhdto.Manv);
                ls.SubItems.Add(dbhdto.Makh);
                ls.SubItems.Add(dbhdto.Masp);
                ls.SubItems.Add(dbhdto.Ngaytao.ToString("dd/MM/yyyy"));
                ls.SubItems.Add(dbhdto.Ngaytra.ToString("dd/MM/yyyy"));
                listView1.Items.Add(ls);

            }

        }
        // THAY ĐỔI  sự kiện load danh sách từ database lên cho kiểu sắp xếp và tìm kiếm theo phân trang
        public void loadtableod(String ten, String Dieukiensx, String Loaisx, String dieukien)
        {
            ofsetorder = (temporder - 1) * recordorder;
            ds.Clear();
            ds = bus.getdspageoder(ten, dieukien, Dieukiensx, Loaisx, ofsetorder, recordorder);
            listView1.Items.Clear();
            foreach (donbaohanhdto dbhdto in ds)
            {

                ListViewItem ls = new ListViewItem(dbhdto.Madonbaohanh);
                ls.SubItems.Add(dbhdto.Manv);
                ls.SubItems.Add(dbhdto.Makh);
                ls.SubItems.Add(dbhdto.Masp);
                ls.SubItems.Add(dbhdto.Ngaytao.ToString("dd/MM/yyyy"));
                ls.SubItems.Add(dbhdto.Ngaytra.ToString("dd/MM/yyyy"));
                listView1.Items.Add(ls);

            }

        }
        // KHÔNG THAY ĐỔI sự kiện hover vào nút
        public void mousehover()
        {
            btnxem.MouseEnter += (sender, e) =>
            {
                btnxem.BackColor = Color.DodgerBlue;
                btnxem.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            btnxem.MouseLeave += (sender, e) =>
            {
                btnxem.BackColor = System.Drawing.SystemColors.Window;
                btnxem.ForeColor = System.Drawing.SystemColors.HotTrack;
            };
            buttonxoa.MouseEnter += (sender, e) =>
            {
                buttonxoa.BackColor = Color.OrangeRed;
                buttonxoa.ForeColor = System.Drawing.SystemColors.Window;
                // Đổi màu nền khi hover
            };
            buttonxoa.MouseLeave += (sender, e) =>
            {
                buttonxoa.BackColor = System.Drawing.SystemColors.Window;
                buttonxoa.ForeColor = Color.OrangeRed;
            };
        }
        //THAY ĐÔI phân trang listview cho tất cả
        public void page()
        {
            temppage = true;
            int kq = bus.getcount();
            int count = flowLayoutPanelpage.Controls.Count;
            if (kq > record)
            {
                flowLayoutPanelpage.Visible = true;
                for (int i = 1; i <= totalpage; i++)
                {

                    count = flowLayoutPanelpage.Controls.Count;
                    btnarray[i] = new System.Windows.Forms.Button();
                    btnarray[i].Text = i.ToString();
                    btnarray[i].Cursor = System.Windows.Forms.Cursors.Hand;
                    if (i == 1)
                    {
                        btnarray[i].BackColor = System.Drawing.Color.DodgerBlue;
                        btnarray[i].ForeColor = System.Drawing.SystemColors.Window;
                    }
                    else
                    {
                        btnarray[i].BackColor = System.Drawing.SystemColors.Window;
                        btnarray[i].ForeColor = System.Drawing.Color.DodgerBlue;
                    }
                    btnarray[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnarray[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    btnarray[i].Size = new System.Drawing.Size(40, 31);
                    btnarray[i].UseVisualStyleBackColor = false;
                    flowLayoutPanelpage.Controls.Add(btnarray[i]);
                    flowLayoutPanelpage.Controls.SetChildIndex(btnarray[i], count - 2);
                    btnarray[i].Visible = false;
                }
                for (int i = 1; i <= totalpage; i++)
                {
                    if (temp == totalpage)
                    {
                        if (i < temp + 2 && i > temp - 3)
                        {
                            btnarray[i].Visible = true;

                        }

                        btnarray[i].Click += btn_Click;
                    }
                    else
                    {
                        if (i < temp + 3 && i > temp - 2)
                        {
                            btnarray[i].Visible = true;

                        }

                        btnarray[i].Click += btn_Click;
                    }

                }
            }
        }
        //KHÔNG THAY ĐỔI sự kiện của các nút só thứ tự phân trang cho tất cả
        private void btn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

            temp = int.Parse(btn.Text);

            for (int i = 1; i <= totalpage; i++)
            {
                if (temp == 1)
                {
                    if (i < temp + 3 && i > temp - 2)
                    {
                        btnarray[i].Visible = true;
                    }
                    else
                    {
                        btnarray[i].Visible = false;
                    }
                }
                else if (temp == totalpage)
                {
                    if (i < temp + 2 && i > temp - 3)
                    {
                        btnarray[i].Visible = true;
                    }
                    else
                    {
                        btnarray[i].Visible = false;
                    }
                }
                else
                {
                    if (i < temp + 2 && i > temp - 2)
                    {
                        btnarray[i].Visible = true;
                    }
                    else
                    {
                        btnarray[i].Visible = false;
                    }
                }

            }
            System.Windows.Forms.Button click = sender as System.Windows.Forms.Button;
            for (int i = 1; i <= totalpage; i++)
            {
                if (click == btnarray[i])
                {
                    loadtable();
                    btnarray[i].BackColor = System.Drawing.Color.DodgerBlue;
                    btnarray[i].ForeColor = System.Drawing.SystemColors.Window;

                }
                else
                {
                    btnarray[i].BackColor = System.Drawing.SystemColors.Window;
                    btnarray[i].ForeColor = System.Drawing.Color.DodgerBlue;
                }
            }
        }
        //KHÔNG THAY ĐỔI set null cho các arraybutton
        public void setvisiblebutonpage(int total, System.Windows.Forms.Button[] array)
        {
            if (total > 0)
            {
                for (int i = 1; i <= total; i++)
                {
                    flowLayoutPanelpage.Controls.Remove(array[i]);
                    array[i] = null;
                }
            }

        }
        //THAY ĐỔI phân trang listview dành cho việc tìm kiếm và sắp xếp
        public void pageorder(String ten, String ketquatim, int tongpage)
        {
            temppage = false;
            int kq = bus.selectcountoder(ten, ketquatim);
            int count = flowLayoutPanelpage.Controls.Count;
            if (kq > recordorder)
            {
                flowLayoutPanelpage.Visible = true;
                for (int i = 1; i <= tongpage; i++)
                {

                    count = flowLayoutPanelpage.Controls.Count;
                    btnarrayod[i] = new System.Windows.Forms.Button();
                    btnarrayod[i].Text = i.ToString();
                    btnarrayod[i].Cursor = System.Windows.Forms.Cursors.Hand;
                    if (i == 1)
                    {
                        btnarrayod[i].BackColor = System.Drawing.Color.DodgerBlue;
                        btnarrayod[i].ForeColor = System.Drawing.SystemColors.Window;
                    }
                    else
                    {
                        btnarrayod[i].BackColor = System.Drawing.SystemColors.Window;
                        btnarrayod[i].ForeColor = System.Drawing.Color.DodgerBlue;
                    }
                    btnarrayod[i].FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    btnarrayod[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
                    btnarrayod[i].Size = new System.Drawing.Size(40, 31);
                    btnarrayod[i].UseVisualStyleBackColor = false;
                    flowLayoutPanelpage.Controls.Add(btnarrayod[i]);
                    flowLayoutPanelpage.Controls.SetChildIndex(btnarrayod[i], count - 2);
                    btnarrayod[i].Visible = false;
                }
                for (int i = 1; i <= tongpage; i++)
                {
                    if (temporder == tongpage)
                    {
                        if (i < temporder + 2 && i > temporder - 3)
                        {
                            btnarrayod[i].Visible = true;

                        }
                        btnarrayod[i].Click += btn_Clickod;
                    }
                    else
                    {
                        if (i < temporder + 3 && i > temporder - 2)
                        {
                            btnarrayod[i].Visible = true;

                        }
                        btnarrayod[i].Click += btn_Clickod;
                    }

                }
            }
            else
            {
                flowLayoutPanelpage.Visible = false;
            }
        }
        //KHÔNG THAY ĐỔI sự kiện của các nút só thứ tự phân trang cho việc tìm kiếm và sắp xếp
        private void btn_Clickod(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;

            temporder = int.Parse(btn.Text);

            for (int i = 1; i <= totalpageorder; i++)
            {
                if (temporder == 1)
                {
                    if (i < temporder + 3 && i > temporder - 2)
                    {
                        btnarrayod[i].Visible = true;
                    }
                    else
                    {
                        btnarrayod[i].Visible = false;
                    }
                }
                else if (temporder == totalpageorder)

                {
                    if (i < temporder + 2 && i > temporder - 3)
                    {
                        btnarrayod[i].Visible = true;
                    }
                    else
                    {
                        btnarrayod[i].Visible = false;
                    }

                }
                else
                {
                    if (i < temporder + 2 && i > temporder - 2)
                    {
                        btnarrayod[i].Visible = true;
                    }
                    else
                    {
                        btnarrayod[i].Visible = false;
                    }
                }

            }
            System.Windows.Forms.Button click = sender as System.Windows.Forms.Button;
            for (int i = 1; i <= totalpageorder; i++)
            {
                if (click == btnarrayod[i])
                {
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                    btnarrayod[i].BackColor = System.Drawing.Color.DodgerBlue;
                    btnarrayod[i].ForeColor = System.Drawing.SystemColors.Window;

                }
                else
                {
                    btnarrayod[i].BackColor = System.Drawing.SystemColors.Window;
                    btnarrayod[i].ForeColor = System.Drawing.Color.DodgerBlue;
                }
            }
        }
        //KHÔNG THAY ĐỔI focus vào button đang được chọn và đặt những button khác không được chọn là màu trắng
        public void designbutton(int a)
        {
            if (temppage == true)
            {
                for (int i = 1; i <= totalpage; i++)
                {
                    if (a == i)
                    {
                        btnarray[i].BackColor = System.Drawing.Color.DodgerBlue;
                        btnarray[i].ForeColor = System.Drawing.SystemColors.Window;

                    }
                    else
                    {
                        btnarray[i].BackColor = System.Drawing.SystemColors.Window;
                        btnarray[i].ForeColor = System.Drawing.Color.DodgerBlue;
                    }
                }

            }
            else
            {
                for (int i = 1; i <= totalpageorder; i++)
                {
                    if (a == i)
                    {
                        btnarrayod[i].BackColor = System.Drawing.Color.DodgerBlue;
                        btnarrayod[i].ForeColor = System.Drawing.SystemColors.Window;

                    }
                    else
                    {
                        btnarrayod[i].BackColor = System.Drawing.SystemColors.Window;
                        btnarrayod[i].ForeColor = System.Drawing.Color.DodgerBlue;
                    }
                }
            }

        }
        ////////// kết thúc phần code viết tay///////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////// bắt đầu code sự kiện của form tự tạo/////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //KHÔNG THAY ĐỔI vẽ cột header của listview
        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            Font HeaderFont = new Font("Arial", 12, FontStyle.Bold);
            Color customHeaderColor = Color.DodgerBlue;
            StringFormat sf = new StringFormat();
            SolidBrush brush = new SolidBrush(Color.White);
            using (Brush hrb = new SolidBrush(customHeaderColor))
            {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.FillRectangle(hrb, e.Bounds);
                e.Graphics.DrawString(e.Header.Text, HeaderFont, brush, e.Bounds, sf);

            }
        }
        // KHÔNG THAY ĐỔI vẽ subitem của listview
        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        //KHÔNG THAY ĐỔI vẽ item của listview
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }
        //THAY ĐỔI double click chuột vào bảng
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedMa = listView1.SelectedItems[0].SubItems[0].Text;
                donbaohanhdto dbhdto = null;
                sanphamdto spdto = null;
                foreach (donbaohanhdto donbhdto in ds)
                {
                    if (donbhdto.Madonbaohanh == selectedMa)
                    {
                        dbhdto = donbhdto;
                    }
                }
                if (dbhdto != null)
                {
                    // truyền thông tin nhân viên được chọn qua form sửa nhân viên
                    editdbh editdon=new editdbh(dbhdto);
                    editdon.StartPosition = FormStartPosition.CenterParent;
                    editdon.ShowDialog();
                    if (temppage == true)
                    {
                        loadtable();
                    }
                    else
                    {
                        loadtableod(ten, tempsx, temploaisx, ketquatim);
                    }
                }
            }
        }
        //KHÔNG THAY ĐỔI buton filter
        private void buttonfilter_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        //KHÔNG THAY ĐỔI timer side
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (side)
            {
                panelfilter.Height -= 10;
                if (panelfilter.Height == panelfilter.MinimumSize.Height)
                {
                    side = false;
                    timer1.Stop();
                }
            }
            else
            {
                panelfilter.Height += 10;
                if (panelfilter.Height == panelfilter.MaximumSize.Height)
                {
                    side = true;
                    timer1.Stop();
                }
            }
        }
        //KHÔNG THAY ĐỔI buton refresh
        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            sx = false;
            timkiem = false;
            temp = 1;
            loadtable();
            setvisiblebutonpage(totalpage, btnarray);
            page();
            textBoxtimkiem.Text = "";
            comboBoxsx.SelectedIndex = 0;
            comboBoxsxlc.SelectedIndex = 0;
            comboboxtimkiem.SelectedIndex = 0;
        }
        //THAY ĐỔI buton tìm kiếm
        private void buttontimkiem_Click(object sender, EventArgs e)
        {
            timkiem = true;
            temporder = 1;
            double totalpagetempoder = 0;
            ketquatim = textBoxtimkiem.Text;
            ketquatim.Trim();
            ten = "";
            setvisiblebutonpage(totalpage, btnarray);
            if (comboboxtimkiem.SelectedIndex == 0)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "MaDBH";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "MaDBH";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }

                pageorder(ten, ketquatim, totalpageorder);

            }
            else if (comboboxtimkiem.SelectedIndex == 1)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "MaNV";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "MaNV";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                pageorder(ten, ketquatim, totalpageorder);
            }
            else if (comboboxtimkiem.SelectedIndex == 2)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "MaKH";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "MaKH";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                pageorder(ten, ketquatim, totalpageorder);
            }
            else if (comboboxtimkiem.SelectedIndex == 3)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "MaSP";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "MaSP";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                pageorder(ten, ketquatim, totalpageorder);
            }
            else if (comboboxtimkiem.SelectedIndex == 4)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "NgayTao";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "NgayTao";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                pageorder(ten, ketquatim, totalpageorder);
            }
            else if (comboboxtimkiem.SelectedIndex == 5)
            {
                setvisiblebutonpage(totalpageorder, btnarrayod);
                ten = "NgayTra";
                int ketquacoutoder = 0;
                ketquacoutoder = bus.selectcountoder(ten, ketquatim);
                totalpagetempoder = (double)ketquacoutoder / recordorder;
                totalpageorder = (int)Math.Ceiling(totalpagetempoder);
                int count = flowLayoutPanelpage.Controls.Count;
                btnarrayod = new System.Windows.Forms.Button[(int)(totalpageorder + 2)];
                if (sx == true)
                {
                    tempsx = tenlcsx;
                    temploaisx = loaisx;
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                else
                {
                    tempsx = "NgayTra";
                    temploaisx = "ASC";
                    loadtableod(ten, tempsx, temploaisx, ketquatim);
                }
                pageorder(ten, ketquatim, totalpageorder);
            }
            

        }
        //KHÔNG THAY ĐỔI buton textbox tìm kiếm nhấn phím enter
        private void textBoxtimkiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttontimkiemm.PerformClick();
                e.Handled = true;
            }
        }
        //KHÔNG THAY ĐỔI combobox lựa chọn loại sắp xếp tăng dần hoặc giảm dần
        private void comboBoxloaisxtangdanhoacgiamdan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxsx.SelectedIndex == 0)
            {
                comboBoxsxlc.Visible = false;
            }
            else
            {
                comboBoxsxlc.Visible = true;
            }
        }
        //THAY ĐỔI buton sắp xếp
        private void btnxem_Click(object sender, EventArgs e)
        {
            temp = 1;
            temporder = 1;
            if (comboBoxsx.SelectedIndex == 0)
            {
                loadtable();
                setvisiblebutonpage(totalpage, btnarray);
                page();
            }
            else if (comboBoxsx.SelectedIndex == 1)
            {
                sx = true;
                //tăng dần
                if (comboBoxsxlc.SelectedIndex == 0)
                {
                    tenlcsx = "MaDBH";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);

                    }
                    //madbh

                }
                else if (comboBoxsxlc.SelectedIndex == 1)
                {
                    tenlcsx = "MaNV";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //manv
                }
                else if (comboBoxsxlc.SelectedIndex == 2)
                {
                    tenlcsx = "MaKH";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //makh
                }
                else if (comboBoxsxlc.SelectedIndex == 3)
                {
                    tenlcsx = "MaSP";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //masp
                }
                else if (comboBoxsxlc.SelectedIndex == 4)
                {
                    tenlcsx = "NgayTao";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //ngaytao
                }
                else if (comboBoxsxlc.SelectedIndex == 5)
                {
                    tenlcsx = "NgayTra";
                    loaisx = "ASC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //ngaytra
                }

            }
            else if (comboBoxsx.SelectedIndex == 2)
            {
                sx = true;
                // giảm dần
                if (comboBoxsxlc.SelectedIndex == 0)
                {
                    tenlcsx = "MaDBH";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);

                    }
                    //madbh

                }
                else if (comboBoxsxlc.SelectedIndex == 1)
                {
                    tenlcsx = "MaNV";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //manv
                }
                else if (comboBoxsxlc.SelectedIndex == 2)
                {
                    tenlcsx = "MaKH";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //makh
                }
                else if (comboBoxsxlc.SelectedIndex == 3)
                {
                    tenlcsx = "MaSP";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //masp
                }
                else if (comboBoxsxlc.SelectedIndex == 4)
                {
                    tenlcsx = "NgayTao";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //ngaytao
                }
                else if (comboBoxsxlc.SelectedIndex == 5)
                {
                    tenlcsx = "NgayTra";
                    loaisx = "DESC";
                    if (timkiem == false)
                    {
                        loadtable();
                        setvisiblebutonpage(totalpage, btnarray);
                        page();
                    }
                    else
                    {
                        tempsx = tenlcsx;
                        temploaisx = loaisx;
                        loadtableod(ten, tenlcsx, loaisx, ketquatim);
                        setvisiblebutonpage(totalpageorder, btnarrayod);
                        pageorder(ten, ketquatim, totalpageorder);
                    }
                    //ngaytra
                }
            }
        }
        //KHÔNG THAY ĐỔI buton trang đầu
        private void buttontrangdau_Click(object sender, EventArgs e)
        {
            if (temppage == true)
            {
                temp = 1;
                loadtable();
                setvisiblebutonpage(totalpage, btnarray);
                page();
            }
            else
            {
                temporder = 1;
                setvisiblebutonpage(totalpage, btnarray);
                loadtableod(ten, tempsx, temploaisx, ketquatim);
                setvisiblebutonpage(totalpageorder, btnarrayod);
                pageorder(ten, ketquatim, totalpageorder);
            }
        }
        //KHÔNG THAY ĐỔI buton previous
        private void buttonprevious_Click_1(object sender, EventArgs e)
        {
            if (temppage == true)
            {
                if (temp > 1)
                {
                    temp = temp - 1;
                    btnarray[temp].PerformClick();
                }
            }
            else
            {
                if (temporder > 1)
                {
                    temporder = temporder - 1;
                    btnarrayod[temporder].PerformClick();
                }
            }

        }
        //KHÔNG THAY ĐỔI buton next
        private void buttonnext_Click(object sender, EventArgs e)
        {
            if (temppage == true)
            {
                if (temp < totalpage)
                {
                    temp = temp + 1;
                    btnarray[temp].PerformClick();
                }
            }
            else
            {
                if (temporder < totalpageorder)
                {
                    temporder = temporder + 1;
                    btnarrayod[temporder].PerformClick();
                }
            }


        }
        //KHÔNG THAY ĐỔI buton trang cuối
        private void buttontrangcuoi_Click_2(object sender, EventArgs e)
        {
            int a = flowLayoutPanelpage.Controls.Count - 4;

            if (temppage == true)
            {
                temp = a;
                loadtable();
                setvisiblebutonpage(totalpage, btnarray);
                page();
                designbutton(a);
            }
            else
            {
                temporder = a;
                setvisiblebutonpage(totalpage, btnarray);
                loadtableod(ten, tempsx, temploaisx, ketquatim);
                setvisiblebutonpage(totalpageorder, btnarrayod);
                pageorder(ten, ketquatim, totalpageorder);
                designbutton(a);
            }
        }
        //buton xóa
        private void buttonxoa_Click(object sender, EventArgs e)
        {

        }

        private void buttonthem_Click(object sender, EventArgs e)
        {
            Themdbh them=new Themdbh();
            them.ShowDialog();
        }
        ////////// kết thúc phần code sự kiện tự tạo của form////////////////////////////////////////////////////////////////////////////////////////  
    }
}
