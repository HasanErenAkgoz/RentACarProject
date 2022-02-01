using Core.Entities;
using Entity.Concrate;
using System;
using System.Collections.Generic;

namespace Entities.DTOs
{
    public class CarDetailDTO : IDto
    {
        public int CarId { get; set; }
        public string Plate { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public string Year { get; set; }
        public string Km { get; set; }
        public string MotorHp { get; set; }
        public string Color { get; set; }
        public Decimal DailyPrice { get; set; }
        public List<string> ImagePath { get; set; }
        public int MinFindeksScore { get; set; }
        public string GearType { get; set; }
        public string FuelType { get; set; }

        public bool Status { get; set; }
    }
}