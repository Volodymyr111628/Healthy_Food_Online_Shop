using ShopData;
using ShopData.Models;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ShopServices
{
    public class ElementAssetService : IElementAsset
    {
        private Context _context;

        public ElementAssetService(Context context)
        {
            _context = context;
        }

        public void Add(Element newElement)
        {
            _context.Add(newElement);
            _context.SaveChanges();
        }

        public IEnumerable<Element> GetAll()
        {
            return _context.Elements;
        }

        public Element GetById(int id)
        {
            return _context.Elements.FirstOrDefault(asset => asset.Id == id);
        }
        public void Delete(Element deleteElement)
        {
            _context.Remove(deleteElement);
            _context.SaveChanges();
        }
        public void Update(Element updateElement)
        {
            _context.Elements.Update(updateElement);
            _context.SaveChanges();
        }
    }
}
