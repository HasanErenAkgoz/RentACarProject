 using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Concrate
{
    public class CarImages : IEntity
    {
        public int Id { get; set; }
        public int CarInfoId { get; set; }
        public virtual CarInfo CarInfo { get; set; }
        public string ImagePath { get; set; }
        public DateTime? ImageDate { get; set; }
    }
}
