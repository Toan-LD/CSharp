using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTCSDLNCTUAN
{
    internal class Database
    {
      
        SqlConnection sqlcon = null;
        SqlDataAdapter da;
        DataSet ds ;

        public Database()
        {
            string connectsql = "Data Source=ToanLD;Initial Catalog=DoAnC#;User ID=sa;Password=Toan03092003;";
            //String connectsql = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=QLDACHBDT;Integrated Security=True";
            sqlcon = new SqlConnection(connectsql);

           
        }
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlcon); 
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlcon); 
            sqlcon.Open(); 
             sqlcmd.ExecuteNonQuery();
            sqlcon.Close();
        }
    }
}
