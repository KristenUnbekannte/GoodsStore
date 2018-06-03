using GoodsStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class GoodsListViewModel
    {
        public IEnumerable<GoodsModel> Goods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public SearchGoods Search { get; set; }
    }
}