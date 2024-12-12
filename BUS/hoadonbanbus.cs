using System;
using System.Collections;
using System.Windows.Forms;


namespace Doanqlchdt.DTO
{
    internal class hoadonbanbus
    {
        hoadonbandao hoadonbanDao = new hoadonbandao();

        public hoadonbanbus()
        {
        }

        public Boolean delete(string maHD)
        {
            return hoadonbanDao.delete(maHD);
        }

        public DateTime getNgayTao(string maHD)
        {
            return hoadonbanDao.getNgayTao(maHD);
        }
        public int getcount()
        {
            return hoadonbanDao.selectcount();
        }
        public ArrayList getdsfrompage(int ofset, int record)
        {
            return hoadonbanDao.getdsformpage(ofset, record);
        }
        public int selectcountoder(String ten, String dieukien)
        {
            return hoadonbanDao.selectcountpagesearch(ten, dieukien);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {
            return hoadonbanDao.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record)
        {
            return hoadonbanDao.getdsformpageodersx(ten, sx, ofset, record);
        }
    }
    public class HOADONBANXACNHANBUS
    {
        private HOADONBANXACNHANDAO hoadonbanDao=new HOADONBANXACNHANDAO();
        public HOADONBANXACNHANBUS()
        {
        }
        public int getcount()
        {
            return hoadonbanDao.selectcount();
        }
        public ArrayList getdsfrompage(int ofset, int record)
        {
            return hoadonbanDao.getdsformpage(ofset, record);
        }
        public int selectcountoder(String ten, String dieukien)
        {
            return hoadonbanDao.selectcountpagesearch(ten, dieukien);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {
            return hoadonbanDao.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record)
        {
            return hoadonbanDao.getdsformpageodersx(ten, sx, ofset, record);
        }

    }
}
