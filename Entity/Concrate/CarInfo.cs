using Core.Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrate
{
    public class CarInfo : IEntity
    {
        [Key]
        public int CarId { get; set; }
        [StringLength(15)]
        public string Plate { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [ForeignKey("Model")]
        public int? ModelId { get; set; }
        public virtual Model Model { get; set; }
        [StringLength(4)]

        public string Year { get; set; }
        [StringLength(10)]
        public string Km { get; set; }
        [StringLength(4)]
        public string MotorHp { get; set; }
        [StringLength(15)]
        public string Color { get; set; }
        [StringLength(30)]
        public string GearType { get; set; }

        [StringLength(30)]
        public string FuelType { get; set; }
        public Decimal DailyPrice { get; set; }
        public int MinFindeksScore { get; set; }
        public bool Status { get; set; }
        public virtual ICollection<CarImages> CarImages { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<CarRentDetailDTO> CarRentDetailDTOs { get; set; }


    }
}