using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
  public  class userForUpdateDto:IDto
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
