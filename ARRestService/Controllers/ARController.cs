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


        //Products GetByUuid
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{productId}")]
        public ActionResult<Products> GetByUuid(Guid productId)
        {
            Products products = _aRManager.GetByUuid(productId);
            if (products == null) return NotFound("No such item, productId " + productId);
            return Ok(products);
        }


        //Products POST 
        [HttpPost]
        public IEnumerable<Products> Post([FromBody] Products value)
        {
            return _aRManager.Add(new Products()
            {
                productId = value.productId,
                productName = value.productName,
                productDescription = value.productDescription,
                ecology = value.ecology,
            });

        }

        //Products PUT
        [HttpPut("{productId}")]
        public Products Put(Guid productId, [FromBody] Products value)
        {
            return _aRManager.Update(productId, value);
        }

        //Products DELETE
        [HttpDelete("{productId}")]
        public Products Delete(Guid productId )
        {
            return _aRManager.Delete(productId);
        }
       

    }
       
}
