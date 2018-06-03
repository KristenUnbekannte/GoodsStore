using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GoodsStore.Domain.Entities
{
    public class Goods
    {        
        [Required]
        public int GoodsId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int ClothesTypeId { get; set; }

        [Required]
  
        public decimal Price { get; set; }
       
        public byte[] ImageData { get; set; }

        public string ImageMimeType { get; set; }

        public int NumberOfReviews { get; set; }
        public double Rating { get; set; }

        public virtual Category Category { get; set; }


        public virtual ClothesType ClothesType { get; set; }

        public virtual ICollection<Size> Sizes { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
