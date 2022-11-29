using ARRestService.Context;
using ARRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARRestService.Managers
{
    public class ARManager
    {
        private ARContext _context;

        public ARManager(ARContext context)
        {
            _context = context; 
        }
        public ARManager()
        {

        }

        //GETBYProductId
        public Products GetByProductId(string productId)
        {
            return _context.Products.Find(productId);
        }

        public Products GetByProductName(string productName)
        {
            return _context.Products.Find(productName);
        }

        //ADD
        public IEnumerable<Products> Add(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();

            return new List<Products>();
        }

        //GET
        public IEnumerable<Products> GetAll()
        {
            IEnumerable<Products> products = from product in _context.Products
                                             select product;
            return products;  
       
        }
   
        //DELETE
        public Products Delete(string productId)
        {
            Products products = _context.Products.Find(productId);
            if (products == null) return null;
            _context.Remove(products);
            return products;
        }

        //UPDATE
        public Products Update(string productId, Products updates)
        {
            Products products = _context.Products.Find(productId);
            if (products == null) return null;
            products.productName = updates.productName;
            products.productDescription = updates.productDescription;
            return products;
        }


    }

}
