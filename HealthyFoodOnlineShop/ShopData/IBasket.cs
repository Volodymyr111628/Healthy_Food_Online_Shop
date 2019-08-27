using ShopData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopData
{
    public interface IBasket
    {
        IEnumerable<Basket> GetAll();
        void AddItem(Basket newItem);
        Basket GetById(int id);
    }
}
