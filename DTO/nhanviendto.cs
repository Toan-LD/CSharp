using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class nhanviendto
    {
        private string maNV;
        private string hoTen;
        private string sDT;
        private string email;
        private int trangThai;
        private string ngaySinh;
        private int maTK;
        private string gioiTinh;
        public nhanviendto()
        {

        }
        public nhanviendto(string maNV, string hoTen, string sDT, string email, string gioiTinh, int trangThai, string ngaySinh, int maTK)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.sDT = sDT;
            this.email = email;
            this.gioiTinh = gioiTinh;
            this.trangThai = trangThai;
            this.ngaySinh = ngaySinh;
            this.maTK = maTK;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string Email { get => email; set => email = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public int TrangThai { get => trangThai; set => trangThai = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public int MaTK { get => maTK; set => maTK = value; }
    }
}
