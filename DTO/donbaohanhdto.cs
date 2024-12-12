using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class donbaohanhdto
    {
        private String madonbaohanh;
        private String manv;
        private String makh;
        private String masp;
        private DateTime ngaytao;
        private DateTime ngaytra;

        public donbaohanhdto()
        {

        }
        public donbaohanhdto(string madonbaohanh, string manv, string makh, string masp, DateTime ngaytao, DateTime ngaytra)
        {
            this.Madonbaohanh = madonbaohanh;
            this.Manv = manv;
            this.Makh = makh;
            this.Masp = masp;
            this.Ngaytao = ngaytao;
            this.Ngaytra = ngaytra;
        }

        public string Madonbaohanh { get => madonbaohanh; set => madonbaohanh = value; }
        public string Manv { get => manv; set => manv = value; }
        public string Makh { get => makh; set => makh = value; }
        public string Masp { get => masp; set => masp = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
        public DateTime Ngaytra { get => ngaytra; set => ngaytra = value; }
    }
}
