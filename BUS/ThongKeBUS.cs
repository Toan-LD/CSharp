using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class ThongKeBUS
    {
        ThongKeDAO thongKeDao = new ThongKeDAO();

        public ArrayList GetSoLuongHoaDonBan()
        {
            return thongKeDao.GetSoLuongHoaDonBan();
        }

        public ArrayList GetSoLuongKhachHang()
        {
            return thongKeDao.GetSoLuongKhachHang();
        }

        public int TongTienBan()
        {
            return thongKeDao.TongTienBan();
        }

        public int SoLuongSanPhamBan()
        { 
            return thongKeDao.SoLuongSanPhamBan();
        }

        public int LayTongTienBanTheoNam(string year)
        {
            return thongKeDao.LayTongTienBanTheoNam(year);
        }

        public int LayTongTienNhapTheoNam(string year)
        {
            return thongKeDao.LayTongTienNhapTheoNam(year);
        }

        public ArrayList GetDSNam()
        {
            return thongKeDao.GetDSNam();
        }

        /*public DataTable LayTongTienTheoThangNam()
        {
            return thongKeDao.LayTongTienTheoThangNam();
        }*/


        public DataTable LayTongTienTheoNam(string year)
        {
            return thongKeDao.LayTongTienTheoThangNam(year);
        }
        public DataTable LayTongTienTheoThangNam1(string year)
        {
            return thongKeDao.LayTongTienTheoThangNam1(year);
        }
    }
}
