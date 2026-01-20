using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdShopManagement
{
    public class CartItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Subtotal => Qty * Price;
    }
}
