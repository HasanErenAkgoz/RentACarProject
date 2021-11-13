using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandServices
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            if (brand.Name.Length > 1)
            {
                _brandDal.Add(brand);
                return new Result(true, Messages.ItemAdded);
            }
            return new Result(false, Messages.ItemAddFailed);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.ItemsListed);
        }
    }
}