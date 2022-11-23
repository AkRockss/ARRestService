using ARRestService.Context;
using ARRestService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        //GET
        public Products GetByUuid(Guid guid)
        {
            return _context.Products.Find(guid);
        }
        //ADD
        public IEnumerable<Products> Add(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();

            return new List<Products>();
        }
        //DELETE
        //Update


    }


}
