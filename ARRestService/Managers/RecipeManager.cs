using ARRestService.Context;
using ARRestService.Models;
using System.Collections.Generic;
using System.Linq;

namespace ARRestService.Managers
{
    public class RecipeManager
    {
        private ARContext _context;

        public RecipeManager(ARContext context)
        {
            _context = context;
        }
        public RecipeManager()
        {

        }

        //GETBYProductId
        public Recipies GetByRecipeId(string recipieId)
        {
            return _context.Recipies.Find(recipieId);
        }

        //GETBYProductName
        public Recipies GetByRecipeTitle(string recipeTitle)
        {
            return _context.Recipies.FirstOrDefault(x => x.recipeTitle == recipeTitle);
        }

        //ADD
        public IEnumerable<Recipies> Add(Recipies recipies)
        {
            _context.Recipies.Add(recipies);
            _context.SaveChanges();

            return new List<Recipies>();
        }

        //GET
        public IEnumerable<Recipies> GetAll()
        {
            IEnumerable<Recipies> recipies = from recipie in _context.Recipies
                                             select recipie;

            return recipies;

        }

        //DELETE


        public Recipies Delete(string recipieId)
        {
            Recipies recipieIdToBeDeleted = GetByRecipeId(recipieId);
            _context.Recipies.Remove(recipieIdToBeDeleted);
            _context.SaveChanges();
            return recipieIdToBeDeleted;
        }

        //UPDATE
        public Recipies Update(string recipieId, Recipies updates)
        {
            Recipies recipiesToBeUpdated = GetByRecipeId(recipieId);
            recipiesToBeUpdated.recipeTitle = updates.recipeTitle;
            recipiesToBeUpdated.recipeDescription = updates.recipeDescription;


            _context.SaveChanges();

            return recipiesToBeUpdated;
        }


    }

}
