using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class TaiKhoanNhanVienBUS
    {
        TaiKhoanNhanVienDAO taiKhoanNhanVienDAO = new TaiKhoanNhanVienDAO();

        public ArrayList GetDSTaiKhoan()
        {
            return taiKhoanNhanVienDAO.GetDSTaiKhoan();
        }

        public ArrayList GetDSUsername()
        {
            return taiKhoanNhanVienDAO.GetDSUsername();
        }

        public ArrayList GetDSUserID()
        {
            return taiKhoanNhanVienDAO.GetDSUserID();
        }

            public void AddAccount(taikhoandto account,int UserID)
        {
            taiKhoanNhanVienDAO.AddAccount(account, UserID);
        }
    }
}
