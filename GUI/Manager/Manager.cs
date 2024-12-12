using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.GUI.Manager
{
    public partial class Manager : Form
    {
        bool sidebarExpand = true;
        bool sidebarhoadon = false;
        bool sidebarsanpham = false;
        private Form currentForm = null;
        public Manager(int quyen)
        {
            InitializeComponent();
            if (quyen == 2)
            {
                button1.Enabled = false;
                button5.Enabled = false;
                buttonsidehoadon.Enabled = false;
                buttondon.Enabled = false;
                
            }
            else if(quyen == 4)
            {
                btnQLNV.Enabled = false;
                button3.Enabled = false;
                buttonnhacungcap.Enabled = false;
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            timerside.Start(); 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {

                panelside.Width -= 10;
                if (panelside.Width == panelside.MinimumSize.Width)
                {
                    sidebarExpand = false;
                   timerside.Stop();
                }
            }
            else
            {
                panelside.Width += 10;
                if (panelside.Width == panelside.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    timerside.Stop();
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timerhoadon.Start();
           
        }

        private void timerhoadon_Tick(object sender, EventArgs e)
        {
            if (sidebarhoadon)
            {

                panelsidehoadon.Height -= 10;
                buttondon.Location = new Point(buttondon.Location.X, buttondon.Location.Y - 10);
                if (panelsidehoadon.Height == panelsidehoadon.MinimumSize.Height)
                {
                    sidebarhoadon = false;
                    timerhoadon.Stop();
                }
            }
            else
            {
                buttondon.Location = new Point(buttondon.Location.X, buttondon.Location.Y + 10);
                panelsidehoadon.Height += 10;
                if (panelsidehoadon.Height == panelsidehoadon.MaximumSize.Height)
                {
                    sidebarhoadon = true;
                    timerhoadon.Stop();
                }
            }
        }

        private void timersanpham_Tick(object sender, EventArgs e)
        {
            if (sidebarsanpham)
            {

                panelsidesanpham.Height -= 10;
                panelsideduoi.Location = new Point(panelsideduoi.Location.X, panelsideduoi.Location.Y-10);
                if (panelsidesanpham.Height == panelsidesanpham.MinimumSize.Height)
                {
                    sidebarsanpham = false;
                    timersanpham.Stop();
                }
            }
            else
            {
                panelsidesanpham.Height += 10;
                panelsideduoi.Location = new Point(panelsideduoi.Location.X, panelsideduoi.Location.Y + 10);
                if (panelsidesanpham.Height == panelsidesanpham.MaximumSize.Height)
                {
                    sidebarsanpham = true;
                    timersanpham.Stop();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timersanpham.Start();
        }
        private void ShowFormInPanel(Form form)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelmain.Controls.Add(form);
            panelmain.Tag = form;
            form.Show();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new khachhanggui());

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new sanphamgui());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new loaisanphamgui());
        }


        private void buttondon_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new donbaohanhgui());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new hoadonbangui());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new hoadonnhapgui());
        }

        private void buttonnhacungcap_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new nhacungcap());
        }

        private void buttontaikhoan_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new taikhoangui());
        }

        private void panelmain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new NhanVien());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new KhuyenMai());
        }


        private void button9_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new ThongKe());
        }
    }
}
