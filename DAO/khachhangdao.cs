using Doanqlchdt.connect;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class khachhangdao
    {
        public khachhangdao() { }

        public Boolean checkMaKH(string id)
        {
            using(SqlConnection conn = new connectToan().connection())
            {
                String query = "select MaKH from KhachHang";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string makh=reader.GetString(0);
                    if(id.Equals(makh)) return false;
                }
                return true;
            }
        }
        public ArrayList findAll()
        {
            ArrayList ds = new System.Collections.ArrayList();
            /*connect.connect cn = new connect.connect();*/
            connectToan cn = new connectToan();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh=(string)reader["MaKH"];
                String name=(string)reader["HoTen"];
                String sdt=(String)reader["SDT"];
                String email=(string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh= (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh=new khachhangdto(mkh,name,gioitinh,sdt,email,ngaysinh,user,trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into KhachHang values(N'" + khdto.Mkh + "',N'" + khdto.Hoten + "',N'" + khdto.Sdt + "',N'" + khdto.Email + "','" + khdto.Ngaysinh + "','"+khdto.MaTK+"','"+khdto.Trangthai+"')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public Boolean update(khachhangdto khdto)
        {
            if (khdto.Mkh != null)
            {
                using(SqlConnection conn= new connectToan().connection())
                {
                    string query = "update KhachHang set HoTen=@ten,SDT=@sdt,Email=@email,NgaySinh=@ngaysinh,GioiTinh=@gioitinh where MaKH=@makh";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ten", khdto.Hoten);
                    cmd.Parameters.AddWithValue("@sdt", khdto.Sdt);
                    cmd.Parameters.AddWithValue("@email", khdto.Email);
                    cmd.Parameters.AddWithValue("@ngaysinh", khdto.Ngaysinh.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@makh", khdto.Mkh);
                    cmd.Parameters.AddWithValue("@gioitinh", khdto.Gioitinh);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            return false;
        }
        public ArrayList getdsmakh(String mkh)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang WHERE MaKH='"+mkh+"'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String name = (string)reader["HoTen"];
                String sdt = (String)reader["SDT"];
                String email = (string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdshoten(String hoten)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang HoTen LIKE '"+hoten+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = (string)reader["MaKH"];
                String name = (string)reader["HoTen"];
                String sdt = (String)reader["SDT"];
                String email = (string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public ArrayList getdssdt(String sdt)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang SDT LIKE '" + sdt + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = (string)reader["MaKH"];
                String name = (string)reader["HoTen"];
                String email = (string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsemail(String email)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang Email LIKE '" + email + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = (string)reader["MaKH"];
                String name = (string)reader["HoTen"];
                String sdt = (String)reader["SDT"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsngaysinh(DateTime ngaysinh)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang NgaySinh LIKE '" + ngaysinh + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = (string)reader["MaKH"];
                String name = (string)reader["HoTen"];
                String sdt = (String)reader["SDT"];
                String email = (string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmatk(String matk)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from KhachHang MaTK LIKE '" + matk + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = (string)reader["MaKH"];
                String name = (string)reader["HoTen"];
                String sdt = (String)reader["SDT"];
                String email = (string)reader["Email"];
                String gioitinh = (string)reader["GioiTinh"];
                DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                int user = (int)reader["MaTK"];
                int trangthai = (int)reader["TinhTrang"];
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public khachhangdto findByID(string id)
        {
            khachhangdto kh = new khachhangdto();
            using(SqlConnection conn=new connectToan().connection())
            {
                string query = "select * from KhachHang where MaKH=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    String mkh = (string)reader["MaKH"];
                    String name = (string)reader["HoTen"];
                    String sdt = (String)reader["SDT"];
                    String email = (string)reader["Email"];
                    String gioitinh = (string)reader["GioiTinh"];
                    DateTime ngaysinh = (DateTime)reader["Ngaysinh"];
                    int user = (int)reader["MaTK"];
                    int trangthai = (int)reader["TinhTrang"];
                    kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, user, trangthai);
                }
            }
            return kh;
        }

        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from KhachHang ";
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
            sqlcommand.CommandText = string.Format("select * from KhachHang ORDER BY MaKH ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                int tinhtrang = reader.GetInt32(7);
                String gioitinh = reader.GetString(6);
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, mtk, tinhtrang);
                ds.Add(kh);
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
            if (ten == "NgaySinh")
            {
                sqlcommand.CommandText = string.Format("select count (*) from KhachHang  Where  CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ", ten);
            }
            else if (ten == "GioiTinh")
            {

                sqlcommand.CommandText = string.Format("select count (*) from KhachHang  Where GioiTinh LIKE N'" + dieukien + "%' ");

            }
            else
            {

                sqlcommand.CommandText = string.Format("select count (*) from KhachHang  Where {0} LIKE N'%" + dieukien + "%' ", ten);

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
            if (ten == "NgaySinh")
            {
                sqlcommand.CommandText = string.Format("select * from KhachHang Where CONVERT(NVARCHAR(MAX), {0}, 103) LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            }
            else if (ten == "GioiTinh")
            {
                sqlcommand.CommandText = string.Format("select * from KhachHang Where GioiTinh LIKE N'" + dieukien + "%' ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", dieukiensx, loaisx, ofset, record);

            }
            else
            {
                sqlcommand.CommandText = string.Format("select * from KhachHang Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            }
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                int tinhtrang = reader.GetInt32(7);
                String gioitinh = reader.GetString(6);
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, mtk, tinhtrang);
                ds.Add(kh);
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
            sqlcommand.CommandText = string.Format("SELECT * FROM KhachHang ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mkh = reader.GetString(0);
                String name = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                DateTime ngaysinh = reader.GetDateTime(4);
                int mtk = reader.GetInt32(5);
                int tinhtrang = reader.GetInt32(7);
                String gioitinh = reader.GetString(6);
                khachhangdto kh = new khachhangdto(mkh, name, gioitinh, sdt, email, ngaysinh, mtk, tinhtrang);
                ds.Add(kh);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(khachhangdto khdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update KhachHang set HoTen= N'" + khdto.Hoten + "',SDT= N'" + khdto.Sdt + "' ,Email= N'" + khdto.Email + "',Ngaysinh='" + khdto.Ngaysinh + "' ,MaTK='" + khdto.MaTK + "',GioiTinh='" + khdto.Gioitinh + "'where MaKH='" + khdto.Mkh + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
    }
}
