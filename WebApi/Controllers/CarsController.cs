using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarServices _carServices;
        public CarsController(ICarServices carServices)
        {
            _carServices = carServices;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _carServices.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
          
        }
        [HttpGet("GetByCarId")]
        public IActionResult GetByPlate(int id)
        {
            var result = _carServices.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAllByPrice")]
        public IActionResult GetAllByPrice(decimal min, decimal max)
        {
            var result = _carServices.GetAllByPrice(min, max);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarDetailDto")]
        public IActionResult GetCarDetailDto()
        {
            var result = _carServices.GetCarDetailDto();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getCarDetailCarId")]
        public IActionResult GetCarDetailCarId(int carId)
        {
            var result = _carServices.GetCarDetailcarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
       

        [HttpGet("GetCarDetailByBrandId")]
        public IActionResult GetCarsDetailByBrandId(int brandId)
        {
            var result = _carServices.GetCarsDetailBrandId(brandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetCarDetailByModelId")]
        public IActionResult GetCarsDetailByModelId(int id)
        {
            var result = _carServices.GetCarsDetailModelId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Car Post Operations
        [HttpPost("Add")]
        public IActionResult Add(CarInfo car)
        {
            var result = _carServices.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(CarInfo car)
        {
            var result = _carServices.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(CarInfo carInfo)
        {
            var result = _carServices.Delete(carInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    
    }
}
