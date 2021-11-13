using Core.Utilities.Results;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICreditCardService
    {
        IResult Add(CreditCard card);
        IResult Payment(CreditCard card);
        IDataResult<CreditCard> GetByUserId(int id);
        IDataResult<List<CreditCard>> GetAll(int userId);
    }
}
