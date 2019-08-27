using HealthyFoodOnlineShop.Models.Catalog;
using Microsoft.AspNetCore.Mvc;
using ShopData;
using ShopData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyFoodOnlineShop.Controllers
{
    public class BasketController:Controller
    {
        private IBasket _assetBas;
        private IElementAsset _assetEl;

        public BasketController(IBasket assetBas,IElementAsset assetEl)
        {
            _assetBas = assetBas;
            _assetEl = assetEl;
        }

        public IActionResult Index(string id)
        {
            double totalSum = 0;
            var assetElementModel = _assetBas.GetAll();


            var userItems = assetElementModel
                .Where(result => result.UserId == id)
                .Select(result => new BasketAssetIndexListingModel
                {
                    ImageUrl = _assetEl.GetById(result.ItemId).Path,
                    Name = _assetEl.GetById(result.ItemId).Name,
                    Price = (_assetEl.GetById(result.ItemId).Price * (1 - (double)_assetEl.GetById(result.ItemId).Discount / 100)) * result.Amount,
                    Amount = result.Amount
                });
            var model1 = new BasketAssetIndexModel()
            {
                Assets = userItems
            };
            foreach(var item in userItems)
            {
                totalSum += item.Price;
            }
            KeyValuePair<BasketAssetIndexModel, double> model = new KeyValuePair<BasketAssetIndexModel, double>(model1,totalSum);
            
           
            return View(model);
        }
        public void AddToBasket(string value)
        {
            var assetElementModel = _assetEl.GetAll();

            string[] arr = value.Split('#');
            string userId = arr[2];
            int elementId = int.Parse(arr[0]);
            int amount = int.Parse(arr[1]);

            Basket item = new Basket()
            {
                ItemId = elementId,
                Amount = amount,
                UserId = userId
            };
            _assetBas.AddItem(item);

           
        }
    }
}
