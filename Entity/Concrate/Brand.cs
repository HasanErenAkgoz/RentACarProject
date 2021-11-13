using Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity.Concrate
{
    public class Brand : IEntity
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<CarInfo> CarInfos { get; set; }


    }
}