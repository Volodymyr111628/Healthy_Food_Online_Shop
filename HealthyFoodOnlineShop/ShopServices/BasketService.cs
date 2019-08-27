using System;
using System.Collections.Generic;
using System.Text;
using ShopData;
using System.Linq;
using ShopData.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopServices
{
    public class BasketService : IBasket
    {
        private Context _context;

        public BasketService(Context context)
        {
            _context = context;
        }
        public void AddItem(Basket newItem)
        {
            _context.Add(newItem);
            _context.SaveChanges();
        }

        public IEnumerable<Basket> GetAll()
        {
            return _context.Basket;
        }

        public Basket GetById(int id)
        {
            return _context.Basket.FirstOrDefault(asset => asset.Id == id);
        }
        
    }
}
