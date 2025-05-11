using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Models.Cart
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice => Items.Sum(i => i.Price * i.Quantity);

        public int TotalItems => Items.Sum(i => i.Quantity);
    }
}