using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.Domain.Entities
{
    public class ClothesType
    {
        public int ClothesTypeId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
        public virtual ICollection<Goods> Goods { get; set; }
    }
}
