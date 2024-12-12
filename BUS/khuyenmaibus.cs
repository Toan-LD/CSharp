using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    internal class khuyenmaibus
    {
        khuyenmaidao khuyenMaidao = new khuyenmaidao();
        public ArrayList GetKM()
        {
            return khuyenMaidao.GetKM();
        }

        public bool GetMaKM(string maKM)
        {
            return khuyenMaidao.GetMaKM(maKM);
        }

        public void AddMaKM(string maKM, double tiLe)
        {
            khuyenMaidao.AddMaKM(maKM, tiLe);
        }

        public void DeleteMaKM(string maKM)
        {
            khuyenMaidao.DeleteMaKM(maKM);
        }
    }
}
