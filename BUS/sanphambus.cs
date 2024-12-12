using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class sanphambus
    {
        private sanphamdao dao=new sanphamdao();
        public sanphambus() { }
      
        public DataTable gettenloaisp()
        {
            return dao.Layloaisanpham();
        }
        public int themsp(sanphamdto spdto)
        {
            return dao.themsanpham(spdto);
        }
        public int getcount()
        {
            return dao.selectcount();
        }
        public ArrayList getdsfrompage(int ofset,int record)
        {
            return dao.getdsformpage(ofset,record);
        }
        public int selectcountoder(String ten, String dieukien)
        {
            return dao.selectcountpagesearch(ten, dieukien);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {
            return dao.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record)
        {
            return dao.getdsformpageodersx(ten, sx, ofset, record);
        }
        public int UPDATE(sanphamdto spdto)
        {
            return dao.UpDate(spdto);
        }
    }
}
