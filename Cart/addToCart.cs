using Doanqlchdt.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.Cart
{
    public class addToCart
    {
        private sanphamdto sanpham;
        private int quantity;

        public addToCart() { }

        public addToCart(sanphamdto sp) {
            this.Sanpham = sp;
            this.Quantity = 1;
        }

        public void BuyProduct(List<sanphamdto> sp)
        {
            
        }

        public sanphamdto Sanpham { get => sanpham; set => sanpham = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
