using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class hoadonnhapdao
    {
        public hoadonnhapdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn,manv,ncc,tongtien,ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(hoadonnhapdto hdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into HoaDonNhap values(N'" + hdndto.Mahdn + "',N'" +hdndto.Manv + "',N'" + hdndto.Ncc + "','" + hdndto.Tongtien + "','" + hdndto.Ngaytao + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close() ;
            return kq;
        }
        public int update(hoadonnhapdto hdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update HoaDonNhap set MaNV= N'" + hdndto.Manv + "',NhaCungCap= N'" + hdndto.Ncc + "',TongTien='" + hdndto.Tongtien + "',NgayTao='" + hdndto.Ngaytao + "' where MaHDN='" + hdndto.Mahdn + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmhdn(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap MaHDN LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmanv(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap MaNV LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsncc(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap NhaCungCap LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstongtien(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytao(DateTime ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from HoaDonNhap NgayTao LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String manv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngaytao = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, manv, ncc, tongtien, ngaytao);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from HoaDonNhap ";
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
            sqlcommand.CommandText = string.Format("select * from HoaDonNhap ORDER BY MaHDN ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String mnv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngay = reader.GetDateTime(4);
                hoadonnhapdto hdndto=new hoadonnhapdto(mhdn, mnv, ncc,tongtien,ngay);
                ds.Add(hdndto);
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
            if (ten == "NgayTao")
            {
                sqlcommand.CommandText = string.Format("select count (*) from HoaDonNhap  Where CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ", ten);

            }
            else
            {
                sqlcommand.CommandText = string.Format("select count (*) from HoaDonNhap Where {0} LIKE N'%" + dieukien + "%' ", ten);

            }


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
            if (ten == "NgayTao")
            {
                sqlcommand.CommandText = string.Format("select * from HoaDonNhap Where CONVERT(NVARCHAR(MAX), {0}, 103)  LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            }
            else
            {
                sqlcommand.CommandText = string.Format("select * from HoaDonNhap Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);

            }

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String mnv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngay = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, mnv, ncc, tongtien, ngay);
                ds.Add(hdndto);
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
            sqlcommand.CommandText = string.Format("SELECT * FROM HoaDonNhap ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String mnv = reader.GetString(1);
                String ncc = reader.GetString(2);
                int tongtien = reader.GetInt32(3);
                DateTime ngay = reader.GetDateTime(4);
                hoadonnhapdto hdndto = new hoadonnhapdto(mhdn, mnv, ncc, tongtien, ngay);
                ds.Add(hdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
    }
}
