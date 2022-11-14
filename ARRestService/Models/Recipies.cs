using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ARRestService.Models
{
    public class Recipies
    {
        [Key]
        public Guid uuid { get; set; }

        public string title { get; set; } 

        public string description { get; set; }

        public Recipies()
        {

        }

        //string directory = @".\xxxxxxx";
        //List<image> ImagesR = new List<image>();
        //foreach (string myFile in Directory.)
	

	}

}
