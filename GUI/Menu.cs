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
    public partial class Menu : Form
    {
        bool sidebarExpand;
        public Menu()
        {
            InitializeComponent();
        }

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {

                sidebar.Width -= 10;
                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebarTimer.Stop();
                }
            } 
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebarTimer.Stop();
                }
            }
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            sidebarTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            loadform(new NhanVien());
        }
        private void btnPhanQuyen_Click(object sender, EventArgs e)
        {
            loadform(new TaiKhoanNhanVien());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            loadform(new ThongKe());
        }

        private void loadform(object Form)
        {
            if(this.mainpanel.Controls.Count > 0)
            {
                this.mainpanel.Controls.RemoveAt(0);
            }
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.mainpanel.Controls.Add(f);
            this.mainpanel.Tag = f;
            f.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Login loginForm = new Login(); 
            loginForm.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadform(new KhuyenMai());
        }
    }
}
