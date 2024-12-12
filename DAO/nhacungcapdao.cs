using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class nhacungcapdao
    {
        public nhacungcapdao() { }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc,tenncc,sdt,email,diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(nhacungcapdto nccdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into NhaCungCap values(N'" + nccdto.Mancc + "',N'" + nccdto.Tenncc + "',N'" + nccdto.Sdt + "',N'" + nccdto.Email + "',N'" + nccdto.Diachi + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public int update(nhacungcapdto nccdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update NhaCungCap set TenNCC= N'" + nccdto.Tenncc + "',SDT= N'" + nccdto.Sdt + "' ,Email= N'" + nccdto.Email + "',DiaChi=N'" + nccdto.Diachi + "' where MaNCC='" + nccdto.Mancc + "' ";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public ArrayList getdsmncc(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap MaNCC LIKE '"+ma+"%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstencc(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap TenNCC LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdssdt(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap SDT LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsemail(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap Email LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsdiachi(String ma)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from NhaCungCap DiaChi LIKE '" + ma + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int them(nhacungcapdto nccdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into NhaCungCap values(N'" + nccdto.Mancc + "',N'" + nccdto.Tenncc + "',N'" + nccdto.Sdt + "',N'" + nccdto.Email + "',N'" + nccdto.Diachi + "')";
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

            sqlcommand.CommandText = "select count (*) from NhaCungCap ";
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
            sqlcommand.CommandText = string.Format("select * from NhaCungCap ORDER BY MaNCC ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
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

                sqlcommand.CommandText = string.Format("select count (*) from NhaCungCap  Where {0} LIKE N'%" + dieukien + "%' ", ten);


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

                sqlcommand.CommandText = string.Format("select * from NhaCungCap Where {0} LIKE N'%" + dieukien + "%' ORDER BY {1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);

            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
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
            sqlcommand.CommandText = string.Format("SELECT * FROM NhaCungCap ORDER BY {0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String mncc = reader.GetString(0);
                String tenncc = reader.GetString(1);
                String sdt = reader.GetString(2);
                String email = reader.GetString(3);
                String diachi = reader.GetString(4);
                nhacungcapdto nccdto = new nhacungcapdto(mncc, tenncc, sdt, email, diachi);
                ds.Add(nccdto);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(nhacungcapdto nccdto)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "update NhaCungCap set TenNCC= N'" + nccdto.Tenncc + "',SDT= N'" + nccdto.Sdt + "' ,Email= N'" + nccdto.Email + "',DiaChi=N'" + nccdto.Diachi + "' where MaNCC='" + nccdto.Mancc + "' ";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
    }
}
