using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.BUS
{
    internal class khachhangbus
    {
        khachhangdao khdao=new khachhangdao();
        public khachhangbus() { }
        public ArrayList getds()
        {
            return khdao.findAll();
        }
        public int insert(khachhangdto khdto)
        {
            return khdao.insert(khdto);
        }
        public int selectcount()
        {
            return khdao.selectcount();
        }
        public ArrayList getdspage(int ofset, int record)
        {
            return khdao.getdsformpage(ofset, record);
        }
        public int selectcountoder(String ten, String dieukien)
        {
            return khdao.selectcountpagesearch(ten, dieukien);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {
            return khdao.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record)
        {
            return khdao.getdsformpageodersx(ten, sx, ofset, record);
        }
        public int UPDATE(khachhangdto khdto)
        {
            return khdao.UpDate(khdto);
        }
    }
}
