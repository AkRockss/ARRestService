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
        public Guid uuid { get; set; }
        public string productName { get; set; }
        public string description { get; set; }
        public bool brand { get; set; }

        public Products()
        {

        }

    }
}
