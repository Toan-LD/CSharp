    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class taikhoandto
    {
        private String username;
        private String password;
        private int quyen;
        private int trangthai;

        public taikhoandto()
        {
        }

        public taikhoandto( string username, string password, int quyen, int trangthai)
        {
            this.username = username;
            this.password = password;
            this.quyen = quyen;
            this.trangthai = trangthai;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
    public class TAIKHOANDTO
    {
        private int matk;
        private String username;
        private String password;
        private int quyen;
        private String tenquyen;
        private int trangthai;
        public TAIKHOANDTO() { }

        public TAIKHOANDTO(int matk, string username, string password, int quyen, string tenquyen, int trangthai)
        {
            this.Matk = matk;
            this.Username = username;
            this.Password = password;
            this.Quyen = quyen;
            this.Tenquyen = tenquyen;
            this.Trangthai = trangthai;
        }

        public int Matk { get => matk; set => matk = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public int Quyen { get => quyen; set => quyen = value; }
        public string Tenquyen { get => tenquyen; set => tenquyen = value; }
        public int Trangthai { get => trangthai; set => trangthai = value; }
    }
}
