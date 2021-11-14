using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CustomerInfoManager : ICustomerInfoServices
    {
        private ICustomerInfoDal _customerInfoDal;

        public CustomerInfoManager(ICustomerInfoDal customerInfoDal)
        {
            _customerInfoDal = customerInfoDal;
        }

        public IResult Add(CustomerInfo customer)
        {

            customer.Status = true;
            _customerInfoDal.Add(customer);
            return new Result(true, Messages.ItemAdded);
        }

        public IResult Delete(CustomerInfo customer)
        {
            customer.Status = false;
            _customerInfoDal.Update(customer);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<CustomerInfoDTO>> GetAll()
        {
            return new SuccessDataResult<List<CustomerInfoDTO>>(_customerInfoDal.GetCustomerDetail(), Messages.ItemsListed);
        }

        public IDataResult<CustomerInfoDTO> GetById(int Id)
        {
            return new SuccessDataResult<CustomerInfoDTO>(_customerInfoDal.GetCustomerDetailId(Id), Messages.ItemsListed);
        }

        public IDataResult<CustomerInfo> GetByTc(string Tc)
        {
            throw new System.NotImplementedException();
        }

 

        public IDataResult<CustomerInfoDTO> getCustomerUserDetailId(int Id)
        {
            return new SuccessDataResult<CustomerInfoDTO>(_customerInfoDal.getCustomerUserDetailId(Id), Messages.ItemsListed);
        }

        public IResult Update(CustomerInfo customer)
        {
            
            _customerInfoDal.Update(customer);
            return new Result(true, Messages.ItemUpdated);
        }
    }
}