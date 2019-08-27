using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyFoodOnlineShop.Models.Catalog
{
    public class BasketAssetIndexListingModel
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
    }
}
