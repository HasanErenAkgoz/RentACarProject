using Core.Utilities.Results;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandServices
    {
        IResult Add(Brand brand);

        IDataResult<List<Brand>> GetAll();


    }
}