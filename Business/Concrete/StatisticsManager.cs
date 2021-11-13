using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrate;
using Entity.DashBoardEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StatisticsManager : IStatisticsServices
    {
        ICarInfoDal _carInfoDal;
        IRentalDal _rentalDal;
        ICustomerInfoDal _CustomerInfo;
        public StatisticsManager(ICarInfoDal carInfoDal, IRentalDal rentalDal
            , ICustomerInfoDal customerInfoDal
           )
        {
            _carInfoDal = carInfoDal;
            _rentalDal = rentalDal;
            _CustomerInfo = customerInfoDal;
        }

        public string CheapestCarPlate()
        {
            var result = (from cars in _carInfoDal.GetAll() orderby cars.DailyPrice descending select cars.Plate).FirstOrDefault().ToString();
            return result;
        }

        public string MostExpensiveCarPlate()
        {
            var result = (from cars in _carInfoDal.GetAll() orderby cars.DailyPrice ascending select cars.Plate).FirstOrDefault();
            return result.ToString();
        }

        public int NumberofRentedVehicles()
        {
            var result = _rentalDal.GetAll().Count();
            return result;
        }

        public List<NameStock> NameStock()
        {
            List<NameStock> snf = new List<NameStock>();
            using (var context = new AkgozRentACarContext())
            {
                snf = context.Brands.Select(sales => new NameStock
                {
                    Name = sales.Name,
                    Stock = sales.CarInfos.Count()
                }).Where(x=>x.Stock>0).ToList();
            }
            return snf;
                 
        }

        public string TopSellingVehiclePlate()
        {

            var result = _carInfoDal.GetAll()
                     .Where(car => car.CarId == (_rentalDal.GetAll()
                    .GroupBy(sales => sales.CustomerInfoId)
                    .OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault()))
                    .Select(k => k.Plate).FirstOrDefault();
            return result;
        }

        

        public int TotalNumberofCustomers()
        {
            var result = _CustomerInfo.GetAll().Count();
            return result;
        }

        public int TotolCarCount()
        {
            var result = _carInfoDal.GetAll().Count();
            return result;
        }
    }
}
