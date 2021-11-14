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
    public class UserOperationClaimController : ControllerBase
    {

        IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _userOperationClaimService.GetById(id);
            if (result.Data != null)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }
        [HttpGet("getbyuserıd")]
        public IActionResult GetByUserId(int id)
        {
            var result = _userOperationClaimService.GetByUserId(id);
            if (result.Data != null)
            {
                return Ok(result);

            }
            else
                return BadRequest(result);
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userOperationClaimService.GetAll();
            if (result.Data != null)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("adduserclaim")]
        public IActionResult AddUserClaim(User user)
        {
            var result = _userOperationClaimService.AddUserClaim(user);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim)
        {

            var result = _userOperationClaimService.Delete(userOperationClaim);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Update(userOperationClaim);
            if (result.Success == true)
            {
                return Ok(result);
            }
            else
                return BadRequest(result);
        }

    }
}
