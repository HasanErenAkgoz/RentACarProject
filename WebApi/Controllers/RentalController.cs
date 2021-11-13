using Business.Abstract;
using Entity.Concrate;
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
    public class RentalController : ControllerBase
    {
      private  IRentalServices _rentalService;
        public RentalController(IRentalServices rentalServices)
        {
            _rentalService = rentalServices;
        }
        [HttpGet("getalldetails")]
        public IActionResult GetAllDetails()
        {
            var result = _rentalService.GetDetailsAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getcarcontrol")]
        public IActionResult GetCarControl(int carId)
        {
            var result = _rentalService.RentalCarControl(carId);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult AddRental(Rental rental)
        {
            var result = _rentalService.Add(rental);
            return Ok(result);

        }
        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);
            if (result != null)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }
}
