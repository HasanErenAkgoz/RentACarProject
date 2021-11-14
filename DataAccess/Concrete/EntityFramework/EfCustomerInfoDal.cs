using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrate;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerInfoDal : EfEntityRepositoryBase<CustomerInfo, AkgozRentACarContext>, ICustomerInfoDal
    {
        public List<CustomerInfoDTO> GetCustomerDetail(Expression<Func<CustomerInfoDTO, bool>> filter = null)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from Customer in context.CustomerInfos
                             join User in context.Users
                             on Customer.UserId equals User.Id
                             select new CustomerInfoDTO
                             {
                                 Id = Customer.Id,
                                 UserId = Customer.user.Id,
                                 Address = Customer.Address,
                                 PhoneNumber = Customer.PhoneNumber,
                                 FindeksScore = Customer.FindeksScore,
                                 Status = Customer.Status,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 Email = User.Email,


                             };
                return result.Where(x => x.Status == true).ToList();
            }
        }
        public CustomerInfoDTO GetCustomerDetailId(int customerId)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from Customer in context.CustomerInfos.Where(x => x.Id == customerId)
                             join User in context.Users
                             on Customer.UserId equals User.Id
                             select new CustomerInfoDTO
                             {
                                 Id = Customer.Id,
                                 Address = Customer.Address,
                                 PhoneNumber = Customer.PhoneNumber,
                                 FindeksScore = Customer.FindeksScore,
                                 Status = Customer.Status,
                                 UserId = Customer.UserId,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 Email = User.Email,

                             };
                return result.SingleOrDefault();

            }
        }

        public CustomerInfoDTO getCustomerUserDetailId(int UserId)
        {
            using (var context = new AkgozRentACarContext())
            {
                var result = from Customer in context.CustomerInfos.Where(x => x.UserId == UserId)
                             join User in context.Users
                             on Customer.UserId equals User.Id
                             select new CustomerInfoDTO
                             {
                                 Id = Customer.Id,
                                 Address = Customer.Address,
                                 PhoneNumber = Customer.PhoneNumber,
                                 FindeksScore = Customer.FindeksScore,
                                 Status = Customer.Status,
                                 UserId = Customer.UserId,
                                 FirstName = User.FirstName,
                                 LastName = User.LastName,
                                 Email = User.Email,

                             };
                return result.SingleOrDefault();
            }
        }
    }
}