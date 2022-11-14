using ARRestService.Context;
using ARRestService.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ARRestService.Models;
using Microsoft.AspNetCore.Http;


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



        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
