using BTCSDLNCTUAN;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class donbaohanhdao
    {
        public donbaohanhdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into DonBaoHanh values(N'" + dbhdto.Madonbaohanh + "',N'" + dbhdto.Manv + "',N'" + dbhdto.Makh + "',N'" + dbhdto.Masp + "','" + dbhdto.Ngaytao + "','" + dbhdto.Ngaytra + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update DonBaoHanh set MaNV= N'" + dbhdto.Manv + "',MaKH= N'" + dbhdto.Makh + "' ,MaSP= N'" + dbhdto.Masp + "',NgayTao='" + dbhdto.Ngaytao + "',NgayTra='" + dbhdto.Ngaytra + "' where MaDBH='" + dbhdto.Madonbaohanh + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public DataTable Laytenkh()
        {
            Database db = new Database();
            string strSQL = "Select * from KhachHang";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public DataTable Laytennv()
        {
            Database db = new Database();
            string strSQL = "Select * from NhanVien";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public DataTable Laytensp()
        {
            Database db = new Database();
            string strSQL = "Select * from SanPham";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public ArrayList getdsmadon(String madon)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh MaDBH LIKE '" + madon + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
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
            sqlcommand.CommandText = "select * from DonBaoHanh MaNV LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmakh(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh MaKH LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmasp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytao(DateTime ngay)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh NgayTao LIKE '" + ngay + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaytra(DateTime ngay)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from DonBaoHanh NgayTra LIKE '" + ngay + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int them(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into DonBaoHanh values(N'" + dbhdto.Madonbaohanh + "',N'" + dbhdto.Manv + "',N'" + dbhdto.Makh + "',N'" + dbhdto.Masp + "','" + dbhdto.Ngaytao + "','" + dbhdto.Ngaytra + "')";
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

            sqlcommand.CommandText = "select count (*) from DonBaoHanh  ";
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
            sqlcommand.CommandText = string.Format("select * from DonBaoHanh  ORDER BY MaDBH ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
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

            if (ten == "NgayTao" || ten == "NgayTra")
            {
                sqlcommand.CommandText = string.Format("select count (*) from DonBaoHanh  Where  CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ", ten);
            }
            else
            {
                sqlcommand.CommandText = string.Format("select count (*) from DonBaoHanh  Where {0} LIKE N'%" + dieukien + "%' ", ten);
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
            if (ten == "NgayTao" || ten == "NgayTra")
            {
                sqlcommand.CommandText = string.Format("select * from DonBaoHanh Where CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            }
            else
            {
                sqlcommand.CommandText = string.Format("select * from DonBaoHanh Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            }

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
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
            sqlcommand.CommandText = string.Format("SELECT * FROM DonBaoHanh ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String madbh = reader.GetString(0);
                String manv = reader.GetString(1);
                String makh = reader.GetString(2);
                String masp = reader.GetString(3);
                DateTime ngaytao = reader.GetDateTime(4);
                DateTime ngaytra = reader.GetDateTime(5);
                donbaohanhdto dbhdto = new donbaohanhdto(madbh, manv, makh, masp, ngaytao, ngaytra);
                ds.Add(dbhdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = sqlcommand.CommandText = "update DonBaoHanh set MaNV= N'" + dbhdto.Manv + "',MaKH= N'" + dbhdto.Makh + "' ,MaSP= N'" + dbhdto.Masp + "',NgayTao='" + dbhdto.Ngaytao + "',NgayTra='" + dbhdto.Ngaytra + "' where MaDBH='" + dbhdto.Madonbaohanh + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public DataTable Laymnv()
        {
            Database db = new Database();
            string strSQL = "Select * from NhanVien";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public DataTable Laykh()
        {
            Database db = new Database();
            string strSQL = "Select * from KhachHang";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public DataTable Laysp()
        {
            Database db = new Database();
            string strSQL = "Select * from SanPham";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public int delete(donbaohanhdto dbhdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "DELETE FROM DonBaoHanh WHERE MaDBH = '" + dbhdto.Madonbaohanh + "'";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
    }
}
