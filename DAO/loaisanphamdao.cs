using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class loaisanphamdao
    {
        public loaisanphamdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp,tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(loaisanphamdto loaispdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into Loaisanpham values(N'" + loaispdto.Maloai + "',N'" + loaispdto.Tenloai + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(loaisanphamdto loaispdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update Loaisanpham set TenLoai= N'" + loaispdto.Tenloai + "' where MaLoai='" + loaispdto.Maloai + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmaloai(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham MaLoai LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp, tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstenloai(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from Loaisanpham TenLoai LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mlsp = reader.GetString(0);
                String tenlsp = reader.GetString(1);
                loaisanphamdto loai = new loaisanphamdto(mlsp, tenlsp);
                ds.Add(loai);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int them(loaisanphamdto loaidto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into Loaisanpham values(N'" + loaidto.Maloai + "',N'" + loaidto.Tenloai + "')";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from Loaisanpham ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();

            connect.Close();
            return kq;
        }
        public ArrayList getdsformpage(int ofset, int record)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("select * from Loaisanpham ORDER BY MaLoai ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String maloaisp = reader.GetString(0);
                String tenloaisp = reader.GetString(1);
                loaisanphamdto loaidto = new loaisanphamdto(maloaisp,tenloaisp);
                ds.Add(loaidto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int selectcountpagesearch(String ten, String dieukien)

        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            dieukien = dieukien.Trim();


            sqlcommand.CommandText = string.Format("select count (*) from Loaisanpham  Where {0} LIKE N'%" + dieukien + "%' ", ten);


            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = string.Format("select * from Loaisanpham Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String maloaisp = reader.GetString(0);
                String tenloaisp = reader.GetString(1);
                loaisanphamdto loaidto = new loaisanphamdto(maloaisp, tenloaisp);
                ds.Add(loaidto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsformpageodersx(String ten, String sx, int ofset, int record)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("SELECT * FROM Loaisanpham ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String maloaisp = reader.GetString(0);
                String tenloaisp = reader.GetString(1);
                loaisanphamdto loaidto = new loaisanphamdto(maloaisp, tenloaisp);
                ds.Add(loaidto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(loaisanphamdto loaidto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update Loaisanpham set TenLoai= N'" + loaidto.Tenloai + "' where MaLoai='" + loaidto.Maloai + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }


    }
}
