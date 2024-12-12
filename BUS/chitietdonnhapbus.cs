using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonnhapbus
    {
        private chitietdonnhapdao chitiet=new chitietdonnhapdao();
        public chitietdonnhapbus()
        {
        }
        public int getcount(String mhd)
        {
            return chitiet.selectcount(mhd);
        }
        public ArrayList getdsfrompage(int ofset, int record, String mhd)
        {
            return chitiet.getdsformpage(ofset, record, mhd);
        }
        public int selectcountoder(String ten, String dieukien, String mhd)
        {
            return chitiet.selectcountpagesearch(ten, dieukien, mhd);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record, String mhd)
        {
            return chitiet.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record, mhd);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record, String mhd)
        {
            return chitiet.getdsformpageodersx(ten, sx, ofset, record, mhd);
        }
    }
}
