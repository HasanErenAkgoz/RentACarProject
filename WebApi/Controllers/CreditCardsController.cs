using Business.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private ICreditCardService _cardService;
        private ICustomerInfoServices _customerService;

        public CreditCardsController(ICreditCardService paymentService, ICustomerInfoServices customerService)
        {
            _cardService = paymentService;
            _customerService = customerService;
        }

        [HttpPost("payment")]
        public IActionResult Payment(CreditCard card)
        {
            Thread.Sleep(2000);
            var result = _cardService.Payment(card);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCard card)
        {
            var userId = _customerService.GetById(card.UserId);
            card.UserId = userId.Data.Id;
            var result = _cardService.Add(card);
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int userId)
        {
            var result = _cardService.GetByUserId(userId);
            return Ok(result.Data);
        }

        [HttpGet("getallbyid")]
        public IActionResult GetAllById(int customerId)
        {
         
            var result = _cardService.GetAll(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            return BadRequest(result);
        }
    }
}
