using Business.Abstract;
using Entities.DTOs;
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
    public class LeasersController : ControllerBase
    {
        IRentalServices _leaserServices;
        public LeasersController(IRentalServices leaserServices)
        {
            _leaserServices = leaserServices;
        }

        //Get Operations
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _leaserServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       
       
        //Post Operations
        [HttpPost("Add")]
        public IActionResult Add(Rental leaser)
        {
            var result = _leaserServices.Add(leaser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(Rental leaser)
        {
            var result = _leaserServices.Delete(leaser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Rental leaser)
        {
            var result = _leaserServices.Update(leaser);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
