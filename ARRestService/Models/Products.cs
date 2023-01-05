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
        public string productId { get; set; }
        [Required]
        public string productBrand { get; set; }
        [Required]
        public string productName { get; set; }
        [Required]
        public string productDescription { get; set; }
        [Required]
        public bool organic { get; set; }
        [Required]
        public bool noeglemaerket { get; set; }

        //public DateTime? deleted { get; set; }

        public Products()
        {
           
        }

        

    }
}
