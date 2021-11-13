using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarServices
    {
        IResult Add(CarInfo car);
        IResult Update(CarInfo car);
        IResult Delete(CarInfo car);
        IResult AddTransactionalTest(CarInfo carInfo);
        IDataResult<List<CarInfo>> GetAll();
        IDataResult<CarInfo> GetByCarId(int id);
        IDataResult<List<CarInfo>> GetByCarPlate(string plate);
        IDataResult<List<CarInfo>> GetAllByPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDTO>> GetCarsDetailBrandId(int brandId);
        IDataResult<List<CarInfo>> GetCarsDetailModelId(int id);
        IDataResult<List<CarDetailDTO>> GetCarDetailDto();
        IDataResult<List<CarDetailDTO>> GetCarDetailcarId(int carId);

    }
}