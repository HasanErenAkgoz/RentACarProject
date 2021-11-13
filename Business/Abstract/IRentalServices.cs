using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrate;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IRentalServices
    {

        IDataResult<List<Rental>> GetAll();

        IDataResult<List<CarRentDetailDTO>> GetDetailsAll();

        IDataResult<Rental> GetById(int Id);

        IResult Add(Rental rental);

        IResult RentalCarControl(int CarId);

        IResult Update(Rental rental);

        IResult Delete(Rental rental);





    }
}