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
        public Guid productId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public bool ecology { get; set; }

        public Products()
        {

        }

    }
}
