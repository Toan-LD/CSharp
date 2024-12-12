using Doanqlchdt.connect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonbandao
    {
        public chitietdonbandao()
        {
        }

        public Boolean delete(string maHD)
        {
            if (!String.IsNullOrEmpty(maHD))
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    string query = "DELETE FROM ChiTietDonBan WHERE MaHDB = @mahd";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@mahd", maHD);
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        public List<chitietdonbandto> findByCondition(string id)
        {
            List<chitietdonbandto> list = new List<chitietdonbandto>();
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select sp.TenSP,sp.GiaBan,ct.SoLuong,ct.TongTien,hd.NgayTao,hd.TongTien as Tong,hd.MaKM \r\nfrom ChiTietDonban ct join SanPham sp on ct.MaSP=sp.MaSP  join HoaDonBan hd on hd.MaHDB=ct.MaHDB\r\nwhere ct.MaHDB=@id";
                SqlCommand cmd=new SqlCommand(query,conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string tenSP = (string)reader["TenSP"];
                    int gia = (int)reader["GiaBan"];
                    int soluong = (int)reader["SoLuong"];
                    int tong = (int)reader["TongTien"];
                    DateTime ngay= (DateTime)reader["NgayTao"];
                    int Tongtien = (int)reader["Tong"];
                    string makm = (string)reader["MaKM"];
                    chitietdonbandto ct = new chitietdonbandto(tenSP, gia, soluong, tong, ngay,Tongtien,makm);
                    list.Add(ct);
                }      
            }
            return list;
        }
        public void insert(chitietdonbandto ctdbdto)
        {
            using(SqlConnection conn=new connectToan().connection())
            {
                string query = "insert into ChiTietDonBan values(@maHDB,@maSP,@gia,@soluong,@tong)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHDB", ctdbdto.Mahdb);
                cmd.Parameters.AddWithValue("@maSP", ctdbdto.Masp);
                cmd.Parameters.AddWithValue("@gia", ctdbdto.Dongia);
                cmd.Parameters.AddWithValue("@soluong", ctdbdto.Soluong);
                cmd.Parameters.AddWithValue("@tong", ctdbdto.Tongtien);
                cmd.ExecuteNonQuery();
            }
        }
        public int update(chitietdonbandto ctdbdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "updateChiTietDonBan set MaSP= N'" + ctdbdto.Masp + "',DonGia= '" + ctdbdto.Dongia + "' ,SoLuong= '" + ctdbdto.Soluong + "',TongTien='" + ctdbdto.Tongtien + "' where MaHDB='" + ctdbdto.Mahdb + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmahd(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from ChiTietDonBan  MaHDB LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  MaSP LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  DonGia LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan  SoLuong LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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
            sqlcommand.CommandText = "select * from ChiTietDonBan TongTien LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhdb = reader.GetString(0);
                String masp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhdb, masp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
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

            sqlcommand.CommandText = "select count (*) from ChiTietDonBan where MaHDB = '"+ mahd + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();

            connect.Close();
            return kq;
        }
        public ArrayList getdsformpage(int ofset, int record,String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("select * from ChiTietDonBan where MaHDB = '"+ mahd + "' ORDER BY MaHDB ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia=reader.GetInt32(2);
                int soluong=reader.GetInt32(3);
                int tongtien=reader.GetInt32(4);
                chitietdonbandto ctdbdto= new chitietdonbandto(mhd,msp,dongia,soluong,tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int selectcountpagesearch(String ten, String dieukien,String mahd)

        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            dieukien = dieukien.Trim();

            sqlcommand.CommandText = string.Format("select count (*) from ChiTietDonBan  Where MaHDB = '"+ mahd + "' and {0} LIKE N'%" + dieukien + "%' ", ten);


            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = (int)sqlcommand.ExecuteScalar();
            connect.Close();
            return kq;
        }
        public ArrayList getdsformpageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record,String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = string.Format("select * from ChiTietDonBan Where  MaHDB = '"+ mahd + "' and {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhd, msp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsformpageodersx(String ten, String sx, int ofset, int record,String mahd)
        {

            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = string.Format("SELECT * FROM ChiTietDonBan Where  MaHDB = '"+ mahd + "' ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mhd = reader.GetString(0);
                String msp = reader.GetString(1);
                int dongia = reader.GetInt32(2);
                int soluong = reader.GetInt32(3);
                int tongtien = reader.GetInt32(4);
                chitietdonbandto ctdbdto = new chitietdonbandto(mhd, msp, dongia, soluong, tongtien);
                ds.Add(ctdbdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }


    }
}
