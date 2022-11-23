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

        //GETBYGUID
        public Products GetByUuid(Guid guid)
        {
            return _context._Products.Find(guid);
        }
        //ADD
        public IEnumerable<Products> Add(Products products)
        {
            _context._Products.Add(products);
            _context.SaveChanges();

            return new List<Products>();
        }

        //GET
        public IEnumerable<Products> GetAll(Guid productId)
        {
            IEnumerable<Products> products = from product in _context._Products where productId != null  
                                             || product.productId.Equals(productId)
                                             select product;
            return products;  
                                             
        }

           
        //}
        //DELETE
        //Update


    }


}
