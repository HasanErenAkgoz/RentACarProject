using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.DTOs;
using Entity.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarInfoDal : EfEntityRepositoryBase<CarInfo, AkgozRentACarContext>, ICarInfoDal
    {
        public CarDetailDTO GetCarDetailCarId(int carId)
        {
            using (AkgozRentACarContext context = new AkgozRentACarContext())
            {
                var result = from cars in context.CarInfos.Where(c => c.CarId == carId)
                             join brand in context.Brands
                             on cars.BrandId equals brand.Id

                             join model in context.Models
                             on cars.ModelId equals model.ModelId
                             select new CarDetailDTO
                             {
                                 CarId = cars.CarId,
                                 Plate = cars.Plate,
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 ModelId = model.ModelId,
                                 ModelName = model.ModelName,
                                 Year = cars.Year,
                                 Km = cars.Km,
                                 MotorHp = cars.MotorHp,
                                 DailyPrice = cars.DailyPrice,
                                 Color = cars.Color,
                                 ImagePath = (from ci in context.CarImages where ci.CarInfoId == carId select ci.ImagePath).ToList(),
                                 MinFindeksScore = cars.MinFindeksScore,

                                 Status =cars.Status

                             };
                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDTO> GetCarDetails(Expression<Func<CarDetailDTO, bool>> filter = null)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from cars in context.CarInfos
                             join brand in context.Brands
                             on cars.BrandId equals brand.Id

                             join model in context.Models
                             on cars.ModelId equals model.ModelId
                             select new CarDetailDTO
                             {
                                 
                                 CarId = cars.CarId,
                                 Plate = cars.Plate,
                                 BrandId = brand.Id,
                                 BrandName = brand.Name,
                                 ModelId = model.ModelId,
                                 ModelName = model.ModelName,
                                 Year = cars.Year,
                                 Km = cars.Km,
                                 MotorHp = cars.MotorHp,
                                 DailyPrice=cars.DailyPrice,
                                 Color = cars.Color,
                                 ImagePath = (from ci in context.CarImages where ci.CarInfoId == cars.CarId select ci.ImagePath).ToList(),
                                 MinFindeksScore = cars.MinFindeksScore,

                                 Status = cars.Status,
                             };
                return filter == null ? result.Where(x=>x.Status==true).ToList() : result.Where(filter).Where(x=>x.Status==true).ToList();
            }
        }

    }
}