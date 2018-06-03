using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.Domain.Entities
{
    public class Size
    {
        public int SizeId { get; set; }

        [MaxLength(10)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Goods> Goods { get; set; }
    }
}
