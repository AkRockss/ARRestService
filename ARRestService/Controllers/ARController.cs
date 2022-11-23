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
            [HttpGet("{uuid}")]
            public ActionResult<Products> GetByUuid(Guid productId)
            {
                Products products = _aRManager.GetByUuid(productId);
                if (products == null) return NotFound("No such item, uuid " + productId);
                return Ok(products);
            }

            //Users GetByUuid

             GET api/< ValuesController >/ 5
            [HttpGet("{id}")]
             public string Get(int id)
             {
                 return "value";
             }

            // POST api/<ValuesController>
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

        PUT api/< ValuesController >/ 5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)



    }
}
