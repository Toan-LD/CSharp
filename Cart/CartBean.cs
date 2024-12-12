using Doanqlchdt.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.Cart
{
    public class CartBean:Dictionary<String,addToCart>
    {
        public Boolean checkCart(String key)
        {
            if (this.ContainsKey(key)) return true;
            return false;
        }
        public void addSanPham(addToCart sp)
        {
            string key = sp.Sanpham.Masp;

            if (this.ContainsKey(key))
            {
                int oldQuantity = this[key].Quantity;
                this[key].Quantity = oldQuantity + 1;
            }
            else
            {
                Add(sp.Sanpham.Masp, sp);
            }
        }



        public Boolean removeSanPham(String code)
        {
            if (this.ContainsKey(code))
            {
                this.Remove(code);
                return true;
            }
            return false;
        }

        public CartBean()
        {
        }

    }
}
