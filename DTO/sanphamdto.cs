using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class sanphamdto
    {
        private String masp;
        private String tensp;
        private String maloai;
        private int  gianhap;
        private int giaban;
        private byte[] hinhanh;
        private string mota;
        private int soluong;

        public sanphamdto(string masp, string tensp, string maloai, int gianhap, int giaban, byte[] hinhanh, string mota,int soluong)
        {
            this.Masp = masp;
            this.Tensp = tensp;
            this.Maloai = maloai;
            this.Gianhap = gianhap;
            this.Giaban = giaban;
            this.Hinhanh = hinhanh;
            this.Mota = mota;
            this.Soluong = soluong;
        }

        public sanphamdto(string masp, int soluong)
        {
            this.masp=masp;
            this.soluong = soluong;
        }


        public sanphamdto    () { }

        public string Masp { get => masp; set => masp = value; }
        public string Tensp { get => tensp; set => tensp = value; }
        public string Maloai { get => maloai; set => maloai = value; }
        public int Gianhap { get => gianhap; set => gianhap = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public byte[] Hinhanh { get => hinhanh; set => hinhanh = value; }
        public string Mota { get => mota; set => mota = value; }
        public int Soluong { get => soluong; set => soluong = value; }
    }
}
