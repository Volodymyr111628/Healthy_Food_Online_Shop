using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ShopData;
using HealthyFoodOnlineShop;
using HealthyFoodOnlineShop.Models.Catalog;

namespace HealthyFoodOnlineShop.Controllers
{
    public class CatalogController :Controller
    {
        const int pageSize = 4;
        private IElementAsset _assets;
        public CatalogController(IElementAsset assets)
        {
            _assets = assets;
        }
        public IActionResult Index(int? id)
        {

            int page = id ?? 0;
            //var assetModels = _assets.GetAll();
            

            //var listingResult = assetModels
            //    .Select(result => new AssetIndexListingModel
            //    {
            //        Id = result.Id,
            //        ImageUrl = result.Path,
            //        Name = result.Name,
            //        Description = result.Description,
            //        Price = result.Price,
            //        Type = result.Type,
            //        Country = result.Country,
            //        Discount = result.Discount
            //    });
            //var model = new AssetIndexModel()
            //{
            //    Assets = listingResult
            //};
            if (Request.Headers["X-Requested-With"]=="XMLHttpRequest")
            {
                return PartialView("_Items", GetItemsPage(page));
            }
            return View(GetItemsPage(page));
        }
        private AssetIndexModel GetItemsPage(int page = 1)
        {
            var itemsToSkip = page * pageSize;
            var assetModels = _assets.GetAll();
            var listingResult = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Path,
                    Name = result.Name,
                    Description = result.Description,
                    Price = result.Price,
                    Type = result.Type,
                    Country = result.Country,
                    Discount = result.Discount
                });
            int countItems = listingResult.Count();

            var items = listingResult.Skip(itemsToSkip).
                Take(pageSize);
            var model = new AssetIndexModel()
            {
                Assets = items
            };
            return model;
        }
        public IActionResult Details(int id)
        {
            var result = _assets.GetById(id);
                
            var model = new AssetIndexListingModel()
            {
                Id = result.Id,
                ImageUrl = result.Path,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                Type = result.Type,
                Country = result.Country,
                Discount = result.Discount
            };
            return View(model);
        }
    }
}
