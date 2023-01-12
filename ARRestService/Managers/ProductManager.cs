using ARRestService.Context;
using ARRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARRestService.Managers
{
    public class ProductManager
    {
        private static int _nextId = 1;
        private readonly ARContext _context;

        public ProductManager(ARContext context)
        {
            _context = context;
        }

        public ProductManager()
        {
        }


        //GET
        public IEnumerable<Products> GetAll()
        {
            IEnumerable<Products> products = from product in _context.Products
                                             select product;

            return products;
        }

        //GETBYProductId
        public Products GetByProductId(int productId)
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
            products.productId = _nextId++;
            _context.Products.Add(products);
            _context.SaveChanges();

            return new List<Products>();
        }

    
        //UPDATE
        public Products Update(int productId, Products updates)
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

        //DELETE
        public Products Delete(int productId)
        {
            Products productIdToBeDeleted = GetByProductId(productId);
            _context.Products.Remove(productIdToBeDeleted);
            _context.SaveChanges();
            return productIdToBeDeleted;
        }

        ////GET
        public IEnumerable<Products> GetAll(string productname = null, string sortBy = null)
        {

            List<Products> result = new List<Products>(_context.Products);
            if (productname != null)
            {
                result = result.FindAll(x => x.productName == productname);
            }

            if (sortBy != null)
            {

                if (sortBy.ToLower() == "productbrand")
                {
                    return result.OrderBy(x => x.productBrand);
                }

                if (sortBy.ToLower() == "productdescription")
                {
                    return result.OrderBy(x => x.productDescription);
                }

                if (sortBy.ToLower() == "organic")
                {
                    return result.OrderBy(x => x.organic);
                }

                if (sortBy.ToLower() == "noeglemaerket")
                {
                    return result.OrderBy(x => x.noeglemaerket);
                }
            }

            return result;

        }

    }

}
