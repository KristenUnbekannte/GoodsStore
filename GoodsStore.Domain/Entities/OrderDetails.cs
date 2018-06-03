using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.Domain.Entities
{
    public class OrderDetails
    {
        public int Id{ get; set; }

        [Required]
        public int GoodsId { get; set; }

        [Required]
        public int SizeId { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        virtual public Goods Goods { get; set; }
        virtual public Size Size { get; set; }

    }
}
