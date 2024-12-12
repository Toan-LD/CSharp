using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonnhapdao
    {
        public chitietdonnhapdao()
        {
        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
              chitietdonnhapdto ctdndto=new chitietdonnhapdto(mhdn,masp,dongia,soluong,tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(chitietdonnhapdto ctdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into ChiTietDonBan values(N'" + ctdndto.Mahdn + "',N'" + ctdndto.Masp + "','" + ctdndto.Dongia + "','" + ctdndto.Soluong + "','" + ctdndto.Tongtien + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(chitietdonnhapdto ctdndto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "updateChiTietDonBan set MaSP= N'" + ctdndto.Masp + "',DonGia= '" + ctdndto.Dongia + "' ,SoLuong= '" + ctdndto.Soluong + "',TongTien='" + ctdndto.Tongtien + "' where MaHDB='" + ctdndto.Mahdn + "' ";
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
            sqlcommand.CommandText = "select * from ChiTietDonNhap MaHDN LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
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
            sqlcommand.CommandText = "select * from ChiTietDonNhap MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsdongia(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap DonGia LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdssoluong(int ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonNhap SoLuong LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
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
            sqlcommand.CommandText = "select * from ChiTietDonNhap TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdn = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdndto = new chitietdonnhapdto(mhdn, masp, dongia, soluong, tongtien);
                ds.Add(ctdndto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int selectcount(String mahd)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from ChiTietDonNhap where MaHDN = '" + mahd + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();

            connect.Close();
            return kq;
        }
        public ArrayList getdsformpage(int ofset, int record, String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("select * from ChiTietDonNhap where MaHDN = '" + mahd + "' ORDER BY MaHDN ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdbdto=new chitietdonnhapdto(mhd, msp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int selectcountpagesearch(String ten, String dieukien, String mahd)

        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            dieukien = dieukien.Trim();

            sqlcommand.CommandText = string.Format("select count (*) ChiTietDonNhap where MaHDN = '" + mahd + "' and {0} LIKE N'%" + dieukien + "%' ", ten);


            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record, String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = string.Format("select * from ChiTietDonNhap where MaHDN = '" + mahd + "' and {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdbdto = new chitietdonnhapdto(mhd, msp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsformpageodersx(String ten, String sx, int ofset, int record, String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("SELECT * FROM ChiTietDonNhap where MaHDN = '" + mahd + "' ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonnhapdto ctdbdto = new chitietdonnhapdto(mhd, msp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

    }
}
