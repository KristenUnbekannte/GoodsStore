﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class OrderDetailsModel
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public int SizeId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderId { get; set; }
        public string GoodsName{ get; set; }
        public string SizeName { get; set; }
    }
}
