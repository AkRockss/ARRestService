using ARRestService.Context;
using ARRestService.Managers;
using ARRestService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARRestService.Controllers
{
    [Route("Recipe/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly RecipeManager _aRManager;

        public RecipeController(ARContext context)
        {
            _aRManager = new RecipeManager(context);
        }


        //Recipies GetByProductId
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByRecipeId/{productId}")]
        public ActionResult<Recipies> GetByRecipeId(string recipeId)
        {
            Recipies recipies = _aRManager.GetByRecipeId(recipeId);
            if (recipies == null) return NotFound("No such item, productId " + recipeId);
            return Ok(recipies);
        }


        //Recipies GetByProductName
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByrecipeTitle/{recipeTitle}")]
        public ActionResult<Recipies> GetByRecipeTitle(string recipeTitle)
        {
            Recipies recipies = _aRManager.GetByRecipeTitle(recipeTitle);
            if (recipies == null) return NotFound("No such item, productName " + recipeTitle);
            return Ok(recipies);
        }

        [HttpGet("GetAllRecipies")]
        public IEnumerable<Recipies> GetAll()
        {
            return _aRManager.GetAll();
        }


        //Recipies POST 
        [HttpPost]
        public IEnumerable<Recipies> Post([FromBody] Recipies value)
        {
            return _aRManager.Add(new Recipies()
            {
                recipeId = value.recipeId,
                recipeTitle = value.recipeTitle,
                recipeDescription = value.recipeDescription,
            }); ;

        }

        //Recipies PUT
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateRecipe/{recipiId}")]
        public ActionResult<Recipies> Put(string recipeId, [FromBody] Recipies value)
        {
            Recipies result = _aRManager.Update(recipeId, value);
            if (result == null) return NotFound("No such item, productId " + recipeId);
            return Ok(result);
        }

        //Recipies DELETE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Delete/{recipiId}")]
        public ActionResult<Recipies> Delete(string recipeId)
        {
            Recipies result = _aRManager.Delete(recipeId);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }


    }

}
