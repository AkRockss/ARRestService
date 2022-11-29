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
    [Route("api/[controller]")]
    [ApiController]
    public class ARController : ControllerBase
    {
        private readonly ARManager _aRManager;

        public ARController(ARContext context)
        {
            _aRManager = new ARManager(context);
        }


        //Products GetByProductId
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{productId}")]
        public ActionResult<Products> GetByUuid(string productId)
        {
            Products products = _aRManager.GetByProductId(productId);
            if (products == null) return NotFound("No such item, productId " + productId);
            return Ok(products);
        }


        //Products GetByProductName
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{productName}")]
        public ActionResult<Products> GetByProductName(string productName)
        {
            Products products = _aRManager.GetByProductId(productName);
            if (products == null) return NotFound("No such item, productName " + productName);
            return Ok(products);
        }

        [HttpGet("GetAll")]
        public IEnumerable<Products> GetAll()
        {
            return _aRManager.GetAll();
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
        [HttpPut("{productId}")]
        public Products Put(string productId, [FromBody] Products value)
        {
            return _aRManager.Update(productId, value);
        }

        //Products DELETE
        [HttpDelete("{productId}")]
        public Products Delete(string productId )
        {
            return _aRManager.Delete(productId);
        }
       

    }
       
}
