using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesServices
    {
        private ICarImagesDal _carImageDal;

        public CarImagesManager(ICarImagesDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[ValidationAspect(typeof(CarImageValidator))]
        public IDataResult<CarImages> Get(int id)
        {
            return new SuccessDataResult<CarImages>(_carImageDal.Get(p => p.Id == id));
        }
        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImageDal.GetAll(), Messages.ItemsListed);
        }
        public IDataResult<List<CarImages>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(carId));
        }

        public IResult Add(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarInfoId));
            if (result != null)
            {
                return result;
            }
           
            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImages carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarInfoId));
            if (result != null) 
            {
                return result;
            }
            carImage.ImageDate = DateTime.Now;
            string oldPath = Get(carImage.Id).Data.ImagePath;
            carImage.ImagePath = FileHelper.Update(oldPath, file);
            return new SuccessResult(Messages.ItemUpdated);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Delete(CarImages carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarInfoId == carid).Count;
            if (carImagecount >= 15)
            {
                return new ErrorResult(Messages.ImageLimitExceeded);
            }

            return new SuccessResult();
        }
        private List<CarImages> CheckIfCarImageNull(int id)
        {
            string path = @"default.jpg";
            var result = _carImageDal.GetAll(c => c.CarInfoId == id).Any();
            if (!result)
            {
                return new List<CarImages> { new CarImages { CarInfoId = id, ImagePath = path, ImageDate = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarInfoId == id);
        }
        private IResult CarImageDelete(CarImages carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
