using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using BTCSDLNCTUAN;
using Doanqlchdt.Cart;
using Doanqlchdt.connect;

namespace Doanqlchdt.DTO
{
    internal class sanphamdao
    {
        public sanphamdao() { }
        public List<sanphamdto> getds()
        {
            List<sanphamdto> ds = new List<sanphamdto>();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "SELECT * FROM SanPham";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = reader.GetString(2);
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                    ds.Add(spdto);
                }
                reader.Close();
            }
            return ds;
        }


        public int insert(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into SanPham values(N'" + spdto.Masp + "',N'" + spdto.Tensp + "',N'" + spdto.Maloai + "','" + spdto.Gianhap + "','" + spdto.Giaban + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update SanPham set TenSP= N'" + spdto.Tensp + "',MaLoai= N'" + spdto.Maloai + "' ,GiaNhap= '" + spdto.Gianhap + "',GiaBan='" + spdto.Giaban + "' where MaSP='" + spdto.Masp + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }

        public void updateQuantity(string masp,int soluong)
        {
            using (SqlConnection conn =new connectToan().connection())
            {
                string query = "update SanPham set SoLuong=SoLuong+@soluong where MaSP=@masp";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masp",masp);
                cmd.Parameters.AddWithValue("@soluong",soluong);
                cmd.ExecuteNonQuery();
            }
        }

        public Boolean updateQuantity(CartBean shop)
        {
            if (shop != null)
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    foreach (var item in shop.Values)
                    {
                        string query = "update SanPham set SoLuong = SoLuong - @quantity where maSP= @maSP";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@quantity", item.Quantity);
                        cmd.Parameters.AddWithValue("@maSP", item.Sanpham.Masp);
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            return false;
        }
        public ArrayList getdsmasp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstensp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham TenSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmaloaisp(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham MaLoai LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsgianhap(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham GiaNhap LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsgiaban(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from SanPham GiaBan LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String msp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                byte[] hinhanh = (byte[])reader["HinhAnh"];
                string mota = (string)reader["MoTa"];
                int soluong = (int)reader["SoLuong"];
                sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public sanphamdto findByID(string id)
        {
            sanphamdto sp = new sanphamdto();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "select * from SanPham sp join Loaisanpham lsp on sp.MaLoai=lsp.MaLoai where MaSP=@id";
                SqlCommand sqlcommand = new SqlCommand(query, connection);
                sqlcommand.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                if (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = (string)reader["TenLoai"];
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sp = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                }
            }
            return sp;
        }

        public List<sanphamdto> findByCondition(string condition, string price, string dau)
        {

            List<sanphamdto> sp = new List<sanphamdto>();
            using (SqlConnection connection = new connectToan().connection())
            {
                string query = "select * from SanPham sp join Loaisanpham lsp on sp.MaLoai=lsp.MaLoai where TenSP like @id and GiaBan" + dau + " @price";

                SqlCommand sqlcommand = new SqlCommand(query, connection);
                sqlcommand.Parameters.AddWithValue("@id", "%" + condition + "%");
                sqlcommand.Parameters.AddWithValue("@price", price);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    String msp = reader.GetString(0);
                    String tensp = reader.GetString(1);
                    String maloai = (string)reader["TenLoai"];
                    int gianhap = reader.GetInt32(3);
                    int giaban = (int)reader["GiaBan"];
                    byte[] hinhanh = (byte[])reader["HinhAnh"];
                    string mota = (string)reader["MoTa"];
                    int soluong = (int)reader["SoLuong"];
                    sanphamdto spdto = new sanphamdto(msp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                    sp.Add(spdto);
                }
            }
            return sp;
        }
        public DataTable Layloaisanpham()
        {
            Database db=new Database();
            string strSQL = "Select * from Loaisanpham";
            DataTable dt = db.Execute(strSQL); return dt;
        }
        public int themsanpham(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into SanPham values (@masp,@tensp,@maloai,@gianhap,@giaban,@hinhanh,@soluong,@mota)";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            sqlcommand.Parameters.Add("@masp",spdto.Masp);
            sqlcommand.Parameters.Add("@tensp",spdto.Tensp);
            sqlcommand.Parameters.Add("@maloai",spdto.Maloai);
            sqlcommand.Parameters.Add("@gianhap",spdto.Gianhap);
            sqlcommand.Parameters.Add("@giaban",spdto.Giaban);
            sqlcommand.Parameters.Add("@mota",spdto.Mota);
            sqlcommand.Parameters.Add("@hinhanh",spdto.Hinhanh);
            sqlcommand.Parameters.Add("@soluong",spdto.Soluong);
            int kq=sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from SanPham ";
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
            sqlcommand.CommandText = string.Format("select * from SanPham ORDER BY MaSP ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String masp = reader.GetString(0);
                String tensp=reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap=reader.GetInt32(3);
                int giaban=reader.GetInt32(4);
                String mota=reader.GetString(7);
                byte[] hinhanh = (byte[])reader.GetValue(5);
                int soluong=reader.GetInt32(6);
                sanphamdto spdto = new sanphamdto(masp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
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
           

                sqlcommand.CommandText = string.Format("select count (*) from SanPham  Where {0} LIKE N'%" + dieukien + "%' ", ten);


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
      
                sqlcommand.CommandText = string.Format("select * from SanPham Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
            
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String masp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                String mota = reader.GetString(5);
                byte[] hinhanh = (byte[])reader.GetValue(6);
                int soluong = reader.GetInt32(7);
                sanphamdto spdto = new sanphamdto(masp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
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
            sqlcommand.CommandText = string.Format("SELECT * FROM SanPham ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String masp = reader.GetString(0);
                String tensp = reader.GetString(1);
                String maloai = reader.GetString(2);
                int gianhap = reader.GetInt32(3);
                int giaban = reader.GetInt32(4);
                String mota = reader.GetString(5);
                byte[] hinhanh = (byte[])reader.GetValue(6);
                int soluong = reader.GetInt32(7);
                sanphamdto spdto = new sanphamdto(masp, tensp, maloai, gianhap, giaban, hinhanh, mota, soluong);
                ds.Add(spdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(sanphamdto spdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "UPDATE SanPham SET TenSP = @TenSP, MaLoai = @MaLoai, GiaNhap = @GiaNhap, GiaBan = @GiaBan, MoTa = @MoTa, HinhAnh = @HinhAnh, SoLuong = @SoLuong WHERE MaSP = @MaSP";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            sqlcommand.Parameters.AddWithValue("@TenSP", spdto.Tensp);
            sqlcommand.Parameters.AddWithValue("@MaLoai", spdto.Maloai);
            sqlcommand.Parameters.AddWithValue("@GiaNhap", spdto.Gianhap);
            sqlcommand.Parameters.AddWithValue("@GiaBan", spdto.Giaban);
            sqlcommand.Parameters.AddWithValue("@MoTa", spdto.Mota);
            sqlcommand.Parameters.AddWithValue("@HinhAnh", spdto.Hinhanh);
            sqlcommand.Parameters.AddWithValue("@SoLuong", spdto.Soluong);
            sqlcommand.Parameters.AddWithValue("@MaSP", spdto.Masp);
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
    }
}
