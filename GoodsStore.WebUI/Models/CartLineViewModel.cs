using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class CartLineViewModel
    {
        public int goodsId { get; set; }
        public int quantity { get; set; }
        public int? sizeId { get; set; }
        public string returnUrl { get; set; }
    }
}