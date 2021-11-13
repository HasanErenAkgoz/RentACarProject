using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FindeksManager : IFindeksService
    {
        private ICustomerInfoServices _customerService;
        private ICarServices _carService;

        public FindeksManager(ICustomerInfoServices customerService, ICarServices carService)
        {
            _customerService = customerService;
            _carService = carService;
        }

        public IResult Query(int carId, int customerId)
        {
            int carScore = _carService.GetByCarId(carId).Data.MinFindeksScore;
            int customerScore = _customerService.GetById(customerId).Data.FindeksScore;
            if (carScore > customerScore)
            {
                return new ErrorResult(Messages.FindeksError);
            }
            return new SuccessResult(Messages.FindeksSuccess);
        }
    }
}
