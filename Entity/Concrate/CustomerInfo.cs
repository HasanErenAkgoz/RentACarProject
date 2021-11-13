using Core.Entities;
using Core.Entities.Concrete;
using Entities.DTOs;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrate
{
    public class CustomerInfo : IEntity
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User user { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int FindeksScore { get; set; }

        public bool Status { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
        public virtual ICollection<CarRentDetailDTO> CarRentDetailDTOs { get; set; }


    }
}