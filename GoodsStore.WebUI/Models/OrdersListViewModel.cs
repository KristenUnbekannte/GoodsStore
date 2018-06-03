using GoodsStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class OrdersListViewModel
    {
        public ICollection<OrderModel> Orders { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string searchName { get; set; }
    }
}