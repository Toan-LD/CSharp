using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class donbaohanhbus
    {
        private donbaohanhdao dao = new donbaohanhdao();
        public donbaohanhbus()
        {
        }

        public DataTable gettensp()
        {
            return dao.Laytensp();
        }
        public DataTable gettennv()
        {
            return dao.Laytennv();
        }
        public DataTable gettenkh()
        {
            return dao.Laytenkh();
        }
        public int them(donbaohanhdto dbhdto)
        {
            return dao.them(dbhdto);
        }
        public int getcount()
        {
            return dao.selectcount();
        }
        public ArrayList getdsfrompage(int ofset, int record)
        {
            return dao.getdsformpage(ofset, record);
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
        public int UPDATE(donbaohanhdto dbhdto)
        {
            return dao.UpDate(dbhdto);
        }
        public DataTable getnv()
        {
            return dao.Laymnv();
        }
        public DataTable getsp()
        {
            return dao.Laysp();
        }
        public DataTable getkh()
        {
            return dao.Laykh();
        }

    }
}
