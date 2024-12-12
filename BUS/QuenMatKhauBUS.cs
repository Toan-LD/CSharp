using Doanqlchdt.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class QuenMatKhauBUS
    {
        QuenMatKhauDAO quenMatKhauDAO = new QuenMatKhauDAO();
        public List<UserInfo> GetUserName(string username)
        {
            return quenMatKhauDAO.GetUserInfo(username);
        }

        public void ChangePassWord(string username, string password)
        {
            quenMatKhauDAO.ChangePassWord(username, password);
        }
    }
}
