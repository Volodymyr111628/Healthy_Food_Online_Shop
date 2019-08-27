using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyFoodOnlineShop.Models.Catalog
{
    public class BasketAssetIndexModel
    {
        public IEnumerable<BasketAssetIndexListingModel> Assets { get; set; }
    }
}
