using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
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
    public class StatisticsController : ControllerBase
    {
        IStatisticsServices _statisticsServices;
        public StatisticsController(IStatisticsServices statisticsServices)
        {
            _statisticsServices = statisticsServices;
        }
        [HttpGet("totalcarcount")]
        public IActionResult TotalCarCount()
        {
            var result = _statisticsServices.TotolCarCount();
            if (result != 0)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("mostexpensivecarplate")]
        public IActionResult MostExpensiveCarPlate()
        {
            var result = _statisticsServices.MostExpensiveCarPlate();
            
                return Ok(result);
            
        }
        [HttpGet("topsellingvehicleplate")]
        public IActionResult TopSellingVehiclePlate()
        {
            var result = _statisticsServices.TopSellingVehiclePlate();
            if (result != "")
            {
                return Ok(result.ToString());
            }
            return BadRequest(result);
        }
        [HttpGet("cheapestcarplate")]
        public IActionResult CheapestCarPlate()
        {
            var result = _statisticsServices.CheapestCarPlate().ToString();
            
                return Ok(result);
            
        }
        [HttpGet("numberofrentedvehicles")]
        public IActionResult NumberofRentedVehicles()
        {
            var result = _statisticsServices.NumberofRentedVehicles();
            if (result != 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("totalnumberofcustomers")]
        public IActionResult TotalNumberofCustomers()
        {
            var result = _statisticsServices.TotalNumberofCustomers();
            if (result != 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        

        [HttpGet("namestock")]
        public IActionResult NameStock()
        {
            var result = _statisticsServices.NameStock();
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest("Hata");
        }

    }
}
