using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(15)]
        public string City { get; set; }

        [Required]
        [MaxLength(15)]
        public string Country { get; set; }

        [Required]
        [MaxLength(25)]
        public string Phone { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public bool GiftWrap { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
