using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
   public class UserOperationClaimDto:IDto
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int OperationClaimId { get; set;}
        public string claimName { get; set; }

        public bool Status { get; set; }
    }
}
