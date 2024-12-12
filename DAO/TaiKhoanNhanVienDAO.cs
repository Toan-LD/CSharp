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
    internal class TaiKhoanNhanVienDAO
    {
        connectToan connectObj = new connectToan();

        public ArrayList GetDSTaiKhoan()
        {
            ArrayList array = new ArrayList();
            using(SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TaiKhoan WHERE Quyen = 2", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read()) 
                {
                    taikhoandto account = new taikhoandto
                    {
                        Username = reader["Username"].ToString(),
                        Password = reader["MatKhau"].ToString(),
                        Quyen = Convert.ToInt32(reader["Quyen"]),
                        Trangthai = Convert.ToInt32(reader["TrangThai"])
                    };
                    array.Add(account);
                }
                return array;   
            }
        }

        public ArrayList GetDSUsername()
        {
            ArrayList array = new ArrayList();  
            using(SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Username FROM TaiKhoan WHERE Quyen = 2", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    array.Add(reader[0].ToString());
                }
            }
            return array;
        }

        public ArrayList GetDSUserID()
        {
            ArrayList array = new ArrayList();
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Username FROM TaiKhoan ", connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    array.Add(reader[0].ToString());
                }
            }
            return array;
        }


        public void AddAccount(taikhoandto account, int UserID)
        {
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sqlCommand = new SqlCommand("INSERT INTO TaiKhoan(UserID ,Username, MatKhau, Quyen, TrangThai) VALUES(@UserID ,@Username, @MatKhau, @Quyen, @TrangThai)", connection);
                sqlCommand.Parameters.AddWithValue("@UserID", UserID);
                sqlCommand.Parameters.AddWithValue("@Username", account.Username);
                sqlCommand.Parameters.AddWithValue("@MatKhau", account.Password);
                sqlCommand.Parameters.AddWithValue("@Quyen", account.Quyen);
                sqlCommand.Parameters.AddWithValue("@TrangThai", account.Trangthai);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
