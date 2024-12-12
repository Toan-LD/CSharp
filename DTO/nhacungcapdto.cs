using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
   public class nhacungcapdto
    {
        private String mancc;
        private String tenncc;
        private String sdt;
        private String email;
        private String diachi;

        public nhacungcapdto() { }  

        public nhacungcapdto(string mancc, string tenncc, string sdt, string email, string diachi)
        {
            this.Mancc = mancc;
            this.Tenncc = tenncc;
            this.Sdt = sdt;
            this.Email = email;
            this.Diachi = diachi;
        }

        public string Mancc { get => mancc; set => mancc = value; }
        public string Tenncc { get => tenncc; set => tenncc = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Diachi { get => diachi; set => diachi = value; }
    }
}
