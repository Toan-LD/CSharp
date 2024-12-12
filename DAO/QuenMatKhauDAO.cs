using Doanqlchdt.connect;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DAO
{
    internal class QuenMatKhauDAO
    {

        private connectToan connectObj = new connectToan();


        public List<UserInfo> GetUserInfo(string username)
        {
            List<UserInfo> userList = new List<UserInfo>();

            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sql = new SqlCommand("SELECT * FROM TaiKhoan LEFT JOIN KhachHang ON TaiKhoan.UserID = KhachHang.MaTK WHERE Username = @username", connection);
                sql.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    string userName = reader["Username"].ToString();
                    string soDienThoai = reader["SDT"].ToString();
                    string ngaySinh = reader["NgaySinh"].ToString();

                    UserInfo userInfo = new UserInfo(userName, soDienThoai, ngaySinh);
                    userList.Add(userInfo);
                }
            }

            return userList;
        }

        public void ChangePassWord(string username, string password)
        {
            using (SqlConnection connection = connectObj.connection())
            {
                SqlCommand sql = new SqlCommand("UPDATE TaiKhoan SET MatKhau = @password WHERE Username = @username", connection);
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue ("Password", password);

                sql.ExecuteNonQuery();
            }
        }
    }
    public class UserInfo
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }

        public UserInfo(string userName, string phoneNumber, string birthday)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            Birthday = birthday;
        }
    }
}
