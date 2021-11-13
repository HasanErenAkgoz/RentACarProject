using Core.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrate
{
    public class Rental : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("CarInfo")]
        public int CarInfoId { get; set; }
        public virtual CarInfo CarInfo { get; set; }
        [ForeignKey("CustomerInfo")]
        public int CustomerInfoId { get; set; }
        public virtual CustomerInfo CustomerInfo { get; set; }
        public DateTime RentDate { get; set; } = DateTime.Now.Date;
        public DateTime? RentEndDate { get; set; } = null;
        public DateTime? ReturnDate { get; set; } = null;
        public decimal TotalPrice { get; set; }
    }
}