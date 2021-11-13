using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
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
    public class OperationClaimController : ControllerBase
    {
        IOperationClaimService _operationClaim;
        public OperationClaimController(IOperationClaimService operationClaim)
        {
            _operationClaim = operationClaim;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _operationClaim.GetAll();
            if (result.Data!=null)
            {
                return Ok(result);
            }
            else
            return BadRequest(result);
        }
        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _operationClaim.GetById(id);
            if (result.Data != null)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpGet("getbyname")]
        public IActionResult GetByName(string name)
        {
            var result = _operationClaim.GetByName(name);
            if (result.Data != null)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(OperationClaim operationClaim)
        {
            var result = _operationClaim.Add(operationClaim);
            if (result.Success)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(OperationClaim operationClaim)
        {
            var result = _operationClaim.Update(operationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(OperationClaim operationClaim)
        {
            var result = _operationClaim.Delete(operationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
    }

}
