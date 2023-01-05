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
    [Route("Product/[controller]")]
    [ApiController]
    [ResponseCache(/*VaryByHeader = "User-agent",*/ Duration = 10, Location = ResponseCacheLocation.Any)]
    public class ProductController : ControllerBase
    {
        private readonly ProductManager _aRManager;
    

        public ProductController(ARContext context)
        {
            _aRManager = new ProductManager(context);
        }



        //Products GetByProductId
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByProductId/{productId}")]
        public ActionResult<Products> GetByProductId(string productId)
        {
            Products products = _aRManager.GetByProductId(productId);
            if (products == null) return NotFound("No such item, productId " + productId);
            return Ok(products);
        }

        //Products GetByProductName
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByProductName/{productName}")]
        public ActionResult<Products> GetByProductName(string productName)
        {
            Products products = _aRManager.GetByProductName(productName);
            if (products == null) return NotFound("No such item, productName " + productName);
            return Ok(products);
        }

        [HttpGet("GetAllProducts")]
        public IEnumerable<Products> GetAll()
        {
            return _aRManager.GetAll();
        }

        [HttpGet("Values")]
        public int Get()
        {
            return DateTime.Now.Second;
        }


        //Products POST 
        [HttpPost]
        public IEnumerable<Products> Post([FromBody] Products value)
        {
            return _aRManager.Add(new Products()
            {
                productId = value.productId,
                productBrand = value.productBrand,
                productName = value.productName,
                productDescription = value.productDescription,
                organic = value.organic,
                noeglemaerket = value.noeglemaerket,


            }); ;

        }

        //Products PUT
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateProduct/{productId}")]
        public ActionResult<Products> Put(string productId, [FromBody] Products value)
        {
            Products result = _aRManager.Update(productId, value);
            if (result == null) return NotFound("No such item, productId " + productId);
            return Ok(result);
        }

        //Products DELETE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Delete/{productId}")]
        public ActionResult<Products> Delete(string productId)
        {
            Products result = _aRManager.Delete(productId);
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



