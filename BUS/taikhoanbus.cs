using Doanqlchdt.DAO;
using Doanqlchdt.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doanqlchdt.BUS
{
    internal class taikhoanbus
    {
        taikhoandao tkdao = new taikhoandao();

        public taikhoanbus()
        {
        }
        public ArrayList getds()
        {
            return tkdao.getds();
        }
        public Boolean checkt(String tk, String mk)
        {
            return tkdao.checkttk(tk, mk);
        }

        public ArrayList getdsquyen(int quyen)
        {
            return tkdao.getdsquyen(quyen);
        }

        public int GetQuyen(string tk, string mk)
        {
            return tkdao.GetQuyen(tk, mk);
        }
        public int getcount()
        {
            return tkdao.selectcount();
        }
        public ArrayList getdsfrompage(int ofset, int record)
        {
            return tkdao.getdsformpage(ofset, record);
        }
        public int selectcountoder(String ten, String dieukien)
        {
            return tkdao.selectcountpagesearch(ten, dieukien);
        }
        public ArrayList getdspageoder(String ten, String dieukien, String dieukiensx, String loaisx, int ofset, int record)
        {
            return tkdao.getdsformpageoder(ten, dieukien, dieukiensx, loaisx, ofset, record);
        }
        public ArrayList getdspagesx(String ten, String sx, int ofset, int record)
        {
            return tkdao.getdsformpageodersx(ten, sx, ofset, record);
        }
        public int UPDATE(taikhoandto tkdto)
        {
            return tkdao.UpDate(tkdto);
        }
    }
}
