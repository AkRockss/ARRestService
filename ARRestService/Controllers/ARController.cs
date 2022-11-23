using ARRestService.Context;
using ARRestService.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ARRestService.Models;
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

        //Products Get, Post, Put, Delete
        //Recipies Get, Post, Put, Delete
        //Users Get, Post, Put, Delete

        // GET: api/<ValuesController>

        // [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]


        //Products GetByUuid
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{uuid}")]
        public ActionResult<Products> GetByUuid(Guid uuid)
        {
            Products products = _aRManager.GetByUuid(uuid);
            if (products == null) return NotFound("No such item, uuid " + uuid);
            return Ok(products);
        }

        //Recipies GetByUuid


        //Users GetByUuid

        // GET api/<ValuesController>/5
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
                uuid = value.uuid,
                productName = value.productName,
                description = value.description,
                brand = value.brand,
            });

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
