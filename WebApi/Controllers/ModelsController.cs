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
    public class ModelsController : ControllerBase
    {
        IModelServices _modelServices;
        public ModelsController(IModelServices modelServices)
        {
            _modelServices = modelServices;
        }
        [HttpGet("GetList")]
        public IActionResult GetList(int BrandId)
        {
            var result = _modelServices.GetAll(BrandId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(Model models)
        {
            var result = _modelServices.Add(models);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
