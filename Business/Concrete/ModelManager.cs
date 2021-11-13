using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ModelManager : IModelServices
    {
        private IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model models)
        {
            if (models.ModelName.Length > 1)
            {
                _modelDal.Add(models);
                return new Result(true, Messages.ItemAdded);
            }
            return new Result(false, Messages.ItemAddFailed);
        }

        public IDataResult<List<Model>> GetAll(int BrandId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(cid => cid.BrandId == BrandId), Messages.ItemsListed);
        }
    }
}