using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class ThongKeDTO
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal TongTienThang { get; set; }

        public ThongKeDTO() { }

        public ThongKeDTO(int thang, int nam, decimal tongTienThang)
        {
            Thang = thang;
            Nam = nam;
            TongTienThang = tongTienThang;
        }

    }
}
