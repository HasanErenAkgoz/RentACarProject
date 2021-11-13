using Core.Utilities.Results;
using Entity.Concrate;
using Entity.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICustomerInfoServices
    {
        IResult Add(CustomerInfo customer);

        IResult Update(CustomerInfo customer);

        IResult Delete(CustomerInfo customer);

        IDataResult<List<CustomerInfoDTO>> GetAll();

        IDataResult<CustomerInfo> GetByTc(string Tc);
        IDataResult<CustomerInfoDTO> GetById(int Id);
    }
}