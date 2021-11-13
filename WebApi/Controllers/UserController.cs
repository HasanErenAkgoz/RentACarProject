using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("getclaims")] 
        public IActionResult GetClaims(User user)
        {
            var result = _userService.GetClaims(user);
            if (result != null)
            {
                return Ok(result);
            }
            else
               return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetById(id);
            if (result!=null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [HttpGet("getbymail")]
        public IActionResult GetByMail(string email)
        {
            var result = _userService.GetByMail(email);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

       [HttpPost("add")]
       public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
