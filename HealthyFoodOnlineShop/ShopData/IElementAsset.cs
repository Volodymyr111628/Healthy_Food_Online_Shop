using ShopData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopData
{
    public interface IElementAsset
    {
        IEnumerable<Element> GetAll();
        Element GetById(int id);
        void Add(Element newElement);
        void Delete(Element deleteElement);
        void Update(Element updateElement);
    }
}
