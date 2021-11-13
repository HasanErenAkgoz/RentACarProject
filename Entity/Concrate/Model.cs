using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrate
{
    public class Model : IEntity
    {
        [Key]
        public int ModelId { get; set; }
        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        [StringLength(50)]
        public string ModelName { get; set; }
        public virtual ICollection<CarInfo> CarInfos { get; set; }


    }
}