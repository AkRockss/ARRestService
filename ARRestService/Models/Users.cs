using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARRestService.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }  

        public string firstName { get; set; } 

        public string lastName { get; set; }

        public string email { get; set; }

        public string country { get; set; }

        public Users()
        {
                
        }
    }
}
