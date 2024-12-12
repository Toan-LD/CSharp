using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Doanqlchdt.connect
{
    internal class connect
    {
        //String sql = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLDACHBDT;Integrated Security=True";
        private string sql = "Data Source=ToanLD;Initial Catalog=DoAnC#;User ID=sa;Password=Toan03092003;";

        SqlConnection sqlcon = null;

        public connect()
        {
        }

        public SqlConnection connection()
        {
            try
            {
                if (sqlcon == null)
                {
                    sqlcon = new SqlConnection(sql);
                }
                if (sqlcon.State == System.Data.ConnectionState.Closed)
                {
                    sqlcon.Open();
                   
                }
            }
           catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sqlcon;
        }
        public void closeconect()
        {
            if(sqlcon!=null && sqlcon.State==System.Data.ConnectionState.Open)
            {
                sqlcon.Close();
                MessageBox.Show("Kết nối đã đóng");
            }
            else
            {
                MessageBox.Show("Chưa tạo kết nối");
            }
        }
    }
}
