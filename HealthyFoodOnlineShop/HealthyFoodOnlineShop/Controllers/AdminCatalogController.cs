using HealthyFoodOnlineShop.Models.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopData;
using ShopData.Models;
using SocialApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyFoodOnlineShop.Controllers
{
    
    public class AdminCatalogController:Controller
    {
        private IElementAsset _asset;
        private UserManager<IdentityUser> _userManager;

        public AdminCatalogController(IElementAsset asset,UserManager<IdentityUser> userManager)
        {
            _asset = asset;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var assetModels = _asset.GetAll();

            var listingModel = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Path,
                    Description = result.Description,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Country = result.Country,
                    Discount = result.Discount
                });
            var model = new AssetIndexModel()
            {
                Assets = listingModel
            };
            return View(model);
        }
        
        public IActionResult AddNewItem(string value)
        {
            string[] arr = value.Split('#');
            Element item = new Element()
            {
                Name = arr[0],
                Price = double.Parse(arr[1]),
                Path = arr[2],
                Type = arr[3],
                Country = arr[4],
                Description = arr[5],
                Discount = 0
            };
            _asset.Add(item);
            var assetModels = _asset.GetAll();

            var listingModel = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Path,
                    Description = result.Description,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Country = result.Country,
                    Discount = result.Discount
                });
            var model = new AssetIndexModel()
            {
                Assets = listingModel
            };
            return View("Index",model);
        }
        public IActionResult DeleteElement(int value)
        {
            Element item = _asset.GetById(value);
            _asset.Delete(item);
            var assetModels = _asset.GetAll();

            var listingModel = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Path,
                    Description = result.Description,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Country = result.Country,
                    Discount = result.Discount
                });
            var model = new AssetIndexModel()
            {
                Assets = listingModel
            };
            return View("Index", model);
        }
        public async void SendMessage(string userEmail, string theme, string messageS)
        {
            EmailService emailService = new EmailService();

            await emailService.SendEmailAsync(userEmail, theme, messageS);

        }
        public IActionResult ChangeDiscount(string value)
        {
            string messageS, theme;
            string[] arr = value.Split('#');
            int Id1 = int.Parse(arr[0]);
            int discount = int.Parse(arr[1]);
            Element item = _asset.GetById(Id1);
            item.Discount = discount;
            theme = "Attention huge discount !!!";
            messageS = "Do not miss an opportunity to buy such a tasty "+item.Name+" with a great discount by "+item.Discount+" % !" +
                " Enjoy our healthy and tasty products! Have a nice day. We are waiting for you !!!" ;
            foreach(var user in _userManager.Users.ToList())
            {
                SendMessage(user.Email, theme, messageS);
            }
            _asset.Update(item);
            var assetModels = _asset.GetAll();

            var listingModel = assetModels
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.Path,
                    Description = result.Description,
                    Name = result.Name,
                    Price = result.Price,
                    Type = result.Type,
                    Country = result.Country,
                    Discount = result.Discount
                });
            var model = new AssetIndexModel()
            {
                Assets = listingModel
            };

            return View("Index", model);
        }

    }
}
