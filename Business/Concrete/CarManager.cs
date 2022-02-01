using Business.Abstract;
using Business.BusinessAspects.AutoFac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        private ICarInfoDal _carDal;

        public CarManager(ICarInfoDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]

        [SecuredOperation("admin")]
        public IResult Add(CarInfo car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfPlateCorret(car.Plate), ChechIfCarPlateExists(car.Plate));
            if (result != null)
            {
                return result;
            }
            else
            {
                car.Status = true;
                _carDal.Add(car);
                return new SuccessResult(Messages.CarAdd);
            }

        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarServices.Get")]
        public IResult Delete(CarInfo car)

        {
            car.Status = false;
            _carDal.Update(car);
            return new SuccessResult(Messages.ItemDeleted);
        }


        public IDataResult<List<CarInfo>> GetAll()
        {
            return new SuccessDataResult<List<CarInfo>>(_carDal.GetAll().Where(x => x.Status == true).ToList(), Messages.ItemsListed);
        }

        public IDataResult<List<CarInfo>> GetAllByPrice(decimal min, decimal max)
        {
            return new DataResult<List<CarInfo>>(_carDal.GetAll(car => car.DailyPrice >= min && car.DailyPrice <= max), true, Messages.ItemsListed);
        }

        public IDataResult<CarInfo> GetByCarId(int id)
        {
            return new DataResult<CarInfo>(_carDal.Get(cid => cid.CarId == id), true, Messages.ItemsListed);
        }
    

        [CacheAspect]
        public IDataResult<List<CarDetailDTO>> GetCarDetailDto()
        {

            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(), Messages.ItemsListed);

        }

        public IDataResult<List<CarDetailDTO>> GetCarsDetailBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(car => car.BrandId == brandId).ToList());
        }


        [CacheRemoveAspect("ICarServices.Get")]
        public IResult Update(CarInfo car)
        {
            _carDal.Update(car);
            return new Result(true, Messages.ItemUpdated);
        }

        private IResult CheckIfCarCountOfPlateCorret(string plate)
        {
            var result = _carDal.GetAll(car => car.Plate == plate).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarCountOfPlateError);
            }
            return new SuccessResult();
        }
        private IResult ChechIfCarPlateExists(string plate)
        {
            var result = _carDal.GetAll(car => car.Plate == plate).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExist);
            }
            return new SuccessResult();
        }


        public IDataResult<List<CarInfo>> GetByCarPlate(string plate)
        {
            return new DataResult<List<CarInfo>>(_carDal.GetAll(cid => cid.Plate == plate), true, Messages.ItemsListed);
        }
        public IDataResult<List<CarInfo>> GetCarsDetailModelId(int id)
        {
            throw new NotImplementedException();
        }
        public IDataResult<List<CarDetailDTO>> GetCarDetailcarId(int carId)
        {
            return new SuccessDataResult<List<CarDetailDTO>>(_carDal.GetCarDetails(x => x.CarId == carId), Messages.ItemsListed);
        }
        public IResult AddTransactionalTest(CarInfo carInfo)
        {
            throw new NotImplementedException();
        }
    }
}
