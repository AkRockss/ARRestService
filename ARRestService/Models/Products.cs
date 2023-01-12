using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARRestService.Models
{
    public class Products
    {
        [Key]
        public int productId { get; set; }
       
        public string productBrand { get; set; }
      
        public string productName { get; set; }
       
        public string productDescription { get; set; }
        
        public bool organic { get; set; }
       
        public bool noeglemaerket { get; set; }

        //public DateTime? deleted { get; set; }

        public override string ToString()
        {
            return productId + " " + productBrand + " " + productName + " " + productDescription + " " + organic + " " + noeglemaerket;
        }

        public Products()
        {
           
        }

        

    }
}
