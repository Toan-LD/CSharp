using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Doanqlchdt.connect;
using System.Collections;
using Doanqlchdt.DAO;
using Doanqlchdt.DTO;

namespace Doanqlchdt
{
    public partial class Form1 : Form
    {
        Doanqlchdt.connect.connect cn = new Doanqlchdt.connect.connect();
        taikhoandao tkdao=new taikhoandao();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            cn.connection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*ArrayList list = tkdao.getds();
            foreach(taikhoandto tk in list)
            {
                ListViewItem listViewItem = new ListViewItem(tk.Matk.ToString());
                listViewItem.SubItems.Add(tk.Username);
                listViewItem.SubItems.Add(tk.Password);
                listViewItem.SubItems.Add(tk.Quyen.ToString());
                listViewItem.SubItems.Add(tk.Trangthai.ToString());
                listView1.Items.Add(listViewItem);
            }*/
            
        }
    }
}
