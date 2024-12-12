using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class chitietdonnhapdto
    {

        private String mahdn;
        private String masp;
        private int dongia;
        private int soluong;
        private int tongtien;

        public chitietdonnhapdto(string mahdn, string masp, int dongia, int soluong, int tongtien)
        {
            this.Mahdn = mahdn;
            this.Masp = masp;
            this.Dongia = dongia;
            this.Soluong = soluong;
            this.Tongtien = tongtien;
        }

        public string Mahdn { get => mahdn; set => mahdn = value; }
        public string Masp { get => masp; set => masp = value; }
        public int Dongia { get => dongia; set => dongia = value; }
        public int Soluong { get => soluong; set => soluong = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }
    }
}
