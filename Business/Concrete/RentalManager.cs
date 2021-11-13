using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrate;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class RentalManager : IRentalServices
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<List<CarRentDetailDTO>> GetDetailsAll()
        {
            return new SuccessDataResult<List<CarRentDetailDTO>>(_rentalDal.GetRentalDetails(), Messages.ItemsListed);
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == Id), Messages.ItemsListed);
        }

        public IResult Add(Rental rental)
        {
            var result = RentalCarControl(rental.CarInfoId);
            if (!result.Success)
            {
                return new ErrorResult(Messages.RentalNotDelivered);
            }
            else
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult RentalCarControl(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarInfoId == carId && r.ReturnDate == null).Any();
            if (result)
            {
                return new ErrorResult(Messages.RentalNotDelivered);
            }

            return new SuccessResult();
        }


        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.ItemDeleted);
        }


    }
}