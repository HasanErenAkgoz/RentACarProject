using Business.Abstract;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        IAdminInfoServices _adminServices;
        public AdminsController(IAdminInfoServices adminservices)
        {
            _adminServices = adminservices;
        }
        //Get Operation 
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _adminServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Post Operation 
        [HttpPost("Add")]
        public IActionResult Add(User admin)
        {
            var result = _adminServices.Add(admin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(User admin)
        {
            var result = _adminServices.Delete(admin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(User admin)
        {
            var result = _adminServices.Update(admin);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
