using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class hoadonbandto
    {
        private String mhdb;
        private String mnv;
        private String mkh;
        private String mkm;
        private double tongtien;
        private DateTime ngaytao;
        private int trangthai;

        public hoadonbandto()
        {

        }

        public hoadonbandto(string mhdb, string mnv, string mkh, string mkm, double tongtien, DateTime ngaytao, int trangthai)
        {
            this.Mhdb = mhdb;
            this.Mnv = mnv;
            this.Mkh = mkh;
            this.Mkm = mkm;
            this.Tongtien = tongtien;
            this.Ngaytao = ngaytao;
            this.Trangthai = trangthai;
        }

        public string Mhdb { get => mhdb; set => mhdb = value; }
        public string Mnv { get => mnv; set => mnv = value; }
        public string Mkh { get => mkh; set => mkh = value; }
        public string Mkm { get => mkm; set => mkm = value; }
        public double Tongtien { get => tongtien; set => tongtien = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
