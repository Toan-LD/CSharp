using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class hoadonnhapdto
    {
        private String mahdn;
        private String manv;
        private String ncc;
        private int tongtien;
        private DateTime ngaytao;

        public hoadonnhapdto()
        {
        }

        public hoadonnhapdto(string mahdn, string manv, string ncc, int tongtien, DateTime ngaytao)
        {
            this.mahdn = mahdn;
            this.manv = manv;
            this.ncc = ncc;
            this.tongtien = tongtien;
            this.ngaytao = ngaytao;
        }

        public string Mahdn { get => mahdn; set => mahdn = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Ncc { get => ncc; set => ncc = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
    }
}
