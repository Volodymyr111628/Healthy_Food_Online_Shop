using System;
using System.Collections.Generic;
using System.Text;

namespace ShopData.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
    }
}
