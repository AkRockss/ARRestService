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

        //GETBYProductName
        public Products GetByProductName(string productName)
        {
            return _context.Products.FirstOrDefault(x => x.productName == productName);
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
            Products productIdToBeDeleted = GetByProductId(productId);
            _context.Products.Remove(productIdToBeDeleted);
            _context.SaveChanges();
            return productIdToBeDeleted;
        }

        //UPDATE
        public Products Update(string productId, Products updates)
        {
            Products productsToBeUpdated = GetByProductId(productId);
            productsToBeUpdated.productName = updates.productName;
            productsToBeUpdated.productBrand = updates.productBrand;
            productsToBeUpdated.productDescription = updates.productDescription;
            productsToBeUpdated.organic = updates.organic;
            productsToBeUpdated.noeglemaerket = updates.noeglemaerket;

            _context.SaveChanges();

            return productsToBeUpdated;
        }


    }

}
