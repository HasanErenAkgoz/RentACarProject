using Core.Entities;
using Entity.Concrate;
using System;

namespace Entities.DTOs
{
    public class CarRentDetailDTO : IDto
    {
        public int Id { get; set; }
        public string plate { get; set; }
        public int CarInfoId { get; set; }
        public CarInfo CarInfo { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
        public int CustomerInfoId { get; set; }
        public CustomerInfo CustomerInfo { get;set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? RentEndDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal TotalPrice { get; set; }


    }
}