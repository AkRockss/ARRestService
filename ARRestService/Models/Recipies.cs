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
        public int recipeId { get; set; }

        public string recipeTitle { get; set; } 

        public string recipeDescription { get; set; }

        public Recipies()
        {

        }

        //string directory = @".\xxxxxxx";
        //List<image> ImagesR = new List<image>();
        //foreach (string myFile in Directory.)
	

	}

}
