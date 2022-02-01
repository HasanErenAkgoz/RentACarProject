using Business.Abstract;
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
    public class BrandsController : ControllerBase
    {
          IBrandServices _brandServices;
        public BrandsController(IBrandServices brandServices)
        {
            _brandServices = brandServices;
        }
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _brandServices.GetAll();
                if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Brand brand)
        {
            var result = _brandServices.Add(brand);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
