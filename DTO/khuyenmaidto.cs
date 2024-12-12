using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class khuyenmaidto
    {
        private string maKM;
        private double tile;

        public khuyenmaidto() { }
        public khuyenmaidto(string maKM,double tile)
        {
            this.maKM = maKM;
            this.tile = tile;
        }
        public string MaKM { get => maKM; set => maKM = value; }
        public double Tile { get => tile; set => tile = value; }
    }
}
