using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
   public class OperationClaimManager:IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Id == id));
        }

        public IDataResult<OperationClaim> GetByName(string name)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(o => o.Name == name));
        }

        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(x=>x.Status==true),Messages.ItemsListed);
        }

        [SecuredOperation("admin")]
        public IResult Add(OperationClaim operationClaim)

        {
            operationClaim.Status = true;
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [SecuredOperation("admin")]
        public IResult Update(OperationClaim operationClaim)
        {
            operationClaim.Status = true;
            _operationClaimDal.Update(operationClaim);

            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        [SecuredOperation("admin")]
        public IResult Delete(OperationClaim operationClaim)
        {
            operationClaim.Status = false;
            _operationClaimDal.Update(operationClaim);

            return new SuccessResult(Messages.OperationClaimDeleted);
        }
    }
}
