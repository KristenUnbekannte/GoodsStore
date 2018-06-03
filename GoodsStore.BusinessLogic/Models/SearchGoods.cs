using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class SearchGoods
    {
        public int? CurrentCategory { get; set; }
        public int? CurrentClothesType { get; set; }
        public int? CurrentSize { get; set; }
        public decimal MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string searchName { get; set; }
    }
}
