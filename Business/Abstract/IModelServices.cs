using Core.Utilities.Results;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IModelServices
    {
        IResult Add(Model models);

        IDataResult<List<Model>> GetAll(int brandId);
        
    }
}