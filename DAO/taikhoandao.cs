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
    internal class taikhoandao
    {
        public taikhoandao()
        {

        }
        public ArrayList getds()
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyen = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyen, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public int insert(taikhoandto tk)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "insert into TaiKhoan values(N'" + tk.Username + "',N'" + tk.Password + "','" + tk.Quyen + "','" + tk.Trangthai + "')";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }
        public Boolean checkttk(String tk, String mk)
        {
            Boolean flag = false;
            /*connect.connect cn = new connect.connect();  */
            connectToan cn = new connectToan();
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = cn.connection();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from TaiKhoan where Username='" + tk + "' and MatKhau='" + mk + "'";
            cmd.Connection = connection;
            SqlDataReader read = cmd.ExecuteReader();
            flag = read.Read();
            read.Close();
            cmd.Connection.Close();
            connection.Close();
            return flag;
        }
        public int update(taikhoandto tk)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "Update TaiKhoan set MatKhau=N'" + tk.Password + "',Quyen='" + tk.Quyen + "',TrangThai='" + tk.Trangthai + "' where Username='" + tk.Username + "'";
            SqlConnection connect = cn.connection();
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;
        }

        public int GetQuyen(string tk, string mk)
        {
            int quyen = 0; // Giá trị mặc định hoặc giá trị không hợp lệ

            /*connect.connect cn = new connect.connect();*/
            connectToan cn = new connectToan();
            SqlConnection connection = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select Quyen from TaiKhoan where Username = '" + tk + "' and MatKhau =  '" + mk + "'";
            sqlcommand.Connection = connection;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            if (reader.Read())
            {
                quyen = Convert.ToInt32(reader["Quyen"]);
            }

            return quyen;
        }

        public ArrayList getdsquyen(int quyen)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where Quyen like '" + quyen + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstk(String user)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where Username like '" + user + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdsmtk(String matk)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where MaTK like '" + matk + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {

                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthai = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }
        public ArrayList getdstrangthai(int trangthai)
        {
            ArrayList ds = new System.Collections.ArrayList();
            connect.connect cn = new connect.connect();
            SqlConnection connect = cn.connection();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "select * from TaiKhoan where TrangThai like '" + trangthai + "%'";
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                String username = reader.GetString(0);
                String password = reader.GetString(1);
                int quyenn = reader.GetInt32(2);
                int trangthaii = reader.GetInt32(3);
                taikhoandto tk = new taikhoandto(username, password, quyenn, trangthaii);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public khachhangdto getKhachHang(string username)
        {
            khachhangdto kh = new khachhangdto();
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select * from TaiKhoan tk join KhachHang kh on tk.UserID=kh.MaTK where tk.Username=@user";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user", username);
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

        public Boolean changePW(int id, string pass)
        {
            if (id != null)
            {
                using (SqlConnection conn = new connectToan().connection())
                {
                    string query = "Update TaiKhoan set MatKhau=@pass where UserID=@id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            return false;
        }

        public Boolean checkOldPass(int id,String oldPass)
        {
            string a=null;
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select MatKhau from TaiKhoan where UserID=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader= cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = reader.GetString(0);
                }
            }
            return String.Equals(a, oldPass);
        }


        public int selectcount()
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;

            sqlcommand.CommandText = "select count (*) from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen ";
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
            sqlcommand.CommandText = string.Format("select TK.UserID,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen ORDER BY UserID ASC OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", ofset, record);
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {    
                int matk=reader.GetInt32(0);
                String username = reader.GetString(1);
                String password = reader.GetString(2);
                int quyen = reader.GetInt32(3);
                String tenquyen=reader.GetString(4);
                int trangthai = reader.GetInt32(5);
                TAIKHOANDTO tk=new TAIKHOANDTO(matk, username, password, quyen,tenquyen, trangthai);
                ds.Add(tk);
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

            if(ten=="TenQuyen")
            {
                sqlcommand.CommandText = string.Format("select count (*) from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and Q.{0} LIKE N'%" + dieukien + "%' ", ten);
            }
            else
            {
                sqlcommand.CommandText = string.Format("select count (*) from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and TK.{0} LIKE N'%" + dieukien + "%' ", ten);
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
            if(ten=="TenQuyen")
            {
                if(dieukiensx=="TenQuyen")
                {
                    sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and Q.{0} LIKE N'%" + dieukien + "%' ORDER BY Q.{1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
                }
                else
                {
                    sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and Q.{0} LIKE N'%" + dieukien + "%' ORDER BY TK.{1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
                }
                
            }
             else
            {
                if(dieukiensx=="TenQuyen")
                {
                    sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and TK.{0} LIKE N'%" + dieukien + "%' ORDER BY Q.{1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
                }
                else
                {
                    sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen and TK.{0} LIKE N'%" + dieukien + "%' ORDER BY TK.{1} {2} OFFSET {3} ROWS FETCH NEXT {4} ROWS ONLY", ten, dieukiensx, loaisx, ofset, record);
                }
               
            }
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                int matk = reader.GetInt32(0);
                String username = reader.GetString(1);
                String password = reader.GetString(2);
                int quyen = reader.GetInt32(3);
                String tenquyen = reader.GetString(4);
                int trangthai = reader.GetInt32(5);
                TAIKHOANDTO tk = new TAIKHOANDTO(matk, username, password, quyen, tenquyen, trangthai);
                ds.Add(tk);
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
            if(ten=="TenQuyen")
            {
                sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen ORDER BY Q.{0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            }
            else
            {
                sqlcommand.CommandText = string.Format("select TK.MaTK,TK.Username,TK.MatKhau,TK.Quyen,Q.TenQuyen,TK.TrangThai from TaiKhoan TK,Quyen Q where TK.Quyen=Q.MaQuyen ORDER BY TK.{0} {1} OFFSET {2} ROWS FETCH NEXT {3} ROWS ONLY", ten, sx, ofset, record);
            }
            sqlcommand.Connection = connect;
            SqlDataReader reader = sqlcommand.ExecuteReader();
            while (reader.Read())
            {
                int matk = reader.GetInt32(0);
                String username = reader.GetString(1);
                String password = reader.GetString(2);
                int quyen = reader.GetInt32(3);
                String tenquyen = reader.GetString(4);
                int trangthai = reader.GetInt32(5);
                TAIKHOANDTO tk = new TAIKHOANDTO(matk, username, password, quyen, tenquyen, trangthai);
                ds.Add(tk);
            }
            reader.Close();
            connect.Close();
            return ds;
        }

        public int UpDate(taikhoandto tk)
        {
            connect.connect cn = new connect.connect();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.CommandType = System.Data.CommandType.Text;
            sqlcommand.CommandText = "UPDATE TaiKhoan set MatKhau=N'" + tk.Password + "',Quyen='" + tk.Quyen + "',TrangThai='" + tk.Trangthai + "' where Username='" + tk.Username + "'";
            SqlConnection connect = cn.connection();
            sqlcommand.Connection = connect;
            int kq = sqlcommand.ExecuteNonQuery();
            connect.Close();
            return kq;

        }
        public Boolean checkUserID(string id)
        {
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "select * from TaiKhoan where Username=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            return false;
        }

        public int GetSoLuong()
        {
            int soLuong = 0;
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM TaiKhoan", connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    soLuong++;
                }
            }
            return soLuong;    
        }

        public int GetSoLuongKH()
        {
            int soLuong = 0;
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM TaiKhoan WHERE Quyen = 3", connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    soLuong++;
                }
            }
            return soLuong + 1;
        }

        public void AddAccount(string userid,string username, string password)
        {

            using (SqlConnection connection = new connectToan().connection())
            {

                // Thực hiện truy vấn để thêm dữ liệu vào bảng TaiKhoan
                string query = "INSERT INTO TaiKhoan (UserID, Username, MatKhau, Quyen, TrangThai) VALUES (@UserID ,@Username, @Password, @Quyen, @TrangThai)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userid);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                command.Parameters.AddWithValue("@Quyen", 3); // Quyen = 3 (tương ứng với KhachHang)
                command.Parameters.AddWithValue("@TrangThai", 1); // Trạng thái tài khoản (có thể thay đổi)

                command.ExecuteNonQuery();
            }
        }

        public void AddCustomer(int userID, string hoTen, string soDienThoai, string email, string ngaysinh, string gioitinh)
        {
            using (SqlConnection connection = new connectToan().connection())
            {

                string query = "INSERT INTO KhachHang (MaKH ,HoTen, SDT, maTK, Email, NgaySinh, GioiTinh, TrangThai, TinhTrang ) VALUES (@MaKH ,@HoTen, @SDT, @MaTK, @email, @ngaysinh, @gioitinh, 1, 1);";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@MaKH", GetSoLuongKH());
                command.Parameters.AddWithValue("@SDT", soDienThoai);
                command.Parameters.AddWithValue("@MaTK", userID);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                command.Parameters.AddWithValue("@gioitinh", gioitinh);

                command.ExecuteNonQuery();
            }
        }
    }
}

