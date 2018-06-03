using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Укажите ваше имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укаже адрес доставки")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Укажите город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Укажите страну")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Укажите телефон для связи")]
        public string Phone { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public bool GiftWrap { get; set; }
        public List<OrderDetailsModel> OrderDetails { get; set; }

    }
}
