using Business.Abstract;
using Core.Utilities.IoC;
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
    public class CustomersController : ControllerBase
    {
        ICustomerInfoServices _customerInfoServices;
        public CustomersController(ICustomerInfoServices customerInfoServices)
        {
            _customerInfoServices = customerInfoServices;
        }
      
        //Get Operation
        [HttpGet("GetList")]
        public IActionResult GetList()
        {
            var result = _customerInfoServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetByTc")]
        public IActionResult GetByTc(string Tc)
        {
            var result = _customerInfoServices.GetByTc(Tc);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //Post Operation

        [HttpPost("add")]
        public IActionResult Add(CustomerInfo customer)
        {
            var result = _customerInfoServices.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CustomerInfo customer)
        {
            var result = _customerInfoServices.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CustomerInfo customer)
        {
            var result = _customerInfoServices.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
