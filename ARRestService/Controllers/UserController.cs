using ARRestService.Context;
using ARRestService.Managers;
using ARRestService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ARRestService.Controllers
{
    [Route("User/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager _aRManager;

        public UserController(ARContext context)
        {
            _aRManager = new UserManager(context);
        }


        //Users GetByUserId
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByUserId/{userId}")]
        public ActionResult<Users> GetByUserId(string userId)
        {
            Users users = _aRManager.GetByUserId(userId);
            if (users == null) return NotFound("No such item, userId " + userId);
            return Ok(users);
        }


        //Users GetByEmail
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("GetByEmail/{email}")]
        public ActionResult<Users> GetByEmail(string email)
        {
            Users users = _aRManager.GetByEmail(email);
            if (users == null) return NotFound("No such item, userName " + email);
            return Ok(users);
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<Users> GetAll()
        {
            return _aRManager.GetAll();
        }


        //Users POST 
        [HttpPost]
        public IEnumerable<Users> Post([FromBody] Users value)
        {
            return _aRManager.Add(new Users()
            {
                userId = value.userId,
                firstName = value.firstName, 
                lastName = value.lastName,
                country = value.country,
                email = value.email,

            }); ;

        }

        //Users PUT
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("UpdateUser/{userId}")]
        public ActionResult<Users> Put(string userId, [FromBody] Users value)
        {
            Users result = _aRManager.Update(userId, value);
            if (result == null) return NotFound("No such item, userId " + userId);
            return Ok(result);
        }

        //Users DELETE
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("Delete/{userId}")]
        public ActionResult<Users> Delete(string userId)
        {
            Users result = _aRManager.Delete(userId);
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
